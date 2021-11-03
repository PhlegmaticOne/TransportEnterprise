using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class CarParkControllerTests
    {
        private readonly CarParkController _carPark;

        public CarParkControllerTests()
        {
            _carPark = new CarParkController(new CarPark(GetSemitrailers(), GetTrcuckTractors()));
        }
        private static List<Semitrailer> GetSemitrailers() => new()
        {
            new Refrigerator(300, 300, new TemperatureRule(-100, 100), 30),
            new Refrigerator(200, 300, new TemperatureRule(-10, 10), 30),
            new TankTruck(500, 200),
            new TiltSemitrailer(1000, 1000),
        };
        private static List<TruckTractor> GetTrcuckTractors() => new()
        {
            new ActrosMP2("S8D8D3"),
            new ActrosMP2("S8D8D4"),
            new ActrosMP3("S9D8D4"),
            new ActrosMP3("S9D8D5"),
        };

        [TestMethod()]
        public void GetSemitrailersTest()
        {
            var refrig = _carPark.GetSemitrailers(s => s is Refrigerator refrigerator &&
                    refrigerator.TemperatureRule.IsInTheRange(new TemperatureRule(-20, 20)));

            Assert.IsTrue(refrig.Count == 1);
            Assert.AreEqual(200, refrig.First().LoadCapacity);
            Assert.AreEqual(300, refrig.First().ValueCapacity);
            Assert.AreEqual(30, (refrig.First() as Refrigerator).NoiseLevelInDecibels);
        }

        [TestMethod()]
        public void GetTruckTractorsTest()
        {
            var truck = _carPark.GetTruckTractors(t => t.SerialNumber == "S9D8D4");
            Assert.IsTrue(truck.Count == 1);
        }

        [TestMethod()]
        public void GetByPatternSemitralersTest()
        {
            var patternSemitrailer = new TankTruck(500, 200);
            var result = _carPark.GetByPattern(patternSemitrailer);
            Assert.IsTrue(result is not null);
        }

        [TestMethod()]
        public void GetByPatternTruckTracktorsTest()
        {
            var patternTruck = new ActrosMP2("S8D8D3");
            var result = _carPark.GetByPattern(patternTruck);
            Assert.IsTrue(result is not null);
        }

        [TestMethod()]
        public void GetAllPossibleCouplingsTest()
        {
            var result = _carPark.GetAllPossibleCouplings();
            Assert.IsTrue(16 == result.Count());
        }

        [TestMethod()]
        public void GetCouplingsTest()
        {
            var result = _carPark.GetCouplings(c => c.TruckTractor is ActrosMP2);
            Assert.IsTrue(8 == result.Count());
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

            Assert.IsTrue(8 == result.Count());
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
            Assert.IsTrue(4 == result.Count());
            Assert.IsTrue(result.All(c => c.Semitrailer is TiltSemitrailer));
        }
    }
}