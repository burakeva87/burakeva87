using UnityEngine;

/// <summary>
/// What one spin paid: the winning lines, the total payout and the scatter count.
///
/// A plain data object with no constructor (C.59). One instance is reused for every
/// spin and cleared with <see cref = "Reset"/>, so resolving a spin allocates nothing.
/// </summary>
public sealed class _0x99dc1491
{
    public const int MaxLines = 9;
    public int WinningLines;
    public long BestLinePayout;
    private readonly int[] _0x9106e95c = new int[MaxLines];
    public void Reset()
    {
        this.Payout = 0L;
        this.Scatters = 0;
        this.WinningLines = 0;
        this.BestSymbol = -1;
        this.BestRun = 0;
        this.BestLinePayout = 0L;
    }

    /// <summary>Copy another result into this one, so a plan can be replayed.</summary>
    public void _0xb6ec59e7(_0x99dc1491 _0x197a3914)
    {
        if (_0x197a3914 == null)
        {
            this.Reset();
            return;
        }

        this.Reset();
        for (int _0xe7fbf24b = 0; _0xe7fbf24b < _0x197a3914.WinningLines; _0xe7fbf24b++)
            this._0x3966d127[_0xe7fbf24b] = _0x197a3914._0x3966d127[_0xe7fbf24b];
        for (int _0xb0753920 = 0; _0xb0753920 < _0x197a3914.WinningLines; _0xb0753920++)
            this._0x07136586[_0xb0753920] = _0x197a3914._0x07136586[_0xb0753920];
        for (int _0x3e403c6e = 0; _0x3e403c6e < _0x197a3914.WinningLines; _0x3e403c6e++)
            this._0x9106e95c[_0x3e403c6e] = _0x197a3914._0x9106e95c[_0x3e403c6e];
        this.WinningLines = _0x197a3914.WinningLines;
        this.Payout = _0x197a3914.Payout;
        this.Scatters = _0x197a3914.Scatters;
        this.BestSymbol = _0x197a3914.BestSymbol;
        this.BestRun = _0x197a3914.BestRun;
        this.BestLinePayout = _0x197a3914.BestLinePayout;
    }

    public long Payout;
    public int Scatters;
    public void _0x6fcb3b7b(int _0x1d0b5d26, int _0x695e3176, int _0x2628d458, long payout)
    {
        if (this.WinningLines < MaxLines)
        {
            this._0x3966d127[this.WinningLines] = _0x1d0b5d26;
            this._0x07136586[this.WinningLines] = _0x695e3176;
            this._0x9106e95c[this.WinningLines] = _0x2628d458;
            this.WinningLines++;
        }

        this.Payout += payout;
        if (payout > this.BestLinePayout)
        {
            this.BestLinePayout = payout;
            this.BestSymbol = _0x695e3176;
            this.BestRun = _0x2628d458;
        }
    }

    public int _0xc8ff40ec(int _0xa706de83)
    {
        if (_0xa706de83 < 0 || _0xa706de83 >= this.WinningLines)
            return 0;
        return this._0x9106e95c[_0xa706de83];
    }

    public int BestSymbol = -1;
    public int BestRun;
    private readonly int[] _0x3966d127 = new int[MaxLines];
    private readonly int[] _0x07136586 = new int[MaxLines];
    public int _0x7e603054(int _0x12f2957d)
    {
        if (_0x12f2957d < 0 || _0x12f2957d >= this.WinningLines)
            return 0;
        return this._0x3966d127[_0x12f2957d];
    }

    public int _0x2f373967(int _0x3265c6f2)
    {
        if (_0x3265c6f2 < 0 || _0x3265c6f2 >= this.WinningLines)
            return _0x52061f7c.Ruby;
        return this._0x07136586[_0x3265c6f2];
    }
}