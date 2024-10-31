using Tao.Sdl;

using MyGame.Views;
using MyGame.Models;
using MyGame.Models.Map;
using MyGame.Models.Units;
using MyGame.Controllers;


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

        /*IN-GAME SCENE*/
        internal static HexGrid Grid;
        internal static HighlightsManager HighlightsManager;
        internal static Character Character;

        internal static Cursor Cursor;
        /**************/

        static void Main(string[] _)
        {
            Renderer = new Renderer(SCREEN_WIDTH, SCREEN_HEIGHT);
            Content = new Content();
            Content.Load();

            Cursor = new Cursor();

            Mouse = new Mouse();
            Grid = new HexGrid();
            HighlightsManager = new HighlightsManager();

            Character = new Character("triangle", 3, new CubeCoordinate(1, 1));
            Character.StartTurn();
            Character.PrepareToMove();

            GameController = new GameController(Grid, HighlightsManager);

            while (IsRunning)
            {
                GameController.CheckInputs();
                GameController.Update();

                Renderer.Clear();

                Renderer.Render(Grid);
                Renderer.Render(HighlightsManager);

                Renderer.Render(Character);

                Renderer.Render(Cursor);

                Renderer.Show();

                Sdl.SDL_Delay(15);  
            }
        }
    }
}