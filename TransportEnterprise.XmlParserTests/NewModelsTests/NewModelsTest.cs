using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Linq;
using TransportEnterprise.Core;
using TransportEnterprise.Models;
using TransportEnterprise.Models.Factories;
using TransportEnterprise.XmlParser.Deserializers;
using TransportEnterprise.XmlParser.Serializers;

namespace TransportEnterprise.XmlParserTests.NewModelsTests
{
    [TestClass]
    public class NewModelsTest
    {
        [TestMethod()]
        public void NewModelsSerializeTest()
        {
            var containerShip = new ContainerShip(10000, 1000);
            var wood = new Wood(40, Color.Brown, WoodType.Oak);
            var textile = new Textile(50, Color.Pink, TextileType.Wool);
            var wardrobe = new Wardrobe(300, 200, "Very big", wood, FurniturePurpose.Hall);
            var carpet = new Carpet(100, 50, "Very warm", textile, FurniturePurpose.Bedroom);

            containerShip.Load(carpet);
            containerShip.Load(wardrobe);

            var path = new XmlTestsFilePathesGetter(containerShip.GetType()).GetFilePath() + "New";
            var serializer = new XMLStreamWriterSerializer<ContainerShip>(path);

            serializer.Serialize(containerShip);
        }

        [TestMethod()]
        public void NewModelsDeserializeTest()
        {
            var path = new XmlTestsFilePathesGetter(typeof(ContainerShip)).GetFilePath() + "New";

            var temperarureXmlFactory = new TemperatureRuleXmlFactory();

            var petrolFactory = new PetrolXmlAbstractFactory();
            var chemistryFactory = new ChemistryXmlAbstractFactory(petrolFactory, temperarureXmlFactory);

            var customerGoodsFactory = new CustomerGoodsAbstractXmlFactory(temperarureXmlFactory);

            var materialsFactory = new MaterialAbstractXmlFactory();
            var furnitureFactory = new FurnitureAbstractXmlFactory(materialsFactory);

            var productFactory = new ProductsWithFurnitureXmlAbstractFactory(chemistryFactory, customerGoodsFactory, furnitureFactory);

            var factory = new SemitrailersWithContainerShipXmlAbstractFactory(productFactory, temperarureXmlFactory);
            var deserializer = new XMLStreamReaderDeserializer<ContainerShip, Semitrailer>(path, factory);
            var semitrailers = deserializer.All();

            Assert.IsTrue(semitrailers.Count == 1);
            Assert.IsInstanceOfType(semitrailers.ElementAt(0), typeof(ContainerShip));
        }
    }
}
