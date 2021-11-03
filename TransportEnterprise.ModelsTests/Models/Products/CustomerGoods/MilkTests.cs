using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class MilkTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var milk = new Milk(100, 100, "Very milky", new TemperatureRule(-10, 10), MilkTaste.Cow);
            Assert.AreEqual("Cow. Milk. Very milky. Weight: 100,0000", milk.ToString());
        }
    }
}