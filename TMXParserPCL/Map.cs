using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace TMXParserPCL
{
    [XmlRoot(DataType="string", ElementName="map")]
    public class Map
    {
        #region Values

        [XmlAttribute(DataType = "string", AttributeName = "version")]
        public string Version { get; set; }
                  

        [XmlAttribute(AttributeName="orientation")]
        public Orientation Orientation { get; set; }
  
        [XmlAttribute(AttributeName = "renderorder")]
        public RenderOrder RenderOrder { get; set; }


        [XmlAttribute(DataType = "int", AttributeName = "width")]
        public int Width { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "height")]
        public int Height { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "tilewidth")]
        public int TileWidth { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "tileheight")]
        public int TileHeight { get; set; }


        [XmlAttribute(DataType = "int", AttributeName = "staggeraxis")]
        public int StaggerAxis { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "staggerindex")]
        public int StaggerIndex { get; set; }


        [XmlAttribute(DataType = "string", AttributeName = "backgroundcolor")]
        public string BackgroundColor { get; set; }


        [XmlAttribute(DataType = "int", AttributeName = "nextobjectid")]
        public int NextObjectID { get; set; }

        #endregion Values



        [XmlElement(ElementName = "properties")]
        public List<Property> Properties { get; set; }
        
        [XmlElement(ElementName = "tileset")]
        public List<TileSet> TileSets { get; set; }

        [XmlElement(ElementName = "layer")]
        public List<Layer> Layers { get; set; }                        

        [XmlElement(ElementName= "objectgroup")]
        public List<ObjectGroup> ObjectGroups { get; set; }     

        [XmlElement(ElementName = "imagelayer")]
        public ImageLayer ImageLayer { get; set; }

              
        public static Map Load(Stream fileStream)
        {     
            var serializer = new XmlSerializer(typeof(Map));
            var map = (Map) serializer.Deserialize(fileStream);

            foreach (var layer in map.Layers)
                layer.Data?.OnXmlDeserialization(layer.Width == 0 ? map.Width : layer.Width, layer.Height == 0 ? map.Height : layer.Height);

            foreach (var tileSet in map.TileSets)
                tileSet.Image?.Data?.OnXmlDeserialization(tileSet.Image.Width == 0 ? map.Width : tileSet.Image.Width, tileSet.Image.Height == 0 ? map.Height : tileSet.Image.Height);

            foreach (var tile in map.TileSets.SelectMany(tileSet => tileSet.Tiles))
                tile.Image?.Data?.OnXmlDeserialization(tile.Image.Width == 0 ? map.Width : tile.Image.Width, tile.Image.Height == 0 ? map.Height : tile.Image.Height);

            if(map.ImageLayer != null)
                foreach (var image in map.ImageLayer.Images)
                    image.Data?.OnXmlDeserialization(image.Width == 0 ? map.Width : image.Width, image.Height == 0 ? map.Height : image.Height);

            return map;
        }
    }

    public enum Orientation
    {
        [XmlEnum(Name = "orthogonal")]
        Orthogonal = 1,
        [XmlEnum(Name = "isometric")]
        Isometric = 2,
        [XmlEnum(Name = "staggered")]
        Staggered = 3,
        [XmlEnum(Name = "hexagonal")]
        Hexagonal = 4
    }

    public enum RenderOrder
    {
        [XmlEnum(Name = "right-down")]
        RightDown = 1,
        [XmlEnum(Name = "right-up")]
        RightUp = 2,
        [XmlEnum(Name = "left-down")]
        LeftDown = 3,
        [XmlEnum(Name = "left-up")]
        LeftUp = 4
    }
        
}