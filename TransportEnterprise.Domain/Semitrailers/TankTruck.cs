namespace TransportEnterprise.Models
{
    public class TankTruck<T> : Semitrailer<T> where T : Chemistry, new()
    {
        public TankTruck(decimal maxLoadWeight) : base(maxLoadWeight) { }
    }
}
