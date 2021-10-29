using System.IO;

namespace TransportEnterprise.XmlParser.Serializers
{
    public class XMLStreamWriterSerializer<T> : XMLSerializer<T> where T : class
    {
        public XMLStreamWriterSerializer(string filePath) : base(filePath) { }
        protected override void Save()
        {
            using(var sw = new StreamWriter(FilePath))
            {
                XmlDocument.Save(sw);
            }
        }
    }
}
