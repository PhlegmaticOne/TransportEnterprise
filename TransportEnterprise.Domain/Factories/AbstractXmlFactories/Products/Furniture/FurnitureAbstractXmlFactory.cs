namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents furniture abstract xml factory
    /// </summary>
    public class FurnitureAbstractXmlFactory : XmlAbstractDomainFactory<Furniture>
    {
        /// <summary>
        /// Material abstract xml factory
        /// </summary>
        private readonly IAbstractMaterialXmlFactory<Material> _abstractMaterialXmlFactory;
        /// <summary>
        /// Initializes new furniture abstract xml factory
        /// </summary>
        /// <param name="abstractMaterialXmlFactory">Specified material abstract xml factory</param>
        public FurnitureAbstractXmlFactory(IAbstractMaterialXmlFactory<Material> abstractMaterialXmlFactory)
        {
            _abstractMaterialXmlFactory = abstractMaterialXmlFactory;
            InitializeFactories();
        }
        /// <summary>
        /// Initializes factories inheriting furniture type
        /// </summary>
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
