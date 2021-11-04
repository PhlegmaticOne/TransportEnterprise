using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class ActrosMP2XmlFactory : TruckTractorsBaseXmlFactory, IXmlDomainFactory<ActrosMP2>
    {
        public ActrosMP2XmlFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailerAbstractXmlFactory) :
                                   base(semitrailerAbstractXmlFactory)
        {
        }

        public ActrosMP2 Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            (string serialNumber, Semitrailer semitrailer) = GetTruckTractorParameters(nodes);
            return new ActrosMP2(semitrailer, serialNumber);
        }
    }
}
