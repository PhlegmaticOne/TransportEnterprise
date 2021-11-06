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
            foreach (var truckTractor in truckTractors)
            {
                var semitrailer = truckTractor.Semitrailer;
                if (semitrailer is not null)
                {
                    var fittedSemitrailer = _semitrailers.FirstOrDefault(s => s.Equals(semitrailer));
                    if (ReferenceEquals(semitrailer, fittedSemitrailer) == false)
                    {
                        _semitrailers.Add(semitrailer);
                    }
                }
            }
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
            if(semitrailer is null)
            {
                return;
            }
            if (_semitrailers.All(s => ReferenceEquals(s, semitrailer) == false))
            {
                _semitrailers.Add(semitrailer);
            }
            else
            {
                throw new ArgumentException("Two track tracktors can't handle one semitrailer");
            }
        }
        /// <summary>
        /// Adds new truck tractor to car park
        /// </summary>
        public void Add(TruckTractor truckTractor)
        {
            if(truckTractor is null)
            {
                return;
            }
            if(_trackTractors.All(t => ReferenceEquals(t, truckTractor) == false))
            {
                _trackTractors.Add(truckTractor);
                Add(truckTractor.Semitrailer);
            }
            else
            {
                throw new ArgumentException("Two track tracktors can't handle one semitrailer");
            }
        }
        /// <summary>
        /// Removes semitrailer from car park
        /// </summary>
        /// <param name="semitrailer"></param>
        public void Remove(Semitrailer semitrailer)
        {
            var truckWithSemitrailer = _trackTractors.FirstOrDefault(t => semitrailer.Equals(t.Semitrailer));
            truckWithSemitrailer?.Unhook();
            _semitrailers.Remove(semitrailer);
        }
        /// <summary>
        /// Removes truck track from car park
        /// </summary>
        public void Remove(TruckTractor truckTractor, RemoveTruckTractorType removeTruckType)
        {
            switch (removeTruckType)
            {
                case RemoveTruckTractorType.RemoveItsSemitrailer:
                {
                    _semitrailers.Remove(truckTractor.Semitrailer);
                    break;
                }
            }
            _trackTractors.Remove(truckTractor);
        }
        /// <summary>
        /// Removes all semitrailers from car park
        /// </summary>
        public void ClearSemitrailers()
        {
            foreach (var semitrailer in _semitrailers)
            {
                _trackTractors.FirstOrDefault(t => semitrailer.Equals(t.Semitrailer))?.Unhook();
            }
            _semitrailers.Clear();
        }
        /// <summary>
        /// Removes all truck tractors from car park
        /// </summary>
        public void ClearTrackTractors(ClearTruckTractorType clearTruckTractorType)
        {
            switch (clearTruckTractorType)
            {
                case ClearTruckTractorType.RemoveAllTruckSemitrailers:
                {
                    foreach (var truck in _trackTractors)
                    {
                        _semitrailers.Remove(truck.Semitrailer);
                    }
                    break;
                }
            }
            _trackTractors.Clear();
        }
        /// <summary>
        /// Updates track tractor to a new truck tractor
        /// </summary>
        public void Update(TruckTractor oldTruckTractor, TruckTractor newTruckTractor)
        {
            Remove(oldTruckTractor, RemoveTruckTractorType.RemoveItsSemitrailer);
            Add(newTruckTractor);
        }
        /// <summary>
        /// Gets all possible coplings that can be loaded from the car park entities
        /// </summary>
        public IEnumerable<Coupling> GetAllPossibleCouplings()
        {
            foreach (var semitrailer in Semitrailers)
            {
                foreach (var truckTractor in TruckTractors)
                {
                    yield return new Coupling(semitrailer, truckTractor);
                }
            }
        }
        /// <summary>
        /// Gets all couplings depending on a specified predicate
        /// </summary>
        public IEnumerable<Coupling> GetCouplings(Func<Coupling, bool> predicate)
        {
            foreach (var semitrailer in Semitrailers)
            {
                foreach (var truckTractor in TruckTractors)
                {
                    var coupling = new Coupling(semitrailer, truckTractor);
                    if (predicate.Invoke(coupling))
                    {
                        yield return coupling;
                    }
                }
            }
        }
        /// <summary>
        /// Gets all coupling that can be loaded with specified collection of prooducts
        /// </summary>
        public IEnumerable<Coupling> GetCouplingsThatCanBeLoaded(IEnumerable<Product> productsToLoad)
        {
            var totalWeight = productsToLoad.Sum(p => p.Weight);
            var totalValue = productsToLoad.Sum(p => p.Value);
            return WorkWithProducts(productsToLoad,
                                    (c) => c.Semitrailer.LoadCapacity >= totalWeight &&
                                           c.Semitrailer.ValueCapacity >= totalValue);
        }
        /// <summary>
        /// Gets all couplings that can be loaded fully with specified collection of products
        /// </summary>
        public IEnumerable<Coupling> GetCouplingsThatCanBeLoadedFull(IEnumerable<Product> productsToLoad)
        {
            var totalWeight = productsToLoad.Sum(p => p.Weight);
            var totalValue = productsToLoad.Sum(p => p.Value);
            return WorkWithProducts(productsToLoad,
                                    (c) => c.Semitrailer.LoadCapacity == totalWeight &&
                                           c.Semitrailer.ValueCapacity >= totalValue);
        }
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
        /// <summary>
        /// Helping method forwork with couplings
        /// </summary>
        private IEnumerable<Coupling> WorkWithProducts(IEnumerable<Product> productsToLoad, Func<Coupling, bool> predicate)
        {
            var predictedFittedCouplings = GetCouplings(predicate).ToList();
            for (int i = 0; i < predictedFittedCouplings.Count; i++)
            {
                var semitrailerLoadingRules = predictedFittedCouplings[i].Semitrailer.GetLoadingRules();
                foreach (var product in productsToLoad)
                {
                    if (semitrailerLoadingRules.CanLoad(product) == false)
                    {
                        predictedFittedCouplings.Remove(predictedFittedCouplings[i]);
                        --i;
                        break;
                    }
                }
            }
            return predictedFittedCouplings;
        }
    }
}

public enum RemoveTruckTractorType
{
    RemoveItsSemitrailer,
    LeaveItsSemitrailer
}

public enum ClearTruckTractorType
{
    RemoveAllTruckSemitrailers,
    LeaveAllTruckSemitrailers
}
