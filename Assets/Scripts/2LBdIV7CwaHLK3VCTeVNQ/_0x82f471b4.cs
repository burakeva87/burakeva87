using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The gilded cabinet: five columns of stones behind a bevelled frame.
///
/// BUILD ORDER IS THE DRAW ORDER (C.13). Inside one canvas a later sibling draws on top,
/// so the order below is not a style choice:
///     backdrop -> frame -> window (masked) -> columns -> glow -> sheen
/// The frame is created BEFORE the window it surrounds. Built the other way round, an
/// opaque-centred frame paints over the symbols and the reels read as an empty gold
/// blot while the game underneath works perfectly - which is exactly what shipped on
/// ANDROID-3297. Only translucent things (the payline glow, the sheen) are created
/// after the stones.
///
/// EVERY NUMBER IS DERIVED, NOT EYEBALLED (C.0 / rule 4). The cell size comes from the
/// board width minus the frame inset, and the window is then sized from the cell, so
/// nothing can stick out past the rounded edge:
///     CELL = floor((BoardWidth - 2*FrameInset) / 5) = floor((1060 - 36) / 5) = 204
///     WINDOW = 204*5 x 204*3 = 1020 x 612
/// </summary>
public sealed class _0x82f471b4 : MonoBehaviour
{
    private RectTransform _0x7f631f59;
    [SerializeField]
    private Sprite[] _symbols;
    private Image _0xd3613149;
    private const float FrameInset = 18f;
    private float _0xdb81b256;
    [SerializeField]
    private Sprite _plate;
    private const float CabinetH = 900f;
    private RectTransform _0x6d551c70;
    public const int Rows = 3;
    public const int Reels = 5;
    public void _0xc6a9c516(int _0x9bd6c51a, int _0x547a03ec)
    {
        if (_0x9bd6c51a >= 0 && _0x9bd6c51a < Reels && this._0x9379bac1[_0x9bd6c51a] != null)
            this._0x9379bac1[_0x9bd6c51a]._0x0bf9c93e(_0x547a03ec);
    }

    /// <summary>
    /// Light every cell that paid. The pulse is on the stone itself and the strip is a
    /// translucent plate over it, so the stone stays readable underneath.
    /// </summary>
    public void _0x28283394(_0x99dc1491 _0xe698f48b)
    {
        this._0x479fe71f();
        if (_0xe698f48b == null || this._0x6d551c70 == null)
            return;
        for (int _0x4fecef99 = 0; _0x4fecef99 < _0xe698f48b.WinningLines; _0x4fecef99++)
        {
            int[] _0xc60e275e = _0xe1643c2c.Line(_0xe698f48b._0x7e603054(_0x4fecef99));
            int _0x87debb7c = _0xe698f48b._0xc8ff40ec(_0x4fecef99);
            for (int _0xe5402e96 = 0; _0xe5402e96 < _0x87debb7c && _0xe5402e96 < Reels; _0xe5402e96++)
            {
                int _0x44f10cfe = _0xc60e275e[_0xe5402e96];
                Image _0x8267e5c0 = _0x2bfe8fd8.Plate(this._0x6d551c70, _0xd230876f._0x06da0d2c(new byte[4] { 112, 91, 88, 64 }, 55) + _0x4fecef99 + _0xd230876f._0x06da0d2c(new byte[1] { 216 }, 160) + _0xe5402e96, new Vector2(0.5f, 0.5f), new Vector2(this._0xdb81b256 - 10f, this._0xdb81b256 - 10f), _0xecf6b76b.GlowStrip, this._plate);
                _0x8267e5c0.rectTransform.anchoredPosition = new Vector2((_0xe5402e96 - 2) * this._0xdb81b256, (1 - _0x44f10cfe) * this._0xdb81b256);
                _0x8267e5c0.color = _0xecf6b76b.Fade(_0xecf6b76b.Gold, 0f);
                Sequence _0xb6a10492 = DOTween.Sequence().SetLink(_0x8267e5c0.gameObject);
                _0xb6a10492.Append(_0x8267e5c0.DOFade(0.55f, 0.35f));
                _0xb6a10492.AppendInterval(0.6f);
                _0xb6a10492.Append(_0x8267e5c0.DOFade(0f, 0.35f));
                _0x9f9dd1c0 _0x1a825318 = this._0x9379bac1[_0xe5402e96];
                if (_0x1a825318 == null)
                    continue;
                Image _0x74371e75 = _0x1a825318._0x9a10b6a9(_0x44f10cfe);
                if (_0x74371e75 == null)
                    continue;
                _0x74371e75.rectTransform.DOPunchScale(Vector3.one * 0.12f, 0.28f, 5, 0.6f).SetLink(_0x74371e75.gameObject);
            }
        }
    }

