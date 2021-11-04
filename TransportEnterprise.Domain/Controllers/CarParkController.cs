using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents instance for doing operations with car park entities
    /// </summary>
    public sealed class CarParkController
    {
        /// <summary>
        /// Car park
        /// </summary>
        private readonly CarPark _carPark;
        /// <summary>
        /// Initializes new controller instance with specified car park
        /// </summary>
        /// <param name="carPark"></param>
        public CarParkController(CarPark carPark) => _carPark = carPark ?? throw new ArgumentNullException(nameof(carPark));
        /// <summary>
        /// Gets semitrailers depending on a specified predicate
        /// </summary>
        public ICollection<Semitrailer> GetSemitrailers(Func<Semitrailer, bool> predicate) =>
            _carPark.Semitrailers.Where(predicate).ToList();
        /// <summary>
        /// Gets truck tractors depending of a specified predicate
        /// </summary>
        public ICollection<TruckTractor> GetTruckTractors(Func<TruckTractor, bool> predicate) =>
            _carPark.TruckTractors.Where(predicate).ToList();
        /// <summary>
        /// Gets first semitrailer from the car cark which is equal to specified semitrailer
        /// </summary>
        public Semitrailer GetByPattern(Semitrailer semitrailer) =>
            _carPark.Semitrailers.FirstOrDefault(s => s.Equals(semitrailer));
        /// <summary>
        /// Gets first truck tractor from the car cark which is equal to specified truck tractor
        /// </summary>
        public TruckTractor GetByPattern(TruckTractor truckTractor) =>
            _carPark.TruckTractors.FirstOrDefault(t => t.Equals(truckTractor));
        /// <summary>
        /// Gets all possible coplings that can be loaded from the car park entities
        /// </summary>
        public IEnumerable<Coupling> GetAllPossibleCouplings()
        {
            foreach (var semitrailer in _carPark.Semitrailers)
            {
                foreach (var truckTractor in _carPark.TruckTractors)
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
            var result = new List<Coupling>();
            foreach (var semitrailer in _carPark.Semitrailers)
            {
                foreach (var truckTractor in _carPark.TruckTractors)
                {
                    var coupling = new Coupling(semitrailer, truckTractor);
                    if (predicate.Invoke(coupling))
                    {
                        result.Add(coupling);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Gets all coupling that can be loaded with specified collection of prooducts
        /// </summary>
        public IEnumerable<Coupling> GetCouplingsThatCanBeLoaded(IEnumerable<Product> productsToLoad)
            => WorkWithProducts(productsToLoad, (c) => c.Semitrailer.LoadCapacity >= productsToLoad.Sum(p => p.Weight));
        /// <summary>
        /// Gets all couplings that can be loaded fully with specified collection of products
        /// </summary>
        public IEnumerable<Coupling> GetCouplingsThatCanBeLoadedFull(IEnumerable<Product> productsToLoad)
            => WorkWithProducts(productsToLoad, (c) => c.Semitrailer.LoadCapacity == productsToLoad.Sum(p => p.Weight));
        /// <summary>
        /// Gets string representation, which contains all semitrailers and truck tractors of car park
        /// </summary>
        /// <returns></returns>
        public string ToStringRepresentation() => new StringBuilder()
            .AppendLine(_carPark.ToString() + "\n")
            .AppendLine("Semitrailers:")
            .AppendLine(string.Join('\n', _carPark.Semitrailers.Select(s => s.ToString())) + '\n')
            .AppendLine("TruckTracktors:")
            .AppendLine(string.Join('\n', _carPark.TruckTractors.Select(t => t.ToString())))
            .ToString();
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
