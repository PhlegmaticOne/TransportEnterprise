using System;

namespace TransportEnterprise.Models
{
    public abstract class TruckTractor : BaseDomainModel
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
    }
}
