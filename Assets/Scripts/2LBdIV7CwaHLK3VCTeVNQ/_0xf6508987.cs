using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Three settings that really do something, and the compliance notice.
///
/// NO AUDIO ROW, DELIBERATELY. The brief asks for sound settings; this pipeline ships
/// games with no sound at all (C.20), so a volume slider or a speaker toggle would be a
/// control that changes nothing - which is also a C.7 violation, because a button has
/// to confirm its action visibly. The row is filled with controls that have a real
/// effect instead of being left as decoration:
///   HAPTICS       - the device really buzzes on a win when it is ON;
///   CELEBRATIONS  - CALM halves the coin burst and raises the WIN pop threshold;
///   RESET         - coins, album, room and ladder go back to day one, and the lobby
///                   visibly redraws behind the sheet.
///
/// RESET ASKS FIRST, in a confirm card built here rather than through PopsController.
/// The MENU scene's PopsController.Pops is an array of nulls on this template - pops
/// exist only in the game scene - so ShowPop(8) from the lobby would throw.
/// </summary>
public sealed class _0xf6508987 : MonoBehaviour
{
    private void _0xd00badec(RectTransform _0x0947feec, _0x42c1db03 _0xb3552c28, string _0xc3982623, string _0x25f89964, float _0xe9ba767c, bool _0x7ea5241b)
    {
        RectTransform _0x8191df33 = _0x2bfe8fd8.Row(_0x0947feec, _0xc3982623, _0x2bfe8fd8.At(621f, _0xe9ba767c), new Vector2(RowW, RowH), _0xecf6b76b.Card, _0xecf6b76b.Fade(_0xecf6b76b.Primary, 0.5f), _0xb3552c28._0x3fb723e6);
        _0x2bfe8fd8.Caption(_0x8191df33, _0xc3982623 + _0x31763a1d._0x59047e66(new byte[5] { 138, 167, 164, 163, 170 }, 198), _0xb3552c28._0xe4f31537, _0x25f89964, new Vector2(0f, 0.5f), new Vector2(560f, 60f), 44f, 34f, _0xecf6b76b.TextPrimary, TextAlignmentOptions.Left).rectTransform.anchoredPosition = new Vector2(_0x2bfe8fd8.TextLeft + 280f, 0f);
        bool _0x1af38fec = _0x7ea5241b ? _0x43ed7f14._0xe987d0c3 : _0x43ed7f14._0xe1eb7714;
        RectTransform _0x7a23b1bf = _0x2bfe8fd8.Node(_0x8191df33, _0xc3982623 + _0x31763a1d._0x59047e66(new byte[4] { 168, 145, 148, 148 }, 248), new Vector2(1f, 0.5f), new Vector2(240f, 84f));
        _0x7a23b1bf.anchoredPosition = new Vector2(-150f, 0f);
        Image _0x66af66b8 = _0x7a23b1bf.gameObject.AddComponent<Image>();
        _0x66af66b8.sprite = _0xb3552c28._0x3fb723e6;
        _0x66af66b8.type = Image.Type.Sliced;
        _0x66af66b8.pixelsPerUnitMultiplier = 1.2f;
        _0x66af66b8.color = _0x1af38fec ? _0xecf6b76b.Teal : _0xecf6b76b.Inactive;
        _0x66af66b8.raycastTarget = true;
        Button _0xde929f07 = _0x7a23b1bf.gameObject.AddComponent<Button>();
        _0xde929f07.targetGraphic = _0x66af66b8;
        _0xde929f07.transition = Selectable.Transition.None;
        RectTransform _0x01261ed2 = _0x2bfe8fd8.Plate(_0x7a23b1bf, _0xc3982623 + _0x31763a1d._0x59047e66(new byte[4] { 165, 128, 129, 140 }, 238), new Vector2(0.5f, 0.5f), new Vector2(72f, 64f), _0xecf6b76b.TextPrimary, _0xb3552c28._0x3fb723e6).rectTransform;
        _0x01261ed2.anchoredPosition = new Vector2(_0x1af38fec ? 72f : -72f, 0f);
        TMP_Text _0xa881b790 = _0x2bfe8fd8.Caption(_0x8191df33, _0xc3982623 + _0x31763a1d._0x59047e66(new byte[5] { 157, 186, 175, 186, 171 }, 206), _0xb3552c28._0xe4f31537, _0x7ea5241b ? (_0x1af38fec ? _0x31763a1d._0x59047e66(new byte[2] { 178, 179 }, 253) : _0x31763a1d._0x59047e66(new byte[3] { 47, 38, 38 }, 96)) : (_0x1af38fec ? _0x31763a1d._0x59047e66(new byte[4] { 98, 113, 104, 104 }, 36) : _0x31763a1d._0x59047e66(new byte[4] { 82, 80, 93, 92 }, 17)), new Vector2(1f, 0.5f), new Vector2(200f, 52f), 36f, 30f, _0x1af38fec ? _0xecf6b76b.TealLight : _0xecf6b76b.TextSoft, TextAlignmentOptions.Center);
        _0xa881b790.rectTransform.anchoredPosition = new Vector2(-150f, -56f);
        if (_0x7ea5241b)
        {
            this._0x73028f46 = _0x66af66b8;
            this._0xe15110c2 = _0x01261ed2;
            this._0xbd23f1fb = _0xa881b790;
            _0xde929f07.onClick.AddListener(() => this._0x7dcc0778());
        }
        else
        {
            this._0x13142d37 = _0x66af66b8;
            this._0x19fbc01f = _0x01261ed2;
            this._0x5e07ecb0 = _0xa881b790;
            _0xde929f07.onClick.AddListener(() => this._0x13c8ed81());
        }
    }

