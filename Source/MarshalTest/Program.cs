using System.Drawing;
using System.Numerics;
using Radish;
using SDL2;

if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) != 0)
    return;

const string testString1 = "Hello, world!";

Console.WriteLine($"The .NET length of \"{testString1}\" is {testString1.Length}");
Console.WriteLine($"The native length of \"{testString1}\" is {MarshalNative.StringLength(testString1)}");

const string testString2 = "Mushrooms";
Console.WriteLine($"Before reverse: {testString2}");
Console.WriteLine($"After reverse: {MarshalNative.StringReverse(testString2)}");

var vec1 = new Vector2(1, 1);

Console.WriteLine($"Length of {nameof(vec1)} is {MarshalNative.VectorLength(vec1)} (.NET: {vec1.Length()})");

using (var window = new Window(1280, 720, "My Window",
           SDL.SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI | SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE))
{
    window.MinimumSize = new Size(640, 480);
    
    MarshalNative.DoSomethingWithWindow(window);
    
    var quit = false;
    while (!quit)
    {
        while (SDL.SDL_PollEvent(out var ev) > 0)
        {
            if (ev.type == SDL.SDL_EventType.SDL_QUIT)
                quit = true;
        }
    }   
}

SDL.SDL_Quit();