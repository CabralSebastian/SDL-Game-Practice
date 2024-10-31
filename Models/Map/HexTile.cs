using MyGame.Models.Units;
using System.Collections.Generic;

namespace MyGame.Models.Map
{
    internal class HexTile
    {
        public Image Image => Program.Content.GetImage("hex_grass");

        internal Unit Unit = null;

        internal bool IsFree => Unit != null;

        internal List<CubeCoordinate> PathToReach {  get; set; }

        internal void Enter(Unit unit)
        {
            Unit = unit;
        }

        internal void Exit()
        {
            Unit = null;
        }
    }
}
