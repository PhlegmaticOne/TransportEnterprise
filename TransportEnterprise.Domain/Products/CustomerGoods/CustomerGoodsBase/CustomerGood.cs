using System;

namespace TransportEnterprise.Models
{
    [Serializable]
    public abstract class CustomerGood : Product, IEquatable<CustomerGood>
    {
        public CustomerGood(int id, decimal weight, string description) : base(id, weight, description)
        {
        }
        public bool Equals(CustomerGood other) => base.Equals(other);
        public override bool Equals(object obj) => obj is CustomerGood product && Equals(product);
        public override int GetHashCode() => base.GetHashCode();
    }
}
