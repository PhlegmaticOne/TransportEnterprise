using System;
using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class CarParkXmlFactory : IDomainFactory<CarPark>
    {
        private readonly ICollection<XmlNode> _nodes;
        public CarParkXmlFactory(XmlNode node) => _nodes = node.ChildNodes.ToList();
        public CarPark Create()
        {
            throw new NotImplementedException();
        }
    }
}
