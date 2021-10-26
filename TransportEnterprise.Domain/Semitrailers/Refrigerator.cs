using System;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class Refrigerator<T> : Semitrailer<T> where T : CustomerGood, ITempereratureDependent
    {
        public Refrigerator(int id, decimal maxLoadWeight) : base(id, maxLoadWeight) { }
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => string.Format("Refrigerator: {0}", base.ToString());
    }
}
