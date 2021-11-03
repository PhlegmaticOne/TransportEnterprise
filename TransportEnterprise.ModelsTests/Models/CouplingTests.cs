using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class CouplingTests
    {
        [TestMethod()]
        public void LoadUnsuccesfullTest()
        {
            var coupling = new Coupling(new TankTruck(100, 100), new ActrosMP2("AAA"));
            Assert.ThrowsException<ArgumentException>(() => coupling.Load(new Milk(111, 111, "sss", new TemperatureRule(-10, 10), MilkTaste.Cow)));
        }

        [TestMethod()]
        public void LoadSuccesfullTest()
        {
            var coupling = new Coupling(new Refrigerator(100, 100, new TemperatureRule(-100, 100), 20), new ActrosMP2("AAA"));
            coupling.Load(new Milk(11, 11, "sss", new TemperatureRule(-10, 10), MilkTaste.Cow));
            Assert.AreEqual(1, coupling.Products.Count);
        }

        [TestMethod()]
        public void UnloadTest()
        {
            var coupling = new Coupling(new Refrigerator(100, 100, new TemperatureRule(-100, 100), 20), new ActrosMP2("AAA"));
            var milk = new Milk(11, 11, "sss", new TemperatureRule(-10, 10), MilkTaste.Cow);
            coupling.Load(milk);
            coupling.Unload(milk);
            Assert.AreEqual(0, coupling.Products.Count);
        }

        [TestMethod()]
        public void UnloadAllTest()
        {
            var coupling = new Coupling(new Refrigerator(100, 100, new TemperatureRule(-100, 100), 20), new ActrosMP2("AAA"));
            var milk1 = new Milk(11, 11, "sss", new TemperatureRule(-10, 10), MilkTaste.Cow);
            var milk2 = new Milk(11, 11, "sss", new TemperatureRule(-10, 10), MilkTaste.Cow);
            var milk3 = new Milk(11, 11, "sss", new TemperatureRule(-10, 10), MilkTaste.Cow);
            var milk4 = new Milk(11, 11, "sss", new TemperatureRule(-10, 10), MilkTaste.Cow);
            coupling.Load(milk1);
            coupling.Load(milk2);
            coupling.Load(milk3);
            coupling.Load(milk4);
            coupling.UnloadAll();

            Assert.AreEqual(0, coupling.Products.Count);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var coupling1 = new Coupling(new Refrigerator(100, 100, new TemperatureRule(-100, 100), 20), new ActrosMP2("AAA"));
            var coupling2 = new Coupling(new Refrigerator(100, 100, new TemperatureRule(-100, 100), 20), new ActrosMP2("AAA"));
            var milk1 = new Milk(11, 11, "sss", new TemperatureRule(-10, 10), MilkTaste.Cow);
            var milk2 = new Milk(11, 11, "sss", new TemperatureRule(-10, 10), MilkTaste.Cow);
            coupling1.Load(milk1);
            coupling2.Load(milk2);

            Assert.AreEqual(coupling1, coupling2);
        }
    }
}