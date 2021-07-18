using System.Collections.Generic;

namespace VendingMachine.QueryBuilder
{
    public class CteFinder
    {
        #region Fields

        private readonly string engineCode;
        private readonly Query query;
        private HashSet<string> namesOfPreviousCtes;
        private List<FromBase> orderedCteList;

        #endregion Fields

        #region Constructors

        public CteFinder(Query query, string engineCode)
        {
            this.query = query;
            this.engineCode = engineCode;
        }

        #endregion Constructors

        #region Methods

        private List<FromBase> findInternal(Query queryToSearch)
        {
            var cteList = queryToSearch.GetComponents<FromBase>("cte", engineCode);

            var resultList = new List<FromBase>();

            foreach (var cte in cteList)
            {
                if (namesOfPreviousCtes.Contains(cte.Alias))
                    continue;

                namesOfPreviousCtes.Add(cte.Alias);
                resultList.Add(cte);

                if (cte is QueryFromClause queryFromClause)
                {
                    resultList.InsertRange(0, findInternal(queryFromClause.Query));
                }
            }

            return resultList;
        }

        public List<FromBase> Find()
        {
            if (null != orderedCteList)
                return orderedCteList;

            namesOfPreviousCtes = new HashSet<string>();

            orderedCteList = findInternal(query);

            namesOfPreviousCtes.Clear();
            namesOfPreviousCtes = null;

            return orderedCteList;
        }

        #endregion Methods
    }
}