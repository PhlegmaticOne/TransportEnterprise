using System;

namespace TransportEnterprise.Models
{
    [Serializable]
    public abstract class CustomerGood : Product
    {
        public CustomerGood(int id, decimal weight, string description) : base(id, weight, description)
        {
        }
    }
}
