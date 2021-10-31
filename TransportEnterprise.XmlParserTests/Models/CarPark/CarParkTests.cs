using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransportEnterprise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportEnterprise.Core;
using TransportEnterprise.XmlParser.Serializers;
using TransportEnterprise.Models.Factories.AbstractXmlFactories;
using TransportEnterprise.XmlParser.Deserializers;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class CarParkTests
    {
        [TestMethod()]
        public void CarParkSerializeTest()
        {
            var semitrailers = new List<Semitrailer>() { GetTankTruck(), GetRefrigerator() };
            var tractors = new List<TruckTractor>() { new ActrosMP2(semitrailers[0]), new ActrosMP3() };

            var carPark = new CarPark(semitrailers, tractors);

            var path = new XmlTestsFilePathesGetter(carPark.GetType()).GetFilePath();
            var serializer = new XMLStreamWriterSerializer<CarPark>(path);

            serializer.Serialize(carPark);
        }

        [TestMethod()]
        public void CarParkDeserializeTest()
        {
            var path = new XmlTestsFilePathesGetter(typeof(CarPark)).GetFilePath();
            var factory = new XmlAbstractDomainFactoriesFactory();
            var deserializer = new XMLStreamReaderDeserializer<CarPark>(path, factory);

            var all = deserializer.All();

            Assert.IsTrue(all.Count == 1);
            Assert.IsInstanceOfType(all.First(), typeof(CarPark));
        }

        private TankTruck GetTankTruck()
        {
            var cd = new List<ChemistryDanger>() { ChemistryDanger.Flammable, ChemistryDanger.Explosive, ChemistryDanger.Toxic };
            var petrol1 = new PetrolA92(10, cd, "Little");
            var petrol2 = new PetrolA92(20, cd, "More");
            var petrol3 = new PetrolA92(30, cd, "More");
            var petrol4 = new PetrolA92(40, cd, "The most");

            var tank = new TankTruck(200);
            tank.Load(petrol1);
            tank.Load(petrol2);
            tank.Load(petrol3);
            tank.Load(petrol4);
            return tank;
        }
        private Refrigerator GetRefrigerator()
        {
            var refrigerator = new Refrigerator(500, new TemperatureRule(-100, 0), 50);
            var cocaCola = new CocaCola(100, "Very tasteful", CocaColaTaste.Orange);
            refrigerator.Load(cocaCola);
            return refrigerator;
        }
    }
}