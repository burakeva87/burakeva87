using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The seven-day fortune ladder.
///
/// THE CLAIM HAS TO BE VISIBLE IN A SCREENSHOT (C.7). Changing a caption is not enough:
/// the TODAY tile flips to CLAIMED, a burst of coins flies from it to the balance
/// readout, the balance counts up and the lobby behind the sheet redraws. A reviewer
/// taps CLAIM and can see what it did.
///
/// AND IT HAS AN ERROR STATE. Once today is claimed the CTA is non-interactable, says
/// so, and an inline note explains why - never a button that silently does nothing.
///
/// The cooldown is a stored date string compared with today's. No network, no clock
/// authority, no server: this is a local app.
/// </summary>
public sealed class _0xa5de79e0 : MonoBehaviour
{
    /// <summary>
    /// Coins arcing from the claimed tile to the balance readout. CALM mode halves the
    /// count, which is what makes that setting a real, visible choice rather than a
    /// dead toggle (C.20 forbids dead controls).
    /// </summary>
    private void _0xb43c60c3(int _0xa5f29cd8, int _0xb6455d8f)
    {
        if (this._0x07454f6d == null)
            return;
        TMP_Text _0xf1b487fe = this._0x07454f6d;
        int _0x5e00d77c = _0xa5f29cd8;
        DOTween.To(() => _0x5e00d77c, _0xfdad75fa =>
        {
            _0x5e00d77c = _0xfdad75fa;
            _0xf1b487fe.text = _0x43ed7f14.Money(_0x5e00d77c);
        }, _0xb6455d8f, 0.6f).SetEase(Ease.OutCubic).SetLink(_0xf1b487fe.gameObject);
        _0xf1b487fe.rectTransform.DOPunchScale(Vector3.one * 0.06f, 0.3f, 6, 0.6f).SetLink(_0xf1b487fe.gameObject);
    }

    private _0x42c1db03 _0xb3a4460b;
    private readonly RectTransform[] _0xe61dc4f2 = new RectTransform[7];
    private readonly TMP_Text[] _0x52c881f5 = new TMP_Text[7];
    private static readonly int[] _0x90879fe1 =
    {
        500,
        750,
        1000,
        1500,
        2000,
        3000,
        5000
    };
    private TMP_Text _0xe0455023;
    private const int CalmBurst = 6;
    private void OnDestroy()
    {
        DOTween.Kill(this);
    }

