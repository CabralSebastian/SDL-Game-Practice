using MyGame.Models;

namespace MyGame.Views
{
    internal interface IDrawable
    {
        Image Image { get; }
        ScreenPosition ScreenPosition { get; }
    }
}
