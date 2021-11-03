using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransportEnterprise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class TiltSemitrailerTests
    {
        private readonly TiltSemitrailer _tiltSemitrailer;
        public TiltSemitrailerTests()
        {
            _tiltSemitrailer = new TiltSemitrailer(1000, 1000);
        }
        [TestMethod()]
        public void LoadTest()
        {
            Array.ForEach(GetProducts().ToArray(), p => _tiltSemitrailer.Load(p));
            Assert.IsTrue(_tiltSemitrailer.Products.Count == 8);
        }

        private static List<Product> GetProducts() => new()
        {
            new Milk(10, 8, "Milky", new TemperatureRule(-100, 100), MilkTaste.Chocolate),
            new Milk(20, 82, "Milky", new TemperatureRule(-10, 10), MilkTaste.Cow),
            new Milk(30, 22, "Milky", new TemperatureRule(-10, 10), MilkTaste.Soy),
            new Milk(40, 11, "Milky", new TemperatureRule(-10, 10), MilkTaste.Chocolate),
            new Milk(50, 10, "Milky", new TemperatureRule(-10, 10), MilkTaste.Cow),
            new CocaCola(10, 10, "Cola", CocaColaTaste.ClassicWithSugar),
            new PetrolA92(10, 10, new List<ChemistryDanger>(){ ChemistryDanger.Flammable}, "Petrol"),
            new PetrolA92(10, 10, new List<ChemistryDanger>(){ ChemistryDanger.Flammable}, "Petrol")
        };

        [TestMethod()]
        public void GetProductsByTypeTest()
        {
            Array.ForEach(GetProducts().ToArray(), p => _tiltSemitrailer.Load(p));

            var milks = _tiltSemitrailer.GetProductsByType(typeof(Milk));
            var colas = _tiltSemitrailer.GetProductsByType(typeof(CocaCola));
            var petrols = _tiltSemitrailer.GetProductsByType(typeof(PetrolA92));

            Assert.AreEqual(5, milks.Count);
            Assert.IsTrue(milks.All(m => m.GetType() == typeof(Milk)));
            Assert.AreEqual(1, colas.Count);
            Assert.IsTrue(colas.All(m => m.GetType() == typeof(CocaCola)));
            Assert.AreEqual(2, petrols.Count);
            Assert.IsTrue(petrols.All(m => m.GetType() == typeof(PetrolA92)));
        }
    }
}