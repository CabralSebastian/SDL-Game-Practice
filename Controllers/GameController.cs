using MyGame.Models;
using MyGame.Models.Map;
using MyGame.Models.Units;
using MyGame.Views;
using System.Diagnostics;
using System.Timers;

namespace MyGame.Controllers
{
    internal class GameController
    {
        private readonly HighlightsManager HighlightsManager;
        private readonly HexGrid Grid;


        private readonly Stopwatch stopwatch;

        private float deltaTimeSeconds = 0f;

        internal GameController(HexGrid grid, HighlightsManager highlightsManager) 
        {
            stopwatch = new Stopwatch();
            Grid = grid;
            HighlightsManager = highlightsManager;
        }


        internal void CheckInputs() 
        {
            Program.Mouse.CheckInputs();
            CubeCoordinate MouseCoordinate = Program.Grid.GetCoordinate(Program.Mouse.Position);

            if (Program.Mouse.IsLeftClickDown)
            {
                Program.Character.Move(MouseCoordinate); 
            }

            if (Program.Mouse.IsRightClickDown)
                Program.IsRunning = false;
        }

        internal void Update() 
        {
            deltaTimeSeconds = stopwatch.ElapsedMilliseconds / 1000f;
            stopwatch.Restart();

            Program.Character.Update(deltaTimeSeconds);

        }

    }
}
