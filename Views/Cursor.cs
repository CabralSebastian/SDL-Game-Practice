using MyGame.Models;

namespace MyGame.Views
{
    internal class Cursor : IDrawable
    {
        public Image Image => Program.Content.GetImage("cursor");

        public ScreenPosition ScreenPosition =>
            Program.Grid.Positions[Program.Grid.GetCoordinate(Program.Mouse.Position)];
    }
}
