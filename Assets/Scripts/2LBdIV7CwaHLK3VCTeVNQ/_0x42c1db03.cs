using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// One overlay shell with three tabs: the symbol album, the daily ladder and settings.
///
/// WHY THESE ARE OUR OWN OBJECTS AND NOT THREE MORE TEMPLATE PANELS. SETTINGS.PANELS on
/// this drop declares SPLASH 0, DEFAULT 1, EMPTY 2 and TUTORIAL0..6 at 13..19, and
/// nothing else. Inventing an index for a COLLECTION or SHOP panel would address a null
/// entry in PanelController.Panels and throw. So the shell is a GameObject this class
/// creates inside DefaultPanel's content container and shows through a reference it
/// owns - which is also what keeps stage 5da away from it (C.2).
///
/// Switching a tab is a VISIBLE change (C.7): the body swaps, the underline slides and
/// the title changes, so a reviewer can see the tap did something.
/// </summary>
public sealed class _0x42c1db03 : MonoBehaviour
{
    private const float TabW = 360f;
    /// <summary>
    /// Built on demand by the lobby rather than in Start, so the two cannot race: the
    /// order of Start calls is undefined and this needs the lobby to exist (C.59).
    /// </summary>
    public void _0x1acbaf35(_0x9129a671 _0x6cccc66d)
    {
        if (this._0x14bb64d4)
            return;
        this._0x14bb64d4 = true;
        this._0xddbbb300 = _0x6cccc66d;
        this._0x92d459a4();
        if (this._0x18cec7c1 != null)
            this._0x18cec7c1.gameObject.SetActive(false);
    }

    public Sprite[] _0xd1a712e2
    {
        get
        {
            return this._symbols;
        }
    }

    public void _0xeffb11a9(int _0x0e01f872)
    {
        if (!this._0x14bb64d4 || this._0x18cec7c1 == null)
            return;
        this._0x18cec7c1.gameObject.SetActive(true);
        this._0x58e96fba(_0x0e01f872);
    }

    private const float TabH = 100f;
    private const float FooterY = 240f;
    private TMP_Text _0x04a76440(string _0x61bd11e9, string _0xe2a583db, int _0x6ba4e991)
    {
        RectTransform _0x079da199 = _0x2bfe8fd8.Node(this._0x18cec7c1, _0x61bd11e9, _0x2bfe8fd8.At(this._0x2bf28126[_0x6ba4e991], TabY), new Vector2(TabW, TabH));
        Image _0x0448778f = _0x079da199.gameObject.AddComponent<Image>();
        _0x0448778f.color = _0xecf6b76b.Fade(_0xecf6b76b.Surface3, 0.55f);
        _0x0448778f.sprite = this._round;
        _0x0448778f.type = Image.Type.Sliced;
        _0x0448778f.pixelsPerUnitMultiplier = 2.6f;
        _0x0448778f.raycastTarget = true;
        Button _0xec258f57 = _0x079da199.gameObject.AddComponent<Button>();
        _0xec258f57.targetGraphic = _0x0448778f;
        _0xec258f57.transition = Selectable.Transition.None;
        int _0x08a54ac7 = _0x6ba4e991;
        _0xec258f57.onClick.AddListener(() => this._0x58e96fba(_0x08a54ac7));
        return _0x2bfe8fd8.Caption(_0x079da199, _0x61bd11e9 + _0xf0e6515c._0x048c7ddd(new byte[5] { 158, 179, 176, 183, 190 }, 210), this._font, _0xe2a583db, new Vector2(0.5f, 0.5f), new Vector2(TabW - 24f, 60f), 40f, 32f, _0xecf6b76b.TextSoft, TextAlignmentOptions.Center);
    }

    [SerializeField]
    private Sprite _plate;
    private void _0x58e96fba(int _0xac578bf7)
    {
        this._0xf77155ac = Mathf.Clamp(_0xac578bf7, TabCollection, TabSettings);
        for (int _0xd34be226 = 0; _0xd34be226 < this._0xfa0b2b23.Length; _0xd34be226++)
            if (this._0xfa0b2b23[_0xd34be226] != null)
                _0xe91c2331.Apply(this._0xfa0b2b23[_0xd34be226], _0xd34be226 == this._0xf77155ac ? _0xecf6b76b.Gold : _0xecf6b76b.TextSoft, 40f, 32f);
        if (this._0xe475ff01 != null)
            this._0xe475ff01.DOAnchorPosX(this._0x2bf28126[this._0xf77155ac] - 621f, 0.22f).SetEase(Ease.OutCubic).SetLink(this._0xe475ff01.gameObject);
        if (this._0xbaa2c569 != null)
            this._0xbaa2c569.text = this._0xf77155ac == TabCollection ? _0xf0e6515c._0x048c7ddd(new byte[12] { 77, 71, 83, 92, 81, 82, 62, 95, 82, 92, 75, 83 }, 30) : this._0xf77155ac == TabBonus ? _0xf0e6515c._0x048c7ddd(new byte[13] { 236, 233, 225, 228, 241, 136, 238, 231, 250, 252, 253, 230, 237 }, 168) : _0xf0e6515c._0x048c7ddd(new byte[14] { 233, 254, 234, 243, 235, 159, 236, 250, 235, 235, 246, 241, 248, 236 }, 191);
        this._0x20fb5e25();
        if (this._0xf77155ac == TabCollection && this._collection != null)
            this._collection._0xbc201cb2(this, this._0x0413729d);
        else if (this._0xf77155ac == TabBonus && this._bonus != null)
            this._bonus._0x59706945(this, this._0x0413729d);
        else if (this._settings != null)
            this._settings._0x6853dfa6(this, this._0x0413729d);
    }

