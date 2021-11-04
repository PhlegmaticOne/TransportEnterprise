using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class CarParkXmlFactory : IXmlDomainFactory<CarPark>
    {
        private readonly IXmlAbstractDomainFactory<Semitrailer> _semitrailersFactory;
        private readonly IXmlAbstractDomainFactory<TruckTractor> _truckTractorsFactory;

        public CarParkXmlFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailersFactory,
                                 IXmlAbstractDomainFactory<TruckTractor> truckTractorsFactory)
        {
            _semitrailersFactory = semitrailersFactory;
            _truckTractorsFactory = truckTractorsFactory;
        }

        public CarPark Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var semitrailers = new List<Semitrailer>();
            foreach (XmlNode semitrailerXmlNode in nodes.GetNode("Semitrailers").ChildNodes)
            {
                var semitrailersFactory = _semitrailersFactory.GetFactory(semitrailerXmlNode);
                semitrailers.Add(semitrailersFactory.Create(semitrailerXmlNode));
            }
            var truckTractors = new List<TruckTractor>();
            foreach (XmlNode truckTractorXmlNode in nodes.GetNode("TruckTractors").ChildNodes)
            {
                var truckTractorsFactory = _truckTractorsFactory.GetFactory(truckTractorXmlNode);
                truckTractors.Add(truckTractorsFactory.Create(truckTractorXmlNode));
            }
            return new CarPark(semitrailers, truckTractors);
        }
    }
}
