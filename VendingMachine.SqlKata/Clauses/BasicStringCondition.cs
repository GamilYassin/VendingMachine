using System;

namespace VendingMachine.QueryBuilder
{
    public class BasicStringCondition : BasicCondition
    {
        #region Fields

        private string escapeCharacter = null;

        #endregion Fields

        #region Properties

        public bool CaseSensitive { get; set; } = false;
        public string EscapeCharacter
        {
            get => escapeCharacter;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    value = null;
                else if (value.Length > 1)
                    throw new ArgumentOutOfRangeException($"The {nameof(EscapeCharacter)} can only contain a single character!");
                escapeCharacter = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new BasicStringCondition
            {
                Engine = Engine,
                Column = Column,
                Operator = Operator,
                Value = Value,
                IsOr = IsOr,
                IsNot = IsNot,
                CaseSensitive = CaseSensitive,
                EscapeCharacter = EscapeCharacter,
                Component = Component,
            };
        }

        #endregion Methods
    }
}