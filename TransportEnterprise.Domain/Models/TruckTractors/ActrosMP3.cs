namespace TransportEnterprise.Models
{
    public class ActrosMP3 : TruckTractor
    {
        public ActrosMP3()
        {
        }

        public ActrosMP3(Semitrailer semitrailer) : base(semitrailer) { }
        public override decimal PetrolPerHour => Semitrailer is null ? 0 : 1.05m + Semitrailer.CurrentLoading;
    }
}
