using UnityEngine;

/// <summary>
/// The five reel strips, rebuilt from the session seed every time the player enters
/// the vault.
///
/// This is half of what makes two sessions visibly different (C.11): the stones that
/// sit NEXT TO each other on a reel change, so the board that scrolls past is a
/// different board, not the same one with a different number in the HUD.
///
/// A strip is 24 entries drawn from the weighted pool, then repaired so that no symbol
/// appears three times in a row - an unrepaired draw occasionally produces a strip that
/// visibly stutters.
/// </summary>
public sealed class _0xfcff778c
{
    public const int Rows = 3;
    /// <summary>
    /// The 5x3 board a set of stop positions produces. grid[reel * Rows + row], row 0
    /// at the top, which is the same order the paylines are written in.
    /// </summary>
    public int[] _0xa8f6c8d4(int[] _0xb695044c)
    {
        int[] _0x6d58539e = new int[Reels * Rows];
        for (int _0xe741b973 = 0; _0xe741b973 < Reels; _0xe741b973++)
        {
            int _0x1a11c27f = _0xb695044c != null && _0xe741b973 < _0xb695044c.Length ? _0xb695044c[_0xe741b973] : 0;
            for (int _0xac133e84 = 0; _0xac133e84 < Rows; _0xac133e84++)
                _0x6d58539e[(_0xe741b973 * Rows) + _0xac133e84] = this._0x4bd9c2ed(_0xe741b973, _0x1a11c27f + _0xac133e84);
        }

        return _0x6d58539e;
    }

    private int[] _0x5404abd0(_0x44a9791c _0x9b3fe73c)
    {
        int[] _0x9fdfccad = _0x52061f7c._0xf1ce2fd5;
        int[] _0x0083c049 = new int[StripLength];
        for (int _0x89502c30 = 0; _0x89502c30 < StripLength; _0x89502c30++)
            _0x0083c049[_0x89502c30] = _0x9fdfccad[_0x9b3fe73c._0x356b07e3(0, _0x9fdfccad.Length)];
        for (int _0x5a1a82bc = 2; _0x5a1a82bc < StripLength; _0x5a1a82bc++)
        {
            int _0x2f3e9212 = 0;
            while (_0x0083c049[_0x5a1a82bc] == _0x0083c049[_0x5a1a82bc - 1] && _0x0083c049[_0x5a1a82bc] == _0x0083c049[_0x5a1a82bc - 2] && _0x2f3e9212 < 12)
            {
                _0x0083c049[_0x5a1a82bc] = _0x9fdfccad[_0x9b3fe73c._0x356b07e3(0, _0x9fdfccad.Length)];
                _0x2f3e9212++;
            }
        }

        return _0x0083c049;
    }

    public const int Reels = 5;
    private int[][] _0xe10441fc = new int[Reels][];
    public _0xfcff778c _0x5301ee5c(_0x44a9791c _0x3eec9d8b)
    {
        this._0xe10441fc = new int[Reels][];
        for (int _0x2e2fe0ea = 0; _0x2e2fe0ea < Reels; _0x2e2fe0ea++)
            this._0xe10441fc[_0x2e2fe0ea] = this._0x5404abd0(_0x3eec9d8b);
        return this;
    }

    public int _0x4bd9c2ed(int _0x6cca68c6, int _0xf1a202fa)
    {
        if (this._0xe10441fc == null || _0x6cca68c6 < 0 || _0x6cca68c6 >= Reels || this._0xe10441fc[_0x6cca68c6] == null)
            return _0x52061f7c.Ruby;
        int _0xed63f29d = this._0xe10441fc[_0x6cca68c6].Length;
        int _0xff7c859a = ((_0xf1a202fa % _0xed63f29d) + _0xed63f29d) % _0xed63f29d;
        return this._0xe10441fc[_0x6cca68c6][_0xff7c859a];
    }

    public const int StripLength = 24;
}