using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TransportEnterprise.Core;
using TransportEnterprise.Models;
using TransportEnterprise.Models.Factories;
using TransportEnterprise.XmlParser.Deserializers;
using TransportEnterprise.XmlParser.Serializers;

namespace TransportEnterprise.XmlParserTests
{
    [TestClass]
    public class CarParkTests
    {
        private static List<Semitrailer> GetSemitrailers() => new()
        {
            new Refrigerator(300, 300, new TemperatureRule(-100, 100), 30),
            new Refrigerator(300, 300, new TemperatureRule(-10, 10), 30),
            new TankTruck(500, 200),
            new TiltSemitrailer(1000, 1000),
        };
        private static List<TruckTractor> GetTrcuckTractors() => new()
        {
            new ActrosMP2("S8D8D3"),
            new ActrosMP2("S8D8D4"),
            new ActrosMP3("S9D8D4"),
            new ActrosMP3("S9D8D4"),
        };

        [TestMethod()]
        public void CarParkSerializeTest()
        {
            var carPark = new CarPark(GetSemitrailers(), GetTrcuckTractors());
            var milk = new Milk(100, 2, "Very tasteful", new TemperatureRule(-10, -2), MilkTaste.Cow);
            carPark.Semitrailers.ElementAt(0).Load(milk);
            carPark.Semitrailers.ElementAt(1).Load(milk);

            var path = new XmlTestsFilePathesGetter(carPark.GetType()).GetFilePath();
            var serializer = new XMLStreamWriterSerializer<CarPark>(path);


            serializer.Serialize(carPark);
        }

        [TestMethod()]
        public void CarParkDeserializeTest()
        {
            #region Init
            var temperarureXmlFactory = new TemperatureRuleXmlFactory();
            var customerGoodsFactory = new CustomerGoodsAbstractXmlFactory(temperarureXmlFactory);
            var petrolFactory = new PetrolXmlAbstractFactory();
            var chemistryFactory = new ChemistryXmlAbstractFactory(petrolFactory, temperarureXmlFactory);
            var productFactory = new ProductsXmlAbstractFactory(chemistryFactory, customerGoodsFactory);
            var semitrailersFactory = new SemitrailersXmlAbstractFactory(productFactory, temperarureXmlFactory);
            var truckTractorsFactory = new TruckTractorsXmlAbstractFactory(semitrailersFactory);
            #endregion

            var factory = new CarParksXmlAbstractFactory(semitrailersFactory, truckTractorsFactory);

            var path = new XmlTestsFilePathesGetter(typeof(CarPark)).GetFilePath();
            var deserializer = new XMLStreamReaderDeserializer<CarPark, CarPark>(path, factory);


            var carPark = deserializer.All();

            Assert.AreEqual(1, carPark.Count);
            Assert.IsInstanceOfType(carPark.First(), typeof(CarPark));
            Assert.AreEqual(4, carPark.First().Semitrailers.Count);
            Assert.AreEqual(4, carPark.First().TruckTractors.Count);
        }
    }
}
