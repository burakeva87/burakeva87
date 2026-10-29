using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The lobby: full-bleed vault art on top, a gilded sheet with the balance, the room
/// progress, three chips and the CTA below (layout M2, bottom sheet).
///
/// NO TITLE. The only branding is the abstract vault mark and the palette; the app's
/// name is in the project settings and appears nowhere on screen (hard rule 1).
///
/// THE PLAY BUTTON DRAWS NOTHING OF ITS OWN, so its face is built here. It is an
/// EMPTY_BASE_BUTTON variant, and "empty" is literal: the variant deactivates
/// BackgroundRoundness, FillRoundess, Border, ShadowFill, ImageFill, Icon,
/// __RESET_STENCIL_MASKS__ and the template's own PanelText, and the layers that
/// survive are children of the deactivated ones, so they cannot paint. The one layer
/// that does paint is Fade, which BASE_BUTTON overrides to alpha 1 WITH
/// raycastTarget 1 - that is what keeps the button pressable, so it is left exactly as
/// it is and our face is added as later children with raycastTarget off, so taps fall
/// straight through to the template Button and its LoadSceneButton driver.
///
/// Exactly one PLAY literal exists in this scene, and it is the one below.
/// </summary>
public sealed class _0x9129a671 : MonoBehaviour
{
    [SerializeField]
    private Sprite _mark;
    private void _0x0cb0ef5c()
    {
        if (this._content == null)
            return;
        RectTransform _0xf924b2f3 = _0x2bfe8fd8.Stretch(this._content, _0x63838571._0xe0838731(new byte[10] { 106, 93, 73, 80, 72, 112, 83, 94, 94, 69 }, 60));
        // ---- the hall above the sheet: mark and drifting shards, nothing readable ----
        Image _0x760e6e1d = _0x2bfe8fd8.Picture(_0xf924b2f3, _0x63838571._0xe0838731(new byte[8] { 164, 141, 128, 128, 161, 141, 158, 135 }, 236), this._mark, _0x2bfe8fd8.At(300f, 2170f), new Vector2(330f, 330f), _0xecf6b76b.Fade(_0xecf6b76b.TextPrimary, 0.55f));
        Image _0x2f76cb4e = _0x2bfe8fd8.Picture(_0xf924b2f3, _0x63838571._0xe0838731(new byte[8] { 150, 173, 164, 183, 161, 131, 164, 183 }, 197), this._shard, _0x2bfe8fd8.At(975f, 2330f), new Vector2(150f, 150f), _0xecf6b76b.Fade(_0xecf6b76b.PrimaryBright, 0.45f));
        _0x2bfe8fd8.Picture(_0xf924b2f3, _0x63838571._0xe0838731(new byte[9] { 138, 177, 184, 171, 189, 151, 188, 184, 171 }, 217), this._shard, _0x2bfe8fd8.At(1035f, 1470f), new Vector2(112f, 112f), _0xecf6b76b.Fade(_0xecf6b76b.TealLight, 0.38f));
        // IDLE MOTION IS BUDGETED, NOT DECORATED FREELY. wait_loader_done samples an 8x8
        // signature every 5 s and needs 15 s under 12/64 before the first frame is taken,
        // so a lobby that never stops moving never settles. The hall art is therefore
        // STILL; the only perpetual motion in this scene is the CTA breathing 2.5% over
        // 1.6 s, which is a measured-safe amount of travel.
        _0x2f76cb4e.rectTransform.localScale = Vector3.one;
        _0x760e6e1d.rectTransform.localScale = Vector3.one;
        // ---- the sheet ----------------------------------------------------------
        _0x2bfe8fd8.Plate(_0xf924b2f3, _0x63838571._0xe0838731(new byte[11] { 3, 56, 53, 53, 36, 3, 56, 49, 52, 63, 39 }, 80), _0x2bfe8fd8.At(621f, SheetTop + 14f), new Vector2(_0x2bfe8fd8.CanvasW, 28f), _0xecf6b76b.ShadowBand, null);
        this._0x5fd5b104 = _0x2bfe8fd8.Node(_0xf924b2f3, _0x63838571._0xe0838731(new byte[5] { 200, 243, 254, 254, 239 }, 155), _0x2bfe8fd8.At(621f, SheetTop * 0.5f), new Vector2(_0x2bfe8fd8.CanvasW, SheetTop));
        this._0x2309a46e = this._0x5fd5b104.gameObject.AddComponent<Image>();
        this._0x2309a46e.sprite = this._plate;
        this._0x2309a46e.type = Image.Type.Sliced;
        this._0x2309a46e.pixelsPerUnitMultiplier = 2.2f;
        this._0x2309a46e.color = _0xecf6b76b.SheetTint;
        this._0x2309a46e.raycastTarget = true;
        this._0x6127004a = _0x2bfe8fd8.Rule(_0xf924b2f3, _0x63838571._0xe0838731(new byte[9] { 37, 30, 19, 19, 2, 51, 18, 17, 19 }, 118), _0x2bfe8fd8.At(621f, SheetTop - 2f), new Vector2(_0x2bfe8fd8.CanvasW, 5f), _0xecf6b76b.Hairline);
        // ---- balance ------------------------------------------------------------
        _0x2bfe8fd8.Caption(_0xf924b2f3, _0x63838571._0xe0838731(new byte[9] { 137, 165, 163, 164, 134, 171, 168, 175, 166 }, 202), this._font, _0x63838571._0xe0838731(new byte[12] { 43, 39, 33, 38, 72, 58, 45, 59, 45, 58, 62, 45 }, 104), _0x2bfe8fd8.At(340f, 1092f), new Vector2(540f, 56f), 38f, 30f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Left);
        this._0xb9780705 = _0x2bfe8fd8.Caption(_0xf924b2f3, _0x63838571._0xe0838731(new byte[9] { 97, 77, 75, 76, 116, 67, 78, 87, 71 }, 34), this._font, _0x63838571._0xe0838731(new byte[1] { 233 }, 217), _0x2bfe8fd8.At(920f, 1086f), new Vector2(520f, 92f), 72f, 48f, _0xecf6b76b.Gold, TextAlignmentOptions.Right);
        // ---- room progress ------------------------------------------------------
        this._0x2d37d101 = _0x2bfe8fd8.Caption(_0xf924b2f3, _0x63838571._0xe0838731(new byte[9] { 65, 124, 124, 126, 95, 114, 113, 118, 127 }, 19), this._font, _0x63838571._0xe0838731(new byte[4] { 240, 237, 237, 239 }, 162), _0x2bfe8fd8.At(380f, 1000f), new Vector2(640f, 52f), 38f, 30f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Left);
        Image _0x9d28f4da = _0x2bfe8fd8.Plate(_0xf924b2f3, _0x63838571._0xe0838731(new byte[9] { 42, 23, 23, 21, 44, 10, 25, 27, 19 }, 120), _0x2bfe8fd8.At(621f, 940f), new Vector2(1020f, 26f), _0xecf6b76b.Surface3, this._round);
        this._0x508d713e = this._0xcda23187(_0x9d28f4da.rectTransform, _0x63838571._0xe0838731(new byte[8] { 176, 141, 141, 143, 164, 139, 142, 142 }, 226), 1020f, 26f, _0xecf6b76b.Teal);
        // ---- three chips --------------------------------------------------------
        Button _0xceac5422 = _0x2bfe8fd8.Chip(_0xf924b2f3, _0x63838571._0xe0838731(new byte[9] { 53, 30, 31, 6, 32, 23, 3, 26, 2 }, 118), this._font, _0x63838571._0xe0838731(new byte[5] { 179, 164, 176, 169, 177 }, 229), _0x2bfe8fd8.At(277f, 790f), new Vector2(ChipW, ChipH), _0xecf6b76b.Surface2, _0xecf6b76b.ChipBorder, _0xecf6b76b.TextPrimary, 42f, 34f, this._round);
        Button _0x7fd54cdc = _0x2bfe8fd8.Chip(_0xf924b2f3, _0x63838571._0xe0838731(new byte[9] { 248, 211, 210, 203, 249, 212, 213, 206, 200 }, 187), this._font, _0x63838571._0xe0838731(new byte[5] { 71, 74, 75, 80, 86 }, 5), _0x2bfe8fd8.At(621f, 790f), new Vector2(ChipW, ChipH), _0xecf6b76b.Surface2, _0xecf6b76b.ChipBorder, _0xecf6b76b.TextPrimary, 42f, 34f, this._round);
        Button _0x5678199e = _0x2bfe8fd8.Chip(_0xf924b2f3, _0x63838571._0xe0838731(new byte[12] { 199, 236, 237, 244, 215, 225, 240, 240, 237, 234, 227, 247 }, 132), this._font, _0x63838571._0xe0838731(new byte[8] { 35, 53, 36, 36, 57, 62, 55, 35 }, 112), _0x2bfe8fd8.At(965f, 790f), new Vector2(ChipW, ChipH), _0xecf6b76b.Surface2, _0xecf6b76b.ChipBorder, _0xecf6b76b.TextPrimary, 42f, 34f, this._round);
        this._0xd645ea5d = _0x7fd54cdc.GetComponentInChildren<TMP_Text>();
        this._0xd3ca8c7b = _0x2bfe8fd8.Plate(_0x7fd54cdc.GetComponent<RectTransform>(), _0x63838571._0xe0838731(new byte[10] { 69, 104, 105, 114, 116, 85, 98, 102, 99, 126 }, 7), new Vector2(1f, 1f), new Vector2(26f, 26f), _0xecf6b76b.Teal, this._round);
        this._0xd3ca8c7b.rectTransform.anchoredPosition = new Vector2(-24f, -22f);
        _0xceac5422.onClick.AddListener(() => this._0x6d867826(0));
        _0x7fd54cdc.onClick.AddListener(() => this._0x6d867826(1));
        _0x5678199e.onClick.AddListener(() => this._0x6d867826(2));
        this._0xaa042464(_0xceac5422.GetComponent<RectTransform>(), 0f);
        this._0xaa042464(_0x7fd54cdc.GetComponent<RectTransform>(), 0.06f);
        this._0xaa042464(_0x5678199e.GetComponent<RectTransform>(), 0.12f);
        // ---- secondary + disclaimer (above nothing, below the CTA) --------------
        Button _0xff5790ee = _0x2bfe8fd8.Chip(_0xf924b2f3, _0x63838571._0xe0838731(new byte[11] { 154, 189, 164, 173, 187, 138, 189, 188, 188, 167, 166 }, 200), this._font, _0x63838571._0xe0838731(new byte[10] { 53, 51, 63, 55, 82, 32, 39, 62, 55, 33 }, 114), _0x2bfe8fd8.At(621f, 400f), new Vector2(520f, 78f), _0xecf6b76b.Fade(_0xecf6b76b.Surface3, 0.9f), _0xecf6b76b.Fade(_0xecf6b76b.Primary, 0.5f), _0xecf6b76b.TextSoft, 44f, 34f, this._round);
        _0xff5790ee.onClick.AddListener(() => this._0xe7608531());
        _0x2bfe8fd8.Caption(_0xf924b2f3, _0x63838571._0xe0838731(new byte[10] { 82, 127, 101, 117, 122, 119, 127, 123, 115, 100 }, 22), this._font, _0x63838571._0xe0838731(new byte[53] { 204, 197, 216, 170, 207, 196, 222, 207, 216, 222, 203, 195, 196, 199, 207, 196, 222, 170, 197, 196, 198, 211, 170, 167, 170, 220, 195, 216, 222, 223, 203, 198, 170, 201, 197, 195, 196, 217, 128, 196, 197, 170, 201, 203, 217, 194, 170, 218, 216, 195, 208, 207, 217 }, 138), _0x2bfe8fd8.At(621f, 236f), new Vector2(1060f, 120f), 32f, 30f, _0xecf6b76b.TextMuted, TextAlignmentOptions.Center);
    // No entry tween on the sheet itself: everything here is placed in absolute
    // canvas units and the sheet is a SIBLING of its own contents, so sliding the
    // plate would leave the balance and the chips hanging in the air. The panel's
    // own DOScale, which the template runs on Show(), is this screen's entrance.
    }

