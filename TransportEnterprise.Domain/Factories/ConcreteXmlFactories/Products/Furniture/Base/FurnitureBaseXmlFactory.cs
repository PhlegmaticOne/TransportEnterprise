using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    //public class FurnitureBaseXmlFactory : ProductsBaseXmlFactory
    //{
    //    public FurnitureBaseXmlFactory(XmlNode node) : base(node)
    //    {
    //    }
    //    protected sealed override void Intialize()
    //    {
    //        base.Intialize();
    //        var material = Nodes.GetNode("Material").ChildNodes.ToList();
    //        var materialPrice = material.GetInnerText("Price");
    //        var materialType = material.GetInnerText("MaterialType");
    //        var furniturePurpose = Nodes.GetNode("FurnirurePurpose").ToFurniturePurpose();
    //        ProductsParameters.Add("FurniturePurpose", furniturePurpose);
    //        ProductsParameters.Add("Price", materialPrice);
    //        ProductsParameters.Add("MaterialType", materialType);
    //    }
    //}
}
