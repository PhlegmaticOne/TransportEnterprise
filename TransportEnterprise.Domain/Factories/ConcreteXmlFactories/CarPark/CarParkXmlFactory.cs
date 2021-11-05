using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents car park xml factory
    /// </summary>
    public class CarParkXmlFactory : IXmlDomainFactory<CarPark>
    {
        /// <summary>
        /// Abstract semitrailers xml factory
        /// </summary>
        private readonly IXmlAbstractDomainFactory<Semitrailer> _semitrailersFactory;
        /// <summary>
        /// Abstract truck tractors xml factory
        /// </summary>
        private readonly IXmlAbstractDomainFactory<TruckTractor> _truckTractorsFactory;
        /// <summary>
        /// Initializes new car park factory instance
        /// </summary>
        /// <param name="semitrailersFactory">Abstract semitrailers factory</param>
        /// <param name="truckTractorsFactory">Abstract truck tractors factory</param>
        public CarParkXmlFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailersFactory,
                                 IXmlAbstractDomainFactory<TruckTractor> truckTractorsFactory)
        {
            _semitrailersFactory = semitrailersFactory;
            _truckTractorsFactory = truckTractorsFactory;
        }
        /// <summary>
        /// Creates car park from xml node
        /// </summary>
        public CarPark Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var semitrailers = new List<Semitrailer>();
            foreach (XmlNode semitrailerXmlNode in nodes.GetNode("Semitrailers").ChildNodes)
            {
                semitrailers.Add(_semitrailersFactory.GetFactory(semitrailerXmlNode).Create(semitrailerXmlNode));
            }
                var truckTractors = new List<TruckTractor>();
            foreach (XmlNode truckTractorXmlNode in nodes.GetNode("TruckTractors").ChildNodes)
            {
                truckTractors.Add(_truckTractorsFactory.GetFactory(truckTractorXmlNode).Create(truckTractorXmlNode));
            }
            return new CarPark(semitrailers, truckTractors);
        }
    }
}