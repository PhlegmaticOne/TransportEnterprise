using System.IO;

namespace TransportEnterprise.XmlParser.Deserializers
{
    public class XMLStreamReaderDeserializer<T> : XMLDeserializer<T> where T : class
    {
        public XMLStreamReaderDeserializer(string filePath) : base(filePath) { }
        protected override void Load()
        {
            using (var sr = new StreamReader(FilePath))
            {
                XmlDocument.Load(sr);
            }
        }
    }
}
