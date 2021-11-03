using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class TruckTractorTests
    {
        private readonly ActrosMP3 _actrosMP3;
        public TruckTractorTests()
        {
            var sem = new TankTruck(100, 100);
            _actrosMP3 = new ActrosMP3(sem, "D2");
        }
        [TestMethod()]
        public void HookUpTest()
        {
            var refr = new Refrigerator(100, 100, new TemperatureRule(-10, 10), 200);
            Assert.IsInstanceOfType(_actrosMP3.Semitrailer, typeof(TankTruck));
            _actrosMP3.HookUp(refr);
            Assert.IsInstanceOfType(_actrosMP3.Semitrailer, typeof(Refrigerator));
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var sem = new TankTruck(100, 100);
            var actrosMP3new = new ActrosMP3(sem, "D2");
            Assert.AreEqual(_actrosMP3, actrosMP3new);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("ActrosMP3: TankTruck. Max load capacity: 100,0000. Current loading: 0,0000. Petrol consumption: 0,0000 l/h",
                 _actrosMP3.ToString());
        }
    }
}