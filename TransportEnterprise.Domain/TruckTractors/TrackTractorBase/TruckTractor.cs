using System;

namespace TransportEnterprise.Models
{
    public abstract class TruckTractor : BaseDomainModel, IEquatable<TruckTractor>
    {
        public TruckTractor(int id, Semitrailer<Product> semitrailer)
        {
            Semitrailer = semitrailer ?? throw new ArgumentNullException(nameof(semitrailer), "Semitrailer cannot be null");
            Id = id;
        }
        public Semitrailer<Product> Semitrailer { get; protected set; }
        public decimal LoadCapacity => Semitrailer.LoadCapacity;
        public abstract decimal PetrolPerHour { get; }
        public virtual void HookUp(Semitrailer<Product> newSemitrailer)
        {
            if(newSemitrailer is not null)
            {
                Semitrailer = newSemitrailer;
            }
        }
        public bool Equals(TruckTractor other) => Semitrailer.Equals(other.Semitrailer) && PetrolPerHour == other.PetrolPerHour;
        public override bool Equals(object obj) => Equals(obj as TruckTractor);
        public override int GetHashCode() => (int)(PetrolPerHour + LoadCapacity);
        public override string ToString()
        {
            return string.Format("Semitrailer: {0}. Petrol consumption: {1:f4} l/h.", Semitrailer.ToString(), PetrolPerHour);
        }
    }
}
