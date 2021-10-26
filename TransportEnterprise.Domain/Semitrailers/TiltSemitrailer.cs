using System;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class TiltSemitrailer : Semitrailer<Product>
    {
        public TiltSemitrailer(int id, decimal maxLoadWeight) : base(id, maxLoadWeight)
        {
            
        }
    }
}
