using System.Xml;
namespace TransportEnterprise.Models.Factories
{
    public class ProductsXmlAbstractFactory : XmlAbstractDomainFactory<Product>
    {
        public ProductsXmlAbstractFactory(XmlNode node) : base(node) { InitializeFactories(); }
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "Methylamine", new MethylamineXmlFactory(Node) },
                { "CocaCola", new CocaColaXmlFactory(Node) },
                { "PetrolA92", new PetrolXmlFactory(Node) }
            };
        }
    }
}
