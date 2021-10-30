using System;

namespace TransportEnterprise.Models
{
    public abstract class CustomerGood : Product, IEquatable<CustomerGood>
    {
        public CustomerGood(decimal weight, string description) : base(weight, description)
        {
        }
        public bool Equals(CustomerGood other) => Weight == other.Weight && Description == other.Description;
        public override bool Equals(object obj) => obj is CustomerGood product && Equals(product);
        public override int GetHashCode() => base.GetHashCode();
    }
}
