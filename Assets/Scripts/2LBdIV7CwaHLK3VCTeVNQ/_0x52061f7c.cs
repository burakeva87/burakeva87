using UnityEngine;

/// <summary>
/// The ten stones, what they pay and which album set they belong to.
///
/// Every payout below is a multiplier of the TOTAL bet, not of a per-line stake, so
/// nothing on screen ever has to do per-line arithmetic. LINES is fixed at 9.
///
/// Declaration order is deliberate (C.52): the plain arrays first, every derived table
/// last. A derived table that read an array declared below it would initialise to null
/// once string encryption turns these into runtime-initialised fields.
/// </summary>
public static class _0x52061f7c
{
    public const int Ruby = 0;
    public const int Wild = 8;
    private static readonly string[] _0x54eb3087 =
    {
        _0x28c69997._0xaa87119e(new byte[4] { 81, 86, 65, 90 }, 3),
        _0x28c69997._0xaa87119e(new byte[8] { 3, 17, 0, 0, 24, 25, 2, 21 }, 80),
        _0x28c69997._0xaa87119e(new byte[7] { 135, 143, 135, 144, 131, 142, 134 }, 194),
        _0x28c69997._0xaa87119e(new byte[5] { 249, 226, 253, 236, 247 }, 173),
        _0x28c69997._0xaa87119e(new byte[5] { 241, 224, 253, 229, 252 }, 178),
        _0x28c69997._0xaa87119e(new byte[4] { 156, 155, 146, 146 }, 222),
        _0x28c69997._0xaa87119e(new byte[4] { 77, 65, 71, 64 }, 14),
        _0x28c69997._0xaa87119e(new byte[7] { 253, 240, 248, 244, 246, 247, 253 }, 185),
        _0x28c69997._0xaa87119e(new byte[4] { 219, 197, 192, 200 }, 140),
        _0x28c69997._0xaa87119e(new byte[3] { 155, 149, 137 }, 208)
    };
    public static int[] _0xf6d9c677
    {
        get
        {
            return _0xf4c28cc8;
        }
    }

    public const int Crown = 4;
    public const int Bell = 5;
    public static string Name(int _0x2c1fc1af)
    {
        if (_0x2c1fc1af < 0 || _0x2c1fc1af >= Count)
            return _0x54eb3087[0];
        return _0x54eb3087[_0x2c1fc1af];
    }

    public const int Scatter = 9;
    public static int AlbumSet(int _0x96fe7292)
    {
        if (_0x96fe7292 < 0 || _0x96fe7292 >= Count)
            return 0;
        return _0xba3619c6[_0x96fe7292];
    }

    public const int Coin = 6;
    /// <summary>The headline multiplier a symbol can reach, for the paytable rows.</summary>
    public static float TopPayout(int _0xf8c8710c)
    {
        return Payout(_0xf8c8710c, 5);
    }

    private static int[] BuildWeightedPool()
    {
        int _0x286c531b = 0;
        for (int _0x86e9fc4e = 0; _0x86e9fc4e < Count; _0x86e9fc4e++)
            _0x286c531b += _0xf4c28cc8[_0x86e9fc4e];
        int[] _0x15962a1c = new int[_0x286c531b];
        int _0xd886dd74 = 0;
        for (int _0x69f69c84 = 0; _0x69f69c84 < Count; _0x69f69c84++)
            for (int _0x479d3afc = 0; _0x479d3afc < _0xf4c28cc8[_0x69f69c84]; _0x479d3afc++)
            {
                _0x15962a1c[_0xd886dd74] = _0x69f69c84;
                _0xd886dd74++;
            }

        return _0x15962a1c;
    }
    private static readonly float[] _0xd1370054 =
    {
        1.2f,
        1.2f,
        1.5f,
        1.5f,
        2.5f,
        3f,
        4f,
        8f,
        10f,
        0f
    };

    private static readonly float[] _0xe35e85f0 =
    {
        3f,
        3f,
        4f,
        4f,
        8f,
        12f,
        20f,
        50f,
        80f,
        0f
    };
    public const int Count = 10;
    public const int Topaz = 3;
    public static int[] _0xf1ce2fd5
    {
        get
        {
            return _0x5c29ff08;
        }
    }

    public static string AlbumSetName(int _0x9d4d51e4)
    {
        if (_0x9d4d51e4 < 0 || _0x9d4d51e4 >= _0xf11af3ca.Length)
            return _0xf11af3ca[0];
        return _0xf11af3ca[_0x9d4d51e4];
    }
    /// <summary>How often a symbol appears on a reel strip. Rarer stones pay more.</summary>
    private static readonly int[] _0xf4c28cc8 =
    {
        22,
        22,
        18,
        18,
        12,
        10,
        8,
        5,
        3,
        4
    };
    public const int Sapphire = 1;

    /// <summary>Derived: the pool a reel strip is built from, each id repeated by weight.</summary>
    private static readonly int[] _0x5c29ff08 = BuildWeightedPool();
    /// <summary>Payout for 3, 4 and 5 of a kind, as a multiplier of the total bet.</summary>
    private static readonly float[] _0xfe3caaf0 =
    {
        0.4f,
        0.4f,
        0.5f,
        0.5f,
        0.8f,
        1.0f,
        1.2f,
        2f,
        3f,
        0f
    };
    public const int Emerald = 2;
    /// <summary>Multiplier of the TOTAL bet for a run of <paramref name = "run"/> symbols.</summary>
    public static float Payout(int _0xbcb845d4, int _0xdb98b6a5)
    {
        if (_0xbcb845d4 < 0 || _0xbcb845d4 >= Count || _0xdb98b6a5 < 3)
            return 0f;
        if (_0xdb98b6a5 == 3)
            return _0xfe3caaf0[_0xbcb845d4];
        if (_0xdb98b6a5 == 4)
            return _0xd1370054[_0xbcb845d4];
        return _0xe35e85f0[_0xbcb845d4];
    }

    private static readonly string[] _0xf11af3ca =
    {
        _0x28c69997._0xaa87119e(new byte[6] { 84, 83, 72, 73, 66, 84 }, 7),
        _0x28c69997._0xaa87119e(new byte[7] { 41, 62, 60, 58, 55, 50, 58 }, 123),
        _0x28c69997._0xaa87119e(new byte[12] { 107, 122, 103, 127, 102, 8, 98, 109, 127, 109, 100, 123 }, 40)
    };
    /// <summary>Album set per symbol: 0 Stones, 1 Regalia, 2 Crown jewels.</summary>
    private static readonly int[] _0xba3619c6 =
    {
        0,
        0,
        0,
        0,
        1,
        1,
        1,
        2,
        2,
        2
    };
    public const int Diamond = 7;
}

internal static class _0x28c69997
{
    internal static string _0xaa87119e(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}