using System;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class TankTruck<T> : Semitrailer<T> where T : Chemistry, new()
    {
        public TankTruck(int id, decimal maxLoadWeight) : base(id, maxLoadWeight) { }
    }
}
