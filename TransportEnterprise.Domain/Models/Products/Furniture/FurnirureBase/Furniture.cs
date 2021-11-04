using System.Drawing;

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
    public class Wardrobe : Furniture
    {
        public Wardrobe(decimal weight, decimal value, string description,
                        Material material, FurniturePurpose furniturePurpose) :
                        base(weight, value, description, material, furniturePurpose)
        {
        }
    }
    public class Carpet : Furniture
    {
        public Carpet(decimal weight, decimal value, string description,
                     Material material, FurniturePurpose furniturePurpose) :
                     base(weight, value, description, material, furniturePurpose)
        {
        }
    }
    public abstract class Material
    {
        protected Material(decimal price, Color color)
        {
            Price = price;
            Color = color;
        }
        public decimal Price { get; }
        public Color Color { get; }
    }
    public class Wood : Material
    {
        public Wood(decimal price, Color color, WoodType woodType) : base(price, color)
        {
            WoodType = woodType;
        }
        public WoodType WoodType { get; }
    }
    public class Textile : Material
    {
        public Textile(decimal price, Color color, TextileType textileType) : base(price, color)
        {
            TextileType = textileType;
        }

        public TextileType TextileType { get; }
    }
    public enum WoodType
    {
        Oak,
        Pine,
        Birch
    }
    public enum TextileType
    {
        Silk,
        Wool
    }
    public enum FurniturePurpose
    {
        Kitchen,
        Bedroom,
        Hall,
        Bathroom
    }
}
