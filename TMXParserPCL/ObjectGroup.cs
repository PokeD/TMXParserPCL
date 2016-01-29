using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TMXParserPCL
{
    public class ObjectGroup
    {
        [XmlAttribute(DataType="string", AttributeName="name")]
        public string Name { get; set; }

        [XmlAttribute(DataType = "string", AttributeName = "color")]
        public string Color { get; set; }

        [Obsolete]
        [XmlAttribute(DataType = "int", AttributeName = "width")]
        public int Width { get; set; }

        [Obsolete]
        [XmlAttribute(DataType = "int", AttributeName = "height")]
        public int Height { get; set; }

        [XmlAttribute(DataType = "string", AttributeName = "opacity")]
        public string _opacity { get; set; }
        public bool Opacity { get { return _opacity != "0"; } set { _opacity = value ? "1" : "0"; } }

        [XmlAttribute(DataType = "string", AttributeName = "visible")]
        public string _visible { get; set; }
        public bool Visible { get { return _visible != "0"; } set { _visible = value ? "1" : "0"; } }

        [XmlAttribute(DataType = "int", AttributeName = "offsetx")]
        public int OffsetX { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "offsety")]
        public int OffsetY { get; set; }

        [XmlAttribute(AttributeName = "draworder")]
        public DrawOrder DrawOrder { get; set; }



        [XmlElement(ElementName = "properties")]
        public List<Property> Properties { get; set; }

        [XmlElement(ElementName = "object")]
        public List<Object> Objects { get; set; }     
    }

    public enum DrawOrder
    {
        [XmlEnum(Name = "topdown")]
        Topdown = 1,
        [XmlEnum(Name = "index")]
        Index = 2
    }
}
