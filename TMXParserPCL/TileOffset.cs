using System.Xml.Serialization;

namespace TMXParserPCL
{
    [XmlRoot(ElementName="tileoffset")]
    public class TileOffset
    {
        [XmlAttribute(DataType="int", AttributeName="x")]
        public int X { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "y")]
        public int Y { get; set; }
    }
}
