using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public class CarPark
    {
        public ICollection<Semitrailer<Product>> Semitrailers { get; set; }
        public ICollection<TruckTractor> Tractors { get; }
    }
}
