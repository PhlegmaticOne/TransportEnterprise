using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    public class Milk : CustomerGood, ITempereratureDependent
    {
        public Milk(decimal weight, string description) : base(weight, description)
        {
        }

        public TemperatureRule TemperatureRule => new(-10, 0);

        public Milk(ICollection<XmlNode> props) : base (props)
        {
        }
    }
}
