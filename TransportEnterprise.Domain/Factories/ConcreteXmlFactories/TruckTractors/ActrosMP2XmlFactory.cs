using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents Actros MP2 xml factory
    /// </summary>
    public class ActrosMP2XmlFactory : TruckTractorsBaseXmlFactory, IXmlDomainFactory<ActrosMP2>
    {
        /// <summary>
        /// IInitializes new Actros MP2 xml factory
        /// </summary>
        /// <param name="semitrailerAbstractXmlFactory">Specified abstract semitrailers xml factory</param>
        public ActrosMP2XmlFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailerAbstractXmlFactory) :
                                   base(semitrailerAbstractXmlFactory)
        {
        }
        /// <summary>
        /// Creates Actros MP2 from xml node
        /// </summary>
        public ActrosMP2 Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            (string serialNumber, Semitrailer semitrailer) = GetTruckTractorParameters(nodes);
            return new ActrosMP2(semitrailer, serialNumber);
        }
    }
}
