using UnityEngine;

/// <summary>
/// The four rooms of the vault. Purely decorative: a room never changes the odds, the
/// bet or what a symbol pays - it changes the trim colour, the backdrop tint and the
/// room label, which is the whole point. Unlocking one has to be VISIBLE (C.7), so the
/// lobby recolours on the spot rather than waiting for the next screen.
/// </summary>
public static class _0x4cd3e5d2
{
    public static Color Tint(int _0x2a680e85)
    {
        return _0xecf6b76b.RoomTint(_0x2a680e85);
    }

    /// <summary>Which room a given number of sealed stones has reached.</summary>
    public static int RoomFor(int _0x130dbc36)
    {
        int _0x574c49f8 = 0;
        for (int _0xf5a660af = 0; _0xf5a660af < Count; _0xf5a660af++)
            if (_0x130dbc36 >= _0x61d7d412[_0xf5a660af])
                _0x574c49f8 = _0xf5a660af;
        return _0x574c49f8;
    }

    public const int Count = 4;
    /// <summary>"ROOM 2 / 4 - GILDED ARCH", for the lobby and the game HUD.</summary>
    public static string Label(int _0x44f50a62)
    {
        return _0x8fba1055._0xe207aca7(new byte[5] { 106, 119, 119, 117, 24 }, 56) + (_0x44f50a62 + 1) + _0x8fba1055._0xe207aca7(new byte[3] { 221, 210, 221 }, 253) + Count + _0x8fba1055._0xe207aca7(new byte[3] { 144, 157, 144 }, 176) + Name(_0x44f50a62);
    }

    private static readonly int[] _0x61d7d412 =
    {
        0,
        8,
        16,
        24
    };
    /// <summary>Sealed stones needed for the NEXT room; the last room reports its own.</summary>
    public static int NextThreshold(int _0x572b7f74)
    {
        if (_0x572b7f74 >= Count - 1)
            return _0x61d7d412[Count - 1];
        return _0x61d7d412[_0x572b7f74 + 1];
    }

    public static string Name(int _0x1e608ae9)
    {
        if (_0x1e608ae9 < 0 || _0x1e608ae9 >= Count)
            return _0x76ed8297[0];
        return _0x76ed8297[_0x1e608ae9];
    }

    private static readonly string[] _0x76ed8297 =
    {
        _0x8fba1055._0xe207aca7(new byte[11] { 171, 184, 177, 171, 184, 169, 221, 181, 188, 177, 177 }, 253),
        _0x8fba1055._0xe207aca7(new byte[11] { 68, 74, 79, 71, 70, 71, 35, 66, 81, 64, 75 }, 3),
        _0x8fba1055._0xe207aca7(new byte[14] { 97, 109, 101, 116, 104, 121, 115, 116, 0, 118, 97, 117, 108, 116 }, 32),
        _0x8fba1055._0xe207aca7(new byte[15] { 29, 16, 24, 20, 22, 23, 29, 121, 13, 28, 11, 11, 24, 26, 28 }, 89)
    };
    public static int Threshold(int _0x692db6a0)
    {
        if (_0x692db6a0 < 0 || _0x692db6a0 >= Count)
            return _0x61d7d412[0];
        return _0x61d7d412[_0x692db6a0];
    }

    public static Color Trim(int _0x6fd1516b)
    {
        return _0xecf6b76b.RoomTrim(_0x6fd1516b);
    }
}

internal static class _0x8fba1055
{
    internal static string _0xe207aca7(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}