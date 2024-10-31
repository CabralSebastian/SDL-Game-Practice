using MyGame.Models;
using MyGame.Models.Map;
using MyGame.Views;
using System;

namespace MyGame.Controllers
{
    internal class GameController
    {
        private readonly HighlightsManager HighlightsManager;
        private readonly HexGrid Grid;
        internal GameController(HexGrid grid, HighlightsManager highlightsManager) 
        {
            Grid = grid;
            HighlightsManager = highlightsManager;
        }

        internal void CheckInputs() 
        {
            Program.Mouse.CheckInputs();

            if (Program.Mouse.IsLeftClickDown)
            {
                HighlightsManager.TurnOnHighlight(Color.Blue, Grid.GetCoordinate(Program.Mouse.Position));
            }

            if (Program.Mouse.IsRightClickDown)
                Program.IsRunning = false;
        }

        internal void Update() 
        {
            


        }

    }
}
