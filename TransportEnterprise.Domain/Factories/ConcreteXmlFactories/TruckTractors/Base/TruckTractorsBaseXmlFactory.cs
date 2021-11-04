using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class TruckTractorsBaseXmlFactory
    {
        private readonly IXmlAbstractDomainFactory<Semitrailer> _semitrailersXmlAbstractFactory;
        public TruckTractorsBaseXmlFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailersXmlAbstractFactory)
        {
            _semitrailersXmlAbstractFactory = semitrailersXmlAbstractFactory;
        }
        protected (string, Semitrailer) GetTruckTractorParameters(ICollection<XmlNode> nodes)
        {
            var semitrailerNode = nodes.GetNode("Semitrailer");
            return (nodes.GetInnerText("SerialNumber"),
                    _semitrailersXmlAbstractFactory.GetFactory(semitrailerNode)?.Create(semitrailerNode));
        }
    }
}
