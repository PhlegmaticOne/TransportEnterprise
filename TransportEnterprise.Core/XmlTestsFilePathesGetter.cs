using System;
using System.IO;
using TransportEnterprise.Core;

namespace TransportEnterprise.Core
{
    public class XmlTestsFilePathesGetter : IFilePathesGetter
    {
        private readonly Type _type;
        public XmlTestsFilePathesGetter(Type type) => _type = type;
        public string GetFilePath() => $"{new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName}\\TestFiles\\{_type.Name}s.xml";
    }
}
