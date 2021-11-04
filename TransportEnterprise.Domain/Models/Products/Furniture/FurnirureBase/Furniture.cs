namespace TransportEnterprise.Models
{
    public abstract class Furniture : Product
    {
        protected Furniture(decimal weight, decimal value, string description,
                               Material material, FurniturePurpose furniturePurpose) :
                               base(weight, value, description)
        {
            Material = material;
            FurniturePurpose = furniturePurpose;
        }

        public Material Material { get; }
        public FurniturePurpose FurniturePurpose { get; }
    }
    public enum FurniturePurpose
    {
        Kitchen,
        Bedroom,
        Hall,
        Bathroom
    }
}
