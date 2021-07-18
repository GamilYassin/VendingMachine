using System;

namespace VendingMachine.QueryBuilder
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    /// <summary>
    ///  This class is used as metadata on a property to determine if it is a primary key
    /// </summary>
    public class KeyAttribute : ColumnAttribute
    {
        #region Constructors

        public KeyAttribute([System.Runtime.CompilerServices.CallerMemberName] string name = "")
        : base(name)
        {
        }

        #endregion Constructors
    }
}