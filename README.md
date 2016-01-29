# PCL Tiled Map File Parser 
Tmx-Mapper-PCL is C# library for parsing Tiled Map's TMX files.

## Usage:
```csharp
var fileStream = File.Open("map.tmx", FileMode.Open);
var map = Map.Load(fileStream);
```
