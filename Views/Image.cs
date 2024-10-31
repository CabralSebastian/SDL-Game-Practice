using System;
using System.Runtime.InteropServices;
using static Tao.Sdl.Sdl;

internal class Image
{
    internal IntPtr Pointer { get; private set; }
    internal int Width { get; private set; }
    internal int Height { get; private set; }

    internal Image(IntPtr pointer)
    {
        Pointer = pointer;

        SDL_Surface surface = Marshal.PtrToStructure<SDL_Surface>(Pointer);
        Width = surface.w;
        Height = surface.h;
    }
}