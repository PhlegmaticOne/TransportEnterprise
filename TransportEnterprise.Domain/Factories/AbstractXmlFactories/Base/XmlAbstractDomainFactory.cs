using System.Collections.Generic;
using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents abstract factory for domain objects
    /// </summary>
    public abstract class XmlAbstractDomainFactory<T> : IXmlAbstractDomainFactory<T> where T : class
    {
        /// <summary>
        /// Factories which are accessible by its generic type names
        /// </summary>
        protected Dictionary<string, IXmlDomainFactory<T>> Factories;
        /// <summary>
        /// Method for initializing factories of inherit classes
        /// </summary>
        protected abstract void InitializeFactories();
        /// <summary>
        /// Gets factory from xml node, which check its name and attributes
        /// </summary>
        /// <returns>null - if factory didn't exist</returns>
        public IXmlDomainFactory<T> GetFactory(XmlNode node)
        {
            if(Factories.TryGetValue(node.Name, out IXmlDomainFactory<T> domainFactoryFromName))
            {
                return domainFactoryFromName;
            }
            if(Factories.TryGetValue(node.Attributes[0].Value, out IXmlDomainFactory<T> domainFactoryFromAttribute))
            {
                return domainFactoryFromAttribute;
            }
            return null;
        }
        /// <summary>
        /// Gets all factories of inherited classes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IXmlDomainFactory<T>> GetAllFactories() => Factories.Values;
    }
}
