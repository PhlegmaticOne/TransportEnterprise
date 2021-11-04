using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents instance of car park with semitrailers and truck tractors 
    /// </summary>
    public sealed class CarPark
    {
        private readonly ICollection<Semitrailer> _semitrailers;
        private readonly ICollection<TruckTractor> _trackTractors;
        /// <summary>
        /// Initializes new empty car park instance
        /// </summary>
        public CarPark()
        {
            _semitrailers = new List<Semitrailer>();
            _trackTractors = new List<TruckTractor>();
        }
        /// <summary>
        /// Initializes new car park instance with specified collections of semitrailers and truck tractors
        /// </summary>
        public CarPark(ICollection<Semitrailer> semitrailers, ICollection<TruckTractor> truckTractors)
        {
            _semitrailers = semitrailers ??
                throw new ArgumentNullException(nameof(semitrailers), "Semitrailers cannot be null");
            _trackTractors = truckTractors ??
                throw new ArgumentNullException(nameof(truckTractors), "Truck tractors cannot be null");
        }
        /// <summary>
        /// Collection of semitrailers of car park
        /// </summary>
        public IReadOnlyCollection<Semitrailer> Semitrailers =>
            new ReadOnlyCollection<Semitrailer>(_semitrailers.ToList());
        /// <summary>
        /// Collection of truck tracktors of car park
        /// </summary>
        public IReadOnlyCollection<TruckTractor> TruckTractors =>
            new ReadOnlyCollection<TruckTractor>(_trackTractors.ToList());
        /// <summary>
        /// Adds new semitrailer to car park
        /// </summary>
        public void Add(Semitrailer semitrailer)
        {
            if (semitrailer is not null)
            {
                _semitrailers.Add(semitrailer);
            }
        }
        /// <summary>
        /// Adds new truck tractor to car park
        /// </summary>
        public void Add(TruckTractor truckTractor)
        {
            if(truckTractor is not null)
            {
                _trackTractors.Add(truckTractor);
            }
        }
        /// <summary>
        /// Removes semitrailer from car park
        /// </summary>
        /// <param name="semitrailer"></param>
        public void Remove(Semitrailer semitrailer) => _semitrailers.Remove(semitrailer);
        /// <summary>
        /// Removes truck track from car park
        /// </summary>
        public void Remove(TruckTractor truckTractor) => _trackTractors.Remove(truckTractor);
        /// <summary>
        /// Removes all semitrailers from car park
        /// </summary>
        public void ClearSemitrailers() => _semitrailers.Clear();
        /// <summary>
        /// Removes all truck tractors from car park
        /// </summary>
        public void ClearTrackTractors() => _trackTractors.Clear();
        /// <summary>
        /// Checks equality of specified object with current car park instance 
        /// </summary>
        public override bool Equals(object obj) => obj is CarPark carPark &&
                                                   _semitrailers.AllEquals(carPark._semitrailers) &&
                                                   _trackTractors.AllEquals(carPark._trackTractors);
        /// <summary>
        /// Gets hash code of car park instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => _semitrailers.GetHashCode();
        /// <summary>
        /// Gets string representation of car park instance
        /// </summary>
        /// <returns></returns>
        public override string ToString() => 
            string.Format("Car Park. Total semitrailers: {0}. Total track tractors: {1}",
                          _semitrailers.Count, _trackTractors.Count);
    }
}
