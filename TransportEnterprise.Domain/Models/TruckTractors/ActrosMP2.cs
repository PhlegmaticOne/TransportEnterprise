namespace TransportEnterprise.Models
{
    public class ActrosMP2 : TruckTractor
    {
        public ActrosMP2()
        {
        }

        public ActrosMP2(Semitrailer semitrailer) : base(semitrailer) { }

        public override decimal PetrolPerHour => Semitrailer is null ? 0 : 1.1m * Semitrailer.LoadCapacity;
    }
}
