using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TransportEnterprise.Models;
using TransportEnterprise.Models.Repositories;

namespace TransportEnterprise.XmlDataAccess
{
    public class XmlRepository<TWriter, TReader, TEntity> : IRepository<TEntity>
                                                            where TWriter : Stream
                                                            where TReader: Stream
                                                            where TEntity : BaseDomainModel
    {
        private readonly string DirectoryPath;
        private readonly XmlSerializer XmlSerializer;
        public XmlRepository(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                throw new ArgumentException($"\"{nameof(directoryPath)}\" cannot be empty or white space.", nameof(directoryPath));
            }
            if (Directory.Exists(directoryPath) == false)
            {
                Directory.CreateDirectory(directoryPath);
            }
            DirectoryPath = directoryPath;
            XmlSerializer = new XmlSerializer(typeof(TEntity));
        }
        public void Add(TEntity entity)
        {
            var serializingFileName = DirectoryPath + entity.Id;
            using var sw = Activator.CreateInstance(typeof(TWriter), serializingFileName) as TWriter;
            XmlSerializer.Serialize(sw, entity);
        }

        public LoadingResult<TEntity> Load(int id)
        {
            using (var sr = Activator.CreateInstance(typeof(TReader)) as TReader)
            {
                var deserializingFileName = DirectoryPath + id.ToString();
                if (File.Exists(deserializingFileName))
                {
                    using var fs = File.OpenRead(deserializingFileName);
                    return new LoadingResult<TEntity>((TEntity)XmlSerializer.Deserialize(fs), LoadingResultType.Succesfull);
                }
            }
            return new LoadingResult<TEntity>(null, LoadingResultType.EntityNotFound);
        }

        public ICollection<TEntity> LoadAll()
        {
            var result = new List<TEntity>();
            foreach (var serializedEntity in Directory.GetFiles(DirectoryPath, "*.xml"))
            {
                using var sr = Activator.CreateInstance(typeof(TReader)) as TReader;
                result.Add(XmlSerializer.Deserialize(sr) as TEntity);
            }
            return result;
        }

        public void Update(int id, TEntity newEntity)
        {
            var deserializingFileName = DirectoryPath + id.ToString();
            if (File.Exists(deserializingFileName) == false || id != newEntity.Id)
            {
                return;
            }
            File.Delete(deserializingFileName);
            Add(newEntity);
        }
    }
}