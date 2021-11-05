using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents tilt semitrailer xml factory
    /// </summary>
    public class TiltSemitrailerXmlFactory : SemitrailersBaseXmlFactory, IXmlDomainFactory<TiltSemitrailer>
    {
        /// <summary>
        /// Initializes new tilt semitrailer xml factory
        /// </summary>
        /// <param name="productAbstractXmlFactory">Specified abstract product xml factory</param>
        public TiltSemitrailerXmlFactory(IXmlAbstractDomainFactory<Product> productAbstractXmlFactory) :
                                         base(productAbstractXmlFactory)
        {
        }
        /// <summary>
        /// Creates tilt semitrailer from xml node
        /// </summary>
        public TiltSemitrailer Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (loadCapacity, valueCapacity, products) = GetSemitrailerParameters(nodes);
            var tiltSemitrailer = new TiltSemitrailer(loadCapacity, valueCapacity);
            foreach (var product in products)
            {
                tiltSemitrailer.Load(product);
            }
            return tiltSemitrailer;
        }
    }
}
