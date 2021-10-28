using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace TransportEnterprise.XmlParser
{
    public abstract class XmlParser<T> : Parser<T> where T : class
    {
        protected string FilePath;
        protected abstract Type WriterType { get; }
        protected abstract Type ReaderType { get; }
        public XmlParser(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException($"\"{nameof(filePath)}\" не может быть пустым или содержать только пробел.", nameof(filePath));
            }

            FilePath = filePath;
            Type = typeof(T);
            ConfigureFile(Type);
        }
        protected XmlDocument XmlDocument;
        protected readonly Type Type;
        public override ICollection<T> DeserializeAll() => new List<T>();
        public override void Serialize(T entity)
        { 
            var sb = new StringBuilder();
            sb.AppendLine($"\n\t<{Type.Name}>");
            ToXml(sb, entity, 2).AppendLine($"\t</{Type.Name}>");

            var fragment = XmlDocument.CreateDocumentFragment();
            fragment.InnerXml = sb.ToString();
            XmlDocument.LastChild.AppendChild(fragment);

            using var sw = Activator.CreateInstance(WriterType, FilePath) as StreamWriter;
            XmlDocument.Save(sw);
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
                            ToXml(sb, innerEntity, (isFirstEntity) ? padding+=2 : padding);
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
        private void ConfigureFile(Type entityType)
        {
            XmlDocument = new XmlDocument();
            if (File.Exists(FilePath) == false)
            {
                var declaration = XmlDocument.CreateXmlDeclaration("1.0", null, null);
                var mainList = XmlDocument.CreateElement($"{entityType.Name}s");
                XmlDocument.AppendChild(declaration);
                XmlDocument.AppendChild(mainList);
                using (var sw = Activator.CreateInstance(WriterType, FilePath) as StreamWriter)
                {
                    XmlDocument.Save(sw.BaseStream);
                }
            }
            else
            {
                XmlDocument.Load(FilePath);
            }
        }
    }
}
