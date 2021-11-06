using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TransportEnterprise.Core;
using TransportEnterprise.Models;
using TransportEnterprise.XmlParser.Serializers;

namespace TransportEnterprise.XmlParserTests.Every
{
    [TestClass]
    public class EveryModelSerializeTests
    {
        [TestMethod]
        public void SerializeAllProductsTest()
        {
            var dangers = new List<ChemistryDanger>() { ChemistryDanger.Flammable, ChemistryDanger.Explosive, ChemistryDanger.Toxic };
            Serialize(GetDiesels(dangers));
            Serialize(GetPetrolA92s(dangers));
            Serialize(GetPetrolA95s(dangers));
            Serialize(GetPetrolA98s(dangers));
            Serialize(GetMethylamines(dangers));
            Serialize(GetCarbons());
            Serialize(GetCocaColas());
            Serialize(GetMilks());
            Serialize(GetSausages());
            Serialize(GetWardrobes());
            Serialize(GetCarpets());
        }
        [TestMethod]
        public void SerializeAllSemitrailersTest()
        {
            Serialize(GetRefrigerators());
            Serialize(GetContainerShips());
            Serialize(GetTankTrucks());
            Serialize(GetTiltSemitrailers());
        }
        [TestMethod]
        public void SerializeAllTrackTractorsTest()
        {
            Serialize(GetActrosMP2s());
            Serialize(GetActrosMP3s());
        }
        [TestMethod]
        public void SerializeCarParkTest()
        {
            List<Semitrailer> semitrailers = new();
            semitrailers.AddRange(GetRefrigerators());
            semitrailers.AddRange(GetTankTrucks());
            semitrailers.AddRange(GetTiltSemitrailers());
            semitrailers.AddRange(GetContainerShips());

            List<TruckTractor> tankTrucks = new();
            tankTrucks.AddRange(GetActrosMP2s());
            tankTrucks.AddRange(GetActrosMP3s());

            Serialize(new List<CarPark>() { new CarPark(semitrailers, tankTrucks) });
        }


        public static void Serialize<TEntity>(IEnumerable<TEntity> entities) where TEntity: class
        {
            var path = new XmlTestsFilePathesGetter(typeof(TEntity)).GetFilePath();
            var serializer = new XMLStreamWriterSerializer<TEntity>(path);
            serializer.SerializeCollection(entities);
        }




