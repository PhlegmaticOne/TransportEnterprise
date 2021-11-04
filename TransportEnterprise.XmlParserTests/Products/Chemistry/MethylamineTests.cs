using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TransportEnterprise.Core;
using TransportEnterprise.XmlParser.Serializers;
using TransportEnterprise.XmlParser.Deserializers;
using TransportEnterprise.Models.Factories;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class MethylamineTests
    {
        [TestMethod()]
        public void MethylamineSerializeTest()
        {
            var meth = new Methylamine(10, 2, new List<ChemistryDanger>() { ChemistryDanger.Flammable, ChemistryDanger.Toxic }, null);
            var path = new XmlTestsFilePathesGetter(meth.GetType()).GetFilePath();
            var serializer = new XMLXmlWriterSerializer<Methylamine>(path);
            serializer.Serialize(meth);
        }

        [TestMethod()]
        public void MethylamineDeserializeTest()
        {
            var path = new XmlTestsFilePathesGetter(typeof(Methylamine)).GetFilePath();
            var petrolFactory = new PetrolXmlAbstractFactory();
            var temperatureFactory = new TemperatureRuleXmlFactory();
            var chemistryFactory = new ChemistryXmlAbstractFactory(petrolFactory, temperatureFactory);
            var deserializer = new XMLXmlReaderDeserializer<Methylamine, Chemistry>(path, chemistryFactory);
            var entity = deserializer.Where(m => m.Weight == 10);
            Assert.IsTrue(entity.Count == 1);
        }
    }
}