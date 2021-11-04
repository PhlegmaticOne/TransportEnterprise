using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class TiltSemitrailerXmlFactory : SemitrailersBaseXmlFactory, IXmlDomainFactory<TiltSemitrailer>
    {
        public TiltSemitrailerXmlFactory(IXmlAbstractDomainFactory<Product> productAbstractXmlFactory) :
                                         base(productAbstractXmlFactory)
        {
        }
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
