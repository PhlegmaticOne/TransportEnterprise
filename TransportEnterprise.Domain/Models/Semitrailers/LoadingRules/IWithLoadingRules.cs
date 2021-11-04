namespace TransportEnterprise.Models
{
    /// <summary>
    /// Interface for semitrailers for implementing adding new products rules
    /// </summary>
    public interface IWithLoadingRules
    {
        /// <summary>
        /// Gets loading rules for adding a new product
        /// </summary>
        LoadingRules GetLoadingRules();
    }
}
