using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class ActrosMP3XmlFactory : TruckTractorsBaseXmlFactory, IXmlDomainFactory<ActrosMP3>
    {
        public ActrosMP3XmlFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailerAbstractXmlFactory) :
                                   base(semitrailerAbstractXmlFactory)
        {
        }

        public ActrosMP3 Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            (string serialNumber, Semitrailer semitrailer) = GetTruckTractorParameters(nodes);
            return new ActrosMP3(semitrailer, serialNumber);
        }
    }
}
