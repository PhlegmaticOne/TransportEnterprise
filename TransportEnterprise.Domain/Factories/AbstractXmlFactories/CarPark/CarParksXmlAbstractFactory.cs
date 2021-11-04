using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public class CarParksXmlAbstractFactory : XmlAbstractDomainFactory<CarPark>
    {
        private readonly IXmlAbstractDomainFactory<Semitrailer> _semitrailersFactory;
        private readonly IXmlAbstractDomainFactory<TruckTractor> _truckTractorsFactory;

        public CarParksXmlAbstractFactory(IXmlAbstractDomainFactory<Semitrailer> semitrailersFactory,
                                          IXmlAbstractDomainFactory<TruckTractor> truckTractorsFactory)
        {
            _semitrailersFactory = semitrailersFactory;
            _truckTractorsFactory = truckTractorsFactory;
            InitializeFactories();
        }

        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "CarPark", new CarParkXmlFactory(_semitrailersFactory, _truckTractorsFactory) },
            };
        }
    }
}
