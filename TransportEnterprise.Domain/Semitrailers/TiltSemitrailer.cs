using System;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class TiltSemitrailer : Semitrailer<Product>
    {
        public TiltSemitrailer(int id, decimal maxLoadWeight) : base(id, maxLoadWeight) { }
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => string.Format("Tilt semitrailer: {0}", base.ToString());
    }
}
