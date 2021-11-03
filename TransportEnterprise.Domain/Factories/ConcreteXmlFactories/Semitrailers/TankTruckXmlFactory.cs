using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class TankTruckXmlFactory : IDomainFactory<TankTruck>
    {
        private readonly ICollection<XmlNode> _nodes;
        private readonly IXmlAbstractDomainFactoriesFactory _abstractDomainFactoriesFactory;

        public TankTruckXmlFactory(XmlNode node, IXmlAbstractDomainFactoriesFactory abstractDomainFactoriesFactory)
        {
            _nodes = node.ChildNodes.ToList();
            _abstractDomainFactoriesFactory = abstractDomainFactoriesFactory;
        }
        public TankTruck Create()
        {
            var loadCapacity = decimal.Parse(_nodes.GetInnerText("LoadCapacity"));
            var valueCapacity = decimal.Parse(_nodes.GetInnerText("ValueCapacity"));
            var xmlProducts = _nodes.GetNode("Products");
            var tankTruck = new TankTruck(loadCapacity, valueCapacity);
            foreach (XmlNode product in xmlProducts)
            {
                var factory = _abstractDomainFactoriesFactory.CreateFactory<Product>(product);
                tankTruck.Load(factory.Create());
            }
            return tankTruck;
        }
    }
}
