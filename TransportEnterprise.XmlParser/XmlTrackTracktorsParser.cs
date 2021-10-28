using TransportEnterprise.Models;

namespace TransportEnterprise.XmlParser
{
    public class XmlTrackTracktorsParser : XmlStreamWriterReaderParser<TruckTractor>
    {
        public XmlTrackTracktorsParser(string filePath) : base(filePath)
        {
        }
    }
}
