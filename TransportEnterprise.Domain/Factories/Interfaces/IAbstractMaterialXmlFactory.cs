using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Contract for creating materials factories of different types 
    /// </summary>
    /// <typeparam name="T">Material</typeparam>
    public interface IAbstractMaterialXmlFactory<out T> where T: Material
    {
        /// <summary>
        /// Creates material factory
        /// </summary>
        /// <param name="node">XmlNode with material propertias in xml</param>
        /// <returns></returns>
        IMaterialXmlFactory<T> CreateMaterialFactory(XmlNode node);
    }
}
