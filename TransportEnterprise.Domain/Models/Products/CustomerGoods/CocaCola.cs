namespace TransportEnterprise.Models
{
    public class CocaCola : CustomerGood
    {
        public CocaCola(decimal weight, string description) : base(weight, description)
        {
        }
        public CocaCola(decimal weight, string description, CocaColaTaste taste) : this(weight, description)
        {
            ColaTaste = taste;
        }
        public CocaColaTaste ColaTaste { get; }
    }
    public enum CocaColaTaste
    {
        ClassicWithSugar,
        ClassicWithoutSugar,
        Orange,
        Vanilla,
        Lemon
    }
}
