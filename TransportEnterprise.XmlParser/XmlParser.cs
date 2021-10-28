using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.XmlParser
{
    public class XmlParser<T> : Parser<T> where T : class
    {
        protected XmlDocument _xmlDocument;
        protected readonly Type _type;
        public XmlParser(string filePath) : base(filePath)
        {
            _type = typeof(T);
            ConfigureFile(_type);
        }
        protected override Type WriterType => typeof(StreamWriter);
        protected override Type ReaderType => typeof(StreamReader);

        public override T Deserialize(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override T Deserialize()
        {
            throw new NotImplementedException();
        }
        public ICollection<T> DeserializeAll()
        {
            var result = new List<T>();
            foreach (XmlNode node in _xmlDocument.LastChild.ChildNodes)
            {
                result.Add(Activator.CreateInstance(_type, node.ChildNodes.ToList()) as T);
            }
            return result;
        }

        public override void Serialize(T entity)
        {
            using (var sw = Activator.CreateInstance(WriterType, FilePath) as StreamWriter)
            {
                var type = entity.GetType();
                var sb = new StringBuilder();
                sb.AppendLine($"\n\t<{type.Name}>");
                ToXml(sb, entity, 2);
                sb.AppendLine($"\t</{type.Name}>");

                var fragment = _xmlDocument.CreateDocumentFragment();
                fragment.InnerXml = sb.ToString();
                _xmlDocument.LastChild.AppendChild(fragment);
                _xmlDocument.Save(sw);
            }
        }
        private void ToXml(StringBuilder sb, object entity, int padding)
        {
            var entityType = entity.GetType();
            var assemblyName = Assembly.GetAssembly(entityType).FullName;
            var paddingTabs = new string('\t', padding);
            foreach (var prop in entityType.GetProperties())
            {
                if (prop.PropertyType.Name == "ICollection`1")
                {
                    sb.AppendLine($"{paddingTabs}<{prop.Name}>");
                    foreach (var innerEntity in prop.GetValue(entity) as IEnumerable)
                    {
                        var innerType = innerEntity.GetType();
                        if (innerType.IsValueType)
                        {
                            sb.AppendLine($"{paddingTabs}\t<{innerType.Name}>{innerEntity}</{innerType.Name}>");
                        }
                        else
                        {
                            ToXml(sb, innerEntity, ++padding);
                        }
                    }
                    sb.AppendLine($"{paddingTabs}</{prop.Name}>");
                }
                else
                {
                    if (Assembly.GetAssembly(prop.PropertyType).FullName != assemblyName)
                    {
                        var s = prop.GetValue(entity);
                        sb.AppendLine($"{paddingTabs}<{prop.Name}>{s}</{prop.Name}>");
                    }
                    else
                    {
                        sb.AppendLine($"{paddingTabs}<{prop.Name}>");
                        ToXml(sb, prop.GetValue(entity), ++padding);
                        sb.AppendLine($"{paddingTabs}</{prop.Name}>");
                    }
                }
            }
        }
        private void ConfigureFile(Type entityType)
        {
            _xmlDocument = new XmlDocument();
            if (File.Exists(FilePath) == false)
            {
                var declaration = _xmlDocument.CreateXmlDeclaration("1.0", null, null);
                var mainList = _xmlDocument.CreateElement($"{entityType.Name}s");
                _xmlDocument.AppendChild(declaration);
                _xmlDocument.AppendChild(mainList);
                using (var sw = Activator.CreateInstance(WriterType, FilePath) as StreamWriter)
                {
                    _xmlDocument.Save(sw.BaseStream);
                }
            }
            else
            {
                _xmlDocument.Load(FilePath);
            }
        }
    }
}
