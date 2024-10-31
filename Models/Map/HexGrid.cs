using System.Collections.Generic;
using System.Linq;

namespace MyGame.Models.Map
{
    internal class HexGrid
    {
        internal readonly int TILE_SIZE = Program.Content.GetImage("hex_grass").Height / 2;
        private const int WIDTH = 10;
        private const int HEIGHT = 10;

        internal readonly Dictionary<CubeCoordinate, HexTile> Tiles;
        internal readonly Dictionary<CubeCoordinate, ScreenPosition> Positions;

        internal HexGrid()
        {
            Tiles = new Dictionary<CubeCoordinate, HexTile>();
            Positions = new Dictionary<CubeCoordinate, ScreenPosition>();

            for (int i = 0; i < WIDTH; i++)
                for (int j = 0; j < HEIGHT; j++)
                {
                    CubeCoordinate coordinate = new CubeCoordinate(i - j / 2, j);
                    //coordinate.CalculateNeighbours();

                    Tiles.Add(coordinate, new HexTile());
                    Positions.Add(coordinate, CubeCoordinateToScreenPosition(coordinate));
                }
        }

        internal HexTile GetTile(CubeCoordinate coordinate)
        {
            return Tiles[coordinate];
        }

        internal CubeCoordinate GetCoordinate(ScreenPosition position)
        {
            List<(ScreenPosition, CubeCoordinate)> HexTilesCenters = Positions.Select(KeyValuePair => (KeyValuePair.Value, KeyValuePair.Key)).ToList();

            return HexTilesCenters
                .OrderBy(tuple => position.DistanceTo(tuple.Item1 + new ScreenPosition(Constants.SquareRootOf3 / 2 * TILE_SIZE, TILE_SIZE)))
                .First().Item2;
        }

        internal HexTile GetTile(ScreenPosition position)
        {
            CubeCoordinate coordinate = GetCoordinate(position);

            return GetTile(coordinate);
        }

        /*
        internal ScreenPosition GetPosition(CubeCoordinate coordinate)
        {
            return Positions[coordinate];
        }
        */

        private ScreenPosition CubeCoordinateToScreenPosition(CubeCoordinate coordinate)
        {
            return new ScreenPosition()
            {
                x = Constants.SquareRootOf3 * TILE_SIZE * (coordinate.q + (float)coordinate.r / 2),
                y = 1.5f * TILE_SIZE * coordinate.r
            };
        }

    }
}
