namespace TransportEnterprise.Models.TruckTractors
{
    public class ActrosMP3 : TruckTractor
    {
        public ActrosMP3(int id, Semitrailer<Product> semitrailer) : base(id, semitrailer) { }
        public override decimal PetrolPerHour => 1.05m + Semitrailer.CurrentLoading;
        public override bool Equals(object obj) => obj is ActrosMP3 actros && Equals(actros);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => string.Format("ActrosMP3. {0}", base.ToString());
    }
}
