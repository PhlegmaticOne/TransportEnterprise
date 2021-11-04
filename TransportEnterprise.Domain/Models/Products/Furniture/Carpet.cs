namespace TransportEnterprise.Models
{
    public class Carpet : Furniture
    {
        public Carpet(decimal weight, decimal value, string description,
                     Material material, FurniturePurpose furniturePurpose) :
                     base(weight, value, description, material, furniturePurpose)
        {
        }
    }
}
