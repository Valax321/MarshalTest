using System.Numerics;
using System.Runtime.InteropServices;

namespace Radish;

[StructLayout(LayoutKind.Sequential)]
public struct NativeVector2
{
    public float x;
    public float y;

    public static implicit operator NativeVector2(in Vector2 vec) => new() { x = vec.X, y = vec.Y };
    public static implicit operator Vector2(in NativeVector2 vec) => new(vec.x, vec.y);
}