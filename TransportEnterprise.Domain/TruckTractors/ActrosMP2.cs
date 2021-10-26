namespace TransportEnterprise.Models
{
    public class ActrosMP2 : TruckTractor
    {
        public ActrosMP2(int id, Semitrailer<Product> semitrailer) : base(id, semitrailer) { }

        public override decimal PetrolPerHour => 1.1m * Semitrailer.LoadCapacity;
        public override bool Equals(object obj) => obj is ActrosMP2 actros && Equals(actros);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => string.Format("ActrosMP2. {0}", base.ToString());
    }
}
