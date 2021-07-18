using Dapper;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VendingMachine.QueryBuilder
{
    public class QueryFactory : IDisposable
    {
        #region Fields

        private bool disposedValue;
        public Action<SqlResult> Logger = result => { };

        #endregion Fields

        #region Constructors

        public QueryFactory()
        {
        }

        public QueryFactory(IDbConnection connection, Compiler compiler, int timeout = 30)
        {
            Connection = connection;
            Compiler = compiler;
            QueryTimeout = timeout;
        }

        #endregion Constructors

        #region Properties

        public Compiler Compiler { get; set; }
        public IDbConnection Connection { get; set; }
        public int QueryTimeout { get; set; } = 30;

        #endregion Properties

        #region Methods

        private static IEnumerable<T> HandleIncludes<T>(Query query, IEnumerable<T> result)
        {
            if (!result.Any())
            {
                return result;
            }

            bool canBeProcessed = query.Includes.Any() && result.ElementAt(0) is IDynamicMetaObjectProvider;

            if (!canBeProcessed)
            {
                return result;
            }

            List<Dictionary<string, object>> dynamicResult = result
                .Cast<IDictionary<string, object>>()
                .Select(x => new Dictionary<string, object>(x, StringComparer.OrdinalIgnoreCase))
                .ToList();

            foreach (Include include in query.Includes)
            {
                if (include.IsMany)
                {
                    if (include.ForeignKey == null)
                    {
                        // try to guess the default key I will try to fetch the table name if
                        // provided and appending the Id as a convention Here am using Humanizer
                        // package to help getting the singular form of the table

                        FromClause fromTable = query.GetOneComponent("from") as FromClause;

                        if (fromTable == null)
                        {
                            throw new InvalidOperationException($"Cannot guess the foreign key for the included relation '{include.Name}'");
                        }

                        string table = fromTable.Alias ?? fromTable.Table;

                        include.ForeignKey = table.Singularize(false) + "Id";
                    }

                    List<string> localIds = dynamicResult.Where(x => x[include.LocalKey] != null)
                    .Select(x => x[include.LocalKey].ToString())
                    .ToList();

                    if (!localIds.Any())
                    {
                        continue;
                    }

                    Dictionary<string, List<Dictionary<string, object>>> children = include
                        .Query
                        .WhereIn(include.ForeignKey, localIds)
                        .Get()
                        .Cast<IDictionary<string, object>>()
                        .Select(x => new Dictionary<string, object>(x, StringComparer.OrdinalIgnoreCase))
                        .GroupBy(x => x[include.ForeignKey].ToString())
                        .ToDictionary(x => x.Key, x => x.ToList());

                    foreach (Dictionary<string, object> item in dynamicResult)
                    {
                        string localValue = item[include.LocalKey].ToString();
                        item[include.Name] = children.ContainsKey(localValue) ? children[localValue] : new List<Dictionary<string, object>>();
                    }

                    continue;
                }

                if (include.ForeignKey == null)
                {
                    include.ForeignKey = include.Name + "Id";
                }

                List<string> foreignIds = dynamicResult
                    .Where(x => x[include.ForeignKey] != null)
                    .Select(x => x[include.ForeignKey].ToString())
                    .ToList();

                if (!foreignIds.Any())
                {
                    continue;
                }

                Dictionary<string, Dictionary<string, object>> related = include
                    .Query
                    .WhereIn(include.LocalKey, foreignIds)
                    .Get()
                    .Cast<IDictionary<string, object>>()
                    .Select(x => new Dictionary<string, object>(x, StringComparer.OrdinalIgnoreCase))
                    .ToDictionary(x => x[include.LocalKey].ToString());

                foreach (Dictionary<string, object> item in dynamicResult)
                {
                    string foreignValue = item[include.ForeignKey].ToString();
                    item[include.Name] = related.ContainsKey(foreignValue) ? related[foreignValue] : null;
                }
            }

            return dynamicResult.Cast<T>();
        }

        private static async Task<IEnumerable<T>> handleIncludesAsync<T>(Query query, IEnumerable<T> result, CancellationToken cancellationToken = default)
        {
            if (!result.Any())
            {
                return result;
            }

            bool canBeProcessed = query.Includes.Any() && result.ElementAt(0) is IDynamicMetaObjectProvider;

            if (!canBeProcessed)
            {
                return result;
            }

            List<Dictionary<string, object>> dynamicResult = result
                .Cast<IDictionary<string, object>>()
                .Select(x => new Dictionary<string, object>(x, StringComparer.OrdinalIgnoreCase))
                .ToList();

            foreach (Include include in query.Includes)
            {
                if (include.IsMany)
                {
                    if (include.ForeignKey == null)
                    {
                        // try to guess the default key I will try to fetch the table name if
                        // provided and appending the Id as a convention Here am using Humanizer
                        // package to help getting the singular form of the table

                        FromClause fromTable = query.GetOneComponent("from") as FromClause;

                        if (fromTable == null)
                        {
                            throw new InvalidOperationException($"Cannot guess the foreign key for the included relation '{include.Name}'");
                        }

                        string table = fromTable.Alias ?? fromTable.Table;

                        include.ForeignKey = table.Singularize(false) + "Id";
                    }

                    List<string> localIds = dynamicResult.Where(x => x[include.LocalKey] != null)
                    .Select(x => x[include.LocalKey].ToString())
                    .ToList();

                    if (!localIds.Any())
                    {
                        continue;
                    }

                    Dictionary<string, List<Dictionary<string, object>>> children = (await include.Query.WhereIn(include.ForeignKey, localIds).GetAsync(cancellationToken: cancellationToken))
                        .Cast<IDictionary<string, object>>()
                        .Select(x => new Dictionary<string, object>(x, StringComparer.OrdinalIgnoreCase))
                        .GroupBy(x => x[include.ForeignKey].ToString())
                        .ToDictionary(x => x.Key, x => x.ToList());

                    foreach (Dictionary<string, object> item in dynamicResult)
                    {
                        string localValue = item[include.LocalKey].ToString();
                        item[include.Name] = children.ContainsKey(localValue) ? children[localValue] : new List<Dictionary<string, object>>();
                    }

                    continue;
                }

                if (include.ForeignKey == null)
                {
                    include.ForeignKey = include.Name + "Id";
                }

                List<string> foreignIds = dynamicResult.Where(x => x[include.ForeignKey] != null)
                    .Select(x => x[include.ForeignKey].ToString())
                    .ToList();

                if (!foreignIds.Any())
                {
                    continue;
                }

                Dictionary<string, Dictionary<string, object>> related = (await include.Query.WhereIn(include.LocalKey, foreignIds).GetAsync(cancellationToken: cancellationToken))
                    .Cast<IDictionary<string, object>>()
                    .Select(x => new Dictionary<string, object>(x, StringComparer.OrdinalIgnoreCase))
                    .ToDictionary(x => x[include.LocalKey].ToString());

                foreach (Dictionary<string, object> item in dynamicResult)
                {
                    string foreignValue = item[include.ForeignKey].ToString();
                    item[include.Name] = related.ContainsKey(foreignValue) ? related[foreignValue] : null;
                }
            }

            return dynamicResult.Cast<T>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Connection.Dispose();
                }
                Connection = null;
                Compiler = null;
                disposedValue = true;
            }
        }

        /// <summary>
        ///  Compile and log query
        /// </summary>
        /// <param name="query">
        /// </param>
        /// <returns>
        /// </returns>
        internal SqlResult CompileAndLog(Query query)
        {
            SqlResult compiled = Compiler.Compile(query);

            Logger(compiled);

            return compiled;
        }

        public T Aggregate<T>(
            Query query,
            string aggregateOperation,
            string[] columns = null,
            IDbTransaction transaction = null,
            int? timeout = null
        )
        {
            return ExecuteScalar<T>(query.AsAggregate(aggregateOperation, columns), transaction, timeout ?? QueryTimeout);
        }

        public async Task<T> AggregateAsync<T>(
            Query query,
            string aggregateOperation,
            string[] columns = null,
            IDbTransaction transaction = null,
            int? timeout = null,
            CancellationToken cancellationToken = default
        )
        {
            return await ExecuteScalarAsync<T>(
                query.AsAggregate(aggregateOperation, columns),
                transaction,
                timeout,
                cancellationToken
            );
        }

        public T Average<T>(Query query, string column, IDbTransaction transaction = null, int? timeout = null)
        {
            return Aggregate<T>(query, "avg", new[] { column });
        }

        public async Task<T> AverageAsync<T>(Query query, string column, CancellationToken cancellationToken = default)
        {
            return await AggregateAsync<T>(query, "avg", new[] { column }, cancellationToken: cancellationToken);
        }

        public void Chunk<T>(
            Query query,
            int chunkSize,
            Func<IEnumerable<T>, int, bool> func,
            IDbTransaction transaction = null,
            int? timeout = null)
        {
            PaginationResult<T> result = Paginate<T>(query, 1, chunkSize, transaction, timeout);

            if (!func(result.List, 1))
            {
                return;
            }

            while (result.HasNext)
            {
                result = result.Next(transaction);
                if (!func(result.List, result.Page))
                {
                    return;
                }
            }
        }

        public void Chunk<T>(Query query, int chunkSize, Action<IEnumerable<T>, int> action, IDbTransaction transaction = null, int? timeout = null)
        {
            PaginationResult<T> result = Paginate<T>(query, 1, chunkSize, transaction, timeout);

            action(result.List, 1);

            while (result.HasNext)
            {
                result = result.Next(transaction);
                action(result.List, result.Page);
            }
        }

        public async Task ChunkAsync<T>(
            Query query,
            int chunkSize,
            Func<IEnumerable<T>, int, bool> func,
            IDbTransaction transaction = null,
            int? timeout = null,
            CancellationToken cancellationToken = default
        )
        {
            PaginationResult<T> result = await PaginateAsync<T>(query, 1, chunkSize, transaction, cancellationToken: cancellationToken);

            if (!func(result.List, 1))
            {
                return;
            }

            while (result.HasNext)
            {
                result = result.Next(transaction);
                if (!func(result.List, result.Page))
                {
                    return;
                }
            }
        }

        public async Task ChunkAsync<T>(
            Query query,
            int chunkSize,
            Action<IEnumerable<T>, int> action,
            IDbTransaction transaction = null,
            int? timeout = null,
            CancellationToken cancellationToken = default
        )
        {
            PaginationResult<T> result = await PaginateAsync<T>(query, 1, chunkSize, transaction, timeout, cancellationToken);

            action(result.List, 1);

            while (result.HasNext)
            {
                result = result.Next(transaction);
                action(result.List, result.Page);
            }
        }

        public T Count<T>(Query query, string[] columns = null, IDbTransaction transaction = null, int? timeout = null)
        {
            return ExecuteScalar<T>(
                query.AsCount(columns),
                transaction,
                timeout
            );
        }

        public async Task<T> CountAsync<T>(Query query, string[] columns = null, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await ExecuteScalarAsync<T>(query.AsCount(columns), transaction, timeout, cancellationToken);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public int Execute(
            Query query,
            IDbTransaction transaction = null,
            int? timeout = null
        )
        {
            SqlResult compiled = CompileAndLog(query);

            return Connection.Execute(
                compiled.Sql,
                compiled.NamedBindings,
                transaction,
                timeout ?? QueryTimeout
            );
        }

        public async Task<int> ExecuteAsync(
            Query query,
            IDbTransaction transaction = null,
            int? timeout = null,
            CancellationToken cancellationToken = default
        )
        {
            SqlResult compiled = CompileAndLog(query);
            CommandDefinition commandDefinition = new CommandDefinition(
                commandText: compiled.Sql,
                parameters: compiled.NamedBindings,
                transaction: transaction,
                commandTimeout: timeout ?? QueryTimeout,
                cancellationToken: cancellationToken);

            return await Connection.ExecuteAsync(commandDefinition);
        }

        public T ExecuteScalar<T>(Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            SqlResult compiled = CompileAndLog(query.Limit(1));

            return Connection.ExecuteScalar<T>(
                compiled.Sql,
                compiled.NamedBindings,
                transaction,
                timeout ?? QueryTimeout
            );
        }

        public async Task<T> ExecuteScalarAsync<T>(
            Query query,
            IDbTransaction transaction = null,
            int? timeout = null,
            CancellationToken cancellationToken = default
        )
        {
            SqlResult compiled = CompileAndLog(query.Limit(1));
            CommandDefinition commandDefinition = new CommandDefinition(
                commandText: compiled.Sql,
                parameters: compiled.NamedBindings,
                transaction: transaction,
                commandTimeout: timeout ?? QueryTimeout,
                cancellationToken: cancellationToken);

            return await Connection.ExecuteScalarAsync<T>(commandDefinition);
        }

        public bool Exists(Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            Query clone = query.Clone()
                .ClearComponent("select")
                .SelectRaw("1 as [Exists]")
                .Limit(1);

            IEnumerable<dynamic> rows = Get(clone, transaction, timeout);

            return rows.Any();
        }

        public async Task<bool> ExistsAsync(Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            Query clone = query.Clone()
                .ClearComponent("select")
                .SelectRaw("1 as [Exists]")
                .Limit(1);

            IEnumerable<dynamic> rows = await GetAsync(clone, transaction, timeout, cancellationToken);

            return rows.Any();
        }

        public T First<T>(Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            T item = FirstOrDefault<T>(query, transaction, timeout);

            if (item == null)
            {
                throw new InvalidOperationException("The sequence contains no elements");
            }

            return item;
        }

        public dynamic First(Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return First<dynamic>(query, transaction, timeout);
        }

        public async Task<T> FirstAsync<T>(Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            T item = await FirstOrDefaultAsync<T>(query, transaction, timeout, cancellationToken);

            if (item == null)
            {
                throw new InvalidOperationException("The sequence contains no elements");
            }

            return item;
        }

        public async Task<dynamic> FirstAsync(Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await FirstAsync<dynamic>(query, transaction, timeout, cancellationToken);
        }

        public T FirstOrDefault<T>(Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            IEnumerable<T> list = Get<T>(query.Limit(1), transaction, timeout);

            return list.ElementAtOrDefault(0);
        }

        public dynamic FirstOrDefault(Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return FirstOrDefault<dynamic>(query, transaction, timeout);
        }

        public async Task<T> FirstOrDefaultAsync<T>(Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            IEnumerable<T> list = await GetAsync<T>(query.Limit(1), transaction, timeout, cancellationToken);

            return list.ElementAtOrDefault(0);
        }

        public async Task<dynamic> FirstOrDefaultAsync(Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await FirstOrDefaultAsync<dynamic>(query, transaction, timeout, cancellationToken);
        }

        /// <summary>
        ///  Create an XQuery instance from a regular Query
        /// </summary>
        /// <param name="query">
        /// </param>
        /// <returns>
        /// </returns>
        public Query FromQuery(Query query)
        {
            XQuery xQuery = new XQuery(Connection, Compiler)
            {
                QueryFactory = this,

                Clauses = query.Clauses.Select(x => x.Clone()).ToList()
            };

            xQuery.SetParent(query.Parent);
            xQuery.QueryAlias = query.QueryAlias;
            xQuery.IsDistinct = query.IsDistinct;
            xQuery.Method = query.Method;
            xQuery.Includes = query.Includes;
            xQuery.Variables = query.Variables;

            xQuery.SetEngineScope(query.EngineScope);

            xQuery.Logger = Logger;

            return xQuery;
        }

        public IEnumerable<T> Get<T>(Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            SqlResult compiled = CompileAndLog(query);

            List<T> result = Connection.Query<T>(
                compiled.Sql,
                compiled.NamedBindings,
                transaction: transaction,
                commandTimeout: timeout ?? QueryTimeout
            ).ToList();

            result = HandleIncludes<T>(query, result).ToList();

            return result;
        }

        public IEnumerable<dynamic> Get(Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return Get<dynamic>(query, transaction, timeout);
        }

        public IEnumerable<IEnumerable<T>> Get<T>(
            Query[] queries,
            IDbTransaction transaction = null,
            int? timeout = null
        )
        {
            SqlMapper.GridReader multi = GetMultiple<T>(
                queries,
                transaction,
                timeout
            );

            using (multi)
            {
                for (int i = 0; i < queries.Length; i++)
                {
                    yield return multi.Read<T>();
                }
            }
        }

        public async Task<IEnumerable<T>> GetAsync<T>(Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            SqlResult compiled = CompileAndLog(query);
            CommandDefinition commandDefinition = new CommandDefinition(
                commandText: compiled.Sql,
                parameters: compiled.NamedBindings,
                transaction: transaction,
                commandTimeout: timeout ?? QueryTimeout,
                cancellationToken: cancellationToken);

            List<T> result = (await Connection.QueryAsync<T>(commandDefinition)).ToList();

            result = (await handleIncludesAsync(query, result, cancellationToken)).ToList();

            return result;
        }

        public async Task<IEnumerable<dynamic>> GetAsync(Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<dynamic>(query, transaction, timeout, cancellationToken);
        }

        public async Task<IEnumerable<IEnumerable<T>>> GetAsync<T>(
            Query[] queries,
            IDbTransaction transaction = null,
            int? timeout = null,
            CancellationToken cancellationToken = default
        )
        {
            SqlMapper.GridReader multi = await GetMultipleAsync<T>(
                queries,
                transaction,
                timeout,
                cancellationToken
            );

            List<IEnumerable<T>> list = new List<IEnumerable<T>>();

            using (multi)
            {
                for (int i = 0; i < queries.Length; i++)
                {
                    list.Add(multi.Read<T>());
                }
            }

            return list;
        }

        public IEnumerable<IDictionary<string, object>> GetDictionary(Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            SqlResult compiled = CompileAndLog(query);

            IEnumerable<dynamic> result = Connection.Query(
                compiled.Sql,
                compiled.NamedBindings,
                transaction: transaction,
                commandTimeout: timeout ?? QueryTimeout
            );

            return result.Cast<IDictionary<string, object>>();
        }

        public async Task<IEnumerable<IDictionary<string, object>>> GetDictionaryAsync(Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            SqlResult compiled = CompileAndLog(query);
            CommandDefinition commandDefinition = new CommandDefinition(
                commandText: compiled.Sql,
                parameters: compiled.NamedBindings,
                transaction: transaction,
                commandTimeout: timeout ?? QueryTimeout,
                cancellationToken: cancellationToken);

            IEnumerable<dynamic> result = await Connection.QueryAsync(commandDefinition);

            return result.Cast<IDictionary<string, object>>();
        }

        public SqlMapper.GridReader GetMultiple<T>(
            Query[] queries,
            IDbTransaction transaction = null,
            int? timeout = null
        )
        {
            SqlResult compiled = Compiler.Compile(queries);

            return Connection.QueryMultiple(
                compiled.Sql,
                compiled.NamedBindings,
                transaction,
                timeout ?? QueryTimeout
            );
        }

        public async Task<SqlMapper.GridReader> GetMultipleAsync<T>(
            Query[] queries,
            IDbTransaction transaction = null,
            int? timeout = null,
            CancellationToken cancellationToken = default)
        {
            SqlResult compiled = Compiler.Compile(queries);
            CommandDefinition commandDefinition = new CommandDefinition(
                commandText: compiled.Sql,
                parameters: compiled.NamedBindings,
                transaction: transaction,
                commandTimeout: timeout ?? QueryTimeout,
                cancellationToken: cancellationToken);

            return await Connection.QueryMultipleAsync(commandDefinition);
        }

        public T Max<T>(Query query, string column)
        {
            return Aggregate<T>(query, "max", new[] { column });
        }

        public async Task<T> MaxAsync<T>(Query query, string column, CancellationToken cancellationToken = default)
        {
            return await AggregateAsync<T>(query, "max", new[] { column }, cancellationToken: cancellationToken);
        }

        public T Min<T>(Query query, string column)
        {
            return Aggregate<T>(query, "min", new[] { column });
        }

        public async Task<T> MinAsync<T>(Query query, string column, CancellationToken cancellationToken = default)
        {
            return await AggregateAsync<T>(query, "min", new[] { column }, cancellationToken: cancellationToken);
        }

        public PaginationResult<T> Paginate<T>(Query query, int page, int perPage = 25, IDbTransaction transaction = null, int? timeout = null)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page param should be greater than or equal to 1", nameof(page));
            }

            if (perPage < 1)
            {
                throw new ArgumentException("PerPage param should be greater than or equal to 1", nameof(perPage));
            }

            long count = Count<long>(query.Clone(), null, transaction, timeout);

            IEnumerable<T> list;

            if (count > 0)
            {
                list = Get<T>(query.Clone().ForPage(page, perPage), transaction, timeout);
            }
            else
            {
                list = Enumerable.Empty<T>();
            }

            return new PaginationResult<T>
            {
                Query = query,
                Page = page,
                PerPage = perPage,
                Count = count,
                List = list
            };
        }

        public async Task<PaginationResult<T>> PaginateAsync<T>(Query query, int page, int perPage = 25, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page param should be greater than or equal to 1", nameof(page));
            }

            if (perPage < 1)
            {
                throw new ArgumentException("PerPage param should be greater than or equal to 1", nameof(perPage));
            }

            long count = await CountAsync<long>(query.Clone(), null, transaction, timeout, cancellationToken);

            IEnumerable<T> list;

            if (count > 0)
            {
                list = await GetAsync<T>(query.Clone().ForPage(page, perPage), transaction, timeout, cancellationToken);
            }
            else
            {
                list = Enumerable.Empty<T>();
            }

            return new PaginationResult<T>
            {
                Query = query,
                Page = page,
                PerPage = perPage,
                Count = count,
                List = list
            };
        }

        public Query Query()
        {
            XQuery query = new XQuery(Connection, Compiler)
            {
                QueryFactory = this,

                Logger = Logger
            };

            return query;
        }

        public Query Query(string table)
        {
            return Query().From(table);
        }

        public IEnumerable<T> Select<T>(string sql, object param = null, IDbTransaction transaction = null, int? timeout = null)
        {
            return Connection.Query<T>(
                sql,
                param,
                transaction: transaction,
                commandTimeout: timeout ?? QueryTimeout
            );
        }

        public IEnumerable<dynamic> Select(string sql, object param = null, IDbTransaction transaction = null, int? timeout = null)
        {
            return Select<dynamic>(sql, param, transaction, timeout);
        }

        public async Task<IEnumerable<T>> SelectAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            CommandDefinition commandDefinition = new CommandDefinition(
                commandText: sql,
                parameters: param,
                transaction: transaction,
                commandTimeout: timeout ?? QueryTimeout,
                cancellationToken: cancellationToken);

            return await Connection.QueryAsync<T>(commandDefinition);
        }

        public async Task<IEnumerable<dynamic>> SelectAsync(string sql, object param = null, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await SelectAsync<dynamic>(sql, param, transaction, timeout, cancellationToken);
        }

        public int Statement(string sql, object param = null, IDbTransaction transaction = null, int? timeout = null)
        {
            return Connection.Execute(sql, param, transaction: transaction, commandTimeout: timeout ?? QueryTimeout);
        }

        public async Task<int> StatementAsync(string sql, object param = null, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            CommandDefinition commandDefinition = new CommandDefinition(
                commandText: sql,
                parameters: param,
                transaction: transaction,
                commandTimeout: timeout ?? QueryTimeout,
                cancellationToken: cancellationToken);
            return await Connection.ExecuteAsync(commandDefinition);
        }

        public T Sum<T>(Query query, string column)
        {
            return Aggregate<T>(query, "sum", new[] { column });
        }

        public async Task<T> SumAsync<T>(Query query, string column, CancellationToken cancellationToken = default)
        {
            return await AggregateAsync<T>(query, "sum", new[] { column }, cancellationToken: cancellationToken);
        }

        #endregion Methods
    }
}