using System;
using UnityEngine;

/// <summary>
/// Everything this game remembers between launches, in one place.
///
/// Local only - PlayerPrefs, no network, no cloud, no account. The coin balance is NOT
/// stored here: coins live in the template's own SETTINGS.PlayerSYSTEM.Coins, so there
/// is exactly one coin number in the project and the template HUD and this game can
/// never disagree.
///
/// The keys are written out as literal strings and never derived with nameof: they are
/// persisted identifiers, obfuscation renames the symbol, and a renamed key is a lost
/// save (C / "no needless nameof").
/// </summary>
public static class _0x43ed7f14
{
    public static string _0x7b4386a8
    {
        get
        {
            return PlayerPrefs.GetString(KeyDailyDate, string.Empty);
        }

        set
        {
            PlayerPrefs.SetString(KeyDailyDate, value);
        }
    }

    public static int _0x17f00794
    {
        get
        {
            return Mathf.Clamp(PlayerPrefs.GetInt(KeyRoom, 0), 0, 3);
        }

        set
        {
            PlayerPrefs.SetInt(KeyRoom, Mathf.Clamp(value, 0, 3));
        }
    }

    public static bool _0xe987d0c3
    {
        get
        {
            return PlayerPrefs.GetInt(KeyHaptics, 1) == 1;
        }

        set
        {
            PlayerPrefs.SetInt(KeyHaptics, value ? 1 : 0);
        }
    }

    public static string _0x70559445
    {
        get
        {
            return PlayerPrefs.GetString(KeyMissionProgress, string.Empty);
        }

        set
        {
            PlayerPrefs.SetString(KeyMissionProgress, value);
        }
    }

    private static readonly string KeyMissionKinds = _0x234b090a._0xd38c3f10(new byte[13] { 4, 6, 18, 78, 13, 19, 14, 78, 11, 9, 14, 4, 19 }, 96);
    private static readonly string KeyCelebrations = _0x234b090a._0xd38c3f10(new byte[16] { 140, 142, 154, 198, 139, 141, 132, 141, 138, 154, 137, 156, 129, 135, 134, 155 }, 232);
    public static string _0xa2088c42
    {
        get
        {
            return PlayerPrefs.GetString(KeyMissionKinds, string.Empty);
        }

        set
        {
            PlayerPrefs.SetString(KeyMissionKinds, value);
        }
    }

    private static readonly string KeyAlbum = _0x234b090a._0xd38c3f10(new byte[9] { 217, 219, 207, 147, 220, 209, 223, 200, 208 }, 189);
    private static readonly string KeyMissionSession = _0x234b090a._0xd38c3f10(new byte[15] { 210, 208, 196, 152, 219, 197, 216, 152, 197, 211, 197, 197, 223, 217, 216 }, 182);
    /// <summary>
    /// Back to day one: coins, album, room and the daily ladder. The settings toggles
    /// are the player's preference, not progress, so they survive.
    /// </summary>
    public static void ResetProgress()
    {
        PlayerPrefs.SetString(KeyAlbum, new string ('0', AlbumSlots));
        PlayerPrefs.SetInt(KeyRoom, 0);
        PlayerPrefs.SetInt(KeyDailyDay, 0);
        PlayerPrefs.SetString(KeyDailyDate, string.Empty);
        PlayerPrefs.SetInt(KeyBet, 50);
        PlayerPrefs.SetInt(KeyMissionSession, -1);
        PlayerPrefs.SetString(KeyMissionProgress, string.Empty);
        _0x778394b0._0x17f70ae0._0x7d96fa30 = StartingCoins;
        PlayerPrefs.Save();
    }

    private static readonly string KeyBet = _0x234b090a._0xd38c3f10(new byte[7] { 199, 197, 209, 141, 193, 198, 215 }, 163);
    public static int _0xaee6d0e1
    {
        get
        {
            return Mathf.Clamp(PlayerPrefs.GetInt(KeyDailyDay, 0), 0, 6);
        }

        set
        {
            PlayerPrefs.SetInt(KeyDailyDay, Mathf.Clamp(value, 0, 6));
        }
    }

