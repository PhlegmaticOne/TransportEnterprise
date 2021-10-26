using System;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class Refrigerator<T> : Semitrailer<T> where T : CustomerGood, ITempereratureDependent
    {
        public Refrigerator(int id, decimal maxLoadWeight) : base(id, maxLoadWeight) { }
    }
}
