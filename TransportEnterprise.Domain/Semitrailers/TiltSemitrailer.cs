namespace TransportEnterprise.Models
{
    public class TiltSemitrailer : Semitrailer<Product>
    {
        public TiltSemitrailer(int id, decimal maxLoadWeight) : base(id, maxLoadWeight)
        {
            
        }
    }
}
