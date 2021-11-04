namespace TransportEnterprise.Models
{
    public class Wardrobe : Furniture
    {
        public Wardrobe(decimal weight, decimal value, string description,
                        Material material, FurniturePurpose furniturePurpose) :
                        base(weight, value, description, material, furniturePurpose)
        {
        }
    }
}
