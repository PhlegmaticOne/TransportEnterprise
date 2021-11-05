using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents products abstract xml factory with new furniture product type
    /// </summary>
    public class ProductsWithFurnitureXmlAbstractFactory : ProductsXmlAbstractFactory
    {
        /// <summary>
        /// Abstract xml factory of furniture types
        /// </summary>
        private readonly IXmlAbstractDomainFactory<Furniture> _furnitureAbstractFactory;
        /// <summary>
        /// Initializes new products xml abstract factory instance
        /// </summary>
        /// <param name="chemistryAbstractFactory">Specified chemistry xml abstract factory</param>
        /// <param name="customerGoodsAbstractFactory">Specified customer goods abstrct xml factory</param>
        /// <param name="furnitureAbstractFactory">Specified abstract xml factory of furniture types</param>
        public ProductsWithFurnitureXmlAbstractFactory(
            IXmlAbstractDomainFactory<Chemistry> chemistryAbstractFactory,
            IXmlAbstractDomainFactory<CustomerGood> customerGoodsAbstractFactory,
            IXmlAbstractDomainFactory<Furniture> furnitureAbstractFactory) :
            base(chemistryAbstractFactory, customerGoodsAbstractFactory)
        {
            _furnitureAbstractFactory = furnitureAbstractFactory;
            InitializeFactories();
        }
        /// <summary>
        /// Initializes all factories of types implements product type and abstract types inrehits it
        /// </summary>
        protected override void InitializeFactories()
        {
            if (_furnitureAbstractFactory is null) return;
            base.InitializeFactories();
            foreach (var factory in _furnitureAbstractFactory.ToKeyValuePairs<Product>())
            {
                Factories.Add(factory.Key, factory.Value);
            }
        }
    }
}
