using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TransportEnterprise.Core;
using TransportEnterprise.Models;

namespace TransportEnterprise.XmlParser.Tests
{
    [TestClass()]
    public class XmlParserTests
    {
        [TestMethod()]
        public void XmlParserTest()
        {
            var milk = new Milk(10, "AAAAAAA");
            var path = new XmlTestsFilePathesGetter(milk.GetType()).GetFilePath();
            var xmlParser = new XmlParser<Milk>(path);
            xmlParser.Serialize(milk);
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            var path = new XmlTestsFilePathesGetter(typeof(Milk)).GetFilePath();
            var xmlParser = new XmlParser<Milk>(path);
            var collection = xmlParser.DeserializeAll();
            Assert.IsTrue(collection.Count == 1);
        }

        [TestMethod()]
        public void SerializeMethylamineTest()
        {
            var meth = new Methylamine(10, new List<ChemistryDanger>() { ChemistryDanger.Explosive, ChemistryDanger.Toxic });
            var path = new XmlTestsFilePathesGetter(meth.GetType()).GetFilePath();
            var xmlParser = new XmlParser<Methylamine>(path);
            xmlParser.Serialize(meth);
        }
    }
}