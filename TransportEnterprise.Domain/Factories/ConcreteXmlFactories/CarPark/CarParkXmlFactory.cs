using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class CarParkXmlFactory : IDomainFactory<CarPark>
    {
        private readonly ICollection<XmlNode> _nodes;
        private readonly IXmlAbstractDomainFactoriesFactory _abstractDomainFactoriesFactory;

        public CarParkXmlFactory(XmlNode node, IXmlAbstractDomainFactoriesFactory abstractDomainFactoriesFactory)
        {
            _nodes = node.ChildNodes.ToList();
            _abstractDomainFactoriesFactory = abstractDomainFactoriesFactory;
        }

        public CarPark Create()
        {
            var semitrailers = new List<Semitrailer>();
            foreach (XmlNode semitrailerXmlNode in _nodes.GetNode("Semitrailers").ChildNodes)
            {
                var semitrailersFactory = _abstractDomainFactoriesFactory.CreateFactory<Semitrailer>(semitrailerXmlNode);
                semitrailers.Add(semitrailersFactory.Create());
            }
            var truckTractors = new List<TruckTractor>();
            foreach (XmlNode truckTractorXmlNode in _nodes.GetNode("TruckTractors").ChildNodes)
            {
                var truckTractorsFactory = _abstractDomainFactoriesFactory.CreateFactory<TruckTractor>(truckTractorXmlNode);
                truckTractors.Add(truckTractorsFactory.Create());
            }
            return new CarPark(semitrailers, truckTractors);
        }
    }
}
