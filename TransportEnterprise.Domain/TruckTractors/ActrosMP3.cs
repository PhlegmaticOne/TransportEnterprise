namespace TransportEnterprise.Models.TruckTractors
{
    public class ActrosMP3 : TruckTractor
    {
        public ActrosMP3(Semitrailer<Product> semitrailer) : base(semitrailer)
        {
        }

        public override decimal PetrolPerHour => 1.05m + Semitrailer.CurrentLoading;
    }
}
