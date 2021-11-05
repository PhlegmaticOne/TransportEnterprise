using System.Xml;

namespace TransportEnterprise.XmlParser.Serializers
{
    public class XMLXmlWriterSerializer<T> : XMLSerializer<T> where T : class
    {
        public XMLXmlWriterSerializer(string filePath) : base(filePath) { }
        protected override void Save()
        {
            using var xmlw = XmlWriter.Create(FilePath);
            XmlDocument.Save(xmlw);
        }
    }
}
