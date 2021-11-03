namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents ActrosMP2 trcuk tractor instance 
    /// </summary>
    public class ActrosMP2 : TruckTractor
    {
        public ActrosMP2() { }

        public ActrosMP2(string serialNumber) : base(serialNumber)
        {
        }

        /// <summary>
        /// Initializes new ActrosMP2 instance with specified semitrailer
        /// </summary>
        /// <param name="semitrailer"></param>
        public ActrosMP2(Semitrailer semitrailer, string serialNumber) : base(semitrailer, serialNumber) { }
        /// <summary>
        /// Overrides petrol per hour
        /// </summary>
        public override decimal PetrolPerHour => Semitrailer is null ? 0 : 1.1m * Semitrailer.LoadCapacity;
    }
}
