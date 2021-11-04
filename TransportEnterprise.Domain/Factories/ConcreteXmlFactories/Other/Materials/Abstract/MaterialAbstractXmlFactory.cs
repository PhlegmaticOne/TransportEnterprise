using System.Collections.Generic;
using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public class MaterialAbstractXmlFactory : IAbstractMaterialXmlFactory<Material>
    {
        private readonly Dictionary<string, IMaterialXmlFactory<Material>> MaterialFactories;
        public MaterialAbstractXmlFactory()
        {
            MaterialFactories = new()
            {
                { "Wood", new WoodXmlFactory() },
                { "Textile", new TextileXmlFactory() }
            };
        }
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
