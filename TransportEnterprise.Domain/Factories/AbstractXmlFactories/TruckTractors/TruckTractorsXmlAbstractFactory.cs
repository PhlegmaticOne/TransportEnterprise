namespace TransportEnterprise.Models.Factories
{
    public class TruckTractorsXmlAbstractFactory : XmlAbstractDomainFactory<TruckTractor>
    {
        private readonly IXmlAbstractDomainFactory<Semitrailer> _semitrailersXmlAbstractFactory;

        public TruckTractorsXmlAbstractFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailersXmlAbstractFactory)
        {
            _semitrailersXmlAbstractFactory = semitrailersXmlAbstractFactory;
            InitializeFactories();
        }
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "ActrosMP2", new ActrosMP2XmlFactory(_semitrailersXmlAbstractFactory) },
                { "ActrosMP3", new ActrosMP3XmlFactory(_semitrailersXmlAbstractFactory) }
            };
        }
    }
}
