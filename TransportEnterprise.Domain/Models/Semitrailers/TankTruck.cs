using System.Linq;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents tank truck semitraile instance
    /// </summary>
    public class TankTruck : Semitrailer
    {
        /// <summary>
        /// Initializes new tank truck instance with specified max load capacity
        /// </summary>
        public TankTruck(decimal maxLoadWeight, decimal maxValueCapacity) : base(maxLoadWeight, maxValueCapacity)
        {
            _rules.AddRange(
                (product) => product is Chemistry,
                (product) => !Products.Any() || Products.First().GetType() == product.GetType()
            );
        }
    }
}
