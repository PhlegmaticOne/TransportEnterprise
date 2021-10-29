using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransportEnterprise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportEnterprise.XmlParser;
using TransportEnterprise.Core;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class ActrosMP2Tests
    {
        [TestMethod()]
        public void ActrosMP2Test()
        {
            var semitrailer = new TankTruck(500);
            var dangers = new List<ChemistryDanger>() { ChemistryDanger.Flammable, ChemistryDanger.Explosive };
            semitrailer.Load(new PetrolA92(10, dangers, "Petrol 92"));
            semitrailer.Load(new PetrolA92(20, dangers, "Petrol 92"));
            semitrailer.Load(new PetrolA92(30, dangers, "Petrol 92"));
            var actros = new ActrosMP2(semitrailer);
            var path = new XmlTestsFilePathesGetter(actros.GetType()).GetFilePath();
        }
    }
}