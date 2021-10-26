namespace TransportEnterprise.Models
{
    public abstract class CustomerGood : Product
    {
        protected CustomerGood(decimal weight, string description) : base(weight, description)
        {
        }
    }
}
