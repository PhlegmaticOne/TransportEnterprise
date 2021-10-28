using System;
using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models;
using TransportEnterprise.Models.Extensions;
using TransportEnterprise.Models.Factories;

namespace TransportEnterprise.XmlParser
{
    public class XmlChemistryParser : XmlStreamWriterReaderParser<Chemistry>
    {
        private readonly IChemistryFactory _chemistryFactory;

        public XmlChemistryParser(string filePath) : base(filePath) { }
        public XmlChemistryParser(string filePath, IChemistryFactory chemistryFactory) : this(filePath)
        {
            _chemistryFactory = chemistryFactory ?? throw new ArgumentNullException(nameof(chemistryFactory));
        }
        public override ICollection<Chemistry> DeserializeAll()
        {
            var result = new List<Chemistry>();
            foreach (XmlNode node in XmlDocument.LastChild.ChildNodes)
            {
                result.Add(_chemistryFactory.Create(node.ChildNodes.ToList()));
            }
            return result;
        }
    }
}
