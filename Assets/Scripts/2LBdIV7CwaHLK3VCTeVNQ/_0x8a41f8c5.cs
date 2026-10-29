using UnityEngine;

/// <summary>
/// Three missions per session, drawn from a pool of eight with the session seed.
///
/// This is the second half of "two sessions look different" (C.11): the reel strips
/// change what scrolls past, the mission draw changes what the player is working on.
/// Quantities are sized to be reachable in about twenty-five spins, so a mission is a
/// thing that completes during a session rather than a number that never moves.
///
/// No constructor (C.59): Init fills the fields and returns the object.
/// </summary>
public sealed class _0x8a41f8c5
{
    private const int KindStreak = 1;
    /// <summary>
    /// The session's missions, restored if this session already drew them and drawn
    /// fresh otherwise. Both scenes call this with the same session index and therefore
    /// see the same three missions with the same progress - no static holder, nothing
    /// to carry across a scene load (rule D).
    /// </summary>
    public _0x8a41f8c5 _0xad1caa14(int _0xac5be2af)
    {
        if (_0x43ed7f14._0x06d12a70 == _0xac5be2af && this._0x72f96796())
            return this;
        this._0x9ac1e897(new _0x44a9791c()._0xfb3266dd(_0xac5be2af, 31));
        _0x43ed7f14._0x06d12a70 = _0xac5be2af;
        this._0xb570059e();
        return this;
    }

    private const int KindScatter = 6;
    private const int KindWild = 5;
    /// <summary>The slot the HUD shows: the first unfinished one, else the last.</summary>
    public int _0x856f47ad
    {
        get
        {
            for (int _0x5cd6a43f = 0; _0x5cd6a43f < Active; _0x5cd6a43f++)
                if (!this._0xf0685520[_0x5cd6a43f])
                    return _0x5cd6a43f;
            return Active - 1;
        }
    }

    private bool[] _0xf0685520 = new bool[Active];
    public const int Reward = 1000;
    private const int KindSeal = 3;
    public const int Active = 3;
    private const int KindHits = 4;
    public const int PoolSize = 8;
    private static readonly int[] _0x9085277f =
    {
        4,
        2,
        1500,
        3,
        6,
        1,
        1,
        5
    };
    private void _0xb570059e()
    {
        _0x43ed7f14._0xa2088c42 = Join(this._0xcf5116f4);
        _0x43ed7f14._0x70559445 = Join(this._0x41cbb983);
    }

    private const int KindHighBet = 7;
    public bool _0x96100be9(int _0x784c0d8c)
    {
        if (_0x784c0d8c < 0 || _0x784c0d8c >= this._0xf0685520.Length)
            return false;
        return this._0xf0685520[_0x784c0d8c];
    }

    /// <summary>"2 / 4", or "1,500" style for the coin-value mission.</summary>
    public string _0xed03db4b(int _0xd6595672)
    {
        int _0x7a7fdefb = this._0x033526df(_0xd6595672);
        int _0xd37ed09e = this._0xc489bb65(_0xd6595672);
        if (_0x7a7fdefb >= 1000)
            return _0x43ed7f14.Money(_0xd37ed09e) + _0xc6767520._0x5e7aaecf(new byte[3] { 227, 236, 227 }, 195) + _0x43ed7f14.Money(_0x7a7fdefb);
        return _0xd37ed09e + _0xc6767520._0x5e7aaecf(new byte[3] { 228, 235, 228 }, 196) + _0x7a7fdefb;
    }

    public int _0x033526df(int _0xfc58657a)
    {
        if (_0xfc58657a < 0 || _0xfc58657a >= this._0xcf5116f4.Length)
            return 1;
        return _0x9085277f[this._0xcf5116f4[_0xfc58657a]];
    }

