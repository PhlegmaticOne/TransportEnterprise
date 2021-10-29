using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransportEnterprise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportEnterprise.Core;
using TransportEnterprise.XmlParser.Serializers;
using TransportEnterprise.XmlParser.Deserializers.Xml;
using TransportEnterprise.Models.Factories;

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
            var deserializer = new XMLXmlReaderDeserializer<Methylamine>(path, new MethylamineFactory());
            var entity = deserializer.Where(m => m.Weight == 10);
        }
    }
}