    /// <summary>The fallback schedule insists on a board; show it exactly.</summary>
    public void _0x1eb76d72(int _0x6e07c4a1, int[] _0x6e08c1bd)
    {
        if (_0x6e07c4a1 < 0 || _0x6e07c4a1 >= Reels || this._0x9379bac1[_0x6e07c4a1] == null || _0x6e08c1bd == null)
            return;
        int _0x026a63f3 = _0x6e07c4a1 * Rows;
        this._0x9379bac1[_0x6e07c4a1]._0xc78fae8c(_0x6e08c1bd[_0x026a63f3], _0x6e08c1bd[_0x026a63f3 + 1], _0x6e08c1bd[_0x026a63f3 + 2]);
    }

    private readonly _0x9f9dd1c0[] _0x9379bac1 = new _0x9f9dd1c0[Reels];
    private Image _0x33ad7560;
    /// <summary>Free spins recolour the trim, so the state is visible, not just counted.</summary>
    public void _0x2bf2fa92(Color _0x2ed5c10a)
    {
        if (this._0xd3613149 != null)
            this._0xd3613149.color = _0xecf6b76b.Fade(_0x2ed5c10a, 0.92f);
    }

    private void OnDestroy()
    {
        DOTween.Kill(this);
    }

    [SerializeField]
    private Sprite _frame;
    public float _0xdc0b84ee
    {
        get
        {
            return this._0xdb81b256;
        }
    }

