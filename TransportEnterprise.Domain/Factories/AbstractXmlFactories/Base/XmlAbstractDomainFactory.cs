using System.Collections.Generic;
using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents abstract factory for domain objects
    /// </summary>
    public abstract class XmlAbstractDomainFactory<T> : IXmlAbstractDomainFactory<T> where T : class
    {
        protected Dictionary<string, IXmlDomainFactory<T>> Factories;
        protected abstract void InitializeFactories();
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

        public IEnumerable<IXmlDomainFactory<T>> GetAllFactories() => Factories.Values;
    }
}
