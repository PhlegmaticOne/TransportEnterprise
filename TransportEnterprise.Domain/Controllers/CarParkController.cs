using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportEnterprise.Models
{
    public sealed class CarParkController
    {
        private readonly CarPark _carPark;
        public CarParkController(CarPark carPark) => _carPark = carPark ?? throw new ArgumentNullException(nameof(carPark));
        public string ToStringRepresentation() => new StringBuilder()
            .AppendLine(_carPark.ToString() + "\n")
            .AppendLine("Semitrailers:")
            .AppendLine(string.Join('\n', _carPark.Semitrailers.Select(s => s.ToString())) + '\n')
            .AppendLine("TruckTracktors:")
            .AppendLine(string.Join('\n', _carPark.TruckTractors.Select(t => t.ToString())))
            .ToString();
        public ICollection<Semitrailer> GetSemitrailers(Func<Semitrailer, bool> predicate) => _carPark.Semitrailers.Where(predicate).ToList();
        public ICollection<TruckTractor> GetTruckTractors(Func<TruckTractor, bool> predicate) => _carPark.TruckTractors.Where(predicate).ToList();
        public Semitrailer GetByPattern(Semitrailer semitrailer) => _carPark.Semitrailers.FirstOrDefault(s => s.Equals(semitrailer));
        public TruckTractor GetByPattern(TruckTractor truckTractor) => _carPark.TruckTractors.FirstOrDefault(t => t.Equals(truckTractor));
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
        public IEnumerable<Coupling> GetCouplingsThatCanBeLoaded(IEnumerable<Product> productsToLoad)
            => WorkWithProducts(productsToLoad, (c) => c.Semitrailer.LoadCapacity >= productsToLoad.Sum(p => p.Weight));
        public IEnumerable<Coupling> GetCouplingsThatCanBeLoadedFull(IEnumerable<Product> productsToLoad)
            => WorkWithProducts(productsToLoad, (c) => c.Semitrailer.LoadCapacity == productsToLoad.Sum(p => p.Weight));
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
