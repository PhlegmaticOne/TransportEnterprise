using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents truck tractors base xml factory
    /// </summary>
    public class TruckTractorsBaseXmlFactory
    {
        /// <summary>
        /// Abstract semitrailers xml factory
        /// </summary>
        private readonly IXmlAbstractDomainFactory<Semitrailer> _semitrailersXmlAbstractFactory;
        /// <summary>
        /// Initializes new truck tractors base xml factory
        /// </summary>
        /// <param name="semitrailersXmlAbstractFactory">Specified abstract semitrailers xml factory</param>
        public TruckTractorsBaseXmlFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailersXmlAbstractFactory) => 
            _semitrailersXmlAbstractFactory = semitrailersXmlAbstractFactory;
        /// <summary>
        /// Gets properties values of truck tractor base type from xml node
        /// </summary>
        protected (string, Semitrailer) GetTruckTractorParameters(ICollection<XmlNode> nodes)
        {
            var semitrailerNode = nodes.GetNode("Semitrailer");
            return (nodes.GetInnerText("SerialNumber"),
                    _semitrailersXmlAbstractFactory.GetFactory(semitrailerNode)?.Create(semitrailerNode));
        }
    }
}