    private Image _0x13142d37;
    private RectTransform _0x19fbc01f;
    private TMP_Text _0x5e07ecb0;
    private RectTransform _0x22d6fa66;
    private void OnDestroy()
    {
        DOTween.Kill(this);
    }

    private _0x42c1db03 _0x7ad669a2;
    private void _0x7dcc0778()
    {
        bool _0xce74cc14 = !_0x43ed7f14._0xe987d0c3;
        _0x43ed7f14._0xe987d0c3 = _0xce74cc14;
        if (this._0x73028f46 != null)
            this._0x73028f46.color = _0xce74cc14 ? _0xecf6b76b.Teal : _0xecf6b76b.Inactive;
        if (this._0xe15110c2 != null)
            this._0xe15110c2.DOAnchorPosX(_0xce74cc14 ? 72f : -72f, 0.18f).SetEase(Ease.OutCubic).SetLink(this._0xe15110c2.gameObject);
        if (this._0xbd23f1fb != null)
        {
            this._0xbd23f1fb.text = _0xce74cc14 ? _0x31763a1d._0x59047e66(new byte[2] { 105, 104 }, 38) : _0x31763a1d._0x59047e66(new byte[3] { 59, 50, 50 }, 116);
            _0xe91c2331.Apply(this._0xbd23f1fb, _0xce74cc14 ? _0xecf6b76b.TealLight : _0xecf6b76b.TextSoft, 36f, 30f);
        }

        if (_0xce74cc14)
            Handheld.Vibrate();
    }

    private void _0xe352ed62()
    {
        _0x43ed7f14.ResetProgress();
        this._0xfa19614d();
        if (this._0x7ad669a2 != null)
            this._0x7ad669a2._0x60561518();
    }

    private RectTransform _0x97aaf2e5;
    private void _0xfa19614d()
    {
        if (this._0x22d6fa66 != null)
            this._0x22d6fa66.gameObject.SetActive(false);
    }

