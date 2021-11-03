using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class TemperatureRuleTests
    {
        [TestMethod()]
        public void IsInTheRangeTest()
        {
            var temp1 = new TemperatureRule(-10, 20);
            var temp2 = new TemperatureRule(-20, 30);
            var temp3 = new TemperatureRule(-9.9, 19.9);

            Assert.IsTrue(temp1.IsInTheRange(temp2));
            Assert.IsFalse(temp1.IsInTheRange(temp3));
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var temp1 = new TemperatureRule(-10, 20);
            var temp2 = new TemperatureRule(-10, 20);
            var temp3 = new TemperatureRule(-9.9, 19.9);

            Assert.AreEqual(temp1, temp2);
            Assert.AreNotEqual(temp1, temp3);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var temp1 = new TemperatureRule(-10, 20);
            Assert.AreEqual("[-10,00; 20,00]", temp1.ToString());
        }
    }
}