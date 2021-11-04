using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class FurnitureBaseXmlFactory : ProductsBaseXmlFactory
    {
        protected readonly IAbstractMaterialXmlFactory<Material> AbstractMaterialXmlFactory;

        public FurnitureBaseXmlFactory(IAbstractMaterialXmlFactory<Material> abstractMaterialXmlFactory)
        {
            AbstractMaterialXmlFactory = abstractMaterialXmlFactory;
        }
        protected (decimal, decimal, string, FurniturePurpose, Material) GetFurnitureParameters(ICollection<XmlNode> nodes)
        {
            var (weight, value, description) = GetProductParameters(nodes);
            var materialNode = nodes.GetNode("Material");
            return (weight, value, description, nodes.GetNode("FurniturePurpose").ToFurniturePurpose(),
                    AbstractMaterialXmlFactory.CreateMaterialFactory(materialNode).CreateMaterial(materialNode));
        }
    }
}
