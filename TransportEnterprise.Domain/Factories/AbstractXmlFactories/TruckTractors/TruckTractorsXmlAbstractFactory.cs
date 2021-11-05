namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents truck tractors abstract xml factory
    /// </summary>
    public class TruckTractorsXmlAbstractFactory : XmlAbstractDomainFactory<TruckTractor>
    {
        /// <summary>
        /// Semitrailers abstract xml factory
        /// </summary>
        private readonly IXmlAbstractDomainFactory<Semitrailer> _semitrailersXmlAbstractFactory;
        /// <summary>
        /// Initializes new truck tractors abstract xml factory
        /// </summary>
        /// <param name="semitrailersXmlAbstractFactory">Specified semitrailers factory</param>
        public TruckTractorsXmlAbstractFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailersXmlAbstractFactory)
        {
            _semitrailersXmlAbstractFactory = semitrailersXmlAbstractFactory;
            InitializeFactories();
        }
        /// <summary>
        /// Initialize all factories of types inherits truck tractors
        /// </summary>
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
