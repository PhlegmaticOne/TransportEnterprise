using System.Xml;

namespace TransportEnterprise.Models.Factories.AbstractXmlFactories
{
    public class XmlAbstractDomainFactoriesFactory : IXmlAbstractDomainFactoriesFactory
    {

        public XmlAbstractDomainFactory<T> CreateFactory<T>(XmlNode node) where T : class => typeof(T).Name switch
        {
            "Product" => new ProductsXmlAbstractFactory(node) as XmlAbstractDomainFactory<T>,
            "Semitrailer" => new SemitrailersXmlAbstractFactory(node, this) as XmlAbstractDomainFactory<T>,
            "TruckTractor" => new TruckTractorsXmlAbstractFactory(node, this) as XmlAbstractDomainFactory<T>,
            "CarPark" => new CarParksXmlAbstractFactory(node, this) as XmlAbstractDomainFactory<T>,
            _ => null
        };
    }
}
