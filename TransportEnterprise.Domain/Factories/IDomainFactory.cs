using System.Collections.Generic;
using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public interface IDomainFactory<T> where T: class
    {
        T Create(ICollection<XmlNode> xmlNodes);
    }
}
