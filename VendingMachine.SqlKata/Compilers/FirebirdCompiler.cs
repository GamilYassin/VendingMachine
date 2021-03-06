using System.Text.RegularExpressions;

namespace VendingMachine.QueryBuilder
{
    public class FirebirdCompiler : Compiler
    {
        #region Constructors

        public FirebirdCompiler()
        {
        }

        #endregion Constructors

        #region Properties

        public override string EngineCode { get; } = EngineCodes.Firebird;

        #endregion Properties

        #region Methods

        protected override string CompileBasicDateCondition(SqlResult ctx, BasicDateCondition condition)
        {
            var column = Wrap(condition.Column);

            string left;

            if (condition.Part == "time")
            {
                left = $"CAST({column} as TIME)";
            }
            else if (condition.Part == "date")
            {
                left = $"CAST({column} as DATE)";
            }
            else
            {
                left = $"EXTRACT({condition.Part.ToUpperInvariant()} FROM {column})";
            }

            var sql = $"{left} {condition.Operator} {Parameter(ctx, condition.Value)}";

            if (condition.IsNot)
            {
                return $"NOT ({sql})";
            }

            return sql;
        }

        protected override string CompileColumns(SqlResult ctx)
        {
            var compiled = base.CompileColumns(ctx);

            var limit = ctx.Query.GetLimit(EngineCode);
            var offset = ctx.Query.GetOffset(EngineCode);

            if (limit > 0 && offset == 0)
            {
                ctx.Bindings.Insert(0, limit);

                ctx.Query.ClearComponent("limit");

                return "SELECT FIRST ?" + compiled.Substring(6);
            }
            else if (limit == 0 && offset > 0)
            {
                ctx.Bindings.Insert(0, offset);

                ctx.Query.ClearComponent("offset");

                return "SELECT SKIP ?" + compiled.Substring(6);
            }

            return compiled;
        }

        protected override SqlResult CompileInsertQuery(Query query)
        {
            var ctx = base.CompileInsertQuery(query);

            var inserts = ctx.Query.GetComponents<InsertClauseBase>("insert", EngineCode);

            if (inserts.Count > 1)
            {
                ctx.RawSql = Regex.Replace(ctx.RawSql, @"\)\s+VALUES\s+\(", ") SELECT ");
                ctx.RawSql = Regex.Replace(ctx.RawSql, @"\),\s*\(", " FROM RDB$DATABASE UNION ALL SELECT ");
                ctx.RawSql = Regex.Replace(ctx.RawSql, @"\)$", " FROM RDB$DATABASE");
            }

            return ctx;
        }

        public override string CompileFalse()
        {
            return "0";
        }

        public override string CompileLimit(SqlResult ctx)
        {
            var limit = ctx.Query.GetLimit(EngineCode);
            var offset = ctx.Query.GetOffset(EngineCode);

            if (limit > 0 && offset > 0)
            {
                ctx.Bindings.Add(offset + 1);
                ctx.Bindings.Add(limit + offset);

                return "ROWS ? TO ?";
            }

            return null;
        }

        public override string CompileTrue()
        {
            return "1";
        }

        public override string WrapValue(string value)
        {
            return base.WrapValue(value).ToUpperInvariant();
        }

        #endregion Methods
    }
}