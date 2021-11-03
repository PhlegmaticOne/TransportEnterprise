using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class RefrigeratorTests
    {
        private readonly Refrigerator _refrigerator;

        public RefrigeratorTests()
        {
            _refrigerator = new Refrigerator(300, 300, new TemperatureRule(-100, 100), 30);
        }
        [TestMethod]
        public void LoadUnsuccessfulBecauseOfProductIsNotITemperatureDependentTest()
        {
            var cocaCole = new CocaCola(10, 10, "SSS", CocaColaTaste.ClassicWithSugar);
            Assert.ThrowsException<ArgumentException>(() => _refrigerator.Load(cocaCole));
        }
        [TestMethod]
        public void LoadUnsuccessfulBecauseOfProductIsNullTest()
        {
            var cocaCole = new CocaCola(301, 10, "SSS", CocaColaTaste.ClassicWithSugar);
            cocaCole = null;
            Assert.ThrowsException<ArgumentException>(() => _refrigerator.Load(cocaCole));
        }
        [TestMethod]
        public void LoadUnsuccessfulBecauseOfOverloadingSemitrailerWithMassTest()
        {
            var cocaCole = new CocaCola(301, 10, "SSS", CocaColaTaste.ClassicWithSugar);
            Assert.ThrowsException<ArgumentException>(() => _refrigerator.Load(cocaCole));
        }
        [TestMethod]
        public void LoadUnsuccessfulBecauseOfOverloadingSemitrailerWithValueTest()
        {
            var cocaCole = new CocaCola(31, 310, "SSS", CocaColaTaste.ClassicWithSugar);
            Assert.ThrowsException<ArgumentException>(() => _refrigerator.Load(cocaCole));
        }
        [TestMethod]
        public void LoadUnsuccessfulBecauseOfNotFittedTemperatureProductRuleTest()
        {
            var milk = new Milk(10, 8, "Milky", new TemperatureRule(-110, 10), MilkTaste.Chocolate);
            Assert.ThrowsException<ArgumentException>(() => _refrigerator.Load(milk));
        }
        [TestMethod]
        public void LoadUnsuccessfulBecauseOfNotFittedTemperatureProductRuleTest1()
        {
            var milk = new Milk(10, 8, "Milky", new TemperatureRule(-10, 110), MilkTaste.Chocolate);
            Assert.ThrowsException<ArgumentException>(() => _refrigerator.Load(milk));
        }
        [TestMethod]
        public void LoadSuccessfulTest()
        {
            Array.ForEach(GetFittedMilks().ToArray(), milk => _refrigerator.Load(milk));
            Assert.AreEqual(150, _refrigerator.CurrentLoading);
            Assert.AreEqual(133, _refrigerator.CurrentLoadedValue);
            Assert.AreEqual(5, _refrigerator.Products.Count);
            Assert.IsTrue(_refrigerator.Products.All(p => p.GetType() == typeof(Milk)));
        }
        private static List<Milk> GetFittedMilks() => new()
        {
            new Milk(10, 8, "Milky", new TemperatureRule(-100, 100), MilkTaste.Chocolate),
            new Milk(20, 82, "Milky", new TemperatureRule(-10, 10), MilkTaste.Cow),
            new Milk(30, 22, "Milky", new TemperatureRule(-10, 10), MilkTaste.Soy),
            new Milk(40, 11, "Milky", new TemperatureRule(-10, 10), MilkTaste.Chocolate),
            new Milk(50, 10, "Milky", new TemperatureRule(-10, 10), MilkTaste.Cow),
        };

        [TestMethod()]
        public void UnloadTest()
        {
            var milks = GetFittedMilks();
            Array.ForEach(milks.ToArray(), milk => _refrigerator.Load(milk));

            _refrigerator.Unload(milks[0]);
            _refrigerator.Unload(milks[1]);

            Assert.IsTrue(_refrigerator.Products.Count == 3);
        }

        [TestMethod()]
        public void UnloadAllTest()
        {
            var milks = GetFittedMilks();
            Array.ForEach(milks.ToArray(), milk => _refrigerator.Load(milk));
            _refrigerator.UnloadAll();

            Assert.IsTrue(_refrigerator.Products.Count == 0);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var refr2 = new Refrigerator(300, 300, new TemperatureRule(-100, 100), 30);
            var refr3 = new Refrigerator(300, 300, new TemperatureRule(-10, 10), 30);

            Assert.AreEqual(_refrigerator, refr2);
            Assert.AreNotEqual(_refrigerator, refr3);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Refrigerator. Max load capacity: 300,0000. Current loading: 0,0000. Noise: 30 dB. Temperature rule: [-100,00; 100,00]",
                _refrigerator.ToString());
        }
    }
}