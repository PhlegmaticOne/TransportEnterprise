using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public class TruckTractorsXmlAbstractFactory : XmlAbstractDomainFactory<TruckTractor>
    {
        public TruckTractorsXmlAbstractFactory(XmlNode node) : base(node)
        {
        }
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "ActrosMP2", new ActrosMP2XmlFactory(Node) }
            };
        }
    }
}
