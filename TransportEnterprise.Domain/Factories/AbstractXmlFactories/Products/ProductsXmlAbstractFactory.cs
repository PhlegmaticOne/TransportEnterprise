using System.Collections.Generic;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class ProductsXmlAbstractFactory : XmlAbstractDomainFactory<Product>
    {
        private readonly IXmlAbstractDomainFactory<Chemistry> _chemistryAbstractFactory;
        private readonly IXmlAbstractDomainFactory<CustomerGood> _customerGoodsAbstractFactory;

        public ProductsXmlAbstractFactory(IXmlAbstractDomainFactory<Chemistry> chemistryAbstractFactory,
                                          IXmlAbstractDomainFactory<CustomerGood> customerGoodsAbstractFactory)
        {
            _chemistryAbstractFactory = chemistryAbstractFactory;
            _customerGoodsAbstractFactory = customerGoodsAbstractFactory;
            InitializeFactories();
        }
        protected override void InitializeFactories()
        {
            var factories = new List<KeyValuePair<string, IXmlDomainFactory<Product>>>();
            factories.AddRange(_chemistryAbstractFactory.ToKeyValuePairs<Product>());
            factories.AddRange(_customerGoodsAbstractFactory.ToKeyValuePairs<Product>());
            Factories = new Dictionary<string, IXmlDomainFactory<Product>>(factories);
        } 
    }
}
