using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// One reel column: three visible cells, one spare above them, and the scroll that
/// carries stones through the window.
///
/// The column is built at runtime, so it is set up through Init rather than through
/// serialized fields (C.59 - no constructor, and set-up belongs in a method the owner
/// calls, not in Awake where it would race the template controllers).
///
/// HOW THE SCROLL WORKS. The four cells sit at fixed local positions one cell apart.
/// The content rect tweens down by exactly one cell, LoopType.Restart snaps it back to
/// zero, and on every completed step the symbols shift down by one place while a fresh
/// stone drops into the spare at the top. The eye sees a continuous reel; the rect
/// never travels more than one cell, so nothing drifts out of the mask.
///
/// Every cell is a UGUI Image with preserveAspect on: the generated stones are square
/// today, and a regeneration that is not would otherwise squash one into an egg (F.2a).
/// </summary>
public sealed class _0x9f9dd1c0 : MonoBehaviour
{
    /// <summary>Forced board: show these three stones whatever the strip says.</summary>
    public void _0xc78fae8c(int _0x92f3f8ed, int _0xfd21d2d3, int _0xd41604e9)
    {
        if (this._0x47a8f0ca == null)
            return;
        this._0x905f2ef4();
        this._0x2cd1b2d7[0] = this._0xeab924e8();
        this._0x2cd1b2d7[1] = _0x92f3f8ed;
        this._0x2cd1b2d7[2] = _0xfd21d2d3;
        this._0x2cd1b2d7[3] = _0xd41604e9;
        this._0xff910c38();
        this._0x47a8f0ca.anchoredPosition = Vector2.zero;
        Sequence _0x371a4102 = DOTween.Sequence().SetLink(this._0x47a8f0ca.gameObject);
        _0x371a4102.Append(this._0x47a8f0ca.DOAnchorPosY(-BounceDepth, 0.08f).SetEase(Ease.OutQuad));
        _0x371a4102.Append(this._0x47a8f0ca.DOAnchorPosY(0f, 0.12f).SetEase(Ease.OutBack));
    }

    private void OnDestroy()
    {
        this._0x905f2ef4();
        DOTween.Kill(this);
    }

    /// <summary>The cell showing visible row <paramref name = "row"/> (0 = top).</summary>
    public Image _0x9a10b6a9(int _0x8fad00ea)
    {
        int _0xc26a6d1b = Mathf.Clamp(_0x8fad00ea + 1, 0, CellCount - 1);
        return this._0x6051e47f[_0xc26a6d1b];
    }

    private void _0x905f2ef4()
    {
        if (this._0xba4e50c0 != null)
        {
            this._0xba4e50c0.Kill();
            this._0xba4e50c0 = null;
        }
    }

    private const float BounceDepth = 22f;
    private readonly Image[] _0x6051e47f = new Image[CellCount];
    /// <summary>
    /// Settle on <paramref name = "stop"/>. The three visible rows become the strip
    /// entries at stop, stop+1 and stop+2 - exactly what ReelStrips.Board reports, so
    /// what the player sees and what the evaluator reads can never disagree.
    /// </summary>
    public void _0x0bf9c93e(int _0x5e838260)
    {
        if (this._0x47a8f0ca == null)
            return;
        this._0x905f2ef4();
        this._0x2cd1b2d7[0] = this._0x319ce7e9(_0x5e838260 - 1);
        for (int _0x58358775 = 0; _0x58358775 < VisibleRows; _0x58358775++)
            this._0x2cd1b2d7[_0x58358775 + 1] = this._0x319ce7e9(_0x5e838260 + _0x58358775);
        this._0xff910c38();
        this._0x47a8f0ca.anchoredPosition = Vector2.zero;
        Sequence _0x2f39a63a = DOTween.Sequence().SetLink(this._0x47a8f0ca.gameObject);
        _0x2f39a63a.Append(this._0x47a8f0ca.DOAnchorPosY(-BounceDepth, 0.08f).SetEase(Ease.OutQuad));
        _0x2f39a63a.Append(this._0x47a8f0ca.DOAnchorPosY(0f, 0.12f).SetEase(Ease.OutBack));
    }

    /// <summary>Visible rows, top to bottom. The board and the paylines use the same order.</summary>
    public const int VisibleRows = 3;
    private int _0xeab924e8()
    {
        if (this._0x1d0fd0d5 != null && this._0x7a90ee7a != null)
            return this._0x1d0fd0d5._0x4bd9c2ed(this._0xae96b92f, this._0x7a90ee7a._0x356b07e3(0, _0xfcff778c.StripLength));
        return _0x52061f7c.Ruby;
    }

