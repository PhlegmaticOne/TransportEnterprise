using System;
using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class SemitrailersBaseXmlFactory
    {
        private readonly IXmlAbstractDomainFactory<Product> ProductsXmlAbstractFactory;
        public SemitrailersBaseXmlFactory(IXmlAbstractDomainFactory<Product> productsXmlAbstractFactory)
        {
            ProductsXmlAbstractFactory = productsXmlAbstractFactory;
        }
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
