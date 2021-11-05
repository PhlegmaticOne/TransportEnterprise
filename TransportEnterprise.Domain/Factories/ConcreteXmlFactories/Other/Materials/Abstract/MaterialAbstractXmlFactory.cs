using System.Collections.Generic;
using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Abstract materials xml factory 
    /// </summary>
    public class MaterialAbstractXmlFactory : IAbstractMaterialXmlFactory<Material>
    {
        /// <summary>
        /// Factories which are accessible by its generic type names
        /// </summary>
        private readonly Dictionary<string, IMaterialXmlFactory<Material>> MaterialFactories;
        /// <summary>
        /// Initializes new abstract materials xml factory 
        /// </summary>
        public MaterialAbstractXmlFactory()
        {
            MaterialFactories = new()
            {
                { "Wood", new WoodXmlFactory() },
                { "Textile", new TextileXmlFactory() }
            };
        }
        /// <summary>
        /// Gets material factory from xml node 
        /// </summary>
        public IMaterialXmlFactory<Material> CreateMaterialFactory(XmlNode node)
        {
            if (MaterialFactories.TryGetValue(node.Name, out IMaterialXmlFactory<Material> materialFactoryFromName))
            {
                return materialFactoryFromName;
            }
            if (MaterialFactories.TryGetValue(node.Attributes[0].Value, out IMaterialXmlFactory<Material> materialFactoryFromAttr))
            {
                return materialFactoryFromAttr;
            }
            return null;
        }
    }
}
