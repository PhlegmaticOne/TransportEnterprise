using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public interface IMaterialXmlFactory<out T> where T: Material
    {
        T CreateMaterial(XmlNode node);
    }
}
