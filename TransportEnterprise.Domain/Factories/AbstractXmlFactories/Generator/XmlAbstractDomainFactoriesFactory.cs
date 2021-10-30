using System.Xml;

namespace TransportEnterprise.Models.Factories.AbstractXmlFactories
{
    public static class XmlAbstractDomainFactoriesFactory
    {
        public static XmlAbstractDomainFactory<T> CreateInstance<T>(XmlNode node) where T: class => typeof(T).Name switch 
        {
            "Product" => new ProductsXmlAbstractFactory(node) as XmlAbstractDomainFactory<T>,
            "Semitrailer" => new SemitrailersXmlAbstractFactory(node) as XmlAbstractDomainFactory<T>,
            "TruckTractor" => new TruckTractorsXmlAbstractFactory(node) as XmlAbstractDomainFactory<T>,
            "CarPark" => new CarParksXmlAbstractFactory(node) as XmlAbstractDomainFactory<T>,
            _ => null
        };
    }
}
