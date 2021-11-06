using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Tests
{
    [TestClass]
    public class CarParkNewTests
    {
        private readonly CarPark _carPark;

        public CarParkNewTests()
        {
            var semitrailers = GetSemitrailers();
            var truckTractors = GetTruckTractors();
            truckTractors.Add(new ActrosMP2(new TiltSemitrailer(111, 1222), "Sss"));
            for (int i = 0; i < 4; i++)
            {
                truckTractors[i].HookUp(semitrailers[i]);
            }
            _carPark = new CarPark(semitrailers, truckTractors);
        }
        private static List<Semitrailer> GetSemitrailers() => new()
        {
            new Refrigerator(300, 300, new TemperatureRule(-100, 100), 30),
            new Refrigerator(300, 300, new TemperatureRule(-10, 10), 30),
            new TankTruck(500, 200),
            new TiltSemitrailer(1000, 1000),
        };
        private static List<TruckTractor> GetTruckTractors() => new()
        {
            new ActrosMP2("S8D8D3"),
            new ActrosMP2("S8D8D4"),
            new ActrosMP3("S9D8D4"),
            new ActrosMP3("S9D8D4"),
        };

        [TestMethod()]
        public void AddTruckTractorTest()
        {
            var newSemitrailer = new TiltSemitrailer(300, 300);
            var newActrosMP2 = new ActrosMP2(newSemitrailer, "SSS");
            var newActrosMP3 = new ActrosMP3(newSemitrailer, "sss");
            _carPark.Add(newActrosMP2);
            Assert.ThrowsException<ArgumentException>(() => _carPark.Add(newActrosMP3));
        }

        [TestMethod()]
        public void RemoveSemitrailerTest()
        {
            _carPark.Remove(GetSemitrailers()[0]);
            Assert.IsTrue(_carPark.Semitrailers.Count == 4);
        }
        [TestMethod()]
        public void RemoveTruckTractorWithItsSemitrailerTest()
        {
            var truck = _carPark.GetTruckTractors(s => s is ActrosMP2);
            _carPark.Remove(truck.First(), RemoveTruckTractorType.RemoveItsSemitrailer);
            Assert.IsTrue(_carPark.TruckTractors.Count == 4);
            Assert.IsTrue(_carPark.Semitrailers.Count == 4);
        }
        [TestMethod()]
        public void RemoveTruckTractorLeaveItsSemitrailerTest()
        {
            var truck = _carPark.GetTruckTractors(t => t is ActrosMP3);
            _carPark.Remove(truck.First(), RemoveTruckTractorType.LeaveItsSemitrailer);
            Assert.IsTrue(_carPark.TruckTractors.Count == 4);
            Assert.IsTrue(_carPark.Semitrailers.Count == 5);
        }

        [TestMethod()]
        public void GetAllCouplingsTest()
        {
            var couplings = _carPark.GetAllPossibleCouplings();
            Assert.IsTrue(couplings.Count() == 25);
        }
        [TestMethod()]
        public void UpdateTest()
        {
            var oldTruck = _carPark.GetTruckTractors(t => t is ActrosMP2).First();
            var newTruck = new ActrosMP2(new TiltSemitrailer(200, 200), oldTruck.SerialNumber);
            _carPark.Update(oldTruck, newTruck);

            Assert.IsTrue(_carPark.GetSemitrailers(s => s is TiltSemitrailer).Count == 3);
            Assert.IsTrue(_carPark.GetSemitrailers(s => s is Refrigerator).Count == 1);
        }
        [TestMethod()]
        public void GetCouplingsThatCanBeLoadedTest()
        {
            var products = new List<Product>()
            {
                new PetrolA92(10, 10, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, "Danger"),
                new PetrolA92(10, 10, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, "Danger"),
                new PetrolA92(10, 10, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, "Danger"),
                new PetrolA92(10, 10, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, "Danger"),
            };
            var result = _carPark.GetCouplingsThatCanBeLoaded(products);

            Assert.IsTrue(15 == result.Count());
            Assert.IsTrue(result.All(c => c.Semitrailer is TankTruck || c.Semitrailer is TiltSemitrailer));
        }

        [TestMethod()]
        public void GetCouplingsThatCanBeLoadedFullTest()
        {
            var products = new List<Product>()
            {
                new CocaCola(500, 500, "Coley", CocaColaTaste.Orange),
                new CocaCola(500, 500, "Coley", CocaColaTaste.ClassicWithoutSugar),
            };
            var result = _carPark.GetCouplingsThatCanBeLoadedFull(products);
            Assert.IsTrue(5 == result.Count());
            Assert.IsTrue(result.All(c => c.Semitrailer is TiltSemitrailer));
        }
    }
}
