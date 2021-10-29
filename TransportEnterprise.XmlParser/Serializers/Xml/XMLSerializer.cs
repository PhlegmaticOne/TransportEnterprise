using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace TransportEnterprise.XmlParser.Serializers
{
    public abstract class XMLSerializer<T> : Serializer<T> where T : class
    {
        protected readonly string FilePath;
        protected readonly XmlDocument XmlDocument;
        public XMLSerializer(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException($"\"{nameof(filePath)}\" cannot be empty or white space.", nameof(filePath));
            }
            XmlDocument = new XmlDocument();
            FilePath = filePath;
            ConfigureFile();
        }
        protected abstract void Save();
        public override void Serialize(T entity)
        {
            var sb = new StringBuilder();
            var typeName = typeof(T).Name;
            sb.AppendLine($"\n\t<{typeName}>");
            ToXml(sb, entity, 2).AppendLine($"\t</{typeName}>");
            var fragment = XmlDocument.CreateDocumentFragment();
            fragment.InnerXml = sb.ToString();
            XmlDocument.LastChild.AppendChild(fragment);
            Save();
        }
        private StringBuilder ToXml(StringBuilder sb, object entity, int padding)
        {
            var entityType = entity.GetType();
            var assemblyName = Assembly.GetAssembly(entityType).FullName;
            var paddingTabs = new string('\t', padding);
            foreach (var prop in entityType.GetProperties())
            {
                if (prop.PropertyType.Name == "ICollection`1")
                {
                    var isFirstEntity = true;
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
                            sb.AppendLine($"{paddingTabs}\t<{innerType.Name}>");
                            ToXml(sb, innerEntity, (isFirstEntity) ? padding += 2 : padding);
                            sb.AppendLine($"{paddingTabs}\t</{innerType.Name}>");
                            isFirstEntity = false;
                        }
                    }
                    sb.AppendLine($"{paddingTabs}</{prop.Name}>");
                }
                else
                {
                    if (Assembly.GetAssembly(prop.PropertyType).FullName != assemblyName)
                    {
                        sb.AppendLine($"{paddingTabs}<{prop.Name}>{prop.GetValue(entity)}</{prop.Name}>");
                    }
                    else
                    {
                        sb.AppendLine($"{paddingTabs}<{prop.Name}>");
                        ToXml(sb, prop.GetValue(entity), ++padding);
                        sb.AppendLine($"{paddingTabs}</{prop.Name}>");
                    }
                }
            }
            return sb;
        }
        private void ConfigureFile()
        {
            if (File.Exists(FilePath) == false)
            {
                var declaration = XmlDocument.CreateXmlDeclaration("1.0", null, null);
                var mainList = XmlDocument.CreateElement($"{typeof(T).Name}s");
                XmlDocument.AppendChild(declaration);
                XmlDocument.AppendChild(mainList);
                Save();
            }
            else
            {
                XmlDocument.Load(FilePath);
            }
        }
    }
}