    private void OnDestroy()
    {
        DOTween.Kill(this);
    }

    private _0x9129a671 _0xddbbb300;
    private void _0x20fb5e25()
    {
        if (this._0x0413729d == null)
            return;
        for (int _0x5151586e = this._0x0413729d.childCount - 1; _0x5151586e >= 0; _0x5151586e--)
            Destroy(this._0x0413729d.GetChild(_0x5151586e).gameObject);
    }

    /// <summary>A board calls this after it changes coins or the album.</summary>
    public void _0x60561518()
    {
        if (this._0xddbbb300 != null)
            this._0xddbbb300._0xb954eee4();
        if (this._collection != null)
            this._collection._0x988ef387();
    }

    private int _0xf77155ac = TabCollection;
    private void _0x92d459a4()
    {
        if (this._content == null)
            return;
        this._0x18cec7c1 = _0x2bfe8fd8.Stretch(this._content, _0xf0e6515c._0x048c7ddd(new byte[17] { 12, 59, 47, 54, 46, 9, 50, 63, 63, 46, 21, 44, 63, 40, 54, 59, 35 }, 90));
        _0x2bfe8fd8.Veil(this._0x18cec7c1, _0xf0e6515c._0x048c7ddd(new byte[10] { 11, 48, 61, 61, 44, 11, 59, 42, 49, 53 }, 88), _0xecf6b76b.Scrim, true);
        RectTransform _0xa817bf5e = _0x2bfe8fd8.Node(this._0x18cec7c1, _0xf0e6515c._0x048c7ddd(new byte[10] { 242, 201, 196, 196, 213, 241, 205, 192, 213, 196 }, 161), _0x2bfe8fd8.At(621f, SheetTop * 0.5f), new Vector2(_0x2bfe8fd8.CanvasW, SheetTop));
        Image _0xf10f9ad6 = _0xa817bf5e.gameObject.AddComponent<Image>();
        _0xf10f9ad6.sprite = this._plate;
        _0xf10f9ad6.type = Image.Type.Sliced;
        _0xf10f9ad6.pixelsPerUnitMultiplier = 2.2f;
        _0xf10f9ad6.color = _0xecf6b76b.SheetTint;
        _0xf10f9ad6.raycastTarget = true;
        _0x2bfe8fd8.Rule(this._0x18cec7c1, _0xf0e6515c._0x048c7ddd(new byte[9] { 89, 98, 111, 111, 126, 79, 110, 109, 111 }, 10), _0x2bfe8fd8.At(621f, SheetTop - 3f), new Vector2(_0x2bfe8fd8.CanvasW, 5f), _0xecf6b76b.Hairline);
        // The body is a full-stretch node, so a board can lay itself out in the same
        // absolute canvas units every other screen uses. It is created BEFORE the title,
        // the tabs and the footer, so chrome always draws over content.
        this._0x0413729d = _0x2bfe8fd8.Stretch(this._0x18cec7c1, _0xf0e6515c._0x048c7ddd(new byte[9] { 221, 230, 235, 235, 250, 204, 225, 234, 247 }, 142));
        this._0xbaa2c569 = _0x2bfe8fd8.Caption(this._0x18cec7c1, _0xf0e6515c._0x048c7ddd(new byte[10] { 211, 232, 229, 229, 244, 212, 233, 244, 236, 229 }, 128), this._font, _0xf0e6515c._0x048c7ddd(new byte[12] { 120, 114, 102, 105, 100, 103, 11, 106, 103, 105, 126, 102 }, 43), _0x2bfe8fd8.At(420f, TitleY), new Vector2(700f, 96f), 72f, 48f, _0xecf6b76b.TextPrimary, TextAlignmentOptions.Left);
        Button _0x3ab008b0 = _0x2bfe8fd8.IconButton(this._0x18cec7c1, _0xf0e6515c._0x048c7ddd(new byte[10] { 56, 3, 14, 14, 31, 40, 7, 4, 24, 14 }, 107), this._closeIcon, _0x2bfe8fd8.At(1118f, TitleY), 112f, 84f, _0xecf6b76b.Fade(_0xecf6b76b.Surface2, 0.9f), _0xecf6b76b.Gold);
        _0x3ab008b0.onClick.AddListener(() => this._0x2b2d6168());
        this._0xe475ff01 = _0x2bfe8fd8.Rule(this._0x18cec7c1, _0xf0e6515c._0x048c7ddd(new byte[12] { 222, 235, 232, 223, 228, 238, 239, 248, 230, 227, 228, 239 }, 138), _0x2bfe8fd8.At(621f, TabY - 56f), new Vector2(TabW - 60f, 6f), _0xecf6b76b.Gold).rectTransform;
        this._0xe475ff01.anchoredPosition = new Vector2(this._0x2bf28126[0] - 621f, 0f);
        this._0xfa0b2b23[0] = this._0x04a76440(_0xf0e6515c._0x048c7ddd(new byte[13] { 59, 14, 13, 44, 0, 3, 3, 10, 12, 27, 6, 0, 1 }, 111), _0xf0e6515c._0x048c7ddd(new byte[10] { 224, 236, 239, 239, 230, 224, 247, 234, 236, 237 }, 163), 0);
        this._0xfa0b2b23[1] = this._0x04a76440(_0xf0e6515c._0x048c7ddd(new byte[8] { 249, 204, 207, 239, 194, 195, 216, 222 }, 173), _0xf0e6515c._0x048c7ddd(new byte[5] { 165, 168, 169, 178, 180 }, 231), 1);
        this._0xfa0b2b23[2] = this._0x04a76440(_0xf0e6515c._0x048c7ddd(new byte[11] { 209, 228, 231, 214, 224, 241, 241, 236, 235, 226, 246 }, 133), _0xf0e6515c._0x048c7ddd(new byte[8] { 78, 88, 73, 73, 84, 83, 90, 78 }, 29), 2);
        Button _0x60b5e8a3 = _0x2bfe8fd8.Cta(this._0x18cec7c1, _0xf0e6515c._0x048c7ddd(new byte[10] { 153, 162, 153, 165, 168, 159, 168, 168, 161, 190 }, 205), this._font, _0xf0e6515c._0x048c7ddd(new byte[12] { 180, 175, 192, 180, 168, 165, 192, 178, 165, 165, 172, 179 }, 224), _0x2bfe8fd8.At(621f, FooterY), new Vector2(760f, 136f), _0xecf6b76b.Primary, _0xecf6b76b.TextPrimary, 48f, 38f, this._round);
        _0x60b5e8a3.onClick.AddListener(() => this._0x14731885());
    }

