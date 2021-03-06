# PCL Tiled Map File Parser 
TMXParserPCL is C# library for parsing Tiled Map's TMX files.

[![nugetpkg](https://img.shields.io/badge/nuget-TMXParserPCL-orange.svg)](https://www.nuget.org/packages/TMXParserPCL/)

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
  
  var tileSetLoaded = TileSet.LoadExternal(fileStream, tileSet);

  // -- Load a file how you want in PCL
  var pictureStream = File.Open(tileSetLoaded.Image.Source, FileMode.Open);
  var picture = new Bitmap(pictureStream);
  loadedImages.Add(picture);

  loadedExternalTileSets.Add(tileSetLoaded);
}
```

There isn't really an other way to load external TileSets, it's needed to be serialized second time
