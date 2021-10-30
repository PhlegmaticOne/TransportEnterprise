using System.Xml;

namespace TransportEnterprise.XmlParser.Deserializers
{
    public class XMLXmlReaderDeserializer<T> : XMLDeserializer<T> where T : class
    {
        public XMLXmlReaderDeserializer(string filePath) : base(filePath) { }
        protected override void Load()
        {
            using (var xmlr = XmlReader.Create(FilePath))
            {
                XmlDocument.Load(xmlr);
            }
        }
    }
}
