namespace TransportEnterprise.Models.Interfaces
{
    /// <summary>
    /// Represents interface for objects with specified temperature rules
    /// </summary>
    public interface ITempereratureDependent
    {
        /// <summary>
        /// Temperature rule for object
        /// </summary>
        TemperatureRule TemperatureRule { get; }
    }
}
