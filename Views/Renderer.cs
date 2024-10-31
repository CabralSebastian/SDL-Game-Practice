using MyGame.Models;
using MyGame.Models.Map;
using MyGame.Models.Units;
using System;
using Tao.Sdl;

namespace MyGame.Views
{
    internal class Renderer
    {
        private readonly IntPtr screen;
        private readonly int screenWidth, screenHeight;

        internal Renderer(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            int colors = 24;

            int flags = (Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT);
            Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
            screen = Sdl.SDL_SetVideoMode(
                screenWidth,
                screenHeight,
                colors,
                flags);

            Sdl.SDL_Rect rect2 =
                new Sdl.SDL_Rect(0, 0, (short)screenWidth, (short)screenHeight);
            Sdl.SDL_SetClipRect(screen, ref rect2);

            SdlTtf.TTF_Init();
        }

        
        internal void Render(Scene scene)
        {
            Clear();

            foreach(IDrawable drawable in scene.Drawables)
                Draw(drawable.Image, drawable.ScreenPosition);

            Show();
        }

        internal void Render(Unit unit)
        {
                Draw(Program.Content.GetImage(unit.Name), unit.Position);
        }

        internal void Render(HexGrid grid)
        {

            foreach (var keyValuePair in grid.Tiles)
            {
                CubeCoordinate coordinate = keyValuePair.Key;
                HexTile tile = keyValuePair.Value;

                ScreenPosition screenPosition = grid.Positions[coordinate];
                Draw(tile.Image, screenPosition);
            }

        }
        internal void Render(HighlightsManager highlightsManager)
        {

            foreach (var keyValuePair in highlightsManager.Highlights)
            {
                CubeCoordinate coordinate = keyValuePair.Key;
                Image image = keyValuePair.Value;

                if(!Program.Grid.Positions.ContainsKey(coordinate))
                    continue;

                ScreenPosition screenPosition = Program.Grid.Positions[coordinate];
                Draw(image, screenPosition);
            }

        }

        internal void Render(IDrawable drawable)
        { 
            Draw(drawable.Image, drawable.ScreenPosition); 
        }

        internal void Clear()
        {
            Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)screenWidth, (short)screenHeight);
            Sdl.SDL_FillRect(screen, ref origin, 0);
        }

        internal void Draw(Image imagen, ScreenPosition position)
        {
            IntPtr imagePointer = imagen.Pointer;

            Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, (short)screenWidth, (short)screenHeight);
            Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)position.x, (short)position.y, (short)screenWidth, (short)screenHeight);
            Sdl.SDL_BlitSurface(imagePointer, ref origen, screen, ref dest);
        }

        internal void Show()
        {
            Sdl.SDL_Flip(screen);
        }
    }
}
