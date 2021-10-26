using System;

namespace TransportEnterprise.Models
{
    public class Coupling
    {
        public Coupling(Semitrailer<Product> semitrailer, TruckTractor truckTractor)
        {
            Semitrailer = semitrailer ?? throw new ArgumentNullException(nameof(semitrailer), "Semitrailer cannot be null");
            TruckTractor = truckTractor ?? throw new ArgumentNullException(nameof(truckTractor), "Truck tractor cannot be null");
        }
        public Semitrailer<Product> Semitrailer { get; }
        public TruckTractor TruckTractor { get; }
    }
}
