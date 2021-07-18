using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.QueryBuilder
{
    public abstract class AbstractQuery
    {
        #region Fields

        public AbstractQuery Parent;

        #endregion Fields
    }

    public abstract partial class QueryBase<Q> : AbstractQuery where Q : QueryBase<Q>
    {
        #region Fields

        private bool notFlag = false;
        private bool orFlag = false;
        public string EngineScope = null;

        #endregion Fields

        #region Constructors

        public QueryBase()
        {
        }

        #endregion Constructors

        #region Properties

        public List<ClauseBase> Clauses { get; set; } = new List<ClauseBase>();

        #endregion Properties

        #region Methods

        /// <summary>
        ///  Set the next boolean operator to "and" for the "where" clause.
        /// </summary>
        /// <returns>
        /// </returns>
        protected Q And()
        {
            orFlag = false;
            return (Q)this;
        }

        /// <summary>
        ///  Get the "not" operator and clear it
        /// </summary>
        /// <returns>
        /// </returns>
        protected bool GetNot()
        {
            bool ret = notFlag;

            // reset the flag
            notFlag = false;
            return ret;
        }

        /// <summary>
        ///  Get the boolean operator and reset it to "and"
        /// </summary>
        /// <returns>
        /// </returns>
        protected bool GetOr()
        {
            bool ret = orFlag;

            // reset the flag
            orFlag = false;
            return ret;
        }

        /// <summary>
        ///  Add a component clause to the query.
        /// </summary>
        /// <param name="component">
        /// </param>
        /// <param name="clause">
        /// </param>
        /// <param name="engineCode">
        /// </param>
        /// <returns>
        /// </returns>
        public Q AddComponent(string component, ClauseBase clause, string engineCode = null)
        {
            if (engineCode == null)
            {
                engineCode = EngineScope;
            }

            clause.Engine = engineCode;
            clause.Component = component;
            Clauses.Add(clause);

            return (Q)this;
        }

        /// <summary>
        ///  If the query already contains a clause for the given component and engine, replace it
        ///  with the specified clause. Otherwise, just add the clause.
        /// </summary>
        /// <param name="component">
        /// </param>
        /// <param name="clause">
        /// </param>
        /// <param name="engineCode">
        /// </param>
        /// <returns>
        /// </returns>
        public Q AddOrReplaceComponent(string component, ClauseBase clause, string engineCode = null)
        {
            engineCode = engineCode ?? EngineScope;

            ClauseBase current = GetComponents(component).SingleOrDefault(c => c.Engine == engineCode);
            if (current != null)
                Clauses.Remove(current);

            return AddComponent(component, clause, engineCode);
        }

        /// <summary>
        ///  Remove all clauses for a component.
        /// </summary>
        /// <param name="component">
        /// </param>
        /// <param name="engineCode">
        /// </param>
        /// <returns>
        /// </returns>
        public Q ClearComponent(string component, string engineCode = null)
        {
            if (engineCode == null)
            {
                engineCode = EngineScope;
            }

            Clauses = Clauses
                .Where(x => !(x.Component == component && (engineCode == null || x.Engine == null || engineCode == x.Engine)))
                .ToList();

            return (Q)this;
        }

        /// <summary>
        ///  Return a cloned copy of the current query.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Q Clone()
        {
            Q q = NewQuery();

            q.Clauses = Clauses.Select(x => x.Clone()).ToList();

            return q;
        }

        /// <summary>
        ///  Add a from Clause
        /// </summary>
        /// <param name="table">
        /// </param>
        /// <returns>
        /// </returns>
        public Q From(string table)
        {
            return AddOrReplaceComponent("from", new FromClause
            {
                Table = table,
            });
        }

        public Q From(Query query, string alias = null)
        {
            query = query.Clone();
            query.SetParent((Q)this);

            if (alias != null)
            {
                query.As(alias);
            };

            return AddOrReplaceComponent("from", new QueryFromClause
            {
                Query = query
            });
        }

        public Q From(Func<Query, Query> callback, string alias = null)
        {
            Query query = new Query();

            query.SetParent((Q)this);

            return From(callback.Invoke(query), alias);
        }

        public Q FromRaw(string sql, params object[] bindings)
        {
            return AddOrReplaceComponent("from", new RawFromClause
            {
                Expression = sql,
                Bindings = bindings,
            });
        }

        /// <summary>
        ///  Get the list of clauses for a component.
        /// </summary>
        /// <returns>
        /// </returns>
        public List<C> GetComponents<C>(string component, string engineCode = null) where C : ClauseBase
        {
            if (engineCode == null)
            {
                engineCode = EngineScope;
            }

            IEnumerable<C> clauses = Clauses
                .Where(x => x.Component == component)
                .Where(x => engineCode == null || x.Engine == null || engineCode == x.Engine)
                .Cast<C>();

            return clauses.ToList();
        }

        /// <summary>
        ///  Get the list of clauses for a component.
        /// </summary>
        /// <param name="component">
        /// </param>
        /// <param name="engineCode">
        /// </param>
        /// <returns>
        /// </returns>
        public List<ClauseBase> GetComponents(string component, string engineCode = null)
        {
            if (engineCode == null)
            {
                engineCode = EngineScope;
            }

            return GetComponents<ClauseBase>(component, engineCode);
        }

        /// <summary>
        ///  Get a single component clause from the query.
        /// </summary>
        /// <returns>
        /// </returns>
        public C GetOneComponent<C>(string component, string engineCode = null) where C : ClauseBase
        {
            engineCode = engineCode ?? EngineScope;

            List<C> all = GetComponents<C>(component, engineCode);
            return all.FirstOrDefault(c => c.Engine == engineCode) ?? all.FirstOrDefault(c => c.Engine == null);
        }

        /// <summary>
        ///  Get a single component clause from the query.
        /// </summary>
        /// <param name="component">
        /// </param>
        /// <param name="engineCode">
        /// </param>
        /// <returns>
        /// </returns>
        public ClauseBase GetOneComponent(string component, string engineCode = null)
        {
            if (engineCode == null)
            {
                engineCode = EngineScope;
            }

            return GetOneComponent<ClauseBase>(component, engineCode);
        }

        /// <summary>
        ///  Return whether the query has clauses for a component.
        /// </summary>
        /// <param name="component">
        /// </param>
        /// <param name="engineCode">
        /// </param>
        /// <returns>
        /// </returns>
        public bool HasComponent(string component, string engineCode = null)
        {
            if (engineCode == null)
            {
                engineCode = EngineScope;
            }

            return GetComponents(component, engineCode).Any();
        }

        public Q NewChild()
        {
            Q newQuery = NewQuery().SetParent((Q)this);
            newQuery.EngineScope = EngineScope;
            return newQuery;
        }

        public abstract Q NewQuery();

        /// <summary>
        ///  Set the next "not" operator for the "where" clause.
        /// </summary>
        /// <returns>
        /// </returns>
        public Q Not(bool flag = true)
        {
            notFlag = flag;
            return (Q)this;
        }

        /// <summary>
        ///  Set the next boolean operator to "or" for the "where" clause.
        /// </summary>
        /// <returns>
        /// </returns>
        public Q Or()
        {
            orFlag = true;
            return (Q)this;
        }

        public Q SetEngineScope(string engine)
        {
            EngineScope = engine;

            return (Q)this;
        }

        public Q SetParent(AbstractQuery parent)
        {
            if (this == parent)
            {
                throw new ArgumentException($"Cannot set the same {nameof(AbstractQuery)} as a parent of itself");
            }

            Parent = parent;
            return (Q)this;
        }

        #endregion Methods
    }
}