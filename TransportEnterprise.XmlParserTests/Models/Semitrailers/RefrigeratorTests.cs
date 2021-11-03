using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TransportEnterprise.Core;
using TransportEnterprise.XmlParser.Serializers;
using TransportEnterprise.XmlParser.Deserializers;
using TransportEnterprise.Models.Factories.AbstractXmlFactories;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class RefrigeratorTests
    {
        [TestMethod()]
        public void RefrigeratorSerializeTest()
        {
            var refrigerator = new Refrigerator(500, 500, new TemperatureRule(-100, 0), 50);
            var milk = new Milk(100, 2, "Very tasteful", new TemperatureRule(-10, -2), MilkTaste.Cow);
            refrigerator.Load(milk);

            var path = new XmlTestsFilePathesGetter(refrigerator.GetType()).GetFilePath();
            var serializer = new XMLStreamWriterSerializer<Refrigerator>(path);

            serializer.Serialize(refrigerator);
        }

        [TestMethod()]
        public void RefrigeratorDeserializeTest()
        {
            var path = new XmlTestsFilePathesGetter(typeof(Refrigerator)).GetFilePath();
            var factory = new XmlAbstractDomainFactoriesFactory();
            var deserializer = new XMLStreamReaderDeserializer<Semitrailer>(path, factory);
            var semitrailers = deserializer.All();

            Assert.IsTrue(semitrailers.Count == 1);
            Assert.IsInstanceOfType(semitrailers.ElementAt(0), typeof(Semitrailer));
            Assert.IsInstanceOfType(semitrailers.ElementAt(0).Products.ElementAt(0), typeof(Milk));
            Assert.IsTrue((semitrailers.ElementAt(0).Products.ElementAt(0) as Milk).MilkTaste == MilkTaste.Cow);
        }
    }
}