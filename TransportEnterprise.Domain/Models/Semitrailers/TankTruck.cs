using System;
using System.Linq;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents tank truck semitraile instance
    /// </summary>
    public class TankTruck : Semitrailer, IEquatable<TankTruck>
    {
        /// <summary>
        /// Initializes new tank truck instance with specified max load capacity
        /// </summary>
        public TankTruck(decimal maxLoadWeight, decimal maxValueCapacity) : base(maxLoadWeight, maxValueCapacity) => 
            _rules.AddRange( (product) => product is Chemistry,
                             (product) => !Products.Any() || Products.First().GetType() == product.GetType());
        /// <summary>
        /// Checks equality of tank trucks
        /// </summary>
        public bool Equals(TankTruck other) => base.Equals(other);
        /// <summary>
        /// Checks equality of current tank truck with specified object
        /// </summary>
        public override bool Equals(object obj) => obj is TankTruck tank && Equals(tank);
        /// <summary>
        /// Gets hash code of tank truck
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}