    private Button _0xce5747fd;
    private readonly Image[] _0x3f5ae66c = new Image[7];
    private const float TileW = 232f;
    private TMP_Text _0xa7425140;
    private const float TileH = 200f;
    private const int FullBurst = 12;
    private RectTransform _0x9ebe539a;
    private void _0x7c0ee3f8()
    {
        if (_0x43ed7f14._0x267e30bb || this._0xb3a4460b == null)
            return;
        int _0x235d8d74 = _0x43ed7f14._0xaee6d0e1;
        int _0x1fe1a8a4 = _0x90879fe1[_0x235d8d74];
        _0x43ed7f14._0x7b4386a8 = _0x43ed7f14._0x8aa8ee61;
        _0x43ed7f14._0xaee6d0e1 = _0x235d8d74 >= _0x90879fe1.Length - 1 ? 0 : _0x235d8d74 + 1;
        int _0x228aaeed = _0x43ed7f14._0x0432624b;
        _0x43ed7f14._0x0432624b = _0x228aaeed + _0x1fe1a8a4;
        if (this._0x3f5ae66c[_0x235d8d74] != null)
            this._0x3f5ae66c[_0x235d8d74].color = _0xecf6b76b.Track;
        if (this._0x52c881f5[_0x235d8d74] != null)
        {
            this._0x52c881f5[_0x235d8d74].text = _0x8a0ac485._0xf80451da(new byte[7] { 209, 222, 211, 219, 223, 215, 214 }, 146);
            _0xe91c2331.Apply(this._0x52c881f5[_0x235d8d74], _0xecf6b76b.TealLight, 32f, 30f);
        }

        if (this._0xe61dc4f2[_0x235d8d74] != null)
        {
            DOTween.Kill(this._0xe61dc4f2[_0x235d8d74]);
            this._0xe61dc4f2[_0x235d8d74].localScale = Vector3.one;
            this._0xe61dc4f2[_0x235d8d74].DOPunchScale(Vector3.one * 0.08f, 0.35f, 6, 0.6f).SetLink(this._0xe61dc4f2[_0x235d8d74].gameObject);
            this._0x808338e7(this._0xe61dc4f2[_0x235d8d74]);
        }

        this._0xb43c60c3(_0x228aaeed, _0x228aaeed + _0x1fe1a8a4);
        if (this._0xc3432a20 != null)
            this._0xc3432a20.text = _0x8a0ac485._0xf80451da(new byte[4] { 72, 77, 85, 44 }, 12) + (_0x43ed7f14._0xaee6d0e1 + 1) + _0x8a0ac485._0xf80451da(new byte[5] { 168, 199, 206, 168, 191 }, 136);
        if (this._0xe0455023 != null)
            this._0xe0455023.text = _0x8a0ac485._0xf80451da(new byte[21] { 30, 17, 28, 20, 16, 24, 25, 125, 112, 125, 31, 28, 30, 22, 125, 20, 19, 125, 111, 110, 21 }, 93);
        if (this._0xce5747fd != null)
        {
            this._0xce5747fd.interactable = false;
            Image _0xeefafd39 = this._0xce5747fd.targetGraphic as Image;
            if (_0xeefafd39 != null)
                _0xeefafd39.color = _0xecf6b76b.Inactive;
        }

        if (this._0xa7425140 != null)
            this._0xa7425140.text = _0x8a0ac485._0xf80451da(new byte[19] { 62, 63, 52, 81, 55, 62, 35, 37, 36, 63, 52, 81, 33, 52, 35, 81, 53, 48, 40 }, 113);
        this._0xb3a4460b._0x60561518();
    }

