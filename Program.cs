using System;
using Tao.Sdl;

using MyGame.Views;
using MyGame.Models;
using MyGame.Controllers;
using MyGame.Models.Map;

namespace MyGame
{
    class Program
    {
        internal const int SCREEN_WIDTH = 1024;
        internal const int SCREEN_HEIGHT = 768;

        internal static bool IsRunning = true;

        internal static Mouse Mouse;

        internal static GameController GameController;
        internal static Renderer Renderer;
        internal static Content Content;

        internal static HexGrid Grid;
        internal static HighlightsManager HighlightsManager;

        internal static Cursor Cursor;

        static void Main(string[] _)
        {
            Renderer = new Renderer(SCREEN_WIDTH, SCREEN_HEIGHT);
            Content = new Content();
            Content.Load();

            Cursor = new Cursor();

            Mouse = new Mouse();
            Grid = new HexGrid();
            HighlightsManager = new HighlightsManager();

            GameController = new GameController(Grid, HighlightsManager);

            while (IsRunning)
            {
                GameController.CheckInputs();
                GameController.Update();

                Renderer.Clear();

                Renderer.Render(Grid);
                Renderer.Render(HighlightsManager);

                Renderer.Render(Cursor);

                Renderer.Show();

                Sdl.SDL_Delay(15);  
            }
        }
    }
}