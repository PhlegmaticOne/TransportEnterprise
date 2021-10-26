namespace TransportEnterprise.Models.TruckTractors
{
    public class ActrosMP3 : TruckTractor
    {
        public ActrosMP3(int id, Semitrailer<Product> semitrailer) : base(id, semitrailer)
        {
        }

        public override decimal PetrolPerHour => 1.05m + Semitrailer.CurrentLoading;
    }
}
