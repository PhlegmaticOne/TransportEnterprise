using System.Xml;
using TransportEnterprise.Models.Factories;

namespace TransportEnterprise.XmlParser.Deserializers
{
    public class XMLXmlReaderDeserializer<TEntity, TBaseType> : XMLDeserializer<TEntity, TBaseType>
                                                                where TEntity: class, TBaseType
                                                                where TBaseType: class
    {
        public XMLXmlReaderDeserializer(string filePath, IXmlAbstractDomainFactory<TBaseType> xmlAbstractDomainFactory) :
            base(filePath, xmlAbstractDomainFactory) { }
        protected override void Load()
        {
            using var xmlr = XmlReader.Create(FilePath);
            XmlDocument.Load(xmlr);
        }
    }
}