    private Image _0xd3ca8c7b;
    [SerializeField]
    private Sprite _plate;
    [SerializeField]
    private _0x42c1db03 _sheet;
    private Image _0x6127004a;
    private Image _0xb5b5f41a;
    private RectTransform _0x508d713e;
    [SerializeField]
    private Sprite _round;
    private Image _0x2309a46e;
    private const float PlayH = 168f;
    [SerializeField]
    private RectTransform _playRoot;
    private void _0x6d867826(int _0x9fe2603c)
    {
        if (this._sheet != null)
            this._sheet._0xeffb11a9(_0x9fe2603c);
    }

    [SerializeField]
    private RectTransform _content;
    private TMP_Text _0xd645ea5d;
    private const float ChipH = 112f;
    /// <summary>
    /// A bar fill pinned to its track's LEFT edge, so growing it extends to the right
    /// instead of fattening about the centre.
    /// </summary>
    private RectTransform _0xcda23187(RectTransform _0x8e6d9016, string _0x396d67aa, float width, float height, Color _0x4f1c73f0)
    {
        GameObject _0x7c23b89f = new GameObject(_0x396d67aa, typeof(RectTransform));
        RectTransform _0xe9dda8dc = _0x7c23b89f.GetComponent<RectTransform>();
        _0xe9dda8dc.SetParent(_0x8e6d9016, false);
        _0xe9dda8dc.anchorMin = new Vector2(0f, 0.5f);
        _0xe9dda8dc.anchorMax = new Vector2(0f, 0.5f);
        _0xe9dda8dc.pivot = new Vector2(0f, 0.5f);
        _0xe9dda8dc.anchoredPosition = Vector2.zero;
        _0xe9dda8dc.sizeDelta = new Vector2(width, height);
        Image _0x542f8ec0 = _0x7c23b89f.AddComponent<Image>();
        _0x542f8ec0.color = _0x4f1c73f0;
        _0x542f8ec0.raycastTarget = false;
        _0x542f8ec0.sprite = this._round;
        _0x542f8ec0.type = Image.Type.Sliced;
        _0x542f8ec0.pixelsPerUnitMultiplier = 2.6f;
        return _0xe9dda8dc;
    }

