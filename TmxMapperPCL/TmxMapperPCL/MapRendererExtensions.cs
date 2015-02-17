﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TmxMapperPCL
{
    public static class MapRendererExtensions
    {
        /// <summary>
        /// Get position of the tile in map
        /// </summary>
        /// <param name="map"></param>
        /// <param name="layer">Tile layer</param>
        /// <param name="tileNumber">Zero based tile index in Data collection</param>
        /// <returns>Tile position</returns>
        public static Image GetTileTarget(this Map map, Layer layer, int tileNumber)
        {
            if (layer.Data != null)
            {
                // Fix index to one based.
                tileNumber++;
                decimal tileTemp = (decimal)tileNumber / (decimal)map.Width;
                int mapY = (int)Math.Ceiling(tileTemp) - 1;
                int mapX = tileNumber - (layer.Width * mapY) - 1;

                Image tileImage = new Image
                {
                    X = mapX * map.TileWidth,
                    Y = mapY * map.TileHeight
                };
                return tileImage;
            }
            return null;
        }


        /// <summary>
        /// Get TileSet image
        /// </summary>
        /// <param name="tileSet"></param>
        /// <param name="tileGID">Tile's group ID<</param>
        /// <returns>Image position, name and other image attributes</returns>
        public static Image GetTileSetImage(this TileSet tileSet, int tileGID)
        {
            if (tileSet.Image != null)
            {
                int tileSetMapWidth = tileSet.Image.Width / tileSet.TileWidth;
                int tileSetMapHeight = tileSet.Image.Height / tileSet.TileHeight;
                int gid = tileGID - (tileSet.FirstGID - 1);

                decimal gidTemp = (decimal)gid / (decimal)tileSetMapWidth;
                int mapY = (int)Math.Ceiling(gidTemp) - 1;
                int mapX = gid - (tileSetMapWidth * mapY) - 1;

                Image tileImage = new Image
                {
                    X = mapX * tileSet.TileWidth,
                    Y = mapY * tileSet.TileHeight,
                    Source = tileSet.Image.Source,
                    Trans = tileSet.Image.Trans,
                    Format = tileSet.Image.Format,
                    Data = tileSet.Image.Data,
                };

                return tileImage;
            }
            return null;
        }

        /// <summary>
        /// Get tileset
        /// </summary>
        /// <param name="map"></param>
        /// <param name="tileGID">Tile's group ID</param>
        /// <returns>TileSet</returns>
        public static TileSet GetTileSet(this Map map, int tileGID)
        {
            if (tileGID == 0)
                return null;

            int tileSets = map.TileSets.Count;

            if (tileSets == 1)
                return map.TileSets[0];

            for (int m = 0; m < tileSets; m++)
            {
                if (map.TileSets[m].FirstGID == tileGID)
                    return map.TileSets[m];

                if (map.TileSets[m].FirstGID > tileGID)
                    return map.TileSets[m - 1];
            }

            return map.TileSets[tileSets - 1];
        }
    }
}