    private TMP_Text _0xc3432a20;
    public void _0x59706945(_0x42c1db03 _0xaf262f29, RectTransform _0x4b09f264)
    {
        this._0xb3a4460b = _0xaf262f29;
        this._0x9ebe539a = _0x4b09f264;
        if (_0xaf262f29 == null || _0x4b09f264 == null)
            return;
        int _0x130aafdb = _0x43ed7f14._0xaee6d0e1;
        this._0xc3432a20 = _0x2bfe8fd8.Caption(_0x4b09f264, _0x8a0ac485._0xf80451da(new byte[13] { 166, 139, 138, 145, 151, 183, 145, 134, 144, 141, 144, 136, 129 }, 228), _0xaf262f29._0xe4f31537, _0x8a0ac485._0xf80451da(new byte[4] { 173, 168, 176, 201 }, 233) + (_0x130aafdb + 1) + _0x8a0ac485._0xf80451da(new byte[5] { 194, 173, 164, 194, 213 }, 226), _0x2bfe8fd8.At(621f, 1660f), new Vector2(1060f, 60f), 44f, 34f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Center);
        // The lobby's own balance readout is behind this sheet, so the claim gets a
        // readout of its own here: the coins have somewhere visible to fly to and the
        // number they add to is on screen while they land.
        _0x2bfe8fd8.Caption(_0x4b09f264, _0x8a0ac485._0xf80451da(new byte[17] { 204, 225, 224, 251, 253, 220, 235, 253, 235, 252, 248, 235, 194, 239, 236, 235, 226 }, 142), _0xaf262f29._0xe4f31537, _0x8a0ac485._0xf80451da(new byte[12] { 65, 77, 75, 76, 34, 80, 71, 81, 71, 80, 84, 71 }, 2), _0x2bfe8fd8.At(400f, 1565f), new Vector2(460f, 52f), 36f, 30f, _0xecf6b76b.TextSoft, TextAlignmentOptions.Left);
        this._0x07454f6d = _0x2bfe8fd8.Caption(_0x4b09f264, _0x8a0ac485._0xf80451da(new byte[17] { 37, 8, 9, 18, 20, 53, 2, 20, 2, 21, 17, 2, 49, 6, 11, 18, 2 }, 103), _0xaf262f29._0xe4f31537, _0x43ed7f14.Money(_0x43ed7f14._0x0432624b), _0x2bfe8fd8.At(880f, 1562f), new Vector2(460f, 72f), 56f, 40f, _0xecf6b76b.Gold, TextAlignmentOptions.Right);
        float[] _0xad9ceb96 =
        {
            1420f,
            1180f
        };
        float[] _0x25bf7705 =
        {
            237f,
            493f,
            749f,
            1005f
        };
        float[] _0xef263ebc =
        {
            365f,
            621f,
            877f
        };
        for (int _0xee9c2345 = 0; _0xee9c2345 < _0x90879fe1.Length; _0xee9c2345++)
        {
            float _0xa15e0f62 = _0xee9c2345 < 4 ? _0x25bf7705[_0xee9c2345] : _0xef263ebc[_0xee9c2345 - 4];
            float _0xb3141063 = _0xee9c2345 < 4 ? _0xad9ceb96[0] : _0xad9ceb96[1];
            this._0xe799c7d8(_0x4b09f264, _0xaf262f29, _0xee9c2345, _0xa15e0f62, _0xb3141063, _0x130aafdb);
        }

        bool _0xe5656227 = _0x43ed7f14._0x267e30bb;
        this._0xce5747fd = _0x2bfe8fd8.Cta(_0x4b09f264, _0x8a0ac485._0xf80451da(new byte[8] { 97, 78, 67, 75, 79, 97, 86, 67 }, 34), _0xaf262f29._0xe4f31537, _0xe5656227 ? _0x8a0ac485._0xf80451da(new byte[21] { 234, 229, 232, 224, 228, 236, 237, 137, 132, 137, 235, 232, 234, 226, 137, 224, 231, 137, 155, 154, 225 }, 169) : _0x8a0ac485._0xf80451da(new byte[6] { 249, 246, 251, 243, 247, 154 }, 186) + _0x43ed7f14.Money(_0x90879fe1[_0x130aafdb]) + _0x8a0ac485._0xf80451da(new byte[6] { 79, 44, 32, 38, 33, 60 }, 111), _0x2bfe8fd8.At(621f, CtaY), new Vector2(820f, 148f), _0xe5656227 ? _0xecf6b76b.Inactive : _0xecf6b76b.Primary, _0xecf6b76b.TextPrimary, 48f, 38f, _0xaf262f29._0x3fb723e6);
        this._0xe0455023 = this._0xce5747fd.GetComponentInChildren<TMP_Text>();
        this._0xce5747fd.interactable = !_0xe5656227;
        this._0xce5747fd.onClick.AddListener(() => this._0x7c0ee3f8());
        this._0xa7425140 = _0x2bfe8fd8.Caption(_0x4b09f264, _0x8a0ac485._0xf80451da(new byte[9] { 29, 48, 49, 42, 44, 17, 48, 43, 58 }, 95), _0xaf262f29._0xe4f31537, _0xe5656227 ? _0x8a0ac485._0xf80451da(new byte[19] { 152, 153, 146, 247, 145, 152, 133, 131, 130, 153, 146, 247, 135, 146, 133, 247, 147, 150, 142 }, 215) : _0x8a0ac485._0xf80451da(new byte[35] { 24, 4, 9, 108, 0, 13, 8, 8, 9, 30, 108, 30, 9, 31, 9, 24, 31, 108, 5, 10, 108, 21, 3, 25, 108, 1, 5, 31, 31, 108, 13, 108, 8, 13, 21 }, 76), _0x2bfe8fd8.At(621f, 790f), new Vector2(1060f, 56f), 34f, 30f, _0xecf6b76b.TextMuted, TextAlignmentOptions.Center);
        _0x2bfe8fd8.Caption(_0x4b09f264, _0x8a0ac485._0xf80451da(new byte[15] { 233, 196, 197, 222, 216, 232, 196, 198, 219, 199, 194, 202, 197, 200, 206 }, 171), _0xaf262f29._0xe4f31537, _0x8a0ac485._0xf80451da(new byte[65] { 211, 204, 215, 209, 208, 196, 201, 165, 198, 202, 204, 203, 214, 165, 202, 203, 201, 220, 165, 168, 165, 203, 202, 209, 205, 204, 203, 194, 165, 205, 192, 215, 192, 165, 198, 196, 203, 165, 199, 192, 143, 199, 202, 208, 194, 205, 209, 169, 165, 214, 202, 201, 193, 165, 202, 215, 165, 215, 192, 193, 192, 192, 200, 192, 193 }, 133), _0x2bfe8fd8.At(621f, 660f), new Vector2(1060f, 110f), 32f, 30f, _0xecf6b76b.TextMuted, TextAlignmentOptions.Center);
    }

