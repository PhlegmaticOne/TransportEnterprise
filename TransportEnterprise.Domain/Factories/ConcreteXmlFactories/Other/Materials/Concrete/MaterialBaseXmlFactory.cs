using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class MaterialBaseXmlFactory
    {
        protected static (decimal, Color) GetMaterialParameters(ICollection<XmlNode> nodes) =>
                         (decimal.Parse(nodes.GetInnerText("Price")),
                         Color.FromName(nodes.GetInnerText("Color")));
    }
}