    public void _0x6853dfa6(_0x42c1db03 _0x91b1a14c, RectTransform _0x0a0bfefa)
    {
        this._0x7ad669a2 = _0x91b1a14c;
        this._0x97aaf2e5 = _0x0a0bfefa;
        if (_0x91b1a14c == null || _0x0a0bfefa == null)
            return;
        _0x2bfe8fd8.Caption(_0x0a0bfefa, _0x31763a1d._0x59047e66(new byte[16] { 118, 64, 81, 81, 76, 75, 66, 86, 118, 80, 71, 81, 76, 81, 73, 64 }, 37), _0x91b1a14c._0xe4f31537, _0x31763a1d._0x59047e66(new byte[21] { 153, 158, 134, 241, 133, 153, 148, 241, 135, 144, 132, 157, 133, 241, 147, 148, 153, 144, 135, 148, 130 }, 209), _0x2bfe8fd8.At(621f, 1660f), new Vector2(1060f, 60f), 44f, 34f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Center);
        this._0xd00badec(_0x0a0bfefa, _0x91b1a14c, _0x31763a1d._0x59047e66(new byte[10] { 134, 187, 163, 156, 181, 164, 160, 189, 183, 167 }, 212), _0x31763a1d._0x59047e66(new byte[7] { 241, 248, 233, 237, 240, 250, 234 }, 185), 1480f, true);
        this._0xd00badec(_0x0a0bfefa, _0x91b1a14c, _0x31763a1d._0x59047e66(new byte[15] { 54, 11, 19, 39, 1, 8, 1, 6, 22, 5, 16, 13, 11, 10, 23 }, 100), _0x31763a1d._0x59047e66(new byte[12] { 11, 13, 4, 13, 10, 26, 9, 28, 1, 7, 6, 27 }, 72), 1310f, false);
        this._0x0441fe75(_0x0a0bfefa, _0x91b1a14c, 1140f);
        _0x2bfe8fd8.Caption(_0x0a0bfefa, _0x31763a1d._0x59047e66(new byte[16] { 159, 179, 177, 172, 176, 181, 189, 178, 191, 185, 146, 179, 168, 181, 191, 185 }, 220), _0x91b1a14c._0xe4f31537, _0x31763a1d._0x59047e66(new byte[95] { 122, 115, 96, 107, 24, 4, 8, 2, 10, 7, 107, 8, 10, 24, 2, 5, 4, 107, 102, 107, 13, 4, 25, 107, 10, 6, 30, 24, 14, 6, 14, 5, 31, 107, 4, 5, 7, 18, 65, 8, 4, 2, 5, 24, 107, 10, 25, 14, 107, 13, 2, 8, 31, 2, 4, 5, 10, 7, 107, 102, 107, 8, 10, 5, 5, 4, 31, 107, 9, 14, 107, 9, 4, 30, 12, 3, 31, 103, 107, 24, 4, 7, 15, 107, 4, 25, 107, 25, 14, 15, 14, 14, 6, 14, 15 }, 75), _0x2bfe8fd8.At(621f, 940f), new Vector2(1100f, 130f), 32f, 30f, _0xecf6b76b.TextMuted, TextAlignmentOptions.Center);
        this._0x50704f2b(_0x0a0bfefa, _0x91b1a14c);
    }