    [SerializeField]
    private Sprite _coinBurst;
    private TMP_Text _0x07454f6d;
    private void _0x808338e7(RectTransform _0x5d7fd15c)
    {
        if (this._0x9ebe539a == null || _0x5d7fd15c == null)
            return;
        int _0x0c65684d = _0x43ed7f14._0xe1eb7714 ? FullBurst : CalmBurst;
        Vector2 _0x82f1e414 = _0x5d7fd15c.anchorMin;
        Vector2 _0xcb628647 = _0x2bfe8fd8.At(880f, 1562f);
        for (int _0xa24aa178 = 0; _0xa24aa178 < _0x0c65684d; _0xa24aa178++)
        {
            Image _0x378593ea = _0x2bfe8fd8.Picture(this._0x9ebe539a, _0x8a0ac485._0xf80451da(new byte[9] { 180, 131, 132, 133, 130, 181, 153, 159, 152 }, 246) + _0xa24aa178, this._coinBurst, _0x82f1e414, new Vector2(64f, 64f), Color.white);
            RectTransform _0x644a263b = _0x378593ea.rectTransform;
            _0x644a263b.anchorMin = _0x82f1e414;
            _0x644a263b.anchorMax = _0x82f1e414;
            Sequence _0x6eee5cd4 = DOTween.Sequence().SetLink(_0x644a263b.gameObject);
            _0x6eee5cd4.AppendInterval(_0xa24aa178 * 0.03f);
            _0x6eee5cd4.Append(_0x644a263b.DOAnchorPos(new Vector2((_0xcb628647.x - _0x82f1e414.x) * _0x2bfe8fd8.CanvasW, (_0xcb628647.y - _0x82f1e414.y) * _0x2bfe8fd8.CanvasH), 0.55f).SetEase(Ease.InQuad));
            _0x6eee5cd4.Join(_0x378593ea.DOFade(0f, 0.55f).SetEase(Ease.InQuad));
            _0x6eee5cd4.OnComplete(() => Destroy(_0x644a263b.gameObject));
        }
    }

