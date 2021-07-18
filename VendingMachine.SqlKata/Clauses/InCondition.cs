using System.Collections.Generic;

namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents a "is in" condition.
    /// </summary>
    public class InCondition<T> : ConditionBase
    {
        #region Properties

        public string Column { get; set; }
        public IEnumerable<T> Values { get; set; }

        #endregion Properties

        #region Methods

        public override ClauseBase Clone()
        {
            return new InCondition<T>
            {
                Engine = Engine,
                Column = Column,
                Values = new List<T>(Values),
                IsOr = IsOr,
                IsNot = IsNot,
                Component = Component,
            };
        }

        #endregion Methods
    }
}