using System;

namespace TransportEnterprise.Models
{
    public abstract class TruckTractor
    {
        public Semitrailer<Product> Semitrailer { get; protected set; }
        public decimal LoadCapacity => Semitrailer.LoadCapacity;
        public TruckTractor(Semitrailer<Product> semitrailer)
        {
            Semitrailer = semitrailer ?? throw new ArgumentNullException(nameof(semitrailer), "Semitrailer cannot be null");
        }
        public virtual void HookUp(Semitrailer<Product> newSemitrailer)
        {
            if(newSemitrailer is not null)
            {
                Semitrailer = newSemitrailer;
            }
        }
        public abstract decimal PetrolPerHour { get; }
    }
}
