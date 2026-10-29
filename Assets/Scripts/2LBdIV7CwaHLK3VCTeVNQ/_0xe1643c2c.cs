using UnityEngine;

/// <summary>
/// The nine fixed paylines and what a board pays on them.
///
/// Lines run left to right from reel 0 and need three or more of a kind. The wild
/// substitutes for everything except the scatter; the scatter pays nothing on a line
/// and instead counts anywhere on the board.
///
/// Every payout is a multiplier of the TOTAL bet (see <see cref = "SymbolTable"/>), so
/// the HUD never has to show per-line arithmetic.
/// </summary>
public static class _0xe1643c2c
{
    /// <summary>
    /// Evaluate one board. Fills <paramref name = "result"/> rather than returning a new
    /// object so a spin allocates nothing on the hot path.
    /// </summary>
    public static void Evaluate(int[] _0x158a9ba9, long _0x9df5d168, _0x99dc1491 _0x715eac84)
    {
        if (_0x715eac84 == null)
            return;
        _0x715eac84.Reset();
        if (_0x158a9ba9 == null || _0x158a9ba9.Length < _0xfcff778c.Reels * _0xfcff778c.Rows)
            return;
        for (int _0x243161d3 = 0; _0x243161d3 < _0x002568ce.Length; _0x243161d3++)
        {
            int[] _0x656218eb = _0x002568ce[_0x243161d3];
            int _0x065d768d = LeadSymbol(_0x158a9ba9, _0x656218eb);
            if (_0x065d768d < 0 || _0x065d768d == _0x52061f7c.Scatter)
                continue;
            int _0xa2af93bd = 0;
            for (int _0x7e2f23c2 = 0; _0x7e2f23c2 < _0xfcff778c.Reels; _0x7e2f23c2++)
            {
                int _0xa5824e19 = _0x158a9ba9[(_0x7e2f23c2 * _0xfcff778c.Rows) + _0x656218eb[_0x7e2f23c2]];
                if (_0xa5824e19 == _0x065d768d || _0xa5824e19 == _0x52061f7c.Wild)
                    _0xa2af93bd++;
                else
                    break;
            }

            if (_0xa2af93bd < 3)
                continue;
            float _0xd46e1375 = _0x52061f7c.Payout(_0x065d768d, _0xa2af93bd);
            if (_0xd46e1375 <= 0f)
                continue;
            _0x715eac84._0x6fcb3b7b(_0x243161d3, _0x065d768d, _0xa2af93bd, (long)Mathf.Round(_0xd46e1375 * _0x9df5d168));
        }

        int _0x6d0d084e = 0;
        for (int _0x325ef827 = 0; _0x325ef827 < _0x158a9ba9.Length; _0x325ef827++)
            if (_0x158a9ba9[_0x325ef827] == _0x52061f7c.Scatter)
                _0x6d0d084e++;
        _0x715eac84.Scatters = _0x6d0d084e;
    }

    public static int _0x8c962780
    {
        get
        {
            return _0x002568ce.Length;
        }
    }

    /// <summary>
    /// The symbol a line actually pays on: the first non-wild from the left, because a
    /// line of wilds followed by rubies pays as rubies unless it is all wilds.
    /// </summary>
    private static int LeadSymbol(int[] _0x3cdb7f36, int[] _0xbbbd686e)
    {
        int _0x072ec8cb = _0x3cdb7f36[_0xbbbd686e[0]];
        if (_0x072ec8cb != _0x52061f7c.Wild)
            return _0x072ec8cb;
        for (int _0xa59c2e30 = 1; _0xa59c2e30 < _0xfcff778c.Reels; _0xa59c2e30++)
        {
            int _0xb93df571 = _0x3cdb7f36[(_0xa59c2e30 * _0xfcff778c.Rows) + _0xbbbd686e[_0xa59c2e30]];
            if (_0xb93df571 == _0x52061f7c.Scatter)
                return _0x52061f7c.Wild;
            if (_0xb93df571 != _0x52061f7c.Wild)
                return _0xb93df571;
        }

        return _0x52061f7c.Wild;
    }

    public static int[] Line(int _0x6708746c)
    {
        if (_0x6708746c < 0 || _0x6708746c >= _0x002568ce.Length)
            return _0x002568ce[0];
        return _0x002568ce[_0x6708746c];
    }

    /// <summary>Nine lines, one row index per reel. Row 0 is the top row.</summary>
    private static readonly int[][] _0x002568ce =
    {
        new[]
        {
            1,
            1,
            1,
            1,
            1
        },
        new[]
        {
            0,
            0,
            0,
            0,
            0
        },
        new[]
        {
            2,
            2,
            2,
            2,
            2
        },
        new[]
        {
            0,
            1,
            2,
            1,
            0
        },
        new[]
        {
            2,
            1,
            0,
            1,
            2
        },
        new[]
        {
            0,
            0,
            1,
            2,
            2
        },
        new[]
        {
            1,
            0,
            1,
            2,
            1
        },
        new[]
        {
            1,
            2,
            1,
            0,
            1
        },
        new[]
        {
            2,
            2,
            1,
            0,
            0
        }
    };
}