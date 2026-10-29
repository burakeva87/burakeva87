using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Everything around the cabinet: the bar at the top, the stat strip, the stake
/// stepper, the SPIN plate and the room progress.
///
/// THE HUD IS OURS, NOT THE TEMPLATE'S (C.2). The game scene ships a TopPanel with
/// LEFT_BUTTON, RIGHT_BUTTON, a timer and two coin containers drawn for another game,
/// and stage 5da switches every one of them off on every run. Content hung on those
/// slots would ship invisible, and nothing in the gate battery would notice. So Back
/// and Pause are built here, in this game's style, and the template slots are neither
/// referenced nor touched.
///
/// TWO BANDS IN THE MISSION LINE (C.25). The progress pips own x 48..96 and the text
/// column starts at 120, so the glyphs can never run under the pips. Left alignment
/// does not do this by itself: it aligns text INSIDE its rect and leaves the rect
/// wherever it was placed.
/// </summary>
public sealed class _0x185ee3e1 : MonoBehaviour
{
    private Button _0xe7d1883e;
    private TMP_Text _0x7ed75784;
    /// <summary>The WIN cell counts up rather than jumping, and flashes while it does.</summary>
    public void _0x0af4aea1(long payout)
    {
        if (this._0x3171c05e == null)
            return;
        TMP_Text _0x71748601 = this._0x3171c05e;
        if (payout <= 0L)
        {
            _0x71748601.text = _0xa148a98c._0x4ab21bd6(new byte[5] { 68, 90, 93, 51, 35 }, 19);
            _0xe91c2331.Apply(_0x71748601, _0xecf6b76b.TextSecondary, 44f, 34f);
            return;
        }

        _0xe91c2331.Apply(_0x71748601, _0xecf6b76b.Gold, 44f, 34f);
        int _0x44d58d14 = 0;
        int _0x9a56fd0b = (int)payout;
        DOTween.To(() => _0x44d58d14, _0xfdad75fa =>
        {
            _0x44d58d14 = _0xfdad75fa;
            _0x71748601.text = _0xa148a98c._0x4ab21bd6(new byte[4] { 200, 214, 209, 191 }, 159) + _0x43ed7f14.Money(_0x44d58d14);
        }, _0x9a56fd0b, 0.6f).SetEase(Ease.OutCubic).SetLink(_0x71748601.gameObject);
        _0x71748601.rectTransform.DOPunchScale(Vector3.one * 0.08f, 0.3f, 6, 0.6f).SetLink(_0x71748601.gameObject);
    }

    [SerializeField]
    private _0x96cf86d8 _director;
    private const float StepperY = 960f;
    /// <summary>Dim the plate and say so while the columns are moving.</summary>
    public void _0xf590af58(bool _0x00cd4fad)
    {
        if (this._0xe7d1883e != null)
            this._0xe7d1883e.interactable = !_0x00cd4fad;
        if (this._0xf79580b7 != null)
            this._0xf79580b7.color = _0x00cd4fad ? _0xecf6b76b.GoldDeep : _0xecf6b76b.Gold;
        if (this._0x5ff6539f != null)
            this._0x5ff6539f.text = _0x00cd4fad ? _0xa148a98c._0x4ab21bd6(new byte[8] { 34, 33, 56, 63, 63, 56, 63, 54 }, 113) : _0xa148a98c._0x4ab21bd6(new byte[4] { 93, 94, 71, 64 }, 14);
    }

    private Image _0xd9006a6b;
    private const float PayY = 400f;
    private const float HintY = 1255f;
    private const float BarY = 2500f;
    private TMP_Text _0xa0d8afd1;
    private Image _0xf79580b7;
    private const float RoomY = 560f;
    [SerializeField]
    private _0x1f01910a _stepper;
    private readonly Image[] _0xaecbb9e9 = new Image[3];
    public void _0x389f9d2f(bool _0xc1c7fe63)
    {
        if (this._0x29bf45a1 == null)
            return;
        _0xe91c2331.Apply(this._0x29bf45a1, _0xc1c7fe63 ? _0xecf6b76b.TealLight : _0xecf6b76b.TextSecondary, 38f, 30f);
    }

