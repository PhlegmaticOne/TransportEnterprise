using System.Collections.Generic;
using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents abstract factory for domain objects
    /// </summary>
    public abstract class XmlAbstractDomainFactory<T> : IAbstractDomainFactory<T> where T : class
    {
        protected XmlNode Node;
        protected Dictionary<string, IDomainFactory<T>> Factories;
        public XmlAbstractDomainFactory(XmlNode node)
        {
            Node = node;
        }
        protected abstract void InitializeFactories();
        public T Create()
        {
            if (Factories.TryGetValue(Node.Name, out IDomainFactory<T> factory))
            {
                return factory.Create();
            }
            else if(Factories.TryGetValue(Node.Attributes[0].Value, out IDomainFactory<T> factory1))
            {
                return factory1.Create();
            }
            return null;
        }
    }
}
