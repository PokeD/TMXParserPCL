using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace TmxMapperPCL
{
    public class Data
    {
        [XmlAttribute(DataType = "string", AttributeName = "encoding")]
        public string Encoding { get; set; }

        [XmlAttribute(DataType = "string", AttributeName = "compression")]
        public string Compression { get; set; }

        [XmlElement(ElementName = "tile")]
        public List<DataTile> Tiles { get; set; } = new List<DataTile>();

        [XmlText]
        public string Value { get; set; }


        private Stream Decode()
        {
            Stream stream;

            if (Encoding != "base64")
                throw new Exception("TmxMapperPCL.Data: Only Base64-encoded data is supported.");

            var rawData = Convert.FromBase64String(Value);
            var memStream = new MemoryStream(rawData);

            if (Compression == "gzip")
                stream = new GZipInputStream(memStream);
            else if (Compression == "zlib")
                stream = new InflaterInputStream(memStream);
            else if (Compression != null)
                throw new Exception("TmxMapperPCL.Data: Unknown compression.");
            else
                stream = memStream;

            var outputStream = new MemoryStream();
            stream.CopyTo(outputStream);
            stream = outputStream;

            return stream;
        }
        public void OnXmlDeserialization(int width, int height)
        {
            switch (Encoding)
            {
                case null:
                    break;

                case "base64":
                    using (var decodeStream = Decode())
                    using (var br = new BinaryReader(decodeStream))
                    {
                        br.BaseStream.Position = 0;

                        for (var i = 0; i < width * height; i++)
                            Tiles.Add(new DataTile() { GID = br.ReadUInt32() });
                    }
                    break;

                case "csv":
                    foreach (var str in Value.Split(','))
                        Tiles.Add(new DataTile() { GID = uint.Parse(str.Trim()) });
                    break;

                default:
                    throw new Exception("TmxLayer: Unknown encoding.");
            }

            Value = string.Empty;
        }
    }

    public class DataTile
    {
        private const uint FLIPPED_HORIZONTALLY_FLAG = 0x80000000;
        private const uint FLIPPED_VERTICALLY_FLAG = 0x40000000;
        private const uint FLIPPED_DIAGONALLY_FLAG = 0x20000000;

        public bool HorizontalFlip => (uint.Parse(_gID) & FLIPPED_HORIZONTALLY_FLAG) != 0;
        public bool VerticalFlip => (uint.Parse(_gID) & FLIPPED_VERTICALLY_FLAG) != 0;
        public bool DiagonalFlip => (uint.Parse(_gID) & FLIPPED_DIAGONALLY_FLAG) != 0;


        [XmlAttribute(DataType = "string", AttributeName = "gid")]
        public string _gID { get; set; }
        public uint GID
        {
            get { return uint.Parse(_gID) & ~(FLIPPED_HORIZONTALLY_FLAG | FLIPPED_VERTICALLY_FLAG | FLIPPED_DIAGONALLY_FLAG); }
            set { _gID = value.ToString(CultureInfo.InvariantCulture); }
        }
    }

}