    private const float SheetTop = 1200f;
    [SerializeField]
    private Sprite _shard;
    /// <summary>
    /// The two rules pages, in order: header, body and button caption of panel 13, then
    /// the same three of panel 14. The scene already carries this copy as prefab-instance
    /// overrides (C.18); these references exist so the lines can also be given the real
    /// line breaks, the palette and the readability settings every runtime label gets,
    /// none of which a scene string can carry (C.10).
    /// </summary>
    [SerializeField]
    private TMP_Text[] _rulesLabels;
    /// <summary>
    /// The two rules pages reached from GAME RULES, plus the pages this game leaves out.
    /// Line breaks are placed by hand here and nowhere else (C.10).
    /// </summary>
    private void _0xbbefb590()
    {
        string[] _0xe9bcbe00 =
        {
            _0x63838571._0xe0838731(new byte[18] { 66, 69, 93, 42, 94, 66, 79, 42, 92, 75, 95, 70, 94, 42, 90, 75, 83, 89 }, 10),
            _0x63838571._0xe0838731(new byte[96] { 97, 116, 101, 21, 102, 101, 124, 123, 21, 97, 122, 21, 113, 103, 122, 101, 21, 115, 124, 99, 112, 21, 103, 112, 112, 121, 102, 27, 63, 120, 116, 97, 118, 125, 21, 6, 21, 122, 103, 21, 120, 122, 103, 112, 21, 102, 97, 122, 123, 112, 102, 21, 115, 103, 122, 120, 21, 97, 125, 112, 63, 121, 112, 115, 97, 21, 103, 112, 112, 121, 21, 116, 121, 122, 123, 114, 21, 116, 123, 108, 21, 122, 115, 21, 97, 125, 112, 21, 12, 21, 121, 124, 123, 112, 102, 27 }, 53),
            _0x63838571._0xe0838731(new byte[9] { 156, 151, 138, 134, 242, 130, 147, 149, 151 }, 210),
            _0x63838571._0xe0838731(new byte[17] { 132, 146, 150, 155, 158, 153, 144, 247, 131, 159, 146, 247, 150, 155, 149, 130, 154 }, 215),
            _0x63838571._0xe0838731(new byte[118] { 243, 224, 243, 228, 239, 150, 225, 255, 248, 150, 229, 243, 247, 250, 229, 150, 255, 226, 229, 150, 229, 226, 249, 248, 243, 150, 255, 248, 226, 249, 150, 226, 254, 243, 150, 247, 250, 244, 227, 251, 152, 188, 240, 255, 250, 250, 150, 226, 254, 243, 150, 247, 250, 244, 227, 251, 150, 226, 249, 150, 249, 230, 243, 248, 150, 226, 254, 243, 150, 248, 243, 238, 226, 150, 228, 249, 249, 251, 152, 188, 245, 249, 255, 248, 229, 150, 247, 228, 243, 150, 240, 255, 245, 226, 255, 249, 248, 247, 250, 150, 247, 248, 242, 150, 254, 247, 224, 243, 150, 248, 249, 150, 224, 247, 250, 227, 243, 152 }, 182),
            _0x63838571._0xe0838731(new byte[13] { 51, 48, 50, 58, 81, 37, 62, 81, 61, 62, 51, 51, 40 }, 113)
        };
        float[] _0x6873e40c =
        {
            64f,
            38f,
            44f,
            64f,
            38f,
            44f
        };
        float[] _0x67f02c9b =
        {
            48f,
            30f,
            34f,
            48f,
            30f,
            34f
        };
        if (this._rulesLabels != null)
            for (int _0x50454c5d = 0; _0x50454c5d < this._rulesLabels.Length && _0x50454c5d < _0xe9bcbe00.Length; _0x50454c5d++)
            {
                TMP_Text _0x06d6d0ba = this._rulesLabels[_0x50454c5d];
                if (_0x06d6d0ba == null)
                    continue;
                _0x06d6d0ba.text = _0xe9bcbe00[_0x50454c5d];
                Color _0x103a79e0 = (_0x50454c5d % 3) == 1 ? _0xecf6b76b.TextSecondary : _0xecf6b76b.TextPrimary;
                _0xe91c2331.Apply(_0x06d6d0ba, _0x103a79e0, _0x6873e40c[_0x50454c5d], _0x67f02c9b[_0x50454c5d]);
                _0x06d6d0ba.alignment = TextAlignmentOptions.Center;
            }

        if (this._blankLabels != null)
            for (int _0x4b3ef28b = 0; _0x4b3ef28b < this._blankLabels.Length; _0x4b3ef28b++)
                if (this._blankLabels[_0x4b3ef28b] != null)
                    this._blankLabels[_0x4b3ef28b].text = string.Empty;
    }

