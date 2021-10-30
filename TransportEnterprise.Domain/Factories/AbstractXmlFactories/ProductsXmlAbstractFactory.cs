using System.Xml;
namespace TransportEnterprise.Models.Factories
{
    public class ProductsXmlAbstractFactory : XmlAbstractDomainFactory<Product>
    {
        public ProductsXmlAbstractFactory(XmlNode node) : base(node) { }
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "Methylamine", new MethylamineXmlFactory(Node) },
                { "CocaCola", new CocaColaXmlFactory(Node) }
            };
        }
    }
}