    private static readonly string[] _0x58ec0788 =
    {
        _0xc6767520._0x5e7aaecf(new byte[25] { 222, 211, 220, 214, 178, 166, 178, 192, 199, 208, 219, 215, 193, 178, 221, 220, 178, 221, 220, 215, 178, 193, 194, 219, 220 }, 146),
        _0xc6767520._0x5e7aaecf(new byte[20] { 21, 11, 12, 98, 112, 98, 17, 18, 11, 12, 17, 98, 11, 12, 98, 3, 98, 16, 13, 21 }, 66),
        _0xc6767520._0x5e7aaecf(new byte[22] { 164, 179, 183, 181, 190, 214, 183, 214, 199, 218, 195, 198, 198, 214, 181, 185, 191, 184, 214, 161, 191, 184 }, 246),
        _0xc6767520._0x5e7aaecf(new byte[17] { 195, 213, 209, 220, 176, 163, 176, 222, 213, 199, 176, 195, 196, 223, 222, 213, 195 }, 144),
        _0xc6767520._0x5e7aaecf(new byte[20] { 35, 34, 63, 75, 42, 37, 50, 75, 39, 34, 37, 46, 75, 93, 75, 63, 34, 38, 46, 56 }, 107),
        _0xc6767520._0x5e7aaecf(new byte[11] { 36, 41, 38, 44, 72, 41, 72, 63, 33, 36, 44 }, 104),
        _0xc6767520._0x5e7aaecf(new byte[21] { 48, 54, 45, 35, 35, 33, 54, 68, 34, 43, 54, 48, 49, 42, 33, 68, 55, 52, 45, 42, 55 }, 100),
        _0xc6767520._0x5e7aaecf(new byte[25] { 40, 52, 57, 59, 61, 88, 77, 88, 43, 40, 49, 54, 43, 88, 57, 44, 88, 58, 61, 44, 88, 73, 72, 72, 83 }, 120)
    };
    private static int[] Parse(string _0xa1515a63)
    {
        if (string.IsNullOrEmpty(_0xa1515a63))
            return null;
        string[] _0xac463e37 = _0xa1515a63.Split(',');
        int[] _0xa904cfab = new int[_0xac463e37.Length];
        for (int _0x7a19d472 = 0; _0x7a19d472 < _0xac463e37.Length; _0x7a19d472++)
        {
            int _0xa408aa65;
            if (!int.TryParse(_0xac463e37[_0x7a19d472], out _0xa408aa65))
                return null;
            _0xa904cfab[_0x7a19d472] = _0xa408aa65;
        }

        return _0xa904cfab;
    }

    public int _0xc489bb65(int _0x66b510ab)
    {
        if (_0x66b510ab < 0 || _0x66b510ab >= this._0x41cbb983.Length)
            return 0;
        return this._0x41cbb983[_0x66b510ab];
    }

    private bool _0x72f96796()
    {
        int[] _0x5446c20c = Parse(_0x43ed7f14._0xa2088c42);
        int[] _0xf90a0a49 = Parse(_0x43ed7f14._0x70559445);
        if (_0x5446c20c == null || _0x5446c20c.Length != Active)
            return false;
        this._0xcf5116f4 = _0x5446c20c;
        this._0x41cbb983 = _0xf90a0a49 != null && _0xf90a0a49.Length == Active ? _0xf90a0a49 : new int[Active];
        this._0xf0685520 = new bool[Active];
        for (int _0x220be84c = 0; _0x220be84c < Active; _0x220be84c++)
            this._0xf0685520[_0x220be84c] = this._0x41cbb983[_0x220be84c] >= _0x9085277f[this._0xcf5116f4[_0x220be84c]];
        return true;
    }

    private static string Join(int[] _0xf410f511)
    {
        if (_0xf410f511 == null || _0xf410f511.Length == 0)
            return string.Empty;
        string _0x525db986 = _0xf410f511[0].ToString();
        for (int _0x801d0736 = 1; _0x801d0736 < _0xf410f511.Length; _0x801d0736++)
            _0x525db986 = _0x525db986 + _0xc6767520._0x5e7aaecf(new byte[1] { 248 }, 212) + _0xf410f511[_0x801d0736];
        return _0x525db986;
    }

