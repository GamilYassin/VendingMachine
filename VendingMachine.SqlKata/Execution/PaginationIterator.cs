using System.Collections;
using System.Collections.Generic;

namespace VendingMachine.QueryBuilder
{
    public class PaginationIterator<T> : IEnumerable<PaginationResult<T>>
    {
        #region Properties

        public PaginationResult<T> CurrentPage { get; set; }
        public PaginationResult<T> FirstPage { get; set; }

        #endregion Properties

        #region Methods

        public IEnumerator<PaginationResult<T>> GetEnumerator()
        {
            CurrentPage = FirstPage;

            yield return CurrentPage;

            while (CurrentPage.HasNext)
            {
                CurrentPage = CurrentPage.Next();
                yield return CurrentPage;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion Methods
    }
}