    [SerializeField]
    private Sprite _iconPause;
    [SerializeField]
    private TMP_FontAsset _font;
    [SerializeField]
    private Sprite _iconBack;
    private TMP_Text _0x3171c05e;
    private const float StripY = 1140f;
    /// <summary>Coins, stake, mission and room, all from the stored state.</summary>
    public void _0x8279fef5()
    {
        if (this._0x7ed75784 != null)
            this._0x7ed75784.text = _0x43ed7f14.Money(_0x43ed7f14._0x0432624b);
        if (this._0x9d080168 != null)
            this._0x9d080168.text = _0xa148a98c._0x4ab21bd6(new byte[4] { 147, 148, 133, 241 }, 209) + _0x43ed7f14.Money(_0x43ed7f14._0x0c1a0cea);
        if (this._stepper != null)
            this._stepper._0x48dc48e8();
        int _0xeef3ec94 = _0x43ed7f14._0xa18ae110;
        int _0x51115c6a = _0x4cd3e5d2.RoomFor(_0xeef3ec94);
        if (this._0xae6c86ee != null)
            this._0xae6c86ee.text = _0x4cd3e5d2.Label(_0x51115c6a) + _0xa148a98c._0x4ab21bd6(new byte[10] { 70, 70, 70, 53, 35, 39, 42, 35, 34, 70 }, 102) + _0xeef3ec94 + _0xa148a98c._0x4ab21bd6(new byte[3] { 232, 231, 232 }, 200) + _0x43ed7f14.AlbumSlots;
        if (this._0xd9006a6b != null)
        {
            int _0xae712718 = _0x4cd3e5d2.NextThreshold(_0x51115c6a);
            float _0xa2b8b310 = _0xae712718 <= 0 ? 1f : Mathf.Clamp01((float)_0xeef3ec94 / _0xae712718);
            this._0xd9006a6b.rectTransform.sizeDelta = new Vector2(Mathf.Max(40f, 1020f * _0xa2b8b310), 22f);
        }
    }

    /// <summary>The hint line doubles as the free-spin banner.</summary>
    public void _0x527fe3af(string _0x0a0c20f3)
    {
        if (this._0x29bf45a1 == null)
            return;
        this._0x29bf45a1.text = _0x0a0c20f3;
    }

