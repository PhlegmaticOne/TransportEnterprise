using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public interface IAbstractMaterialXmlFactory<out T> where T: Material
    {
        IMaterialXmlFactory<T> CreateMaterialFactory(XmlNode node);
    }
}
