namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents ActrosMP3 instance
    /// </summary>
    public class ActrosMP3 : TruckTractor
    {
        public ActrosMP3() { }

        public ActrosMP3(string serialNumber) : base(serialNumber)
        {
        }

        /// <summary>
        /// Initializes new ActrosMP3 instance with specified semitrailer
        /// </summary>
        /// <param name="semitrailer"></param>
        public ActrosMP3(Semitrailer semitrailer, string serialNumber) : base(semitrailer, serialNumber) { }
        /// <summary>
        /// Overrides petrol per hour 
        /// </summary>
        public override decimal PetrolPerHour => Semitrailer is null ? 0 : 1.05m * Semitrailer.CurrentLoading;
    }
}
