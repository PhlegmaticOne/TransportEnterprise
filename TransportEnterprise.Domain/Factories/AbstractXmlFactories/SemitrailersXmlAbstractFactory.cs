using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public class SemitrailersXmlAbstractFactory : XmlAbstractDomainFactory<Semitrailer>
    {
        public SemitrailersXmlAbstractFactory(XmlNode node) : base(node)
        {
        }
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "Refrigerator", new RefrigeratorXmlFactory(Node) }
            };
        }
    }
}
