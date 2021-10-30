using System;
using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class ActrosMP2XmlFactory : IDomainFactory<TruckTractor>
    {
        private readonly ICollection<XmlNode> _nodes;
        public ActrosMP2XmlFactory(XmlNode node) => _nodes = node.ChildNodes.ToList();
        public TruckTractor Create()
        {
            throw new NotImplementedException();
        }
    }
}
