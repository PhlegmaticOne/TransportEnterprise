using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents tank truck xml factory
    /// </summary>
    public class TankTruckXmlFactory : SemitrailersBaseXmlFactory, IXmlDomainFactory<TankTruck>
    {
        /// <summary>
        /// Initializes new tank truck xml factory
        /// </summary>
        /// <param name="productsAbstractXmlFactory">Specified abstract product xml factory</param>
        public TankTruckXmlFactory(IXmlAbstractDomainFactory<Product> productsAbstractXmlFactory) :
                                   base(productsAbstractXmlFactory)
        {
        }
        /// <summary>
        /// Creates tank truck from xml node
        /// </summary>
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