    private const float RowW = 1060f;
    /// <summary>
    /// The confirm card. Built once, hidden, and raised by RESET - so the destructive
    /// action always asks, and it asks inside this sheet rather than through a pop list
    /// the menu scene does not populate.
    /// </summary>
    private void _0x50704f2b(RectTransform _0x6b978880, _0x42c1db03 _0x49163675)
    {
        this._0x22d6fa66 = _0x2bfe8fd8.Stretch(_0x6b978880, _0x31763a1d._0x59047e66(new byte[12] { 72, 127, 105, 127, 110, 89, 117, 116, 124, 115, 104, 119 }, 26));
        _0x2bfe8fd8.Veil(this._0x22d6fa66, _0x31763a1d._0x59047e66(new byte[12] { 207, 227, 226, 234, 229, 254, 225, 223, 239, 254, 229, 225 }, 140), _0xecf6b76b.Fade(_0xecf6b76b.DeepInk, 0.86f), true);
        RectTransform _0xea9b2658 = _0x2bfe8fd8.Node(this._0x22d6fa66, _0x31763a1d._0x59047e66(new byte[11] { 103, 75, 74, 66, 77, 86, 73, 103, 69, 86, 64 }, 36), _0x2bfe8fd8.At(621f, 1340f), new Vector2(1020f, 700f));
        Image _0xf9c06f57 = _0xea9b2658.gameObject.AddComponent<Image>();
        _0xf9c06f57.sprite = _0x49163675._0xd69ec975;
        _0xf9c06f57.type = Image.Type.Sliced;
        _0xf9c06f57.pixelsPerUnitMultiplier = 2.2f;
        _0xf9c06f57.color = _0xecf6b76b.Surface1;
        _0xf9c06f57.raycastTarget = true;
        _0x2bfe8fd8.Rule(_0xea9b2658, _0x31763a1d._0x59047e66(new byte[11] { 22, 58, 59, 51, 60, 39, 56, 16, 49, 50, 48 }, 85), new Vector2(0.5f, 1f), new Vector2(980f, 5f), _0xecf6b76b.Hairline).rectTransform.anchoredPosition = new Vector2(0f, -12f);
        _0x2bfe8fd8.Caption(_0xea9b2658, _0x31763a1d._0x59047e66(new byte[12] { 249, 213, 212, 220, 211, 200, 215, 238, 211, 206, 214, 223 }, 186), _0x49163675._0xe4f31537, _0x31763a1d._0x59047e66(new byte[16] { 65, 86, 64, 86, 71, 51, 71, 91, 86, 51, 69, 82, 70, 95, 71, 44 }, 19), new Vector2(0.5f, 0.78f), new Vector2(940f, 96f), 64f, 48f, _0xecf6b76b.TextPrimary, TextAlignmentOptions.Center);
        _0x2bfe8fd8.Caption(_0xea9b2658, _0x31763a1d._0x59047e66(new byte[11] { 138, 166, 167, 175, 160, 187, 164, 139, 166, 173, 176 }, 201), _0x49163675._0xe4f31537, _0x31763a1d._0x59047e66(new byte[46] { 112, 125, 125, 17, 114, 126, 120, 127, 98, 29, 17, 98, 101, 126, 127, 116, 98, 17, 112, 127, 117, 17, 99, 126, 126, 124, 98, 59, 118, 126, 17, 115, 112, 114, 122, 17, 101, 126, 17, 117, 112, 104, 17, 126, 127, 116 }, 49), new Vector2(0.5f, 0.52f), new Vector2(940f, 130f), 38f, 30f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Center);
        Button _0xba3294e5 = _0x2bfe8fd8.Cta(_0xea9b2658, _0x31763a1d._0x59047e66(new byte[10] { 18, 62, 63, 55, 56, 35, 60, 8, 52, 34 }, 81), _0x49163675._0xe4f31537, _0x31763a1d._0x59047e66(new byte[5] { 202, 221, 203, 221, 204 }, 152), new Vector2(0.28f, 0.2f), new Vector2(420f, 130f), _0xecf6b76b.Danger, _0xecf6b76b.TextPrimary, 44f, 34f, _0x49163675._0x3fb723e6);
        Button _0x9008b069 = _0x2bfe8fd8.Cta(_0xea9b2658, _0x31763a1d._0x59047e66(new byte[9] { 112, 92, 93, 85, 90, 65, 94, 125, 92 }, 51), _0x49163675._0xe4f31537, _0x31763a1d._0x59047e66(new byte[4] { 56, 54, 54, 35 }, 115), new Vector2(0.72f, 0.2f), new Vector2(420f, 130f), _0xecf6b76b.Primary, _0xecf6b76b.TextPrimary, 44f, 34f, _0x49163675._0x3fb723e6);
        _0xba3294e5.onClick.AddListener(() => this._0xe352ed62());
        _0x9008b069.onClick.AddListener(() => this._0xfa19614d());
        this._0x22d6fa66.gameObject.SetActive(false);
    }

