using System.Collections.Generic;
using System.Xml.Serialization;

namespace TmxMapperPCL
{
    public class Terrain
    {
        [XmlAttribute(DataType="string", AttributeName="name")]
        public string Name { get; set; }

        [XmlAttribute(DataType = "string", AttributeName = "tile")]
        public string Title { get; set; }



        [XmlElement(ElementName = "properties")]
        public List<Property> Properties { get; set; }    
    }
}
