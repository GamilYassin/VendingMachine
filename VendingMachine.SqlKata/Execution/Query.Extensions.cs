using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace VendingMachine.QueryBuilder
{
    public static class QueryExtensions
    {
        #region Methods

        internal static XQuery CastToXQuery(Query query, string method = null)
        {
            XQuery xQuery = query as XQuery;

            if (xQuery is null)
            {
                if (method == null)
                {
                    throw new InvalidOperationException(
                        $"Execution methods can only be used with `{nameof(XQuery)}` instances, " +
                        $"consider using the `{nameof(QueryFactory)}.{nameof(QueryFactory.Query)}()` to create executable queries, " +
                        $"check https://sqlkata.com/docs/execution/setup#xquery-class for more info");
                }

                throw new InvalidOperationException($"The method '{method}()' can only be used with `{nameof(XQuery)}` instances, " +
                    $"consider using the `{nameof(QueryFactory)}.{nameof(QueryFactory.Query)}()` to create executable queries, " +
                    $"check https://sqlkata.com/docs/execution/setup#xquery-class for more info");
            }

            return xQuery;
        }

        internal static QueryFactory CreateQueryFactory(XQuery xQuery)
        {
            QueryFactory factory = new QueryFactory(xQuery.Connection, xQuery.Compiler)
            {
                Logger = xQuery.Logger
            };

            return factory;
        }

        internal static QueryFactory CreateQueryFactory(Query query)
        {
            return CreateQueryFactory(CastToXQuery(query));
        }

        public static T Aggregate<T>(this Query query, string aggregateOperation, string[] columns, IDbTransaction transaction = null, int? timeout = null)
        {
            QueryFactory db = CreateQueryFactory(query);

            return db.ExecuteScalar<T>(query.AsAggregate(aggregateOperation, columns), transaction, timeout);
        }

        public static async Task<T> AggregateAsync<T>(this Query query, string aggregateOperation, string[] columns, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            QueryFactory db = CreateQueryFactory(query);
            return await db.ExecuteScalarAsync<T>(query.AsAggregate(aggregateOperation, columns), transaction, timeout, cancellationToken);
        }

        public static T Average<T>(this Query query, string column, IDbTransaction transaction = null, int? timeout = null)
        {
            return query.Aggregate<T>("avg", new[] { column }, transaction, timeout);
        }

        public static async Task<T> AverageAsync<T>(this Query query, string column, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await query.AggregateAsync<T>("avg", new[] { column }, transaction, timeout, cancellationToken);
        }

        public static void Chunk<T>(this Query query, int chunkSize, Func<IEnumerable<T>, int, bool> func, IDbTransaction transaction = null, int? timeout = null)
        {
            QueryFactory db = CreateQueryFactory(query);

            db.Chunk<T>(query, chunkSize, func, transaction, timeout);
        }

        public static void Chunk(this Query query, int chunkSize, Func<IEnumerable<dynamic>, int, bool> func, IDbTransaction transaction = null, int? timeout = null)
        {
            query.Chunk<dynamic>(chunkSize, func, transaction, timeout);
        }

        public static void Chunk<T>(this Query query, int chunkSize, Action<IEnumerable<T>, int> action, IDbTransaction transaction = null, int? timeout = null)
        {
            QueryFactory db = CreateQueryFactory(query);

            db.Chunk(query, chunkSize, action, transaction, timeout);
        }

        public static void Chunk(this Query query, int chunkSize, Action<IEnumerable<dynamic>, int> action, IDbTransaction transaction = null, int? timeout = null)
        {
            query.Chunk<dynamic>(chunkSize, action, transaction, timeout);
        }

        public static async Task ChunkAsync<T>(this Query query, int chunkSize, Func<IEnumerable<T>, int, bool> func, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            await CreateQueryFactory(query).ChunkAsync<T>(query, chunkSize, func, transaction, timeout, cancellationToken);
        }

        public static async Task ChunkAsync(this Query query, int chunkSize, Func<IEnumerable<dynamic>, int, bool> func, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            await ChunkAsync<dynamic>(query, chunkSize, func, transaction, timeout, cancellationToken);
        }

        public static async Task ChunkAsync<T>(this Query query, int chunkSize, Action<IEnumerable<T>, int> action, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            await CreateQueryFactory(query).ChunkAsync<T>(query, chunkSize, action, transaction, timeout, cancellationToken);
        }

        public static async Task ChunkAsync(this Query query, int chunkSize, Action<IEnumerable<dynamic>, int> action, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            await ChunkAsync<dynamic>(query, chunkSize, action, transaction, timeout, cancellationToken);
        }

        public static T Count<T>(this Query query, string[] columns = null, IDbTransaction transaction = null, int? timeout = null)
        {
            QueryFactory db = CreateQueryFactory(query);

            return db.ExecuteScalar<T>(query.AsCount(columns), transaction, timeout);
        }

        public static async Task<T> CountAsync<T>(this Query query, string[] columns = null, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            QueryFactory db = CreateQueryFactory(query);

            return await db.ExecuteScalarAsync<T>(query.AsCount(columns), transaction, timeout, cancellationToken);
        }

        public static int Decrement(this Query query, string column, int value = 1, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).Execute(query.AsDecrement(column, value), transaction, timeout);
        }

        public static async Task<int> DecrementAsync(this Query query, string column, int value = 1, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).ExecuteAsync(query.AsDecrement(column, value), transaction, timeout, cancellationToken);
        }

        public static int Delete(this Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).Execute(query.AsDelete(), transaction, timeout);
        }

        public static async Task<int> DeleteAsync(this Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).ExecuteAsync(query.AsDelete(), transaction, timeout, cancellationToken);
        }

        public static bool Exists(this Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).Exists(query, transaction, timeout);
        }

        public static async Task<bool> ExistsAsync(this Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).ExistsAsync(query, transaction, timeout, cancellationToken);
        }

        public static T First<T>(this Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).First<T>(query, transaction, timeout);
        }

        public static dynamic First(this Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return First<dynamic>(query, transaction, timeout);
        }

        public static async Task<T> FirstAsync<T>(this Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).FirstAsync<T>(query, transaction, timeout, cancellationToken);
        }

        public static async Task<dynamic> FirstAsync(this Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await FirstAsync<dynamic>(query, transaction, timeout, cancellationToken);
        }

        public static T FirstOrDefault<T>(this Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).FirstOrDefault<T>(query, transaction, timeout);
        }

        public static dynamic FirstOrDefault(this Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return FirstOrDefault<dynamic>(query, transaction, timeout);
        }

        public static async Task<T> FirstOrDefaultAsync<T>(this Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).FirstOrDefaultAsync<T>(query, transaction, timeout, cancellationToken);
        }

        public static async Task<dynamic> FirstOrDefaultAsync(this Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await FirstOrDefaultAsync<dynamic>(query, transaction, timeout, cancellationToken);
        }

        public static IEnumerable<T> Get<T>(this Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).Get<T>(query, transaction, timeout);
        }

        public static IEnumerable<dynamic> Get(this Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return query.Get<dynamic>(transaction, timeout);
        }

        public static async Task<IEnumerable<T>> GetAsync<T>(this Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).GetAsync<T>(query, transaction, timeout, cancellationToken);
        }

        public static async Task<IEnumerable<dynamic>> GetAsync(this Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<dynamic>(query, transaction, timeout, cancellationToken);
        }

        public static int Increment(this Query query, string column, int value = 1, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).Execute(query.AsIncrement(column, value), transaction, timeout);
        }

        public static async Task<int> IncrementAsync(this Query query, string column, int value = 1, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).ExecuteAsync(query.AsIncrement(column, value), transaction, timeout, cancellationToken);
        }

        public static int Insert(this Query query, IEnumerable<KeyValuePair<string, object>> values, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).Execute(query.AsInsert(values), transaction, timeout);
        }

        public static int Insert(this Query query, IEnumerable<string> columns, IEnumerable<IEnumerable<object>> valuesCollection, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).Execute(query.AsInsert(columns, valuesCollection), transaction, timeout);
        }

        public static int Insert(this Query query, IEnumerable<string> columns, Query fromQuery, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).Execute(query.AsInsert(columns, fromQuery), transaction, timeout);
        }

        public static int Insert(this Query query, object data, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).Execute(query.AsInsert(data), transaction, timeout);
        }

        public static async Task<int> InsertAsync(this Query query, IEnumerable<KeyValuePair<string, object>> values, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).ExecuteAsync(query.AsInsert(values), transaction, timeout, cancellationToken);
        }

        public static async Task<int> InsertAsync(this Query query, IEnumerable<string> columns, IEnumerable<IEnumerable<object>> valuesCollection, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).ExecuteAsync(query.AsInsert(columns, valuesCollection), transaction, timeout, cancellationToken);
        }

        public static async Task<int> InsertAsync(this Query query, IEnumerable<string> columns, Query fromQuery, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).ExecuteAsync(query.AsInsert(columns, fromQuery), transaction, timeout, cancellationToken);
        }

        public static async Task<int> InsertAsync(this Query query, object data, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).ExecuteAsync(query.AsInsert(data), transaction, timeout, cancellationToken);
        }

        public static T InsertGetId<T>(this Query query, object data, IDbTransaction transaction = null, int? timeout = null)
        {
            QueryFactory db = CreateQueryFactory(query);

            InsertGetIdRow<T> row = db.First<InsertGetIdRow<T>>(query.AsInsert(data, true), transaction, timeout);

            return row.Id;
        }

        public static T InsertGetId<T>(this Query query, IEnumerable<KeyValuePair<string, object>> data, IDbTransaction transaction = null, int? timeout = null)
        {
            InsertGetIdRow<T> row = CreateQueryFactory(query).First<InsertGetIdRow<T>>(query.AsInsert(data, true), transaction, timeout);

            return row.Id;
        }

        public static async Task<T> InsertGetIdAsync<T>(this Query query, object data, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            InsertGetIdRow<T> row = await CreateQueryFactory(query)
                .FirstAsync<InsertGetIdRow<T>>(query.AsInsert(data, true), transaction, timeout, cancellationToken);

            return row.Id;
        }

        public static async Task<T> InsertGetIdAsync<T>(this Query query, IEnumerable<KeyValuePair<string, object>> data, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            InsertGetIdRow<T> row = await CreateQueryFactory(query).FirstAsync<InsertGetIdRow<T>>(query.AsInsert(data, true), transaction, timeout, cancellationToken);

            return row.Id;
        }

        public static T Max<T>(this Query query, string column, IDbTransaction transaction = null, int? timeout = null)
        {
            return query.Aggregate<T>("max", new[] { column }, transaction, timeout);
        }

        public static async Task<T> MaxAsync<T>(this Query query, string column, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await query.AggregateAsync<T>("max", new[] { column }, transaction, timeout, cancellationToken);
        }

        public static T Min<T>(this Query query, string column, IDbTransaction transaction = null, int? timeout = null)
        {
            return query.Aggregate<T>("min", new[] { column }, transaction, timeout);
        }

        public static async Task<T> MinAsync<T>(this Query query, string column, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await query.AggregateAsync<T>("min", new[] { column }, transaction, timeout, cancellationToken);
        }

        public static bool NotExist(this Query query, IDbTransaction transaction = null, int? timeout = null)
        {
            return !CreateQueryFactory(query).Exists(query, transaction, timeout);
        }

        public static async Task<bool> NotExistAsync(this Query query, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return !(await CreateQueryFactory(query).ExistsAsync(query, transaction, timeout, cancellationToken));
        }

        public static PaginationResult<T> Paginate<T>(this Query query, int page, int perPage = 25, IDbTransaction transaction = null, int? timeout = null)
        {
            QueryFactory db = CreateQueryFactory(query);

            return db.Paginate<T>(query, page, perPage, transaction, timeout);
        }

        public static PaginationResult<dynamic> Paginate(this Query query, int page, int perPage = 25, IDbTransaction transaction = null, int? timeout = null)
        {
            return query.Paginate<dynamic>(page, perPage, transaction, timeout);
        }

        public static async Task<PaginationResult<T>> PaginateAsync<T>(this Query query, int page, int perPage = 25, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            QueryFactory db = CreateQueryFactory(query);

            return await db.PaginateAsync<T>(query, page, perPage, transaction, timeout, cancellationToken);
        }

        public static async Task<PaginationResult<dynamic>> PaginateAsync(this Query query, int page, int perPage = 25, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await PaginateAsync<dynamic>(query, page, perPage, transaction, timeout, cancellationToken);
        }

        public static T Sum<T>(this Query query, string column, IDbTransaction transaction = null, int? timeout = null)
        {
            return query.Aggregate<T>("sum", new[] { column }, transaction, timeout);
        }

        public static async Task<T> SumAsync<T>(this Query query, string column, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await query.AggregateAsync<T>("sum", new[] { column }, transaction, timeout, cancellationToken);
        }

        public static int Update(this Query query, IEnumerable<KeyValuePair<string, object>> values, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).Execute(query.AsUpdate(values), transaction, timeout);
        }

        public static int Update(this Query query, object data, IDbTransaction transaction = null, int? timeout = null)
        {
            return CreateQueryFactory(query).Execute(query.AsUpdate(data), transaction, timeout);
        }

        public static async Task<int> UpdateAsync(this Query query, IEnumerable<KeyValuePair<string, object>> values, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).ExecuteAsync(query.AsUpdate(values), transaction, timeout, cancellationToken);
        }

        public static async Task<int> UpdateAsync(this Query query, object data, IDbTransaction transaction = null, int? timeout = null, CancellationToken cancellationToken = default)
        {
            return await CreateQueryFactory(query).ExecuteAsync(query.AsUpdate(data), transaction, timeout, cancellationToken);
        }

        #endregion Methods
    }
}