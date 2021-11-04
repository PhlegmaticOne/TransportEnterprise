using System;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents a container ship
    /// </summary>
    public class ContainerShip : Semitrailer, IEquatable<ContainerShip>
    {
        /// <summary>
        /// Initializes new container ship instance
        /// </summary>
        /// <param name="maxLoadWeight">Specified max load weight</param>
        /// <param name="maxLoadValue">Specified max load value</param>
        public ContainerShip(decimal maxLoadWeight, decimal maxLoadValue) : base(maxLoadWeight, maxLoadValue) => 
            _rules.AddRange((product) => product.Weight >= 100);
        /// <summary>
        /// Checks equality of two container ships
        /// </summary>
        public bool Equals(ContainerShip other) => base.Equals(other);
        /// <summary>
        /// Checks equality of current container ship with specified object
        /// </summary>
        public override bool Equals(object obj) => obj is ContainerShip ship && Equals(ship);
        /// <summary>
        /// Gets hash code of container ship
        /// </summary>
        public override int GetHashCode() => base.GetHashCode();
    }
}