    private static readonly string KeyRoom = _0x234b090a._0xd38c3f10(new byte[8] { 227, 225, 245, 169, 245, 232, 232, 234 }, 135);
    public static int _0x99cdb961
    {
        get
        {
            int _0x24e6f175 = _0x0c1a0cea;
            for (int _0x9b2347d4 = 0; _0x9b2347d4 < _0xbdba56d5.Length; _0x9b2347d4++)
                if (_0xbdba56d5[_0x9b2347d4] == _0x24e6f175)
                    return _0x9b2347d4;
            return 1;
        }
    }

    public static string _0x8aa8ee61
    {
        get
        {
            return DateTime.Now.ToString(_0x234b090a._0xd38c3f10(new byte[8] { 131, 131, 131, 131, 183, 183, 158, 158 }, 250));
        }
    }

    private static readonly string KeyMissionProgress = _0x234b090a._0xd38c3f10(new byte[16] { 207, 205, 217, 133, 198, 216, 197, 133, 219, 217, 196, 204, 217, 206, 216, 216 }, 171);
    public static int[] _0x6dee615f
    {
        get
        {
            return _0xbdba56d5;
        }
    }

    public const int RefillAmount = 5000;
    /// <summary>Bumped on every entry into the vault; the seed is derived from it.</summary>
    public static int NextSession()
    {
        int _0x9efd259e = PlayerPrefs.GetInt(KeySession, 0) + 1;
        PlayerPrefs.SetInt(KeySession, _0x9efd259e);
        return _0x9efd259e;
    }

    public static bool IsSealed(int _0xf7dc45be)
    {
        if (_0xf7dc45be < 0 || _0xf7dc45be >= AlbumSlots)
            return false;
        return _0x8e38b2e0[_0xf7dc45be] == '1';
    }

    private static readonly string KeyDailyDate = _0x234b090a._0xd38c3f10(new byte[14] { 216, 218, 206, 146, 216, 221, 213, 208, 197, 146, 216, 221, 200, 217 }, 188);
    /// <summary>Seal a slot. Returns true only when it was not already sealed.</summary>
    public static bool Seal(int _0x4111e5ad)
    {
        if (_0x4111e5ad < 0 || _0x4111e5ad >= AlbumSlots)
            return false;
        char[] _0x9fefab24 = _0x8e38b2e0.ToCharArray();
        if (_0x9fefab24[_0x4111e5ad] == '1')
            return false;
        _0x9fefab24[_0x4111e5ad] = '1';
        _0x8e38b2e0 = new string (_0x9fefab24);
        return true;
    }

    public static int _0x0c1a0cea
    {
        get
        {
            int _0x5272ff45 = PlayerPrefs.GetInt(KeyBet, 50);
            for (int _0xacbcf1d7 = 0; _0xacbcf1d7 < _0xbdba56d5.Length; _0xacbcf1d7++)
                if (_0xbdba56d5[_0xacbcf1d7] == _0x5272ff45)
                    return _0x5272ff45;
            return 50;
        }

        set
        {
            PlayerPrefs.SetInt(KeyBet, value);
        }
    }

    /// <summary>
    /// True the first time this install runs, so the opening balance can be seeded
    /// without ever overwriting a real one.
    /// </summary>
    public static void EnsureSeeded()
    {
        if (!PlayerPrefs.HasKey(KeyAlbum))
        {
            PlayerPrefs.SetString(KeyAlbum, new string ('0', AlbumSlots));
            _0x778394b0._0x17f70ae0._0x7d96fa30 = StartingCoins;
        }

        if (!PlayerPrefs.HasKey(KeyBet))
            PlayerPrefs.SetInt(KeyBet, 50);
    }

    public const int MinimumBet = 20;
    public const int AlbumSlots = 30;
    public static int _0x0432624b
    {
        get
        {
            return _0x778394b0._0x17f70ae0._0x7d96fa30;
        }

        set
        {
            _0x778394b0._0x17f70ae0._0x7d96fa30 = value < 0 ? 0 : value;
        }
    }

