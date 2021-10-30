using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models
{
    public class CarPark
    {
        private readonly ICollection<Semitrailer> _semitrailers;
        private readonly ICollection<TruckTractor> _trackTractors;
        public CarPark()
        {
            _semitrailers = new List<Semitrailer>();
            _trackTractors = new List<TruckTractor>();
        }
        public CarPark(ICollection<Semitrailer> semitrailers, ICollection<TruckTractor> truckTractors)
        {
            _semitrailers = semitrailers ?? throw new ArgumentNullException(nameof(semitrailers), "Semitrailers cannot be null");
            _trackTractors = truckTractors ?? throw new ArgumentNullException(nameof(truckTractors), "Truck tractors cannot be null");
        }
        public IReadOnlyCollection<Semitrailer> Semitrailers => new ReadOnlyCollection<Semitrailer>(_semitrailers.ToList());
        public IReadOnlyCollection<TruckTractor> TruckTractors => new ReadOnlyCollection<TruckTractor>(_trackTractors.ToList());
        public void Add(Semitrailer semitrailer)
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
        public void Remove(Semitrailer semitrailer) => _semitrailers.Remove(semitrailer);
        public void Remove(TruckTractor truckTractor) => _trackTractors.Remove(truckTractor);
        public void ClearSemitrailers() => _semitrailers.Clear();
        public void ClearTrackTractors() => _trackTractors.Clear();
        public override bool Equals(object obj) => obj is CarPark carPark &&
                                                   _semitrailers.AllEquals(carPark._semitrailers) &&
                                                   _trackTractors.AllEquals(carPark._trackTractors);
        public override int GetHashCode() => _semitrailers.GetHashCode();
        public override string ToString() => 
            string.Format("Car Park. Total semitrailers: {0}. Total track tractors: {1}", _semitrailers.Count, _trackTractors.Count);
    }
}
