using System;

namespace TransportEnterprise.Models
{
    public class CocaCola : CustomerGood, IEquatable<CocaCola>
    {
        /// <summary>
        /// Initializes new coca cola instance
        /// </summary>
        /// <param name="weight">Specified weight</param>
        /// <param name="description">Description</param>
        /// <param name="cocaColaTaste">Specified coca cola taste</param>
        public CocaCola(decimal weight, decimal value, string description, CocaColaTaste cocaColaTaste) : base(weight, value, description)
        {
            ColaTaste = cocaColaTaste;
        }
        /// <summary>
        /// Coca cola taste
        /// </summary>
        public CocaColaTaste ColaTaste { get; }
        /// <summary>
        /// Check equality of specified coca cola instance with current coca cola instance
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CocaCola other) => ColaTaste == other.ColaTaste && base.Equals(other);

        public override bool Equals(object obj) => Equals(obj as CocaCola);

        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => string.Format("{0}. {1}", ColaTaste, base.ToString());
    }
    /// <summary>
    /// Represents taste of coca cola
    /// </summary>
    public enum CocaColaTaste
    {
        ClassicWithSugar,
        ClassicWithoutSugar,
        Orange,
        Vanilla,
        Lemon
    }
}
