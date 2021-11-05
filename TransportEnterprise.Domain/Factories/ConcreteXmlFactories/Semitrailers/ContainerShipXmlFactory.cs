using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents container ship xml factory
    /// </summary>
    public class ContainerShipXmlFactory : SemitrailersBaseXmlFactory, IXmlDomainFactory<ContainerShip>
    {
        /// <summary>
        /// Initializes new container ships xml factory
        /// </summary>
        /// <param name="productsXmlAbstractFactory">Specified abstract product xml factory</param>
        public ContainerShipXmlFactory(IXmlAbstractDomainFactory<Product> productsXmlAbstractFactory) :
            base(productsXmlAbstractFactory) { }
        /// <summary>
        /// Creates container ship from xml node
        /// </summary>
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
