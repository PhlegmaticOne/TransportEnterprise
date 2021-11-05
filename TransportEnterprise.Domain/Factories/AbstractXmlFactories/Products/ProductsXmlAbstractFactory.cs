using System.Collections.Generic;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents products xml abstract factory
    /// </summary>
    public class ProductsXmlAbstractFactory : XmlAbstractDomainFactory<Product>
    {
        /// <summary>
        /// Chemistry abstract xml factory
        /// </summary>
        private readonly IXmlAbstractDomainFactory<Chemistry> _chemistryAbstractFactory;
        /// <summary>
        /// Customer goods abstract factory
        /// </summary>
        private readonly IXmlAbstractDomainFactory<CustomerGood> _customerGoodsAbstractFactory;
        /// <summary>
        /// Initializes new products xml abstract factory instance
        /// </summary>
        /// <param name="chemistryAbstractFactory">Specified chemistry xml abstract factory</param>
        /// <param name="customerGoodsAbstractFactory">Specified customer goods abstrct xml factory</param>
        public ProductsXmlAbstractFactory(IXmlAbstractDomainFactory<Chemistry> chemistryAbstractFactory,
                                          IXmlAbstractDomainFactory<CustomerGood> customerGoodsAbstractFactory)
        {
            _chemistryAbstractFactory = chemistryAbstractFactory;
            _customerGoodsAbstractFactory = customerGoodsAbstractFactory;
            InitializeFactories();
        }
        /// <summary>
        /// Initializes all factories of types implements product type and abstract types inrehits it
        /// </summary>
        protected override void InitializeFactories()
        {
            var factories = new List<KeyValuePair<string, IXmlDomainFactory<Product>>>();
            factories.AddRange(_chemistryAbstractFactory.ToKeyValuePairs<Product>());
            factories.AddRange(_customerGoodsAbstractFactory.ToKeyValuePairs<Product>());
            Factories = new Dictionary<string, IXmlDomainFactory<Product>>(factories);
        } 
    }
}
