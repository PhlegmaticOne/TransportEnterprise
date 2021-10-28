using System.Collections.Generic;

namespace TransportEnterprise.XmlParser
{
    public abstract class Parser<T> where T: class
    {
        public abstract void Serialize(T entity);
        public abstract ICollection<T> DeserializeAll();
    }
}
