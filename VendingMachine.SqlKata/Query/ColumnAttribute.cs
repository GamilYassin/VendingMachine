using System;

namespace VendingMachine.QueryBuilder
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    /// <summary>
    ///  This class is used as metadata on a property to generate different name in the output query.
    /// </summary>
    public class ColumnAttribute : Attribute
    {
        #region Constructors

        public ColumnAttribute(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        #endregion Constructors

        #region Properties

        public string Name { get; private set; }

        #endregion Properties
    }
}