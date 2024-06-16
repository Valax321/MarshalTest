# P/Invoke Demos

Some test/demo things I put together for learning modern-style .NET P/Invoke.

## Usage

I only have CMake presets for macOS since that's what I'm using for development, but adding them for other platforms would be trivial.

Building the CMake project with the presets will put the SDL2 and Test P/Invoke libs directly into the folder where the C# project will put its binaries. 

For production work with this sort of project structure it's probably worth using CMake's install feature to bundle everything up for release, or do whatever undocumented stuff .NET expects when shipping a Nuget package with native components.

## License

LICENSE applies for all files in this repo except `SDL2.cs`. The license for that code is at the top of it's file.
