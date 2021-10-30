using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TransportEnterprise.Core;
using TransportEnterprise.XmlParser.Serializers;
using TransportEnterprise.XmlParser.Deserializers;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class MethylamineTests
    {
        [TestMethod()]
        public void MethylamineSerializeTest()
        {
            var meth = new Methylamine(10, new List<ChemistryDanger>() { ChemistryDanger.Flammable, ChemistryDanger.Toxic });
            var path = new XmlTestsFilePathesGetter(meth.GetType()).GetFilePath();
            var serializer = new XMLXmlWriterSerializer<Methylamine>(path);
            serializer.Serialize(meth);
        }

        [TestMethod()]
        public void MethylamineDeserializeTest()
        {
            var path = new XmlTestsFilePathesGetter(typeof(Methylamine)).GetFilePath();
            var deserializer = new XMLXmlReaderDeserializer<Product>(path);
            var entity = deserializer.Where(m => m.Weight == 10);
            var carPark = new CarPark();
        }
    }
}