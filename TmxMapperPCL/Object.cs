using System.Collections.Generic;
using System.Xml.Serialization;

namespace TmxMapperPCL
{
    public class Object
    {
        [XmlAttribute(DataType = "int", AttributeName = "id")]
        public int ID { get; set; }

        [XmlAttribute(DataType = "string", AttributeName = "name")]
        public string Name { get; set; }
                
        [XmlAttribute(DataType = "string", AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "x")]
        public int X { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "y")]
        public int Y { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "width")]
        public int Width { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "height")]
        public int Height { get; set; }

        [XmlAttribute(DataType = "int", AttributeName = "rotation")]
        public int Rotation { get; set; }
        
        [XmlAttribute(DataType = "int", AttributeName = "gid")]
        public int GID { get; set; }

        [XmlAttribute(DataType = "string", AttributeName = "visible")]
        private string _visible { get; set; }
        public bool Visible { get { return _visible != "0"; } set { _visible = value ? "1" : "0"; } }



        [XmlElement(ElementName = "properties")]
        public List<Property> Properties { get; set; }

        [XmlElement(ElementName = "ellipse")]
        public Ellipse Ellipse { get; set; }

        [XmlElement(ElementName = "polygon")]
        public Polygon Polygon { get; set; }

        [XmlElement(ElementName= "polyline")]
        public Polyline Polyline { get; set; }
        
        [XmlElement(ElementName = "image")]
        public Image Image { get; set; }
    }

    public class Ellipse
    {

    }

    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class Polygon
    {
        [XmlAttribute(DataType="string", AttributeName= "points")]
        public string Data { get; set; }

        public List<Coord> Points
        {
            get
            {
                if(string.IsNullOrEmpty(Data))
                    return new List<Coord>();

                var list = new List<Coord>();

                var points = Data.Split(',');
                for (var i = 0; i < points.Length; i += 2)
                    list.Add( new Coord() { X = int.Parse(points[i]), Y = int.Parse(points[i + 1]) });

                return list;
            }
        }
    }

    public class Polyline
    {
        [XmlAttribute(DataType = "string", AttributeName = "points")]
        public string Data { get; set; }

        public List<Coord> Points
        {
            get
            {
                if (string.IsNullOrEmpty(Data))
                    return new List<Coord>();

                var list = new List<Coord>();

                var points = Data.Split(',');
                for (var i = 0; i < points.Length; i += 2)
                    list.Add(new Coord() { X = int.Parse(points[i]), Y = int.Parse(points[i + 1]) });

                return list;
            }
        }
    }
}
