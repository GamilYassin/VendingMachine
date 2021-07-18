using System;

namespace VendingMachine.QueryBuilder
{
    public class DeepJoin : JoinBase
    {
        #region Properties

        public string Expression { get; set; }
        public Func<string, string> SourceKeyGenerator { get; set; }
        public string SourceKeySuffix { get; set; }
        public string TargetKey { get; set; }
        public Func<string, string> TargetKeyGenerator { get; set; }
        public string Type { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new DeepJoin
            {
                Engine = Engine,
                Component = Component,
                Type = Type,
                Expression = Expression,
                SourceKeySuffix = SourceKeySuffix,
                TargetKey = TargetKey,
                SourceKeyGenerator = SourceKeyGenerator,
                TargetKeyGenerator = TargetKeyGenerator,
            };
        }

        #endregion Methods
    }
}