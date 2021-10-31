using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TransportEnterprise.Models.Factories;
using TransportEnterprise.Models.Factories.AbstractXmlFactories;

namespace TransportEnterprise.XmlParser.Deserializers
{
    public abstract class XMLDeserializer<T> : Deserializer<T> where T: class
    {
        protected readonly XmlDocument XmlDocument;
        protected readonly string FilePath;
        private readonly IXmlAbstractDomainFactoriesFactory _abstractDomainFactoriesFactory;

        public XMLDeserializer(string filePath, IXmlAbstractDomainFactoriesFactory abstractDomainFactoriesFactory)
        {
            if(File.Exists(filePath) == false)
            {
                throw new FileNotFoundException("File does not exist", filePath);
            }
            FilePath = filePath;
            _abstractDomainFactoriesFactory = abstractDomainFactoriesFactory;
            XmlDocument = new XmlDocument();
            Load();
        }
        protected abstract void Load();
        public override ICollection<T> All()
        {
            var result = new List<T>();
            foreach (XmlNode entity in XmlDocument.LastChild.ChildNodes)
            {
                var factory = _abstractDomainFactoriesFactory.CreateFactory<T>(entity);
                result.Add(factory.Create());
            }
            return result;
        }
        public override T FirstOrDefault(Func<T, bool> predicate)
        {
            foreach (var entity in All())
            {
                if (predicate.Invoke(entity))
                {
                    return entity;
                }
            }
            return null;
        }
        public override ICollection<T> Where(Func<T, bool> predicate)
        {
            var result = new List<T>();
            foreach (var entity in All())
            {
                if (predicate.Invoke(entity))
                {
                    result.Add(entity);
                }
            }
            return result;
        }
    }
}