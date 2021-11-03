namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Interface for creating domain models
    /// </summary>
    public interface IDomainFactory<out T> where T: class
    {
        /// <summary>
        /// Creates new domain entity
        /// </summary>
        /// <returns></returns>
        T Create();
    }
}
