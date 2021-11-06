using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace TransportEnterprise.Models.Tests
{
    [TestClass()]
    public class ContainerShipTests
    {
        private readonly ContainerShip _containerShip;
        public ContainerShipTests()
        {
            _containerShip = new ContainerShip(200, 1000);
        }
        [TestMethod()]
        public void ContainerShipSuccessfulLoadProductTest()
        {
            var wardrobe = new Wardrobe(103, 10, "Ad222", new Wood(30, Color.Black, WoodType.Pine), FurniturePurpose.Bedroom);
            _containerShip.Load(wardrobe);
            Assert.AreEqual(1, _containerShip.Products.Count);
        }
        [TestMethod()]
        public void ContainerShipUnsuccessfulLoadProductTest()
        {
            var wardrobe = new Wardrobe(10, 10, "Ad222", new Wood(30, Color.Black, WoodType.Pine), FurniturePurpose.Bedroom);

            Assert.ThrowsException<ArgumentException>(() => _containerShip.Load(wardrobe));
        }
        [TestMethod()]
        public void EqualsTest()
        {
            var equalSimitrailer = new ContainerShip(200, 1000);
            Assert.AreEqual(_containerShip, equalSimitrailer);
        }
    }
}