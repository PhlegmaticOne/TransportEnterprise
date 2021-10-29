using System.IO;
using TransportEnterprise.Models.Factories;

namespace TransportEnterprise.XmlParser.Deserializers.Xml
{
    public class XMLStreamReaderDeserializer<T> : XMLDeserializer<T> where T : class
    {
        public XMLStreamReaderDeserializer(string filePath, IDomainFactory<T> factory) : base(filePath, factory) { }
        protected override void Load()
        {
            using (var sr = new StreamReader(FilePath))
            {
                XmlDocument.Load(sr);
            }
        }
    }
}
