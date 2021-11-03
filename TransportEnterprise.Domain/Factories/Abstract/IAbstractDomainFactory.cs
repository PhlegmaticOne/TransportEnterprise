namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Interface for abstract factories
    /// </summary>
    public interface IAbstractDomainFactory<out T> where T: class
    {
        /// <summary>
        /// Creates instance of specified type or any instance that inherits this type
        /// </summary>
        /// <returns></returns>
        T Create();
    }
}
