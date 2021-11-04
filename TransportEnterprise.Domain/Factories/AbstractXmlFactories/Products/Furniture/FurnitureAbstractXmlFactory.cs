namespace TransportEnterprise.Models.Factories
{
    public class FurnitureAbstractXmlFactory : XmlAbstractDomainFactory<Furniture>
    {
        private readonly IAbstractMaterialXmlFactory<Material> _abstractMaterialXmlFactory;

        public FurnitureAbstractXmlFactory(IAbstractMaterialXmlFactory<Material> abstractMaterialXmlFactory)
        {
            _abstractMaterialXmlFactory = abstractMaterialXmlFactory;
            InitializeFactories();
        }

        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "Carpet", new CarpetXmlFactory(_abstractMaterialXmlFactory) },
                { "Wardrobe", new WardrobeXmlFactory(_abstractMaterialXmlFactory) }
            };
        }
    }
}
