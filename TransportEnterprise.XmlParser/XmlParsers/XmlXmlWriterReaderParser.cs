using System;
using System.Xml;

namespace TransportEnterprise.XmlParser
{
    public class XmlXmlWriterReaderParser<T> : XmlParser<T> where T : class
    {
        public XmlXmlWriterReaderParser(string filePath) : base(filePath) { }

        protected override Type WriterType => typeof(XmlWriter);
        protected override Type ReaderType => typeof(XmlReader);
    }
}
