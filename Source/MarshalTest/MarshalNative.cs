using System.Buffers;
using System.Runtime.InteropServices;
using System.Text;
using JetBrains.Annotations;

namespace Radish;

[PublicAPI]
public static partial class MarshalNative
{
    [LibraryImport(nameof(MarshalNative), EntryPoint = "MRSH_StringLength", StringMarshalling = StringMarshalling.Utf8)]
    public static partial int StringLength(string str);

    [LibraryImport(nameof(MarshalNative), EntryPoint = "MRSH_StringReverse", StringMarshalling = StringMarshalling.Utf8)]
    private static partial void _StringReverse(string src, [Out] byte[] dst);
    
    public static string StringReverse(string str)
    {
        // We can't modify strings directly it seems -- so we need to allocate an appropriately sized
        // result buffer and have the native code work on that
        
        ArgumentNullException.ThrowIfNull(str);

        if (str.Length == 0)
            return string.Empty;

        using var dst = ArrayPool<byte>.Shared.Rent(Encoding.UTF8.GetByteCount(str) + 1, true);
        _StringReverse(str, dst);
        var result = Encoding.UTF8.GetString(dst);
        return result;
    }

    [LibraryImport(nameof(MarshalNative), EntryPoint = "MRSH_VectorLength")]
    public static partial float VectorLength(in NativeVector2 vec);

    [LibraryImport(nameof(MarshalNative), EntryPoint = "MRSH_DoSomethingWithWindow")]
    private static partial void _DoSomethingWithWindow(IntPtr window);

    public static void DoSomethingWithWindow(Window window)
    {
        ObjectDisposedException.ThrowIf(window.Handle == IntPtr.Zero, window);
        _DoSomethingWithWindow(window.Handle);
    }
}