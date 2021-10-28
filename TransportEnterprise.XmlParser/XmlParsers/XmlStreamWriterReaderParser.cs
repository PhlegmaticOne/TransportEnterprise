using System;
using System.IO;

namespace TransportEnterprise.XmlParser
{
    public class XmlStreamWriterReaderParser<T> : XmlParser<T> where T : class
    {
        public XmlStreamWriterReaderParser(string filePath) : base(filePath) { }

        protected override Type WriterType => typeof(StreamWriter);
        protected override Type ReaderType => typeof(StreamReader);
    }
}
