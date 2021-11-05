namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents abstract factory for creating car parks
    /// </summary>
    public class CarParksXmlAbstractFactory : XmlAbstractDomainFactory<CarPark>
    {
        /// <summary>
        /// Abstract factory of semitrailers
        /// </summary>
        private readonly IXmlAbstractDomainFactory<Semitrailer> _semitrailersFactory;
        /// <summary>
        /// Abstract factory of truck tractors
        /// </summary>
        private readonly IXmlAbstractDomainFactory<TruckTractor> _truckTractorsFactory;
        /// <summary>
        /// Initializes new car par xml abstract factory instance
        /// </summary>
        /// <param name="semitrailersFactory">Specified factory of semitrailers</param>
        /// <param name="truckTractorsFactory">Specified factory of truck tractors</param>
        public CarParksXmlAbstractFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailersFactory,
                                          IXmlAbstractDomainFactory<TruckTractor> truckTractorsFactory)
        {
            _semitrailersFactory = semitrailersFactory;
            _truckTractorsFactory = truckTractorsFactory;
            InitializeFactories();
        }
        /// <summary>
        /// Initializes factories of car parks
        /// </summary>
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "CarPark", new CarParkXmlFactory(_semitrailersFactory, _truckTractorsFactory) },
            };
        }
    }
}
