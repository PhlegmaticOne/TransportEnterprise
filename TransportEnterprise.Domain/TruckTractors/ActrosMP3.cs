namespace TransportEnterprise.Models
{
    public class ActrosMP3 : TruckTractor
    {
        public ActrosMP3(Semitrailer semitrailer) : base(semitrailer) { }
        public override decimal PetrolPerHour => 1.05m + Semitrailer.CurrentLoading;
    }
}
