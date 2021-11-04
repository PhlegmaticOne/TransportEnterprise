using System.Collections.Generic;
using TransportEnterprise.Models.Factories;

namespace TransportEnterprise.Models.Extensions
{
    public static class IXmlAbstractDomainFactoryExtensions
    {
        public static IDictionary<string, IXmlDomainFactory<T>> ToDictionaryOfFactories<T>
            (this IXmlAbstractDomainFactory<T> xmlAbstractDomainFactory) where T: class
        {
            var result = new Dictionary<string, IXmlDomainFactory<T>>();
            foreach (var factory in xmlAbstractDomainFactory.GetAllFactories())
            {
                result.Add(factory.GetType().GenericTypeArguments[0].Name, factory);
            }
            return result;
        }
        public static IEnumerable<KeyValuePair<string, IXmlDomainFactory<T>>> ToKeyValuePairs<T>
            (this IXmlAbstractDomainFactory<T> xmlAbstractDomainFactory) where T : class
        {
            var result = new List<KeyValuePair<string, IXmlDomainFactory<T>>>();
            foreach (var factory in xmlAbstractDomainFactory.GetAllFactories())
            {
                var type = factory.GetType();
                var arg = type.GetInterface("IXmlDomainFactory`1").GenericTypeArguments[0].Name;
                result.Add(new(arg, factory));
            }
            return result;
        }
    }
}
