using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace TransportEnterprise.Models
{
    public abstract class CustomerGood : Product, IEquatable<CustomerGood>
    {
        public CustomerGood(decimal weight, string description) : base(weight, description)
        {
        }
        public CustomerGood(ICollection<XmlNode> props)
        {
            Weight = decimal.Parse(props.First(p => p.OuterXml.Contains("Weight")).InnerText);
            Description = props.First(p => p.OuterXml.Contains("Description")).InnerText;
        }
        public bool Equals(CustomerGood other) => Weight == other.Weight && Description == other.Description;
        public override bool Equals(object obj) => obj is CustomerGood product && Equals(product);
        public override int GetHashCode() => base.GetHashCode();
    }
}
