using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransportEnterprise.Core;
using TransportEnterprise.XmlParser;

namespace TransportEnterprise.Models.Factories.Tests
{
    [TestClass()]
    public class MethilamineFactoryTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            var path = new XmlTestsFilePathesGetter(typeof(Methylamine)).GetFilePath();
            var xmlParser = new XmlChemistryParser(path, new MethilamineFactory());
            var meths = xmlParser.DeserializeAll();
            Assert.IsTrue(meths.Count == 1);
        }
    }
}