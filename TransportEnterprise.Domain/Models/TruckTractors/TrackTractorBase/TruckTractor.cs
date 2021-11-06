using System;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents base truck tracktor instance
    /// </summary>
    public abstract class TruckTractor : IEquatable<TruckTractor>
    {
        public TruckTractor() : this(null) { }
        public TruckTractor(string serialNumber)
        {
            SerialNumber = serialNumber ?? Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Initializes new truck tracktor instance with specified semitrailer
        /// </summary>
        protected TruckTractor(Semitrailer semitrailer, string serialNumber) : this(serialNumber) => Semitrailer = semitrailer;
        /// <summary>
        /// Current semitrailer of current truck tractor instance
        /// </summary>
        public Semitrailer Semitrailer { get; protected set; }
        /// <summary>
        /// Gets petrol per hour of truck tractor
        /// </summary>
        public abstract decimal PetrolPerHour { get; }
        /// <summary>
        /// Serial number
        /// </summary>
        public string SerialNumber { get; }
        /// <summary>
        /// Changes semitrailer of current truck tractor to a new semitrailer
        /// </summary>
        public virtual void HookUp(Semitrailer newSemitrailer)
        {
            if(newSemitrailer is not null)
            {
                Semitrailer = newSemitrailer;
            }
        }
        /// <summary>
        /// Unhooks semitrailer from truck tracktor
        /// </summary>
        public void Unhook() => Semitrailer = null;
        /// <summary>
        /// Checks equality of other truck tractor with current truck tractor
        /// </summary>
        public bool Equals(TruckTractor other)
        {
            var possibleEquality = other.SerialNumber == SerialNumber &&
                                   other.PetrolPerHour == PetrolPerHour &&
                                   other.GetType() == GetType();
            return Semitrailer is not null ? Semitrailer.Equals(other.Semitrailer) && possibleEquality :
                                             possibleEquality;
        }
        /// <summary>
        /// Check equality of specified object with current truck tractor instance
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => Equals(obj as TruckTractor);
        /// <summary>
        /// Gets hash code of current trcuk tracktor instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => (int)(PetrolPerHour + Semitrailer.LoadCapacity);
        /// <summary>
        /// Gets string representation of current truck tractor instance
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format("{0}: {1}. Petrol consumption: {2:f4} l/h", GetType().Name, Semitrailer?.ToString(), PetrolPerHour);

    }
}
