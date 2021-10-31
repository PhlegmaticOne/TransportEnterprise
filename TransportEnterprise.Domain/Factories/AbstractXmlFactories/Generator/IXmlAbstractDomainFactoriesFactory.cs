using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public interface IXmlAbstractDomainFactoriesFactory
    {
        XmlAbstractDomainFactory<T> CreateFactory<T>(XmlNode node) where T: class;
    }
}
