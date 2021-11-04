using System.IO;
using TransportEnterprise.Models.Factories;

namespace TransportEnterprise.XmlParser.Deserializers
{
    public class XMLStreamReaderDeserializer<TEntity, TBaseType> : XMLDeserializer<TEntity, TBaseType>
                                                                   where TEntity: class, TBaseType
                                                                   where TBaseType: class
    {
        public XMLStreamReaderDeserializer(string filePath, IXmlAbstractDomainFactory<TBaseType> xmlAbstractDomainFactory) :
            base(filePath, xmlAbstractDomainFactory) { }
        protected override void Load()
        {
            using var sr = new StreamReader(FilePath);
            XmlDocument.Load(sr);
        }
    }
}
