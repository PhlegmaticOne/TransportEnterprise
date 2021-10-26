namespace TransportEnterprise.Models
{
    public class ActrosMP2 : TruckTractor
    {
        public ActrosMP2(int id, Semitrailer<Product> semitrailer) : base(id, semitrailer) { }

        public override decimal PetrolPerHour => 1.1m * Semitrailer.LoadCapacity;
    }
}
