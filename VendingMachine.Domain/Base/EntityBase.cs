using System;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.Base
{
    public abstract class EntityBase : IEntity
    {
        #region Constructors

        public EntityBase()
        {

        }

        public EntityBase(int id)
        {
            Id = id;
        }

        #endregion Constructors

        #region Properties

        public int Id { get; set; }

        #endregion Properties

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            EntityBase other = (EntityBase)obj;
            return !(other is null) && Id == other.Id;
        }

        public static bool operator ==(EntityBase base1, EntityBase base2)
        {
            return ((base1 == null) && (base2 == null)) 
                || (base1 != null && base2 != null && base1.Equals(base2));
        }

        public static bool operator !=(EntityBase base1, EntityBase base2)
        {
            return !(base1 == base2);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public abstract override string ToString();
    }
}