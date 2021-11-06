using System.Collections.Generic;

namespace TransportEnterprise.XmlParser.Serializers
{
    public abstract class Serializer<T> where T: class
    {
        public abstract void Serialize(T entity);
        public abstract void SerializeCollection(IEnumerable<T> entities);
    }
}