    private const float TitleY = 1890f;
    public _0x9129a671 _0xf24c6554
    {
        get
        {
            return this._0xddbbb300;
        }
    }

    [SerializeField]
    private Sprite[] _symbols;
    private RectTransform _0x18cec7c1;
    private void _0x14731885()
    {
        if (_0x764d1f95.Instance != null)
            _0x764d1f95.Instance._0x3b3b6907(_0x778394b0._0xb8e5a259.SCENE_1);
    }

    private RectTransform _0x0413729d;
    private bool _0x14bb64d4;
    private readonly float[] _0x2bf28126 =
    {
        231f,
        621f,
        1011f
    };
    [SerializeField]
    private TMP_FontAsset _font;
    private RectTransform _0xe475ff01;
    private const float SheetTop = 2000f;
    private const float TabY = 1760f;
    public const int TabCollection = 0;
    [SerializeField]
    private _0x243e0d9e _collection;
    [SerializeField]
    private Sprite _closeIcon;
    public TMP_FontAsset _0xe4f31537
    {
        get
        {
            return this._font;
        }
    }

    public void _0x2b2d6168()
    {
        if (this._0x18cec7c1 != null)
            this._0x18cec7c1.gameObject.SetActive(false);
        if (this._0xddbbb300 != null)
            this._0xddbbb300._0xb954eee4();
    }

    public Sprite _0x3fb723e6
    {
        get
        {
            return this._round;
        }
    }

    [SerializeField]
    private _0xf6508987 _settings;
    [SerializeField]
    private _0xa5de79e0 _bonus;
    private readonly TMP_Text[] _0xfa0b2b23 = new TMP_Text[3];
    public const int TabSettings = 2;
    public const int TabBonus = 1;
    [SerializeField]
    private Sprite _round;
    public Sprite _0xd69ec975
    {
        get
        {
            return this._plate;
        }
    }

    private TMP_Text _0xbaa2c569;
    [SerializeField]
    private RectTransform _content;
}

internal static class _0xf0e6515c
{
    internal static string _0x048c7ddd(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}