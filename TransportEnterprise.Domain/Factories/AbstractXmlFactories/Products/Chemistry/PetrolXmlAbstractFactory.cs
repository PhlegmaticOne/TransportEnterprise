namespace TransportEnterprise.Models.Factories
{
    public class PetrolXmlAbstractFactory : XmlAbstractDomainFactory<Petrol>
    {
        public PetrolXmlAbstractFactory() => InitializeFactories();
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
