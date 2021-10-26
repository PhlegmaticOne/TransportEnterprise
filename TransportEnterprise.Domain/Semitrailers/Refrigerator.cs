namespace TransportEnterprise.Models
{
    public class Refrigerator<T> : Semitrailer<T> where T : CustomerGood, ITempereratureDependent
    {
        public Refrigerator(int id, decimal maxLoadWeight) : base(id, maxLoadWeight) { }
    }
}