    private const int KindRubies = 0;
    /// <summary>
    /// Fold one resolved spin into every mission. Returns how many missions completed
    /// on this spin, so the caller can pay the reward and fire the coin burst.
    /// </summary>
    public int _0x68854378(int[] _0xb39ae14b, _0x99dc1491 _0x19cc13f1, long _0x899fcdbf, int _0xec41c1de)
    {
        if (_0x19cc13f1 == null)
            return 0;
        bool _0xa5b6f88d = _0x19cc13f1.Payout > 0L;
        this._0x57d98447 = _0xa5b6f88d ? this._0x57d98447 + 1 : 0;
        int _0x2cdb207e = 0;
        bool _0x30654267 = false;
        if (_0xb39ae14b != null)
            for (int _0x247b6c9a = 0; _0x247b6c9a < _0xb39ae14b.Length; _0x247b6c9a++)
            {
                if (_0xb39ae14b[_0x247b6c9a] == _0x52061f7c.Ruby)
                    _0x2cdb207e++;
                if (_0xb39ae14b[_0x247b6c9a] == _0x52061f7c.Wild)
                    _0x30654267 = true;
            }

        int _0x48b622ba = 0;
        for (int _0xa5799a66 = 0; _0xa5799a66 < Active; _0xa5799a66++)
        {
            if (this._0xf0685520[_0xa5799a66])
                continue;
            int _0xd1854232 = this._0xcf5116f4[_0xa5799a66];
            int _0x8dd5b71f = this._0x41cbb983[_0xa5799a66];
            if (_0xd1854232 == KindRubies)
                this._0x41cbb983[_0xa5799a66] = Mathf.Max(_0x8dd5b71f, _0x2cdb207e);
            else if (_0xd1854232 == KindStreak)
                this._0x41cbb983[_0xa5799a66] = Mathf.Max(_0x8dd5b71f, this._0x57d98447);
            else if (_0xd1854232 == KindBigWin)
                this._0x41cbb983[_0xa5799a66] = (int)Mathf.Max(_0x8dd5b71f, _0x19cc13f1.Payout);
            else if (_0xd1854232 == KindSeal)
                this._0x41cbb983[_0xa5799a66] = _0x8dd5b71f + _0xec41c1de;
            else if (_0xd1854232 == KindHits)
                this._0x41cbb983[_0xa5799a66] = _0x8dd5b71f + (_0xa5b6f88d ? 1 : 0);
            else if (_0xd1854232 == KindWild)
                this._0x41cbb983[_0xa5799a66] = _0x8dd5b71f + (_0x30654267 ? 1 : 0);
            else if (_0xd1854232 == KindScatter)
                this._0x41cbb983[_0xa5799a66] = _0x8dd5b71f + (_0x19cc13f1.Scatters >= 3 ? 1 : 0);
            else if (_0xd1854232 == KindHighBet)
                this._0x41cbb983[_0xa5799a66] = _0x8dd5b71f + (_0x899fcdbf >= 100L ? 1 : 0);
            if (this._0x41cbb983[_0xa5799a66] >= _0x9085277f[_0xd1854232])
            {
                this._0x41cbb983[_0xa5799a66] = _0x9085277f[_0xd1854232];
                this._0xf0685520[_0xa5799a66] = true;
                _0x48b622ba++;
            }
        }

        this._0xb570059e();
        return _0x48b622ba;
    }

    private const int KindBigWin = 2;
    private int[] _0xcf5116f4 = new int[Active];
    private int[] _0x41cbb983 = new int[Active];
    public _0x8a41f8c5 _0x9ac1e897(_0x44a9791c _0x4ba49555)
    {
        this._0xcf5116f4 = _0x4ba49555._0x54b9e660(PoolSize, Active);
        this._0x41cbb983 = new int[Active];
        this._0xf0685520 = new bool[Active];
        this._0x57d98447 = 0;
        return this;
    }

    private int _0x57d98447;
    public string _0x6cd9fbe5(int _0x73e11844)
    {
        if (_0x73e11844 < 0 || _0x73e11844 >= this._0xcf5116f4.Length)
            return _0x58ec0788[0];
        return _0x58ec0788[this._0xcf5116f4[_0x73e11844]];
    }
}

internal static class _0xc6767520
{
    internal static string _0x5e7aaecf(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}