    /// <summary>Build the whole HUD inside the game panel's content container.</summary>
    public void _0x517f6642(RectTransform _0x755dc4de)
    {
        if (_0x755dc4de == null)
            return;
        RectTransform _0x93e7d3c0 = _0x2bfe8fd8.Node(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[6] { 142, 179, 162, 132, 167, 180 }, 198), _0x2bfe8fd8.At(621f, BarY), new Vector2(_0x2bfe8fd8.CanvasW, BarH));
        Image _0x3eea897c = _0x93e7d3c0.gameObject.AddComponent<Image>();
        _0x3eea897c.sprite = this._plate;
        _0x3eea897c.type = Image.Type.Sliced;
        _0x3eea897c.pixelsPerUnitMultiplier = 2.2f;
        _0x3eea897c.color = _0xecf6b76b.Fade(_0xecf6b76b.Surface1, 0.94f);
        _0x3eea897c.raycastTarget = false;
        _0x2bfe8fd8.Rule(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[10] { 93, 96, 113, 87, 116, 103, 80, 113, 114, 112 }, 21), _0x2bfe8fd8.At(621f, BarY - (BarH * 0.5f)), new Vector2(_0x2bfe8fd8.CanvasW, 5f), _0xecf6b76b.Hairline);
        Button _0x0cdb8ef9 = _0x2bfe8fd8.IconButton(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[10] { 42, 9, 11, 3, 42, 29, 28, 28, 7, 6 }, 104), this._iconBack, _0x2bfe8fd8.At(120f, 2534f), 128f, 104f, _0xecf6b76b.Fade(_0xecf6b76b.Surface2, 0.95f), _0xecf6b76b.TextPrimary);
        _0x0cdb8ef9.onClick.AddListener(() => this._0xa5a991d2());
        Button _0x24091926 = _0x2bfe8fd8.IconButton(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[11] { 91, 106, 126, 120, 110, 73, 126, 127, 127, 100, 101 }, 11), this._iconPause, _0x2bfe8fd8.At(268f, 2534f), 128f, 104f, _0xecf6b76b.Fade(_0xecf6b76b.Surface2, 0.95f), _0xecf6b76b.TextPrimary);
        _0x24091926.onClick.AddListener(() => this._0x6f13c504());
        _0x2bfe8fd8.Caption(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[10] { 95, 115, 117, 114, 111, 80, 125, 126, 121, 112 }, 28), this._font, _0xa148a98c._0x4ab21bd6(new byte[5] { 136, 132, 130, 133, 152 }, 203), _0x2bfe8fd8.At(1080f, 2564f), new Vector2(300f, 44f), 34f, 30f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Right);
        this._0x7ed75784 = _0x2bfe8fd8.Caption(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[10] { 140, 160, 166, 161, 188, 153, 174, 163, 186, 170 }, 207), this._font, _0xa148a98c._0x4ab21bd6(new byte[1] { 222 }, 238), _0x2bfe8fd8.At(1080f, 2508f), new Vector2(300f, 70f), 56f, 40f, _0xecf6b76b.Gold, TextAlignmentOptions.Right);
        for (int _0x31d400cb = 0; _0x31d400cb < this._0xaecbb9e9.Length; _0x31d400cb++)
        {
            Image _0xd1522337 = _0x2bfe8fd8.Plate(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[10] { 218, 254, 228, 228, 254, 248, 249, 199, 254, 231 }, 151) + _0x31d400cb, _0x2bfe8fd8.At(GutterX, 2434f), new Vector2(48f, 12f), _0xecf6b76b.Inactive, this._round);
            _0xd1522337.rectTransform.anchoredPosition = new Vector2(0f, 20f - (_0x31d400cb * 20f));
            this._0xaecbb9e9[_0x31d400cb] = _0xd1522337;
        }

        this._0xa0d8afd1 = _0x2bfe8fd8.Caption(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[11] { 233, 205, 215, 215, 205, 203, 202, 240, 193, 220, 208 }, 164), this._font, _0xa148a98c._0x4ab21bd6(new byte[7] { 253, 249, 227, 227, 249, 255, 254 }, 176), _0x2bfe8fd8.At(TextLeft + 390f, 2434f), new Vector2(760f, 48f), 34f, 30f, _0xecf6b76b.TextSoft, TextAlignmentOptions.Left);
        this._0xdb798429 = _0x2bfe8fd8.Caption(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[15] { 185, 157, 135, 135, 157, 155, 154, 164, 134, 155, 147, 134, 145, 135, 135 }, 244), this._font, _0xa148a98c._0x4ab21bd6(new byte[5] { 221, 205, 194, 205, 221 }, 237), _0x2bfe8fd8.At(1080f, 2434f), new Vector2(240f, 48f), 34f, 30f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Right);
        this._0x29bf45a1 = _0x2bfe8fd8.Caption(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[11] { 194, 238, 239, 245, 243, 238, 237, 201, 232, 239, 245 }, 129), this._font, _0xa148a98c._0x4ab21bd6(new byte[16] { 237, 248, 233, 153, 234, 233, 240, 247, 153, 237, 246, 153, 235, 246, 245, 245 }, 185), _0x2bfe8fd8.At(621f, HintY), new Vector2(900f, 56f), 38f, 30f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Center);
        this._0xb5809bdb(_0x755dc4de);
        if (this._stepper != null)
            this._stepper._0xf010ec6d(_0x755dc4de, this._font, this._round, StepperY);
        this._0xe7d1883e = _0x2bfe8fd8.Cta(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[10] { 252, 223, 198, 193, 237, 218, 219, 219, 192, 193 }, 175), this._font, _0xa148a98c._0x4ab21bd6(new byte[4] { 38, 37, 60, 59 }, 117), _0x2bfe8fd8.At(621f, SpinY), new Vector2(820f, 180f), _0xecf6b76b.Gold, _0xecf6b76b.TextPrimary, 64f, 44f, this._round);
        this._0xf79580b7 = this._0xe7d1883e.targetGraphic as Image;
        this._0x5ff6539f = this._0xe7d1883e.GetComponentInChildren<TMP_Text>();
        this._0xe7d1883e.onClick.AddListener(() => this._0xd6904974());
        this._0xd7b62932(_0x755dc4de);
        this._0x1470db0d(_0x755dc4de);
        _0x2bfe8fd8.Caption(_0x755dc4de, _0xa148a98c._0x4ab21bd6(new byte[10] { 63, 25, 21, 29, 54, 23, 12, 17, 27, 29 }, 120), this._font, _0xa148a98c._0x4ab21bd6(new byte[53] { 243, 250, 231, 149, 240, 251, 225, 240, 231, 225, 244, 252, 251, 248, 240, 251, 225, 149, 250, 251, 249, 236, 149, 152, 149, 227, 252, 231, 225, 224, 244, 249, 149, 246, 250, 252, 251, 230, 191, 251, 250, 149, 246, 244, 230, 253, 149, 229, 231, 252, 239, 240, 230 }, 181), _0x2bfe8fd8.At(621f, NoticeY), new Vector2(1100f, 110f), 32f, 30f, _0xecf6b76b.TextMuted, TextAlignmentOptions.Center);
    }

    private TMP_Text _0x5ff6539f;
    private const float TextLeft = 120f;
    private void OnDestroy()
    {
        DOTween.Kill(this);
    }

    private void _0xd7b62932(RectTransform _0x386aa417)
    {
        this._0xae6c86ee = _0x2bfe8fd8.Caption(_0x386aa417, _0xa148a98c._0x4ab21bd6(new byte[9] { 204, 241, 241, 243, 210, 255, 252, 251, 242 }, 158), this._font, _0xa148a98c._0x4ab21bd6(new byte[4] { 248, 229, 229, 231 }, 170), _0x2bfe8fd8.At(621f, RoomY + 52f), new Vector2(1060f, 48f), 34f, 30f, _0xecf6b76b.TextSoft, TextAlignmentOptions.Center);
        Image _0xf2ceafda = _0x2bfe8fd8.Plate(_0x386aa417, _0xa148a98c._0x4ab21bd6(new byte[9] { 62, 3, 3, 1, 56, 30, 13, 15, 7 }, 108), _0x2bfe8fd8.At(621f, RoomY), new Vector2(1020f, 22f), _0xecf6b76b.Fade(_0xecf6b76b.Track, 0.92f), this._round);
        GameObject _0x31118230 = new GameObject(_0xa148a98c._0x4ab21bd6(new byte[8] { 39, 26, 26, 24, 51, 28, 25, 25 }, 117), typeof(RectTransform));
        RectTransform _0x7b3adfb5 = _0x31118230.GetComponent<RectTransform>();
        _0x7b3adfb5.SetParent(_0xf2ceafda.rectTransform, false);
        _0x7b3adfb5.anchorMin = new Vector2(0f, 0.5f);
        _0x7b3adfb5.anchorMax = new Vector2(0f, 0.5f);
        _0x7b3adfb5.pivot = new Vector2(0f, 0.5f);
        _0x7b3adfb5.anchoredPosition = Vector2.zero;
        _0x7b3adfb5.sizeDelta = new Vector2(120f, 22f);
        this._0xd9006a6b = _0x31118230.AddComponent<Image>();
        this._0xd9006a6b.sprite = this._round;
        this._0xd9006a6b.type = Image.Type.Sliced;
        this._0xd9006a6b.pixelsPerUnitMultiplier = 2.6f;
        this._0xd9006a6b.color = _0xecf6b76b.Teal;
        this._0xd9006a6b.raycastTarget = false;
    }

    private void _0x6f13c504()
    {
        if (this._director != null)
            this._director._0x0fb71a98();
    }

    private TMP_Text _0xdb798429;
    [SerializeField]
    private Sprite[] _symbols;
    private void _0xb5809bdb(RectTransform _0x38d77fc3)
    {
        RectTransform _0x4bc0dac0 = _0x2bfe8fd8.Node(_0x38d77fc3, _0xa148a98c._0x4ab21bd6(new byte[9] { 225, 198, 211, 198, 225, 198, 192, 219, 194 }, 178), _0x2bfe8fd8.At(621f, StripY), new Vector2(1120f, 96f));
        Image _0x91c51eae = _0x4bc0dac0.gameObject.AddComponent<Image>();
        _0x91c51eae.sprite = this._round;
        _0x91c51eae.type = Image.Type.Sliced;
        _0x91c51eae.pixelsPerUnitMultiplier = 2.6f;
        _0x91c51eae.color = _0xecf6b76b.Fade(_0xecf6b76b.Surface3, 0.92f);
        _0x91c51eae.raycastTarget = false;
        _0x2bfe8fd8.Rule(_0x4bc0dac0, _0xa148a98c._0x4ab21bd6(new byte[9] { 179, 148, 129, 148, 178, 149, 140, 133, 161 }, 224), new Vector2(0.5f, 0.5f), new Vector2(4f, 60f), _0xecf6b76b.Inactive).rectTransform.anchoredPosition = new Vector2(-187f, 0f);
        _0x2bfe8fd8.Rule(_0x4bc0dac0, _0xa148a98c._0x4ab21bd6(new byte[9] { 127, 88, 77, 88, 126, 89, 64, 73, 110 }, 44), new Vector2(0.5f, 0.5f), new Vector2(4f, 60f), _0xecf6b76b.Inactive).rectTransform.anchoredPosition = new Vector2(187f, 0f);
        this._0x9d080168 = _0x2bfe8fd8.Caption(_0x4bc0dac0, _0xa148a98c._0x4ab21bd6(new byte[7] { 150, 177, 164, 177, 135, 160, 177 }, 197), this._font, _0xa148a98c._0x4ab21bd6(new byte[6] { 205, 202, 219, 175, 186, 191 }, 143), new Vector2(0.5f, 0.5f), new Vector2(340f, 56f), 44f, 34f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Center);
        this._0x9d080168.rectTransform.anchoredPosition = new Vector2(-374f, 0f);
        _0x2bfe8fd8.Caption(_0x4bc0dac0, _0xa148a98c._0x4ab21bd6(new byte[9] { 6, 33, 52, 33, 25, 60, 59, 48, 38 }, 85), this._font, _0xa148a98c._0x4ab21bd6(new byte[7] { 147, 150, 145, 154, 140, 255, 230 }, 223), new Vector2(0.5f, 0.5f), new Vector2(340f, 56f), 44f, 34f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Center);
        this._0x3171c05e = _0x2bfe8fd8.Caption(_0x4bc0dac0, _0xa148a98c._0x4ab21bd6(new byte[7] { 98, 69, 80, 69, 102, 88, 95 }, 49), this._font, _0xa148a98c._0x4ab21bd6(new byte[5] { 91, 69, 66, 44, 60 }, 12), new Vector2(0.5f, 0.5f), new Vector2(340f, 56f), 44f, 34f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Center);
        this._0x3171c05e.rectTransform.anchoredPosition = new Vector2(374f, 0f);
    }

    private const float SpinY = 740f;
    [SerializeField]
    private Sprite _round;
    private TMP_Text _0xae6c86ee;
    private TMP_Text _0x29bf45a1;
    [SerializeField]
    private Sprite _plate;
    private void _0xd6904974()
    {
        if (this._director != null)
            this._director._0x5e39aca2();
    }

    private TMP_Text _0x9d080168;
    private const float GutterX = 72f;
    /// <summary>
    /// What the big stones pay, so the paytable is on the screen the player is on
    /// rather than behind another tap.
    /// </summary>
    private void _0x1470db0d(RectTransform _0xaff8a7c8)
    {
        _0x2bfe8fd8.Caption(_0xaff8a7c8, _0xa148a98c._0x4ab21bd6(new byte[8] { 245, 196, 220, 241, 204, 209, 201, 192 }, 165), this._font, _0xa148a98c._0x4ab21bd6(new byte[25] { 250, 225, 254, 142, 254, 239, 247, 253, 142, 131, 142, 232, 231, 248, 235, 142, 231, 224, 142, 239, 142, 226, 231, 224, 235 }, 174), _0x2bfe8fd8.At(621f, PayY + 110f), new Vector2(1060f, 46f), 34f, 30f, _0xecf6b76b.TextSoft, TextAlignmentOptions.Center);
        int[] _0x3aea2c3b =
        {
            _0x52061f7c.Wild,
            _0x52061f7c.Diamond,
            _0x52061f7c.Coin,
            _0x52061f7c.Bell
        };
        float[] _0xffc9a12a =
        {
            237f,
            493f,
            749f,
            1005f
        };
        for (int _0x11502851 = 0; _0x11502851 < _0x3aea2c3b.Length; _0x11502851++)
        {
            RectTransform _0xbc13e4fa = _0x2bfe8fd8.Node(_0xaff8a7c8, _0xa148a98c._0x4ab21bd6(new byte[7] { 136, 185, 161, 140, 177, 180, 189 }, 216) + _0x11502851, _0x2bfe8fd8.At(_0xffc9a12a[_0x11502851], PayY), new Vector2(236f, 160f));
            Image _0x840ecaef = _0xbc13e4fa.gameObject.AddComponent<Image>();
            _0x840ecaef.sprite = this._round;
            _0x840ecaef.type = Image.Type.Sliced;
            _0x840ecaef.pixelsPerUnitMultiplier = 2.6f;
            _0x840ecaef.color = _0xecf6b76b.Fade(_0xecf6b76b.Surface2, 0.9f);
            _0x840ecaef.raycastTarget = false;
            if (this._symbols != null && _0x3aea2c3b[_0x11502851] < this._symbols.Length)
                _0x2bfe8fd8.Picture(_0xbc13e4fa, _0xa148a98c._0x4ab21bd6(new byte[6] { 137, 184, 160, 152, 171, 173 }, 217) + _0x11502851, this._symbols[_0x3aea2c3b[_0x11502851]], new Vector2(0.5f, 0.64f), new Vector2(96f, 96f), Color.white);
            _0x2bfe8fd8.Caption(_0xbc13e4fa, _0xa148a98c._0x4ab21bd6(new byte[8] { 242, 195, 219, 244, 195, 206, 215, 199 }, 162) + _0x11502851, this._font, _0xa148a98c._0x4ab21bd6(new byte[1] { 150 }, 238) + Mathf.RoundToInt(_0x52061f7c.TopPayout(_0x3aea2c3b[_0x11502851])), new Vector2(0.5f, 0.22f), new Vector2(200f, 48f), 36f, 30f, _0xecf6b76b.Gold, TextAlignmentOptions.Center);
        }
    }

    private const float BarH = 196f;
    /// <summary>The focused mission, with its pips, in the top bar.</summary>
    public void _0xc30cb38b(_0x8a41f8c5 _0x2b7bccc5)
    {
        if (_0x2b7bccc5 == null)
            return;
        int _0x678cf7e0 = _0x2b7bccc5._0x856f47ad;
        if (this._0xa0d8afd1 != null)
            this._0xa0d8afd1.text = _0xa148a98c._0x4ab21bd6(new byte[8] { 132, 128, 154, 154, 128, 134, 135, 233 }, 201) + _0x2b7bccc5._0x6cd9fbe5(_0x678cf7e0);
        if (this._0xdb798429 != null)
            this._0xdb798429.text = _0x2b7bccc5._0x96100be9(_0x678cf7e0) ? _0xa148a98c._0x4ab21bd6(new byte[4] { 18, 25, 24, 19 }, 86) : _0x2b7bccc5._0xed03db4b(_0x678cf7e0);
        float _0x6024ba2c = _0x2b7bccc5._0x033526df(_0x678cf7e0) <= 0 ? 1f : (float)_0x2b7bccc5._0xc489bb65(_0x678cf7e0) / _0x2b7bccc5._0x033526df(_0x678cf7e0);
        for (int _0x9adb6491 = 0; _0x9adb6491 < this._0xaecbb9e9.Length; _0x9adb6491++)
            if (this._0xaecbb9e9[_0x9adb6491] != null)
                this._0xaecbb9e9[_0x9adb6491].color = _0x6024ba2c >= (_0x9adb6491 + 1) / 3f ? _0xecf6b76b.Gold : _0xecf6b76b.Inactive;
    }

    private const float NoticeY = 230f;
    private void _0xa5a991d2()
    {
        if (_0x764d1f95.Instance != null)
            _0x764d1f95.Instance._0x3b3b6907(_0x778394b0._0xb8e5a259.SCENE_0);
    }
}

internal static class _0xa148a98c
{
    internal static string _0x4ab21bd6(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}