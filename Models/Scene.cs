using MyGame.Views;
using System.Collections.Generic;

namespace MyGame.Models
{
    internal class Scene
    {   
        internal readonly List<IDrawable> Drawables = new List<IDrawable>();

        internal void AddDrawable(IDrawable drawable)
        {
            Drawables.Add(drawable);
        }

        internal void RemoveDrawable(IDrawable drawable)
        {
            Drawables.Remove(drawable);
        }
    }
}
