using System;
using Tao.Sdl;

namespace MyGame.Models
{
    internal class Mouse
    {
        internal ScreenPosition Position { get; private set; }
        internal bool IsRightClickUp { get; private set; }
        internal bool IsLeftClickUp { get; private set; }
        internal bool IsRightClickDown { get; private set; }
        internal bool IsLeftClickDown { get; private set; }

        internal void CheckInputs()
        {
            Sdl.SDL_PumpEvents();
            ResetClicks();

            while (Sdl.SDL_PollEvent(out Sdl.SDL_Event mouseEvent) != 0)
            {
                if (mouseEvent.type == Sdl.SDL_MOUSEBUTTONDOWN)
                {
                    IsRightClickDown = mouseEvent.button.button == Sdl.SDL_BUTTON_RIGHT;
                    IsLeftClickDown = mouseEvent.button.button == Sdl.SDL_BUTTON_LEFT;
                }

                if (mouseEvent.type == Sdl.SDL_MOUSEBUTTONUP)
                {
                    IsRightClickUp = mouseEvent.button.button == Sdl.SDL_BUTTON_RIGHT;
                    IsLeftClickUp = mouseEvent.button.button == Sdl.SDL_BUTTON_LEFT;
                }

                //else if (mouseEvent.type == Sdl.SDL_MOUSEMOTION)
                    UpdateMousePosition();
            }
        }

        private void UpdateMousePosition()
        {
            Sdl.SDL_GetMouseState(out int mouseX, out int mouseY);

            Position = new ScreenPosition(mouseX, mouseY);
        }

        private void ResetClicks()
        {
            IsRightClickUp = false;
            IsLeftClickUp = false;
            IsRightClickDown = false;
            IsLeftClickDown = false;
        }
    }
}
