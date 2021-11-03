using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class CarParkTests
    {
        private readonly CarPark _carPark;

        public CarParkTests()
        {
            _carPark = new CarPark(GetSemitrailers(), GetTrcuckTractors());
        }
        private static List<Semitrailer> GetSemitrailers() => new()
        {
            new Refrigerator(300, 300, new TemperatureRule(-100, 100), 30),
            new Refrigerator(300, 300, new TemperatureRule(-10, 10), 30),
            new TankTruck(500, 200),
            new TiltSemitrailer(1000, 1000),
        };
        private static List<TruckTractor> GetTrcuckTractors() => new()
        {
            new ActrosMP2("S8D8D3"),
            new ActrosMP2("S8D8D4"),
            new ActrosMP3("S9D8D4"),
            new ActrosMP3("S9D8D4"),
        };

        [TestMethod()]
        public void AddSemitrailerTest()
        {
            var sem = new TankTruck(100, 2);
            _carPark.Add(sem);
            Assert.IsTrue(_carPark.Semitrailers.Count == 5);
        }

        [TestMethod()]
        public void AddTruckTractorTest()
        {
            var tr = new ActrosMP2();
            _carPark.Add(tr);
            Assert.IsTrue(_carPark.TruckTractors.Count == 5);
        }

        [TestMethod()]
        public void RemoveTruckTractorTest()
        {
            var tr = new ActrosMP2("S8D8D4");
            _carPark.Remove(tr);
            Assert.IsTrue(_carPark.TruckTractors.Count == 3);
        }

        [TestMethod()]
        public void RemoveSemitrailerTest()
        {
            var sem = new TankTruck(500, 200);
            _carPark.Remove(sem);
            Assert.IsTrue(_carPark.Semitrailers.Count == 3);
        }

        [TestMethod()]
        public void ClearSemitrailersTest()
        {
            _carPark.ClearSemitrailers();
            Assert.IsTrue(_carPark.Semitrailers.Count == 0);
        }

        [TestMethod()]
        public void ClearTrackTractorsTest()
        {
            _carPark.ClearTrackTractors();
            Assert.IsTrue(_carPark.TruckTractors.Count == 0);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var carPark = new CarPark(GetSemitrailers(), GetTrcuckTractors());
            Assert.AreEqual(_carPark, carPark);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Car Park. Total semitrailers: 4. Total track tractors: 4", _carPark.ToString());
        }
    }
}