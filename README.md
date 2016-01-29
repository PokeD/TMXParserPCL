# PCL Tiled Map File Parser 
TMXParserPCL is C# library for parsing Tiled Map's TMX files.

## Usage:
```csharp
// -- Load a file how you want in PCL
var fileStream = File.Open("map.tmx", FileMode.Open);

var map = Map.Load(fileStream);


// If TileSet is an external file
var loadedExternalTileSets = new List<TileSet>();
var loadedImages = new List<Bitmap>();
foreach (var tileSet in map.TileSets)
{
  // -- Load a file how you want in PCL
  var fileStream = File.Open(tileSet.Source, FileMode.Open);
  
  var firstGID = tileSet.FirstGID;
  var serializer = new XmlSerializer(typeof(TileSet));
  var tileSetLoaded = (TileSet) serializer.Deserialize(fileStream);
  tileSetLoaded.FirstGID = firstGID;

  // -- Load a file how you want in PCL
  var pictureStream = File.Open(tileSet.Image.Source, FileMode.Open);
  var picture = new Bitmap(pictureStream);
  loadedImages.Add(picture);

  loadedExternalTileSets.Add(tileSetLoaded);
}
```

There isn't really an other way to load external TileSets, it's needed to be serialized second time
