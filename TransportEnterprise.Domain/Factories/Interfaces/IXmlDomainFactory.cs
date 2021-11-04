using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Interface for creating domain models
    /// </summary>
    public interface IXmlDomainFactory<out T> where T: class
    {
        /// <summary>
        /// Creates new domain entity
        /// </summary>
        /// <returns></returns>
        T Create(XmlNode node);
    }
}
