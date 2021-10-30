using System;
using System.Collections.Generic;
using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public class CarParksXmlAbstractFactory : XmlAbstractDomainFactory<CarPark>
    {
        public CarParksXmlAbstractFactory(XmlNode node) : base(node)
        {
        }

        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "CarPark", new CarParkXmlFactory(Node) },
            };
        }
    }
}
