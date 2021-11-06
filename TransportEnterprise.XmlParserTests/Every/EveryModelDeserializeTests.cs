using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TransportEnterprise.Core;
using TransportEnterprise.Models;
using TransportEnterprise.Models.Factories;
using TransportEnterprise.XmlParser.Deserializers;

namespace TransportEnterprise.XmlParserTests.Every
{
    [TestClass]
    public class EveryModelDeserializeTests
    {
        private static TemperatureRuleXmlFactory _temperarureXmlFactory;
        private static PetrolXmlAbstractFactory _petrolFactory;
        private static ChemistryXmlAbstractFactory _chemistryFactory;
        private static CustomerGoodsAbstractXmlFactory _customerGoodsFactory;
        private static MaterialAbstractXmlFactory _materialsFactory;
        private static FurnitureAbstractXmlFactory _furnitureFactory;
        private static SemitrailersWithContainerShipXmlAbstractFactory _semitrailersFactory;
        private static TruckTractorsXmlAbstractFactory _truckTractorsFactory;
        private static ProductsWithFurnitureXmlAbstractFactory _productFactory;
        private static CarParksXmlAbstractFactory _carParkFactory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _temperarureXmlFactory = new TemperatureRuleXmlFactory();
            _petrolFactory = new PetrolXmlAbstractFactory();
            _chemistryFactory = new ChemistryXmlAbstractFactory(_petrolFactory, _temperarureXmlFactory);
            _customerGoodsFactory = new CustomerGoodsAbstractXmlFactory(_temperarureXmlFactory);
            _materialsFactory = new MaterialAbstractXmlFactory();
            _furnitureFactory = new FurnitureAbstractXmlFactory(_materialsFactory);
            _productFactory = new ProductsWithFurnitureXmlAbstractFactory(_chemistryFactory, _customerGoodsFactory, _furnitureFactory);
            _semitrailersFactory = new SemitrailersWithContainerShipXmlAbstractFactory(_productFactory, _temperarureXmlFactory);
            _truckTractorsFactory = new TruckTractorsXmlAbstractFactory(_semitrailersFactory);
            _carParkFactory = new CarParksXmlAbstractFactory(_semitrailersFactory, _truckTractorsFactory);
        }

        [TestMethod]
        public void DeserializePetrolsTest()
        {
            DeserializePetrols<Diesel>();
            DeserializePetrols<PetrolA92>();
            DeserializePetrols<PetrolA95>();
            DeserializePetrols<PetrolA98>();
        }
        public static void DeserializePetrols<T>() where T: Petrol
        {
            var path = new XmlTestsFilePathesGetter(typeof(T)).GetFilePath();
            var deserializer = new XMLStreamReaderDeserializer<T, Petrol>(path, _petrolFactory);
            var result = deserializer.All();
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(product => product is T));
        }

        [TestMethod]
        public void DeserializeChemistryTest()
        {
            DeserializeChemistry<Carbon>();
            DeserializeChemistry<Methylamine>();
        }
        public static void DeserializeChemistry<T>() where T : Chemistry
        {
            var path = new XmlTestsFilePathesGetter(typeof(T)).GetFilePath();
            var deserializer = new XMLStreamReaderDeserializer<T, Chemistry>(path, _chemistryFactory);
            var result = deserializer.All();
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(product => product is T));
        }

        [TestMethod]
        public void DeserializeCustomerGoodsTest()
        {
            DeserializeCustomerGoods<CocaCola>();
            DeserializeCustomerGoods<Milk>();
            DeserializeCustomerGoods<Sausage>();
        }
        public static void DeserializeCustomerGoods<T>() where T : CustomerGood
        {
            var path = new XmlTestsFilePathesGetter(typeof(T)).GetFilePath();
            var deserializer = new XMLStreamReaderDeserializer<T, CustomerGood>(path, _customerGoodsFactory);
            var result = deserializer.All();
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(product => product is T));
        }

        [TestMethod]
        public void DeserializeFurnitureTest()
        {
            DeserializeFurnitures<Carpet>();
            DeserializeFurnitures<Wardrobe>();
        }
        public static void DeserializeFurnitures<T>() where T : Furniture
        {
            var path = new XmlTestsFilePathesGetter(typeof(T)).GetFilePath();
            var deserializer = new XMLStreamReaderDeserializer<T, Furniture>(path, _furnitureFactory);
            var result = deserializer.All();
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(product => product is T));
        }

        [TestMethod]
        public void DeserializeSemitrailersTest()
        {
            DeserializeSemitrailers<Refrigerator>();
            DeserializeSemitrailers<TankTruck>();
            DeserializeSemitrailers<ContainerShip>();
            DeserializeSemitrailers<TiltSemitrailer>();
        }
        public static void DeserializeSemitrailers<T>() where T : Semitrailer
        {
            var path = new XmlTestsFilePathesGetter(typeof(T)).GetFilePath();
            var deserializer = new XMLStreamReaderDeserializer<T, Semitrailer>(path, _semitrailersFactory);
            var result = deserializer.All();
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(product => product is T));
        }

        [TestMethod]
        public void DeserializeTruckTractorsTest()
        {
            DeserializeTruckTractors<ActrosMP2>();
            DeserializeTruckTractors<ActrosMP3>();
        }
        public static void DeserializeTruckTractors<T>() where T : TruckTractor
        {
            var path = new XmlTestsFilePathesGetter(typeof(T)).GetFilePath();
            var deserializer = new XMLStreamReaderDeserializer<T, TruckTractor>(path, _truckTractorsFactory);
            var result = deserializer.All();
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(product => product is T));
        }

        [TestMethod]
        public void DeserializeCarParkTest()
        {
            var path = new XmlTestsFilePathesGetter(typeof(CarPark)).GetFilePath();
            var deserializer = new XMLStreamReaderDeserializer<CarPark, CarPark>(path, _carParkFactory);
            var result = deserializer.All();
            Assert.AreEqual(1, result.Count);

            var carPark = result.First();
            Assert.AreEqual(12, carPark.Semitrailers.Count);
            Assert.AreEqual(4, carPark.TruckTractors.Count);
        }
    }
}
