using System;
using System.Collections;
using System.Text;
using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    public abstract class TruckTractor : IEquatable<TruckTractor>
    {
        public TruckTractor() { }
        public TruckTractor(Semitrailer semitrailer)
        {
            Semitrailer = semitrailer ?? throw new ArgumentNullException(nameof(semitrailer), "Semitrailer cannot be null");
        }
        public Semitrailer Semitrailer { get; protected set; }
        public decimal GetLoadCapacity() => Semitrailer.LoadCapacity;
        public abstract decimal PetrolPerHour { get; }
        public virtual void HookUp(Semitrailer newSemitrailer)
        {
            if(newSemitrailer is not null)
            {
                Semitrailer = newSemitrailer;
            }
        }
        public bool Equals(TruckTractor other) => Semitrailer.Equals(other.Semitrailer) && PetrolPerHour == other.PetrolPerHour;
        public override bool Equals(object obj) => Equals(obj as TruckTractor);
        public override int GetHashCode() => (int)(PetrolPerHour + GetLoadCapacity());
        public override string ToString() => string.Format("{0}: {1}. Petrol consumption: {2:f4} l/h.", GetType().Name, Semitrailer.ToString(), PetrolPerHour);

    }
}
