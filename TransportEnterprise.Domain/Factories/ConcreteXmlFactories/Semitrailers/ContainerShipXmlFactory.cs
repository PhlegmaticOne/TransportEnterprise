using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class ContainerShipXmlFactory : SemitrailersBaseXmlFactory, IXmlDomainFactory<ContainerShip>
    {
        public ContainerShipXmlFactory(IXmlAbstractDomainFactory<Product> productsXmlAbstractFactory) :
            base(productsXmlAbstractFactory)
        {

        }

        public ContainerShip Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (loadCapacity, valueCapacity, products) = GetSemitrailerParameters(nodes);
            var containerShip = new ContainerShip(loadCapacity, valueCapacity);
            foreach (var product in products)
            {
                containerShip.Load(product);
            }
            return containerShip;
        }
    }
}