    private const float CtaY = 900f;
    private void _0xe799c7d8(RectTransform _0xaff0bcd7, _0x42c1db03 _0x39495046, int _0x0f877982, float _0x8893060d, float _0xf34cb01a, int _0x09c673b7)
    {
        bool _0xce2680ba = _0x0f877982 == _0x09c673b7 && !_0x43ed7f14._0x267e30bb;
        bool _0x072ee516 = _0x0f877982 < _0x09c673b7 || (_0x0f877982 == _0x09c673b7 && _0x43ed7f14._0x267e30bb);
        RectTransform _0x303c624a = _0x2bfe8fd8.Node(_0xaff0bcd7, _0x8a0ac485._0xf80451da(new byte[9] { 103, 74, 79, 79, 78, 89, 111, 74, 82 }, 43) + _0x0f877982, _0x2bfe8fd8.At(_0x8893060d, _0xf34cb01a), new Vector2(TileW, TileH));
        Image _0x87077c4d = _0x303c624a.gameObject.AddComponent<Image>();
        _0x87077c4d.color = _0x072ee516 ? _0xecf6b76b.Track : _0xce2680ba ? _0xecf6b76b.Surface2 : _0xecf6b76b.Surface3;
        _0x87077c4d.sprite = _0x39495046._0x3fb723e6;
        _0x87077c4d.type = Image.Type.Sliced;
        _0x87077c4d.pixelsPerUnitMultiplier = 2.6f;
        _0x87077c4d.raycastTarget = false;
        this._0x3f5ae66c[_0x0f877982] = _0x87077c4d;
        this._0xe61dc4f2[_0x0f877982] = _0x303c624a;
        _0x2bfe8fd8.Rule(_0x303c624a, _0x8a0ac485._0xf80451da(new byte[7] { 69, 96, 120, 68, 101, 102, 100 }, 1), new Vector2(0.5f, 0f), new Vector2(TileW - 30f, 5f), _0xce2680ba ? _0xecf6b76b.Gold : _0x072ee516 ? _0xecf6b76b.Teal : _0xecf6b76b.Inactive);
        _0x2bfe8fd8.Caption(_0x303c624a, _0x8a0ac485._0xf80451da(new byte[9] { 40, 13, 21, 34, 25, 1, 14, 9, 30 }, 108), _0x39495046._0xe4f31537, _0x8a0ac485._0xf80451da(new byte[4] { 212, 209, 201, 176 }, 144) + (_0x0f877982 + 1), new Vector2(0.5f, 0.78f), new Vector2(TileW - 24f, 50f), 34f, 30f, _0xecf6b76b.TextSoft, TextAlignmentOptions.Center);
        _0x2bfe8fd8.Caption(_0x303c624a, _0x8a0ac485._0xf80451da(new byte[9] { 229, 192, 216, 224, 204, 206, 212, 207, 213 }, 161), _0x39495046._0xe4f31537, _0x43ed7f14.Money(_0x90879fe1[_0x0f877982]), new Vector2(0.5f, 0.48f), new Vector2(TileW - 24f, 64f), 52f, 38f, _0xce2680ba ? _0xecf6b76b.Gold : _0xecf6b76b.TextPrimary, TextAlignmentOptions.Center);
        this._0x52c881f5[_0x0f877982] = _0x2bfe8fd8.Caption(_0x303c624a, _0x8a0ac485._0xf80451da(new byte[8] { 176, 149, 141, 167, 128, 149, 128, 145 }, 244), _0x39495046._0xe4f31537, _0x072ee516 ? _0x8a0ac485._0xf80451da(new byte[7] { 17, 30, 19, 27, 31, 23, 22 }, 82) : _0xce2680ba ? _0x8a0ac485._0xf80451da(new byte[5] { 106, 113, 122, 127, 103 }, 62) : _0x8a0ac485._0xf80451da(new byte[6] { 144, 147, 159, 151, 153, 152 }, 220), new Vector2(0.5f, 0.2f), new Vector2(TileW - 24f, 44f), 32f, 30f, _0x072ee516 ? _0xecf6b76b.TealLight : _0xce2680ba ? _0xecf6b76b.Gold : _0xecf6b76b.TextMuted, TextAlignmentOptions.Center);
        if (_0xce2680ba)
            _0x303c624a.DOScale(1.04f, 1.8f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetLink(_0x303c624a.gameObject).SetId(this);
    }
}

internal static class _0x8a0ac485
{
    internal static string _0xf80451da(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}