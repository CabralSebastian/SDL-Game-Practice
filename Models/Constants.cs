using MyGame.Models.Map;
using System.Collections.Generic;

namespace MyGame.Models
{
    internal static class Constants
    {
        internal static float SquareRootOf3 = 1.732f;

        internal readonly static List<CubeCoordinate> CubeCoordinatesDirections = new List<CubeCoordinate>()
            {
                new CubeCoordinate(1,0), new CubeCoordinate(-1,0),
                new CubeCoordinate(0,1), new CubeCoordinate(0,-1),
                new CubeCoordinate(1,-1), new CubeCoordinate(-1, 1),
            };
    }
}
