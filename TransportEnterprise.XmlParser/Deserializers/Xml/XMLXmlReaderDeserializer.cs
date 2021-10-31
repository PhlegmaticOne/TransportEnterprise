using System.Xml;
using TransportEnterprise.Models.Factories;

namespace TransportEnterprise.XmlParser.Deserializers
{
    public class XMLXmlReaderDeserializer<T> : XMLDeserializer<T> where T : class
    {
        public XMLXmlReaderDeserializer(string filePath, IXmlAbstractDomainFactoriesFactory factory) : base(filePath, factory) { }
        protected override void Load()
        {
            using (var xmlr = XmlReader.Create(FilePath))
            {
                XmlDocument.Load(xmlr);
            }
        }
    }
}
