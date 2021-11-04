namespace TransportEnterprise.Models
{
    public class ContainerShip : Semitrailer
    {
        public ContainerShip(decimal maxLoadWeight, decimal maxLoadValue) : base(maxLoadWeight, maxLoadValue)
        {
            _rules.AddRange((product) => product is Furniture);
        }
    }
}
