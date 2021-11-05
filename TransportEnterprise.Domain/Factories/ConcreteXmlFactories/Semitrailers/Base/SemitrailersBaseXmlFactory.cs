using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents semitrailers base xml factory
    /// </summary>
    public class SemitrailersBaseXmlFactory
    {
        /// <summary>
        /// Abstract product xml factory
        /// </summary>
        private readonly IXmlAbstractDomainFactory<Product> ProductsXmlAbstractFactory;
        /// <summary>
        /// Initializes new semitrailers abstract factory
        /// </summary>
        /// <param name="productsXmlAbstractFactory">Specified abstract product xml factory</param>
        public SemitrailersBaseXmlFactory(IXmlAbstractDomainFactory<Product> productsXmlAbstractFactory) =>
            ProductsXmlAbstractFactory = productsXmlAbstractFactory;
        /// <summary>
        /// Gets properties values of semitrailers base type from xml node
        /// </summary>
        protected (decimal, decimal, ICollection<Product>) GetSemitrailerParameters(ICollection<XmlNode> nodes)
        {
            var products = new List<Product>();
            foreach (XmlNode product in nodes.GetNode("Products"))
            {
                products.Add(ProductsXmlAbstractFactory.GetFactory(product).Create(product));
            }
            return (decimal.Parse(nodes.GetInnerText("LoadCapacity")),
                    decimal.Parse(nodes.GetInnerText("ValueCapacity")),
                    products);   
        }
    }
}
