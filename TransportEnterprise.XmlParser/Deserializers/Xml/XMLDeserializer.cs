using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TransportEnterprise.Models.Factories;

namespace TransportEnterprise.XmlParser.Deserializers
{
    public abstract class XMLDeserializer<TEntity, TBaseType> : Deserializer<TEntity>
                                                                where TEntity : class, TBaseType
                                                                where TBaseType: class
    {
        protected readonly XmlDocument XmlDocument;
        protected readonly string FilePath;
        private readonly IXmlAbstractDomainFactory<TBaseType> _xmlAbstractDomainFactory;

        public XMLDeserializer(string filePath, IXmlAbstractDomainFactory<TBaseType> xmlAbstractDomainFactory)
        {
            if(File.Exists(filePath) == false)
            {
                throw new FileNotFoundException("File does not exist", filePath);
            }
            FilePath = filePath;
            _xmlAbstractDomainFactory = xmlAbstractDomainFactory;
            XmlDocument = new XmlDocument();
            Load();
        }
        protected abstract void Load();
        public override ICollection<TEntity> All()
        {
            var result = new List<TEntity>();
            foreach (XmlNode entity in XmlDocument.LastChild.ChildNodes)
            {
                result.Add(_xmlAbstractDomainFactory.GetFactory(entity).Create(entity) as TEntity);
            }
            return result;
        }
        public override TEntity FirstOrDefault(Func<TEntity, bool> predicate)
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
        public override ICollection<TEntity> Where(Func<TEntity, bool> predicate)
        {
            var result = new List<TEntity>();
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