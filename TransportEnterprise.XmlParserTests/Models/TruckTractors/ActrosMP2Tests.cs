using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TransportEnterprise.Models.Factories;
using TransportEnterprise.XmlParser.Deserializers;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class ActrosMP2Tests
    {
        [TestMethod()]
        public void ActrosMP2SerializeTest()
        {
            var cd = new List<ChemistryDanger>() { ChemistryDanger.Flammable, ChemistryDanger.Explosive, ChemistryDanger.Toxic };
            var petrol1 = new PetrolA92(10, 2, cd, "Little");
            var petrol2 = new PetrolA92(20, 2, cd, "More");
            var petrol3 = new PetrolA92(30, 2, cd, "More");
            var petrol4 = new PetrolA92(40, 2, cd, "The most");

            var tank = new TankTruck(200, 200);
            tank.Load(petrol1);
            tank.Load(petrol2);
            tank.Load(petrol3);
            tank.Load(petrol4);

            var actrosmp2 = new ActrosMP2(tank, null);

            var path = new TransportEnterprise.Core.XmlTestsFilePathesGetter(actrosmp2.GetType()).GetFilePath();
            var serializer = new XmlParser.Serializers.XMLStreamWriterSerializer<ActrosMP2>(path);

            serializer.Serialize(actrosmp2);
        }

        [TestMethod()]
        public void ActrosMP2DeserializeTest()
        {
            var path = new TransportEnterprise.Core.XmlTestsFilePathesGetter(typeof(ActrosMP2)).GetFilePath();

            #region Init
            var temperarureXmlFactory = new TemperatureRuleXmlFactory();
            var customerGoodsFactory = new CustomerGoodsAbstractXmlFactory(temperarureXmlFactory);
            var petrolFactory = new PetrolXmlAbstractFactory();
            var chemistryFactory = new ChemistryXmlAbstractFactory(petrolFactory, temperarureXmlFactory);
            var productFactory = new ProductsXmlAbstractFactory(chemistryFactory, customerGoodsFactory);
            var semitrailersFactory = new SemitrailersXmlAbstractFactory(productFactory, temperarureXmlFactory);
            #endregion
            var factory = new TruckTractorsXmlAbstractFactory(semitrailersFactory);

            var deserializer = new XMLStreamReaderDeserializer<ActrosMP2, TruckTractor>(path, factory);

            var all = deserializer.All();

            Assert.IsTrue(all.Count == 1);
        }
    }
}