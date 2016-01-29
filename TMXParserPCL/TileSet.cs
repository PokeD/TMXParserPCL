using System.Collections.Generic;
using System.Xml.Serialization;

namespace TMXParserPCL
{
    [XmlRoot(ElementName = "tileset")]  
    public class TileSet
    {
        [XmlAttribute(DataType="int", AttributeName="firstgid")]
        public int FirstGID { get; set; }

        [XmlAttribute(DataType="string", AttributeName="source")]
        public string Source { get; set; }
        
        [XmlAttribute(DataType="string", AttributeName="name")]
        public string Name { get; set; }
        
        [XmlAttribute(DataType = "int", AttributeName = "tilewidth")]
        public int TileWidth { get; set; }
        
        [XmlAttribute(DataType = "int", AttributeName = "tileheight")]
        public int TileHeight { get; set; }
        
        [XmlAttribute(DataType = "int", AttributeName = "spacing")]
        public int Spacing { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "margin")]
        public int Margin { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "tilecount")]
        public int Tilecount { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "columns")]
        public int Columns { get; set; }



        [XmlElement(ElementName = "tileoffset")]
        public TileOffset TileOffset { get; set; }

        [XmlElement(ElementName = "properties")]
        public List<Property> Properties { get; set; }

        [XmlElement(ElementName = "image")]
        public Image Image { get; set; }

        [XmlElement(ElementName = "terraintypes")]
        public List<Terrain> TerrainTypes { get; set; }

        [XmlElement(ElementName = "tile")]
        public List<Tile> Tiles { get; set; }
    }
}
