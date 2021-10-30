namespace TransportEnterprise.Models.Factories
{
    public interface IDomainFactory<out T> where T: class
    {
        T Create();
    }
}