    [SerializeField]
    private TMP_FontAsset _font;
    private TMP_Text _0x2d37d101;
    private void _0xe7608531()
    {
        if (_0xd5e1760c.Instance != null)
            _0xd5e1760c.Instance._0x14f99188(_0x778394b0._0x147ecbe6.TUTORIAL0);
    }

    private const float PlayW = 790f;
    private TMP_Text _0xb9780705;
    /// <summary>
    /// The CTA face. It is added to the template button's own rect as the LAST children,
    /// so it draws over the Fade layer, and every piece of it is raycastTarget = false
    /// so the tap reaches the Button underneath.
    /// </summary>
    private void _0x2fa2ef28()
    {
        if (this._playRoot == null)
            return;
        _0x2bfe8fd8.Plate(this._playRoot, _0x63838571._0xe0838731(new byte[10] { 253, 193, 204, 212, 254, 197, 204, 201, 194, 218 }, 173), new Vector2(0.5f, 0.5f), new Vector2(PlayW + 18f, PlayH + 18f), _0xecf6b76b.Fade(_0xecf6b76b.DeepInk, 0.55f), this._round);
        this._0xb5b5f41a = _0x2bfe8fd8.Plate(this._playRoot, _0x63838571._0xe0838731(new byte[9] { 122, 70, 75, 83, 122, 70, 75, 94, 79 }, 42), new Vector2(0.5f, 0.5f), new Vector2(PlayW, PlayH), _0xecf6b76b.Gold, this._round);
        _0x2bfe8fd8.Plate(this._playRoot, _0x63838571._0xe0838731(new byte[9] { 243, 207, 194, 218, 225, 198, 213, 198, 207 }, 163), new Vector2(0.5f, 1f), new Vector2(PlayW - 40f, 5f), _0xecf6b76b.BevelTop, null).rectTransform.anchoredPosition = new Vector2(0f, -12f);
        _0x2bfe8fd8.Plate(this._playRoot, _0x63838571._0xe0838731(new byte[8] { 112, 76, 65, 89, 102, 79, 79, 84 }, 32), new Vector2(0.5f, 0f), new Vector2(PlayW - 40f, 5f), _0xecf6b76b.Fade(_0xecf6b76b.Primary, 0.8f), null).rectTransform.anchoredPosition = new Vector2(0f, 12f);
        _0x2bfe8fd8.Caption(this._playRoot, _0x63838571._0xe0838731(new byte[11] { 239, 211, 222, 198, 252, 222, 207, 203, 214, 208, 209 }, 191), this._font, _0x63838571._0xe0838731(new byte[8] { 131, 159, 146, 138, 243, 157, 156, 132 }, 211), new Vector2(0.5f, 0.5f), new Vector2(PlayW - 70f, 96f), 64f, 48f, _0xecf6b76b.TextPrimary, TextAlignmentOptions.Center);
        this._playRoot.DOScale(1.025f, 1.6f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetLink(this._playRoot.gameObject).SetId(this);
    }

    private void OnDestroy()
    {
        DOTween.Kill(this);
    }

    private void _0xaa042464(RectTransform _0xe2c0047f, float _0x6f9c38e6)
    {
        if (_0xe2c0047f == null)
            return;
        _0xe2c0047f.localScale = Vector3.one * 0.9f;
        _0xe2c0047f.DOScale(1f, 0.25f).SetDelay(_0x6f9c38e6).SetEase(Ease.OutBack).SetLink(_0xe2c0047f.gameObject);
    }

    /// <summary>
    /// Every text on a tutorial page this game does NOT dress. The template ships
    /// "Lorem Ipsum" and "HEADER" there and it would go to the store untouched (C.15).
    /// </summary>
    [SerializeField]
    private TMP_Text[] _blankLabels;
    /// <summary>Redraw every number the sheet or a spin may have changed.</summary>
    public void _0xb954eee4()
    {
        int _0xd3c79f1f = _0x43ed7f14._0xa18ae110;
        int _0xa8d5bb32 = _0x4cd3e5d2.RoomFor(_0xd3c79f1f);
        if (_0x43ed7f14._0x17f00794 != _0xa8d5bb32)
            _0x43ed7f14._0x17f00794 = _0xa8d5bb32;
        if (this._0xb9780705 != null)
            this._0xb9780705.text = _0x43ed7f14.Money(_0x43ed7f14._0x0432624b);
        if (this._0x2d37d101 != null)
            this._0x2d37d101.text = _0x4cd3e5d2.Label(_0xa8d5bb32) + _0x63838571._0xe0838731(new byte[3] { 49, 49, 49 }, 17) + _0xd3c79f1f + _0x63838571._0xe0838731(new byte[3] { 6, 9, 6 }, 38) + _0x4cd3e5d2.NextThreshold(_0xa8d5bb32);
        if (this._0x508d713e != null)
        {
            int _0x37989bdc = _0x4cd3e5d2.NextThreshold(_0xa8d5bb32);
            float _0xddd8a1a2 = _0x37989bdc <= 0 ? 1f : Mathf.Clamp01((float)_0xd3c79f1f / _0x37989bdc);
            this._0x508d713e.sizeDelta = new Vector2(1020f * Mathf.Max(0.04f, _0xddd8a1a2), 26f);
        }

        Color _0xf8ffbdd3 = _0x4cd3e5d2.Trim(_0xa8d5bb32);
        if (this._0x6127004a != null)
            this._0x6127004a.color = _0xecf6b76b.Fade(_0xf8ffbdd3, 0.85f);
        if (this._0x2309a46e != null)
            this._0x2309a46e.color = _0xecf6b76b.Fade(_0x4cd3e5d2.Tint(_0xa8d5bb32), 0.97f);
        if (this._0xb5b5f41a != null)
            this._0xb5b5f41a.color = _0xecf6b76b.Gold;
        bool _0xae9c2bfa = !_0x43ed7f14._0x267e30bb;
        if (this._0xd645ea5d != null)
            this._0xd645ea5d.text = _0xae9c2bfa ? _0x63838571._0xe0838731(new byte[5] { 97, 108, 109, 118, 112 }, 35) : _0x63838571._0xe0838731(new byte[9] { 98, 111, 110, 117, 115, 0, 18, 19, 104 }, 32);
        if (this._0xd3ca8c7b != null)
            this._0xd3ca8c7b.gameObject.SetActive(_0xae9c2bfa);
    }

    private RectTransform _0x5fd5b104;
    private const float ChipW = 320f;
    private void Start()
    {
        _0x43ed7f14.EnsureSeeded();
        this._0xbbefb590();
        this._0x2fa2ef28();
        this._0x0cb0ef5c();
        if (this._sheet != null)
            this._sheet._0x1acbaf35(this);
        this._0xb954eee4();
    }
}

internal static class _0x63838571
{
    internal static string _0xe0838731(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}