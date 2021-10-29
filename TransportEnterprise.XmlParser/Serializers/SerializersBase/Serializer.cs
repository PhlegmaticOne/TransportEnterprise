namespace TransportEnterprise.XmlParser.Serializers
{
    public abstract class Serializer<T> where T: class
    {
        public abstract void Serialize(T entity);
    }
}
