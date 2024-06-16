using System.Drawing;
using SDL2;

namespace Radish;

public class Window : IDisposable
{
    public Point Position
    {
        get
        {
            ObjectDisposedException.ThrowIf(Handle == IntPtr.Zero, this);
            SDL.SDL_GetWindowPosition(Handle, out var w, out var h);
            return new Point(w, h);
        }
        set
        {
            ObjectDisposedException.ThrowIf(Handle == IntPtr.Zero, this);
            SDL.SDL_SetWindowPosition(Handle, value.X, value.Y);
        }
    }
    
    public Size Size
    {
        get
        {
            ObjectDisposedException.ThrowIf(Handle == IntPtr.Zero, this);
            SDL.SDL_GetWindowSize(Handle, out var w, out var h);
            return new Size(w, h);
        }
        set
        {
            ObjectDisposedException.ThrowIf(Handle == IntPtr.Zero, this);
            SDL.SDL_SetWindowSize(Handle, value.Width, value.Height);
        }
    }

    public Size MinimumSize
    {
        get
        {
            ObjectDisposedException.ThrowIf(Handle == IntPtr.Zero, this);
            SDL.SDL_GetWindowMinimumSize(Handle, out var w, out var h);
            return new Size(w, h);
        }
        set
        {
            ObjectDisposedException.ThrowIf(Handle == IntPtr.Zero, this);
            SDL.SDL_SetWindowMinimumSize(Handle, value.Width, value.Height);
        }
    }
    
    public Size MaximumSize
    {
        get
        {
            ObjectDisposedException.ThrowIf(Handle == IntPtr.Zero, this);
            SDL.SDL_GetWindowMaximumSize(Handle, out var w, out var h);
            return new Size(w, h);
        }
        set
        {
            ObjectDisposedException.ThrowIf(Handle == IntPtr.Zero, this);
            SDL.SDL_SetWindowMaximumSize(Handle, value.Width, value.Height);
        }
    }

    public string Title
    {
        get
        {
            ObjectDisposedException.ThrowIf(Handle == IntPtr.Zero, this);
            return SDL.SDL_GetWindowTitle(Handle);
        }
        set
        {
            ObjectDisposedException.ThrowIf(Handle == IntPtr.Zero, this);
            ArgumentNullException.ThrowIfNull(value);
            SDL.SDL_SetWindowTitle(Handle, value);
        }
    }

    public IntPtr Handle { get; private set; }

    public Window(int width, int height, string title, SDL.SDL_WindowFlags flags)
    {
        Handle = SDL.SDL_CreateWindow(title, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, width, height,
            flags);

        if (Handle == IntPtr.Zero)
            throw new Exception($"Failed to create window: {SDL.SDL_GetError()}");
    }

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            SDL.SDL_DestroyWindow(Handle);
            Handle = IntPtr.Zero;
        }
    }
}