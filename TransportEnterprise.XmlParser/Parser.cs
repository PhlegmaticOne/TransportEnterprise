using System;

namespace TransportEnterprise.XmlParser
{
    public abstract class Parser<T> where T: class
    {
        protected string FilePath;
        protected abstract Type WriterType { get; }
        protected abstract Type ReaderType { get; }
        public Parser(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException($"\"{nameof(filePath)}\" не может быть пустым или содержать только пробел.", nameof(filePath));
            }

            FilePath = filePath;
        }
        public abstract void Serialize(T entity);
        public abstract T Deserialize(Func<T, bool> predicate);
        public abstract T Deserialize();
    }
}
