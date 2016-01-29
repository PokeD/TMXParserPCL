using System.Xml.Serialization;

namespace TMXParserPCL
{     
    public class Property
    {
        [XmlAttribute(DataType = "string", AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(DataType = "string", AttributeName = "value")]
        public string Value { get; set; }
    }
}
