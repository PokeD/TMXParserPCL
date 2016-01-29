using System.Xml.Serialization;

namespace TMXParserPCL
{
    public class Image
    {
        [XmlAttribute(DataType = "string", AttributeName = "format")]
        public string Format { get; set; }

        [XmlAttribute(DataType = "string", AttributeName = "source")]
        public string Source { get; set; }

        [XmlAttribute(DataType = "string", AttributeName = "trans")]
        public string Trans { get; set; }

        [XmlAttribute(DataType="int", AttributeName="width")]
        public int Width { get; set; }
               
        [XmlAttribute(DataType="int", AttributeName="height")]
        public int Height { get; set; }



        [XmlElement(ElementName = "data")]
        public Data Data { get; set; }
    }
}
