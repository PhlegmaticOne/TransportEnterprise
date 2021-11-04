using System.Collections.Generic;
using TransportEnterprise.Models.Factories;

namespace TransportEnterprise.Models.Extensions
{
    /// <summary>
    /// Extensions for IXmlAbstractDomainFactory 
    /// </summary>
    public static class IXmlAbstractDomainFactoryExtensions
    {
        /// <summary>
        /// Gets key-value pairs which keys are string type names of factories generic types, values - factories of specified type
        /// </summary>
        public static IEnumerable<KeyValuePair<string, IXmlDomainFactory<T>>> ToKeyValuePairs<T>
            (this IXmlAbstractDomainFactory<T> xmlAbstractDomainFactory) where T : class
        {
            foreach (var factory in xmlAbstractDomainFactory.GetAllFactories())
            {
                yield return new(factory.GetType().GetInterface("IXmlDomainFactory`1").GenericTypeArguments[0].Name, factory);
            }
        }
    }
}
