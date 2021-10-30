namespace TransportEnterprise.Models.Factories
{
    public interface IAbstractDomainFactory<out T> where T: class
    {
        T Create();
    }
}
