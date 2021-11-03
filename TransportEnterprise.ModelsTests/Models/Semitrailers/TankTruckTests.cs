using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class TankTruckTests
    {
        private readonly TankTruck _tankTruck;
        public TankTruckTests()
        {
            _tankTruck = new TankTruck(500, 200);
        }
        [TestMethod]
        public void LoadUnsuccessfulBecauseOfProductIsNotOfFirstLoadedTypeTest()
        {
            var meth = new Methylamine(10, 20, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, new TemperatureRule(-100, 10), "Danger");
            var petrol = new PetrolA92(10, 20, new List<ChemistryDanger>() { ChemistryDanger.Toxic }, "Petrol");
            _tankTruck.Load(meth);
            Assert.ThrowsException<ArgumentException>(() => _tankTruck.Load(petrol));
        }

        [TestMethod]
        public void LoadSuccessfulTest()
        {
            var meth1 = new Methylamine(20, 20, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, new TemperatureRule(-100, 10), "Danger");
            var meth2 = new Methylamine(60, 10, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, new TemperatureRule(-100, 10), "Danger");
            var meth3 = new Methylamine(80, 50, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, new TemperatureRule(-100, 10), "Danger");
            var meth4 = new Methylamine(1, 20, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, new TemperatureRule(-100, 10), "Danger");
            var meth5 = new Methylamine(20, 100, new List<ChemistryDanger>() { ChemistryDanger.Flammable }, new TemperatureRule(-100, 10), "Danger");
            _tankTruck.Load(meth1);
            _tankTruck.Load(meth2);
            _tankTruck.Load(meth3);
            _tankTruck.Load(meth4);
            _tankTruck.Load(meth5);

            Assert.AreEqual(181, _tankTruck.CurrentLoading);
            Assert.AreEqual(200, _tankTruck.CurrentLoadedValue);
            Assert.AreEqual(5, _tankTruck.Products.Count);
            Assert.IsTrue(_tankTruck.Products.All(p => p.GetType() == typeof(Methylamine)));
        }
    }
}