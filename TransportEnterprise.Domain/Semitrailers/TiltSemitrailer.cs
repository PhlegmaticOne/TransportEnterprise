namespace TransportEnterprise.Models
{
    public class TiltSemitrailer : Semitrailer<Product>
    {
        public TiltSemitrailer(decimal maxLoadWeight) : base(maxLoadWeight)
        {
            
        }
    }
}
