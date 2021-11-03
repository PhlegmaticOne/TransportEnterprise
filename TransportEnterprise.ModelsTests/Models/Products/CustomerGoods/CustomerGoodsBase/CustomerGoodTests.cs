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
    public class CustomerGoodTests
    {
        [TestMethod()]
        public void EqualsWithOtherObjectTest()
        {
            CustomerGood product1 = new Milk(100, 100, "Very milky", new TemperatureRule(-10, 10), MilkTaste.Cow);
            object product2 = new Milk(100, 100, "Very milky", new TemperatureRule(-10, 10), MilkTaste.Cow);
            object product3 = new Milk(110, 100, "Very milky", new TemperatureRule(-20, 1), MilkTaste.Chocolate);

            Assert.AreEqual(product1, product2);
            Assert.AreNotEqual(product2, product3);
        }

        [TestMethod()]
        public void EqualsWithOtherCustomerGoodTest()
        {
            CustomerGood product1 = new CocaCola(100, 100, "Very colacoley", CocaColaTaste.ClassicWithSugar);
            CustomerGood product2 = new CocaCola(100, 100, "Very colacoley", CocaColaTaste.ClassicWithSugar);
            CustomerGood product3 = new CocaCola(110, 100, "Very colacoley", CocaColaTaste.Lemon);

            Assert.AreEqual(product1, product2);
            Assert.AreNotEqual(product2, product3);
        }
    }
}