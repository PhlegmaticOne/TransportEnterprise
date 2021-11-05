using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents furniture base xml factory
    /// </summary>
    public class FurnitureBaseXmlFactory : ProductsBaseXmlFactory
    {
        /// <summary>
        /// Materials abstract xml factory
        /// </summary>
        protected readonly IAbstractMaterialXmlFactory<Material> AbstractMaterialXmlFactory;
        /// <summary>
        /// Initializes new furniture base xml factory
        /// </summary>
        /// <param name="abstractMaterialXmlFactory">Specified materials abstract xml factory</param>
        public FurnitureBaseXmlFactory(IAbstractMaterialXmlFactory<Material> abstractMaterialXmlFactory) => 
            AbstractMaterialXmlFactory = abstractMaterialXmlFactory;
        /// <summary>
        /// Gets properties values of furniture base type from xml node
        /// </summary>
        protected (decimal, decimal, string, FurniturePurpose, Material) GetFurnitureParameters(ICollection<XmlNode> nodes)
        {
            var (weight, value, description) = GetProductParameters(nodes);
            var materialNode = nodes.GetNode("Material");
            return (weight, value, description, nodes.GetNode("FurniturePurpose").ToFurniturePurpose(),
                    AbstractMaterialXmlFactory.CreateMaterialFactory(materialNode).CreateMaterial(materialNode));
        }
    }
}