    private void _0x0441fe75(RectTransform _0x90f4f4c2, _0x42c1db03 _0x45e48d73, float _0x22d87360)
    {
        RectTransform _0xe3bf481c = _0x2bfe8fd8.Row(_0x90f4f4c2, _0x31763a1d._0x59047e66(new byte[8] { 19, 46, 54, 19, 36, 50, 36, 53 }, 65), _0x2bfe8fd8.At(621f, _0x22d87360), new Vector2(RowW, RowH), _0xecf6b76b.Card, _0xecf6b76b.Fade(_0xecf6b76b.Danger, 0.6f), _0x45e48d73._0x3fb723e6);
        _0x2bfe8fd8.Caption(_0xe3bf481c, _0x31763a1d._0x59047e66(new byte[10] { 93, 106, 124, 106, 123, 67, 110, 109, 106, 99 }, 15), _0x45e48d73._0xe4f31537, _0x31763a1d._0x59047e66(new byte[14] { 100, 115, 101, 115, 98, 22, 102, 100, 121, 113, 100, 115, 101, 101 }, 54), new Vector2(0f, 0.5f), new Vector2(560f, 60f), 44f, 34f, _0xecf6b76b.TextPrimary, TextAlignmentOptions.Left).rectTransform.anchoredPosition = new Vector2(_0x2bfe8fd8.TextLeft + 280f, 0f);
        Button _0x476a73cf = _0x2bfe8fd8.Cta(_0xe3bf481c, _0x31763a1d._0x59047e66(new byte[11] { 56, 15, 25, 15, 30, 40, 31, 30, 30, 5, 4 }, 106), _0x45e48d73._0xe4f31537, _0x31763a1d._0x59047e66(new byte[5] { 251, 236, 250, 236, 253 }, 169), new Vector2(1f, 0.5f), new Vector2(240f, 92f), _0xecf6b76b.Danger, _0xecf6b76b.TextPrimary, 40f, 32f, _0x45e48d73._0x3fb723e6);
        _0x476a73cf.GetComponent<RectTransform>().anchoredPosition = new Vector2(-150f, 0f);
        _0x476a73cf.onClick.AddListener(() => this._0x3be30029());
    }

    private TMP_Text _0xbd23f1fb;
    private const float RowH = 140f;
    private void _0x3be30029()
    {
        if (this._0x22d6fa66 == null)
            return;
        this._0x22d6fa66.gameObject.SetActive(true);
        this._0x22d6fa66.localScale = Vector3.one * 0.92f;
        this._0x22d6fa66.DOScale(1f, 0.18f).SetEase(Ease.OutBack).SetLink(this._0x22d6fa66.gameObject);
    }

    private Image _0x73028f46;
    private void _0x13c8ed81()
    {
        bool _0x5c425e5d = !_0x43ed7f14._0xe1eb7714;
        _0x43ed7f14._0xe1eb7714 = _0x5c425e5d;
        if (this._0x13142d37 != null)
            this._0x13142d37.color = _0x5c425e5d ? _0xecf6b76b.Teal : _0xecf6b76b.Inactive;
        if (this._0x19fbc01f != null)
            this._0x19fbc01f.DOAnchorPosX(_0x5c425e5d ? 72f : -72f, 0.18f).SetEase(Ease.OutCubic).SetLink(this._0x19fbc01f.gameObject);
        if (this._0x5e07ecb0 != null)
        {
            this._0x5e07ecb0.text = _0x5c425e5d ? _0x31763a1d._0x59047e66(new byte[4] { 226, 241, 232, 232 }, 164) : _0x31763a1d._0x59047e66(new byte[4] { 217, 219, 214, 215 }, 154);
            _0xe91c2331.Apply(this._0x5e07ecb0, _0x5c425e5d ? _0xecf6b76b.TealLight : _0xecf6b76b.TextSoft, 36f, 30f);
        }
    }

    private RectTransform _0xe15110c2;
}

internal static class _0x31763a1d
{
    internal static string _0x59047e66(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}