    private const int CellCount = VisibleRows + 1;
    private Sprite _0x42035e18(int _0xd5dd8860)
    {
        if (this._0xdc20adc3 == null || this._0xdc20adc3.Length == 0)
            return null;
        int _0x340f417e = _0xd5dd8860 < 0 ? 0 : _0xd5dd8860 % this._0xdc20adc3.Length;
        return this._0xdc20adc3[_0x340f417e];
    }

    private void _0xff910c38()
    {
        for (int _0x8a2868ba = 0; _0x8a2868ba < CellCount; _0x8a2868ba++)
            if (this._0x6051e47f[_0x8a2868ba] != null)
            {
                this._0x6051e47f[_0x8a2868ba].sprite = this._0x42035e18(this._0x2cd1b2d7[_0x8a2868ba]);
                this._0x6051e47f[_0x8a2868ba].color = Color.white;
                this._0x6051e47f[_0x8a2868ba].rectTransform.localScale = Vector3.one;
            }
    }

    private Sprite[] _0xdc20adc3;
    private int _0xae96b92f;
    private float _0xd36d271c;
    private float _0xd63ba151(int _0xb7100956)
    {
        // index 0 is the spare above the window, 1..3 are the visible rows.
        return (2 - _0xb7100956) * this._0xd36d271c;
    }

    private const float StepSeconds = 0.075f;
    private _0x44a9791c _0x7a90ee7a;
    private readonly int[] _0x2cd1b2d7 = new int[CellCount];
    private Tween _0xba4e50c0;
    /// <summary>Start scrolling. Safe to call on a column that is already moving.</summary>
    public void _0x7c5ef7ec()
    {
        if (this._0x47a8f0ca == null)
            return;
        this._0x905f2ef4();
        this._0x47a8f0ca.anchoredPosition = Vector2.zero;
        this._0xba4e50c0 = this._0x47a8f0ca.DOAnchorPosY(-this._0xd36d271c, StepSeconds).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart).OnStepComplete(() => this._0xcd35dc64()).SetLink(this._0x47a8f0ca.gameObject);
    }

    private _0xfcff778c _0x1d0fd0d5;
    private void _0xcd35dc64()
    {
        for (int _0x3db06c6d = CellCount - 1; _0x3db06c6d > 0; _0x3db06c6d--)
            this._0x2cd1b2d7[_0x3db06c6d] = this._0x2cd1b2d7[_0x3db06c6d - 1];
        this._0x2cd1b2d7[0] = this._0xeab924e8();
        this._0xff910c38();
    }

    private RectTransform _0x47a8f0ca;
    private int _0x319ce7e9(int _0x556e4874)
    {
        if (this._0x1d0fd0d5 == null)
            return _0x52061f7c.Ruby;
        return this._0x1d0fd0d5._0x4bd9c2ed(this._0xae96b92f, _0x556e4874);
    }

    /// <summary>
    /// Build the column inside <paramref name = "host"/>. The caller owns the window and
    /// its mask; this only lays out the cells and keeps the references it needs.
    /// </summary>
    public _0x9f9dd1c0 _0xb091d56f(RectTransform _0xd2c4d115, _0xfcff778c _0x3a02a00e, _0x44a9791c _0xd1672b5e, Sprite[] _0x42e779a0, int _0xa4d3cf31, float _0x7d5da305)
    {
        this._0x1d0fd0d5 = _0x3a02a00e;
        this._0x7a90ee7a = _0xd1672b5e;
        this._0xdc20adc3 = _0x42e779a0;
        this._0xae96b92f = _0xa4d3cf31;
        this._0xd36d271c = _0x7d5da305;
        this._0x47a8f0ca = _0x2bfe8fd8.Node(_0xd2c4d115, _0x9fa743ed._0xf3c144a2(new byte[11] { 161, 150, 150, 159, 176, 156, 157, 135, 150, 157, 135 }, 243), new Vector2(0.5f, 0.5f), new Vector2(_0x7d5da305, _0x7d5da305 * VisibleRows));
        for (int _0xa6e6887c = 0; _0xa6e6887c < CellCount; _0xa6e6887c++)
        {
            this._0x2cd1b2d7[_0xa6e6887c] = this._0xeab924e8();
            Image _0x7895d473 = _0x2bfe8fd8.Picture(this._0x47a8f0ca, _0x9fa743ed._0xf3c144a2(new byte[4] { 46, 8, 1, 1 }, 109) + _0xa6e6887c, this._0x42035e18(this._0x2cd1b2d7[_0xa6e6887c]), new Vector2(0.5f, 0.5f), new Vector2(_0x7d5da305 * 0.86f, _0x7d5da305 * 0.86f), Color.white);
            _0x7895d473.rectTransform.anchoredPosition = new Vector2(0f, this._0xd63ba151(_0xa6e6887c));
            this._0x6051e47f[_0xa6e6887c] = _0x7895d473;
        }

        return this;
    }
}

internal static class _0x9fa743ed
{
    internal static string _0xf3c144a2(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}