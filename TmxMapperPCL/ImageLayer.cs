using System.Collections.Generic;
using System.Xml.Serialization;

namespace TmxMapperPCL
{
    public class ImageLayer
    {
        [XmlAttribute(DataType="string", AttributeName="name")]
        public string Name { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "offsetx")]
        public int OffsetX { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "offsety")]
        public int OffsetY { get; set; }

        /*
        [XmlAttribute(DataType = "int", AttributeName = "x")]
        public int X { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "y")]
        public int Y { get; set; }
        */

        [XmlAttribute(DataType = "string", AttributeName = "opacity")]
        public string _opacity { get; set; }
        public bool Opacity { get { return _opacity != "0"; } set { _opacity = value ? "1" : "0"; } }

        [XmlAttribute(DataType = "string", AttributeName = "visible")]
        public string _visible { get; set; }
        public bool Visible { get { return _visible != "0"; } set { _visible = value ? "1" : "0"; } }



        [XmlElement(ElementName = "properties")]
        public List<Property> Properties { get; set; }

        [XmlElement(ElementName = "image")]
        public List<Image> Images { get; set; }
    }
}
