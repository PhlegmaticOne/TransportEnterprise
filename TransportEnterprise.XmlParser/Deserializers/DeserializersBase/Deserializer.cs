using System;
using System.Collections.Generic;

namespace TransportEnterprise.XmlParser.Deserializers
{
    public abstract class Deserializer<T> where T: class
    {
        public abstract T FirstOrDefault(Func<T, bool> predicate);
        public abstract ICollection<T> All();
        public abstract ICollection<T> Where(Func<T, bool> prediacte);
    }
}
