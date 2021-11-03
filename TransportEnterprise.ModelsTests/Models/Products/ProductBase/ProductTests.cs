using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void EqualsWithObjectTest()
        {
            Product product1 = new Milk(20, 2, "Very delicious", new TemperatureRule(-10, 0), MilkTaste.Chocolate);
            object product2 = new Milk(20, 2, "Very delicious", new TemperatureRule(-10, 0), MilkTaste.Chocolate);
            object product3 = new Methylamine(100, 100, new List<ChemistryDanger>() { ChemistryDanger.Flammable },
                                new TemperatureRule(-90, 10), "Very dangerous");
            Assert.AreEqual(product1, product2);
            Assert.AreNotEqual(product1, product3);
        }

        [TestMethod()]
        public void EqualsWithAnotherProductTest()
        {
            Product product1 = new Milk(20, 2, "Very delicious", new TemperatureRule(-10, 0), MilkTaste.Chocolate);
            Product product2 = new Milk(20, 2, "Very delicious", new TemperatureRule(-10, 0), MilkTaste.Chocolate);
            Product product3 = new Milk(21, 2, "Very delicious", new TemperatureRule(-10, 0), MilkTaste.Chocolate);

            Assert.AreEqual(product1, product2);
            Assert.AreNotEqual(product1, product3);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Product product = new Methylamine(100, 100, new List<ChemistryDanger>() { ChemistryDanger.Flammable },
                                new TemperatureRule(-90, 10), "Very dangerous");
            Assert.AreEqual("Flammable. Methylamine. Very dangerous. Weight: 100,0000", product.ToString());
        }
    }
}