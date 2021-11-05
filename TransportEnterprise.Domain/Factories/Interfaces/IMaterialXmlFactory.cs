using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents contract for creating materials of differents types
    /// </summary>
    public interface IMaterialXmlFactory<out T> where T: Material
    {
        /// <summary>
        /// Creates material from xml node with material properies
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        T CreateMaterial(XmlNode node);
    }
}
