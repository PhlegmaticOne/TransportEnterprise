using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class CarPark : BaseDomainModel
    {
        private readonly ICollection<Semitrailer<Product>> _semitrailers;
        private readonly ICollection<TruckTractor> _trackTractors;
        public CarPark(int id, ICollection<Semitrailer<Product>> semitrailers, ICollection<TruckTractor> truckTractors)
        {
            _semitrailers = semitrailers ?? throw new ArgumentNullException(nameof(semitrailers), "Semitrailers cannot be null");
            _trackTractors = truckTractors ?? throw new ArgumentNullException(nameof(truckTractors), "Truck tractors cannot be null");
            Id = id;
        }
        public void Add(Semitrailer<Product> semitrailer)
        {
            if (semitrailer is not null)
            {
                _semitrailers.Add(semitrailer);
            }
        }
        public void Add(TruckTractor truckTractor)
        {
            if(truckTractor is not null)
            {
                _trackTractors.Add(truckTractor);
            }
        }

        public override bool Equals(object obj) => obj is CarPark carPark &&
                                                   _semitrailers.AllEquals((s, i) => s.Equals(carPark._semitrailers.ElementAt(i))) &&
                                                   _trackTractors.AllEquals((t, i) => t.Equals(carPark._trackTractors.ElementAt(i)));
        public override int GetHashCode() => Id;
        public override string ToString() => 
            string.Format("Car Park №{0}. Total semitrailers: {1}. Total track tractors: {2}", Id, _semitrailers.Count, _trackTractors.Count);
    }
}