    public static bool _0x267e30bb
    {
        get
        {
            return _0x7b4386a8 == _0x8aa8ee61;
        }
    }

    public static int _0xa18ae110
    {
        get
        {
            string _0xff6cc4fe = _0x8e38b2e0;
            int _0x4b2d6bae = 0;
            for (int _0x807b9d10 = 0; _0x807b9d10 < _0xff6cc4fe.Length; _0x807b9d10++)
                if (_0xff6cc4fe[_0x807b9d10] == '1')
                    _0x4b2d6bae++;
            return _0x4b2d6bae;
        }
    }

    public static int _0x71107a07
    {
        get
        {
            return PlayerPrefs.GetInt(KeySession, 1);
        }
    }

    public const int StartingCoins = 10000;
    /// <summary>Thousands separated with a comma, no currency symbol anywhere.</summary>
    public static string Money(long _0x7bde79eb)
    {
        bool _0x7f24c7a9 = _0x7bde79eb < 0L;
        long _0xadd175c6 = _0x7f24c7a9 ? -_0x7bde79eb : _0x7bde79eb;
        string _0x7ec69e88 = _0xadd175c6.ToString();
        string _0x2d4c0709 = string.Empty;
        int _0xbc15372b = 0;
        for (int _0xcfed01fc = _0x7ec69e88.Length - 1; _0xcfed01fc >= 0; _0xcfed01fc--)
        {
            _0x2d4c0709 = _0x7ec69e88[_0xcfed01fc] + _0x2d4c0709;
            _0xbc15372b++;
            if (_0xbc15372b % 3 == 0 && _0xcfed01fc > 0)
                _0x2d4c0709 = _0x234b090a._0xd38c3f10(new byte[1] { 115 }, 95) + _0x2d4c0709;
        }

        return _0x7f24c7a9 ? _0x234b090a._0xd38c3f10(new byte[1] { 8 }, 37) + _0x2d4c0709 : _0x2d4c0709;
    }

    private static readonly string KeyHaptics = _0x234b090a._0xd38c3f10(new byte[11] { 217, 219, 207, 147, 213, 220, 205, 201, 212, 222, 206 }, 189);
    /// <summary>
    /// The session the stored mission set belongs to. Both scenes read the same three
    /// missions and the same progress through this, which is why no static holder is
    /// needed to carry them from the lobby into the vault.
    /// </summary>
    public static int _0x06d12a70
    {
        get
        {
            return PlayerPrefs.GetInt(KeyMissionSession, -1);
        }

        set
        {
            PlayerPrefs.SetInt(KeyMissionSession, value);
        }
    }

    private static readonly string KeySession = _0x234b090a._0xd38c3f10(new byte[11] { 17, 19, 7, 91, 6, 16, 6, 6, 28, 26, 27 }, 117);
    private static readonly int[] _0xbdba56d5 =
    {
        20,
        50,
        100,
        250,
        500
    };
    /// <summary>True for FULL celebrations, false for CALM.</summary>
    public static bool _0xe1eb7714
    {
        get
        {
            return PlayerPrefs.GetInt(KeyCelebrations, 1) == 1;
        }

        set
        {
            PlayerPrefs.SetInt(KeyCelebrations, value ? 1 : 0);
        }
    }

    /// <summary>A 30-character mask, one digit per album slot.</summary>
    public static string _0x8e38b2e0
    {
        get
        {
            string _0xdd190ba5 = PlayerPrefs.GetString(KeyAlbum, new string ('0', AlbumSlots));
            if (_0xdd190ba5.Length != AlbumSlots)
                _0xdd190ba5 = new string ('0', AlbumSlots);
            return _0xdd190ba5;
        }

        set
        {
            PlayerPrefs.SetString(KeyAlbum, value);
        }
    }

    private static readonly string KeyDailyDay = _0x234b090a._0xd38c3f10(new byte[13] { 112, 114, 102, 58, 112, 117, 125, 120, 109, 58, 112, 117, 109 }, 20);
}

internal static class _0x234b090a
{
    internal static string _0xd38c3f10(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}