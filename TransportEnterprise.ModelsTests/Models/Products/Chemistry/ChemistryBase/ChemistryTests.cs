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
    public class ChemistryTests
    {
        [TestMethod()]
        public void EqualsWithObjectTest()
        {
            Chemistry product1 = new Methylamine(100, 100, new List<ChemistryDanger>() { ChemistryDanger.Flammable },
                                new TemperatureRule(-90, 10), "Very dangerous");
            object product2 = new Methylamine(100, 100, new List<ChemistryDanger>() { ChemistryDanger.Flammable },
                                new TemperatureRule(-90, 10), "Very dangerous");
            object product3 = new Methylamine(110, 100, new List<ChemistryDanger>() { ChemistryDanger.Flammable },
                                new TemperatureRule(-90, 10), "Very dangerous");

            Assert.AreEqual(product1, product2);
            Assert.AreNotEqual(product2, product3);
        }

        [TestMethod()]
        public void EqualsWithOtherChemistryTest()
        {
            Chemistry product1 = new Methylamine(100, 100, new List<ChemistryDanger>() { ChemistryDanger.Flammable },
                                new TemperatureRule(-90, 10), "Very dangerous");
            Chemistry product2 = new PetrolA92(110, 100, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, "Very dangerous");
            Chemistry product3 = new PetrolA92(110, 100, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, "Very dangerous");

            Assert.AreEqual(product2, product3);
            Assert.AreNotEqual(product1, product2);
        }
        [TestMethod()]
        public void ToStringTest()
        {
            Chemistry product = new PetrolA92(110, 100, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, "Very dangerous");
            Assert.AreEqual("Flammable. PetrolA92. Very dangerous. Weight: 110,0000", product.ToString());
        }
    }
}