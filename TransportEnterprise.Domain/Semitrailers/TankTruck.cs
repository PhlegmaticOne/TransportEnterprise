using System;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class TankTruck<T> : Semitrailer<T> where T : Chemistry, new()
    {
        public TankTruck(int id, decimal maxLoadWeight) : base(id, maxLoadWeight) { }
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => string.Format("Tank truck: {0}", base.ToString());
    }
}
