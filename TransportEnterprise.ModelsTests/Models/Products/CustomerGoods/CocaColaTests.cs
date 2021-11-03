using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class CocaColaTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var cocaCola =  new CocaCola(100, 100, "Very colacoley", CocaColaTaste.ClassicWithSugar);
            Assert.AreEqual("ClassicWithSugar. CocaCola. Very colacoley. Weight: 100,0000", cocaCola.ToString());
        }
    }
}