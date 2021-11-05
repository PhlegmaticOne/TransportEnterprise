using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents material base xml factory
    /// </summary>
    public class MaterialBaseXmlFactory
    {
        /// <summary>
        /// Gets properties values of material base type from xml node
        /// </summary>
        protected static (decimal, Color) GetMaterialParameters(ICollection<XmlNode> nodes) =>
                         (decimal.Parse(nodes.GetInnerText("Price")),
                         Color.FromName(nodes.GetInnerText("Color")));
    }
}
