using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents Actros MP3 xml factory
    /// </summary>
    public class ActrosMP3XmlFactory : TruckTractorsBaseXmlFactory, IXmlDomainFactory<ActrosMP3>
    {
        /// <summary>
        /// Initializes new Actros MP3 xml factory
        /// </summary>
        /// <param name="semitrailerAbstractXmlFactory">Specified abstract semitrailers xml factory</param>
        public ActrosMP3XmlFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailerAbstractXmlFactory) :
                                   base(semitrailerAbstractXmlFactory)
        {
        }
        /// <summary>
        /// Creates Actros MP3 from xml node
        /// </summary>
        public ActrosMP3 Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            (string serialNumber, Semitrailer semitrailer) = GetTruckTractorParameters(nodes);
            return new ActrosMP3(semitrailer, serialNumber);
        }
    }
}