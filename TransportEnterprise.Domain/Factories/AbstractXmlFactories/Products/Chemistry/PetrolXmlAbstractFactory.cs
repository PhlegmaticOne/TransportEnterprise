namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents petrol abstract factory 
    /// </summary>
    public class PetrolXmlAbstractFactory : XmlAbstractDomainFactory<Petrol>
    {
        /// <summary>
        /// Initializes new petrol xml abstract factory
        /// </summary>
        public PetrolXmlAbstractFactory() => InitializeFactories();
        /// <summary>
        /// Initiallizes petrol factories 
        /// </summary>
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "PetrolA92", new PetrolA92XmlFactory() },
                { "PetrolA95", new PetrolA95XmlFactory() },
                { "PetrolA98", new PetrolA98XmlFactory() },
                { "Diesel", new DieselXmlFactory() },
            };
        }
    }
}
