namespace VendingMachine.QueryBuilder
{
    public class PostgresCompiler : Compiler
    {
        #region Constructors

        public PostgresCompiler()
        {
            LastId = "SELECT lastval() AS id";
        }

        #endregion Constructors

        #region Properties

        public override string EngineCode { get; } = EngineCodes.PostgreSql;

        #endregion Properties

        #region Methods

        protected override string CompileBasicDateCondition(SqlResult ctx, BasicDateCondition condition)
        {
            var column = Wrap(condition.Column);

            string left;

            if (condition.Part == "time")
            {
                left = $"{column}::time";
            }
            else if (condition.Part == "date")
            {
                left = $"{column}::date";
            }
            else
            {
                left = $"DATE_PART('{condition.Part.ToUpperInvariant()}', {column})";
            }

            var sql = $"{left} {condition.Operator} {Parameter(ctx, condition.Value)}";

            if (condition.IsNot)
            {
                return $"NOT ({sql})";
            }

            return sql;
        }

        #endregion Methods
    }
}