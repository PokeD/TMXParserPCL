using System.Collections.Generic;
using System.Xml.Serialization;

namespace TmxMapperPCL
{
    public class Frame
    {
        [XmlAttribute(DataType = "int", AttributeName = "tileid")]
        public int TileID { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "duration")]
        public int Duration { get; set; }
    }

    public class Tile
    {
        [XmlAttribute(DataType="string", AttributeName="id")]      
        public string ID { get; set; }
       
        [XmlElement(ElementName = "terrain")]
        public Terrain Terrain { get; set; }

        [XmlAttribute(DataType = "string", AttributeName = "probability")]
        public string Probability { get; set; }



        [XmlElement(ElementName = "properties")]
        public List<Property> Properties { get; set; }

        [XmlElement(ElementName = "image")]
        public Image Image { get; set; }

        [XmlElement(ElementName = "objectgroup")]
        public List<ObjectGroup> ObjectGroups { get; set; }

        [XmlElement(ElementName = "animation")]
        public List<Frame> Animations { get; set; }
    }
}
