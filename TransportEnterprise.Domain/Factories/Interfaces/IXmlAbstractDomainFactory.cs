using System.Collections.Generic;
using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Interface for abstract factories
    /// </summary>
    public interface IXmlAbstractDomainFactory<out T> where T: class
    {
        /// <summary>
        /// Creates instance of specified type or any instance that inherits this type
        /// </summary>
        /// <returns></returns>
        IXmlDomainFactory<T> GetFactory(XmlNode node);
        IEnumerable<IXmlDomainFactory<T>> GetAllFactories();
    }
}
