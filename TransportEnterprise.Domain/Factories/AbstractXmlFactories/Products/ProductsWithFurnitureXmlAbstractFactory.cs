using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class ProductsWithFurnitureXmlAbstractFactory : ProductsXmlAbstractFactory
    {
        private readonly IXmlAbstractDomainFactory<Furniture> _furnitureAbstractFactory;

        public ProductsWithFurnitureXmlAbstractFactory(
            IXmlAbstractDomainFactory<Chemistry> chemistryAbstractFactory,
            IXmlAbstractDomainFactory<CustomerGood> customerGoodsAbstractFactory,
            IXmlAbstractDomainFactory<Furniture> furnitureAbstractFactory) :
            base(chemistryAbstractFactory, customerGoodsAbstractFactory)
        {
            _furnitureAbstractFactory = furnitureAbstractFactory;
            InitializeFactories();
        }
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
