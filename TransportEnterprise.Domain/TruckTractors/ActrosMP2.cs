namespace TransportEnterprise.Models
{
    public class ActrosMP2 : TruckTractor
    {
        public ActrosMP2(Semitrailer semitrailer) : base(semitrailer) { }

        public override decimal PetrolPerHour => 1.1m * Semitrailer.LoadCapacity;
    }
}