        private static List<Diesel> GetDiesels(List<ChemistryDanger> dangers) => new()
        {
            new Diesel(10, 30, dangers, "Diesel"),
            new Diesel(100, 20, dangers, "More diesel")
        };
        private static List<PetrolA92> GetPetrolA92s(List<ChemistryDanger> dangers) => new()
        {
            new PetrolA92(10, 30, dangers, "Petrol A92"),
            new PetrolA92(100, 20, dangers, "More petrol A92")
        };
        private static List<PetrolA95> GetPetrolA95s(List<ChemistryDanger> dangers) => new()
        {
            new PetrolA95(10, 30, dangers, "Petrol A95"),
            new PetrolA95(100, 20, dangers, "More A95")
        };
        private static List<PetrolA98> GetPetrolA98s(List<ChemistryDanger> dangers) => new()
        {
            new PetrolA98(10, 30, dangers, "A98"),
            new PetrolA98(100, 20, dangers, "More A98")
        };
        private static List<Methylamine> GetMethylamines(List<ChemistryDanger> dangers)
        {
            var methylamineTemperatureRule = new TemperatureRule(-90, 10);
            return new()
            {
                new Methylamine(10, 30, dangers, methylamineTemperatureRule, "Meth"),
                new Methylamine(100, 20, dangers, methylamineTemperatureRule, "Meth")
            };
        }
        private static List<Carbon> GetCarbons()
        {
            var carbonDangers = new List<ChemistryDanger>() { ChemistryDanger.Benign };
            return new()
            {
                new Carbon(10, 30, carbonDangers, "Carbon"),
                new Carbon(100, 20, carbonDangers, "Carbon")
            };
        }
        private static List<CocaCola> GetCocaColas() => new()
        {
            new CocaCola(3, 6, "AAA", CocaColaTaste.Orange),
            new CocaCola(45, 22, "Big", CocaColaTaste.Vanilla)
        };
        private static List<Milk> GetMilks()
        {
            var milkTemperatureRule = new TemperatureRule(-5, 15);
            return  new()
            {
                new Milk(30, 30, "SSS", milkTemperatureRule, MilkTaste.Cow),
                new Milk(40, 20, "FFF", milkTemperatureRule, MilkTaste.Chocolate)
            };
        }
        private static List<Sausage> GetSausages()
        {
            var sausageTemperatureRule = new TemperatureRule(0, 20);
            return new()
            {
                new Sausage(30, 100, "For childs", SausageType.Chicken, sausageTemperatureRule),
                new Sausage(10, 20, "For adults", SausageType.Pork, sausageTemperatureRule)
            };
        }
        private static List<Wardrobe> GetWardrobes()
        {
            var wood1 = new Wood(40, Color.Black, WoodType.Birch);
            var wood2 = new Wood(40, Color.Brown, WoodType.Oak);
            return new()
            {
                new Wardrobe(300, 200, "Very big", wood1, FurniturePurpose.Hall),
                new Wardrobe(300, 200, "Very big", wood2, FurniturePurpose.Bedroom)
            };
        }
        private static List<Carpet> GetCarpets()
        {
            var textile1 = new Textile(50, Color.Pink, TextileType.Wool);
            var textile2 = new Textile(50, Color.Purple, TextileType.Silk);
            return new()
            {
                new Carpet(100, 50, "Very warm", textile1, FurniturePurpose.Bedroom),
                new Carpet(100, 50, "Very warm", textile2, FurniturePurpose.Hall)
            };
        }
        private static List<ContainerShip> GetContainerShips()
        {
            List < ContainerShip > result =  new()
            {
                new ContainerShip(3000, 3000),
                new ContainerShip(5000, 5000)
            };
            foreach (var carpet in GetCarpets())
            {
                foreach (var cc in result)
                {
                    cc.Load(carpet);
                }
            }
            return result;
        }
        private static List<Refrigerator> GetRefrigerators()
        {
            var tempRule = new TemperatureRule(-100, 100);
            List <Refrigerator> result = new()
            {
                new Refrigerator(3000, 3000, tempRule, 30),
                new Refrigerator(5000, 5000, tempRule, 50),
            };
            foreach (var product in GetMilks())
            {
                foreach (var refr in result)
                {
                    refr.Load(product);
                }
            }
            return result;
        }
        private static List<TankTruck> GetTankTrucks()
        {
            List < TankTruck > result =  new()
            {
                new TankTruck(3000, 3000),
                new TankTruck(5000, 5000)
            };
            foreach (var pr in GetPetrolA95s(new List<ChemistryDanger>() { ChemistryDanger.Flammable, ChemistryDanger.Explosive, ChemistryDanger.Toxic }))
            {
                foreach (var s in result)
                {
                    s.Load(pr);
                }
            }
            return result;
        }
        private static List<TiltSemitrailer> GetTiltSemitrailers()
        {
            List < TiltSemitrailer > result =  new()
            {
                new TiltSemitrailer(3000, 3000),
                new TiltSemitrailer(5000, 5000)
            };
            foreach (var s in GetCarbons())
            {
                foreach (var ts in result)
                {
                    ts.Load(s);
                }
            }
            return result;
        }
        private static List<ActrosMP2> GetActrosMP2s()
        {
            return new()
            {
                new ActrosMP2(GetRefrigerators().ElementAt(0), "SS9988"),
                new ActrosMP2(GetTiltSemitrailers().ElementAt(0), "AA6677")
            };
        }
        private static List<ActrosMP3> GetActrosMP3s()
        {
            return new()
            {
                new ActrosMP3(GetTankTrucks().ElementAt(0), "SS9988"),
                new ActrosMP3(GetContainerShips().ElementAt(0), "AA6677")
            };
        }
    }
}
