namespace TransportEnterprise.Models
{
    public class Refrigerator<T> : Semitrailer<T> where T : CustomerGood, ITempereratureDependent
    {
        public Refrigerator(decimal maxLoadWeight) : base(maxLoadWeight) { }
    }
}
