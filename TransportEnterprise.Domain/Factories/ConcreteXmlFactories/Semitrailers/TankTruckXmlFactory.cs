using System;
using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class TankTruckXmlFactory : SemitrailersBaseXmlFactory, IXmlDomainFactory<TankTruck>
    {
        public TankTruckXmlFactory(IXmlAbstractDomainFactory<Product> productsAbstractXmlFactory) :
                                   base(productsAbstractXmlFactory)
        {
        }
        public TankTruck Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (loadCapacity, valueCapacity, products) = GetSemitrailerParameters(nodes);
            var tankTruck = new TankTruck(loadCapacity, valueCapacity);
            foreach (var product in products)
            {
                tankTruck.Load(product);
            }
            return tankTruck;
        }
    }
}