    /// <summary>
    /// Lay the cabinet out at <paramref name = "centreY"/> in canvas units, inside the
    /// panel content the director passes in.
    /// </summary>
    public void _0x13c8e82e(RectTransform _0x8d05e1ca, _0xfcff778c _0x5b33931a, _0x44a9791c _0x82e815c4, float _0xa6ea537d)
    {
        if (_0x8d05e1ca == null)
            return;
        this._0xdb81b256 = Mathf.Floor((BoardWidth - (2f * FrameInset)) / Reels);
        float _0x690cb481 = this._0xdb81b256 * Reels;
        float _0x0f967147 = this._0xdb81b256 * Rows;
        this._0x7f631f59 = _0x2bfe8fd8.Node(_0x8d05e1ca, _0xd230876f._0x06da0d2c(new byte[11] { 114, 69, 69, 76, 99, 65, 66, 73, 78, 69, 84 }, 32), _0x2bfe8fd8.At(621f, _0xa6ea537d), new Vector2(CabinetW, CabinetH));
        // 1. backdrop - the cabinet body
        this._0x33ad7560 = _0x2bfe8fd8.Plate(this._0x7f631f59, _0xd230876f._0x06da0d2c(new byte[11] { 169, 139, 136, 131, 132, 143, 158, 168, 133, 142, 147 }, 234), new Vector2(0.5f, 0.5f), new Vector2(CabinetW, CabinetH), _0xecf6b76b.Fade(_0xecf6b76b.Surface3, 0.96f), this._plate);
        _0x2bfe8fd8.Rule(this._0x7f631f59, _0xd230876f._0x06da0d2c(new byte[12] { 18, 48, 51, 56, 63, 52, 37, 19, 52, 39, 52, 61 }, 81), new Vector2(0.5f, 1f), new Vector2(CabinetW - 60f, 6f), _0xecf6b76b.BevelTop).rectTransform.anchoredPosition = new Vector2(0f, -16f);
        _0x2bfe8fd8.Rule(this._0x7f631f59, _0xd230876f._0x06da0d2c(new byte[11] { 34, 0, 3, 8, 15, 4, 21, 39, 14, 14, 21 }, 97), new Vector2(0.5f, 0f), new Vector2(CabinetW - 60f, 6f), _0xecf6b76b.BevelBottom).rectTransform.anchoredPosition = new Vector2(0f, 16f);
        // 2. the frame, UNDER the stones it surrounds
        this._0xd3613149 = _0x2bfe8fd8.Plate(this._0x7f631f59, _0xd230876f._0x06da0d2c(new byte[12] { 183, 149, 150, 157, 154, 145, 128, 178, 134, 149, 153, 145 }, 244), new Vector2(0.5f, 0.56f), new Vector2(_0x690cb481 + 96f, _0x0f967147 + 96f), _0xecf6b76b.Fade(_0xecf6b76b.Gold, 0.92f), this._frame);
        // 3. the window: everything below is clipped to it
        RectTransform _0xbba4546c = _0x2bfe8fd8.Node(this._0x7f631f59, _0xd230876f._0x06da0d2c(new byte[10] { 252, 203, 203, 194, 249, 199, 192, 202, 193, 217 }, 174), new Vector2(0.5f, 0.56f), new Vector2(_0x690cb481, _0x0f967147));
        Image _0xc640ebfb = _0xbba4546c.gameObject.AddComponent<Image>();
        _0xc640ebfb.color = _0xecf6b76b.Fade(_0xecf6b76b.DeepInk, 0.92f);
        _0xc640ebfb.raycastTarget = false;
        _0xbba4546c.gameObject.AddComponent<RectMask2D>();
        // 4. the columns
        for (int _0xef6aef9e = 0; _0xef6aef9e < Reels; _0xef6aef9e++)
        {
            RectTransform _0x452b5062 = _0x2bfe8fd8.Node(_0xbba4546c, _0xd230876f._0x06da0d2c(new byte[4] { 47, 24, 24, 17 }, 125) + _0xef6aef9e, new Vector2(0.5f, 0.5f), new Vector2(this._0xdb81b256, _0x0f967147));
            _0x452b5062.anchoredPosition = new Vector2((_0xef6aef9e - 2) * this._0xdb81b256, 0f);
            _0x9f9dd1c0 _0xc0933c3c = _0x452b5062.gameObject.AddComponent<_0x9f9dd1c0>();
            this._0x9379bac1[_0xef6aef9e] = _0xc0933c3c._0xb091d56f(_0x452b5062, _0x5b33931a, _0x82e815c4, this._symbols, _0xef6aef9e, this._0xdb81b256);
        }

        // 5. the glow, translucent, so C.13 allows it over the stones
        this._0x6d551c70 = _0x2bfe8fd8.Node(this._0x7f631f59, _0xd230876f._0x06da0d2c(new byte[11] { 171, 154, 130, 151, 146, 149, 158, 188, 151, 148, 140 }, 251), new Vector2(0.5f, 0.56f), new Vector2(_0x690cb481, _0x0f967147));
        // 6. a faint sheen across the glass, also translucent
        _0x2bfe8fd8.Plate(this._0x7f631f59, _0xd230876f._0x06da0d2c(new byte[12] { 216, 250, 249, 242, 245, 254, 239, 200, 243, 254, 254, 245 }, 155), new Vector2(0.5f, 0.78f), new Vector2(_0x690cb481 - 40f, 90f), _0xecf6b76b.Fade(_0xecf6b76b.GoldLight, 0.07f), this._plate);
    }

    private const float CabinetW = 1150f;
    private const float BoardWidth = 1060f;
    public void _0xce9f91dd()
    {
        this._0x479fe71f();
        for (int _0xa8325435 = 0; _0xa8325435 < Reels; _0xa8325435++)
            if (this._0x9379bac1[_0xa8325435] != null)
                this._0x9379bac1[_0xa8325435]._0x7c5ef7ec();
        if (this._0x7f631f59 != null)
            this._0x7f631f59.DOPunchScale(Vector3.one * 0.012f, 0.18f, 6, 0.8f).SetLink(this._0x7f631f59.gameObject);
    }

    public void _0x479fe71f()
    {
        if (this._0x6d551c70 == null)
            return;
        for (int _0xb793cf97 = this._0x6d551c70.childCount - 1; _0xb793cf97 >= 0; _0xb793cf97--)
            Destroy(this._0x6d551c70.GetChild(_0xb793cf97).gameObject);
    }
}

internal static class _0xd230876f
{
    internal static string _0x06da0d2c(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}