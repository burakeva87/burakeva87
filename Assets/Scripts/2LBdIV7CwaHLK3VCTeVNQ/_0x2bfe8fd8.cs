using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The canvas-space building blocks every screen of this game is made of.
///
/// SIGNATURE ORDER, because two of these are easy to swap and the mistake is invisible
/// until the review screenshot (C.14): in every call below, "fill" is the BACKING
/// colour of a surface and "tint" is the colour of TEXT. Pass a dark palette colour as
/// a tint and the caption disappears into its own outline.
///
/// DRAW ORDER (C.13): inside one canvas the hierarchy IS the order and a later sibling
/// draws on top. Every helper here creates its plate FIRST and its caption LAST, and
/// nothing opaque is ever created after the content it surrounds.
///
/// Every rect is a POINT anchor (anchorMin == anchorMax) with an explicit sizeDelta.
/// Stretching anchors with a zero sizeDelta are exactly what turn a button into a
/// full-screen slab (G.3), so they appear only in <see cref = "Stretch"/>, which is for
/// full-bleed backdrops and nothing else.
/// </summary>
public static class _0x2bfe8fd8
{
    /// <summary>
    /// Content art. ALWAYS preserveAspect: the generated PNGs are square today, and a
    /// regeneration that is not would otherwise turn a stone into an egg (F.2a).
    /// </summary>
    public static Image Picture(RectTransform _0x0f6dd29c, string _0x20be8033, Sprite _0x7708bafd, Vector2 _0x916d2082, Vector2 _0xc0e9813a, Color _0xcb61cf7f)
    {
        RectTransform _0x8aa0e720 = Node(_0x0f6dd29c, _0x20be8033, _0x916d2082, _0xc0e9813a);
        Image _0xa2f6543b = _0x8aa0e720.gameObject.AddComponent<Image>();
        _0xa2f6543b.sprite = _0x7708bafd;
        _0xa2f6543b.color = _0xcb61cf7f;
        _0xa2f6543b.type = Image.Type.Simple;
        _0xa2f6543b.preserveAspect = true;
        _0xa2f6543b.raycastTarget = false;
        return _0xa2f6543b;
    }

    /// <summary>A full-bleed surface, for backdrops and scrims.</summary>
    public static Image Veil(RectTransform _0xd73ea9a9, string _0xf35aafde, Color _0x22d27bdc, bool _0xc7a3f568)
    {
        RectTransform _0x3ced8e36 = Stretch(_0xd73ea9a9, _0xf35aafde);
        Image _0x5238e454 = _0x3ced8e36.gameObject.AddComponent<Image>();
        _0x5238e454.color = _0x22d27bdc;
        _0x5238e454.raycastTarget = _0xc7a3f568;
        return _0x5238e454;
    }

    /// <summary>Centre of the indicator gutter inside a mission/album row (C.25).</summary>
    public const float GutterCentre = 86f;
    /// <summary>
    /// A surface. <paramref name = "fill"/> is the BACKING colour. A sliced sprite makes
    /// it a 9-slice plate and gets no preserveAspect - stretching is the whole point of
    /// a plate and preserveAspect breaks the slicing (F.2a).
    /// </summary>
    public static Image Plate(RectTransform _0x57cdf82f, string _0xcd45a39f, Vector2 _0x80cc5971, Vector2 _0x4ac9dfa6, Color _0xb63af9b3, Sprite _0x0592c113)
    {
        RectTransform _0x56281945 = Node(_0x57cdf82f, _0xcd45a39f, _0x80cc5971, _0x4ac9dfa6);
        Image _0x953f62b6 = _0x56281945.gameObject.AddComponent<Image>();
        _0x953f62b6.color = _0xb63af9b3;
        _0x953f62b6.raycastTarget = false;
        if (_0x0592c113 != null)
        {
            _0x953f62b6.sprite = _0x0592c113;
            _0x953f62b6.type = Image.Type.Sliced;
            _0x953f62b6.pixelsPerUnitMultiplier = 2.2f;
        }

        return _0x953f62b6;
    }

    /// <summary>A full-bleed child. Backdrops and scrims only.</summary>
    public static RectTransform Stretch(RectTransform _0xe61f5060, string _0x1ebd71e0)
    {
        GameObject _0x29ab66c1 = new GameObject(_0x1ebd71e0, typeof(RectTransform));
        RectTransform _0xe5b1f4bf = _0x29ab66c1.GetComponent<RectTransform>();
        _0xe5b1f4bf.SetParent(_0xe61f5060, false);
        _0xe5b1f4bf.anchorMin = Vector2.zero;
        _0xe5b1f4bf.anchorMax = Vector2.one;
        _0xe5b1f4bf.offsetMin = Vector2.zero;
        _0xe5b1f4bf.offsetMax = Vector2.zero;
        _0xe5b1f4bf.localScale = Vector3.one;
        return _0xe5b1f4bf;
    }

    public static RectTransform Node(RectTransform _0x270cad7d, string _0xe6e7a28a, Vector2 _0x3b283cfe, Vector2 _0xb610b7de)
    {
        GameObject _0x685b8b87 = new GameObject(_0xe6e7a28a, typeof(RectTransform));
        RectTransform _0x7c64b6a4 = _0x685b8b87.GetComponent<RectTransform>();
        _0x7c64b6a4.SetParent(_0x270cad7d, false);
        _0x7c64b6a4.anchorMin = _0x3b283cfe;
        _0x7c64b6a4.anchorMax = _0x3b283cfe;
        _0x7c64b6a4.pivot = new Vector2(0.5f, 0.5f);
        _0x7c64b6a4.anchoredPosition = Vector2.zero;
        _0x7c64b6a4.sizeDelta = _0xb610b7de;
        _0x7c64b6a4.localScale = Vector3.one;
        return _0x7c64b6a4;
    }

    /// <summary>
    /// A pressable surface with its own caption.
    ///
    /// Order inside: shadow -> plate -> bevel -> caption, so the label is the LAST
    /// child and nothing can bury it (C.13 / E.1). The Button's own Image is the plate,
    /// which is the only raycast target; the caption does not take taps.
    /// </summary>
    public static Button Cta(RectTransform _0x0679b3e8, string _0x188ca956, TMP_FontAsset _0x4d78e749, string _0x9b4ab604, Vector2 _0x19f23eea, Vector2 _0x3b86cad9, Color _0xe3827582, Color _0xc7998e75, float _0x2e5b3ee0, float _0xb6dc9878, Sprite _0x74617866)
    {
        RectTransform _0xb7f6eeb0 = Node(_0x0679b3e8, _0x188ca956, _0x19f23eea, _0x3b86cad9);
        Image _0xecd8fe0a = _0xb7f6eeb0.gameObject.AddComponent<Image>();
        _0xecd8fe0a.color = _0xe3827582;
        _0xecd8fe0a.raycastTarget = true;
        if (_0x74617866 != null)
        {
            _0xecd8fe0a.sprite = _0x74617866;
            _0xecd8fe0a.type = Image.Type.Sliced;
            _0xecd8fe0a.pixelsPerUnitMultiplier = 2.2f;
        }

        Button _0x011b053e = _0xb7f6eeb0.gameObject.AddComponent<Button>();
        _0x011b053e.targetGraphic = _0xecd8fe0a;
        _0x011b053e.transition = Selectable.Transition.None;
        Plate(_0xb7f6eeb0, _0x188ca956 + _0xb6e4e484._0x20ed4e95(new byte[5] { 67, 100, 119, 100, 109 }, 1), new Vector2(0.5f, 1f), new Vector2(_0x3b86cad9.x - 24f, 4f), _0xecf6b76b.BevelTop, null).rectTransform.anchoredPosition = new Vector2(0f, -7f);
        Plate(_0xb7f6eeb0, _0x188ca956 + _0xb6e4e484._0x20ed4e95(new byte[4] { 177, 152, 152, 131 }, 247), new Vector2(0.5f, 0f), new Vector2(_0x3b86cad9.x - 24f, 4f), _0xecf6b76b.BevelBottom, null).rectTransform.anchoredPosition = new Vector2(0f, 7f);
        Caption(_0xb7f6eeb0, _0x188ca956 + _0xb6e4e484._0x20ed4e95(new byte[5] { 187, 150, 149, 146, 155 }, 247), _0x4d78e749, _0x9b4ab604, new Vector2(0.5f, 0.5f), new Vector2(_0x3b86cad9.x - 48f, _0x3b86cad9.y * 0.66f), _0x2e5b3ee0, _0xb6dc9878, _0xc7998e75, TextAlignmentOptions.Center);
        return _0x011b053e;
    }

    /// <summary>Turn a canvas-space y into the normalised anchor the rect wants.</summary>
    public static Vector2 At(float _0xc50a1d3b, float _0xcb7b1df0)
    {
        return new Vector2(_0xc50a1d3b / CanvasW, _0xcb7b1df0 / CanvasH);
    }

    /// <summary>
    /// A label. <paramref name = "tint"/> is the TEXT colour and must be a light one.
    /// Wrapping off, autosize on, floor at the readability threshold - see
    /// <see cref = "TextReadability"/>.
    /// </summary>
    public static TMP_Text Caption(RectTransform _0x22b1e440, string _0xef59e8b3, TMP_FontAsset _0x310102dd, string _0x8690c7d2, Vector2 _0x1484d0bd, Vector2 _0x04c8c3cc, float _0x06cddc5a, float _0xe6304eef, Color _0xae1391de, TextAlignmentOptions _0xfbb6f0cd)
    {
        RectTransform _0x36905aef = Node(_0x22b1e440, _0xef59e8b3, _0x1484d0bd, _0x04c8c3cc);
        TextMeshProUGUI _0x8802643c = _0x36905aef.gameObject.AddComponent<TextMeshProUGUI>();
        if (_0x310102dd != null)
            _0x8802643c.font = _0x310102dd;
        _0x8802643c.text = _0x8690c7d2;
        _0x8802643c.alignment = _0xfbb6f0cd;
        _0x8802643c.raycastTarget = false;
        _0xe91c2331.Apply(_0x8802643c, _0xae1391de, _0x06cddc5a, _0xe6304eef);
        return _0x8802643c;
    }

    /// <summary>A small square icon button: picture only, no caption (C.17).</summary>
    public static Button IconButton(RectTransform _0x9ace0f73, string _0x08a571c7, Sprite _0x48963934, Vector2 _0xd6b015ff, float _0xdb6cb8a8, float _0xf410c4e8, Color _0xd302664a, Color _0x1293e1c4)
    {
        RectTransform _0x34155966 = Node(_0x9ace0f73, _0x08a571c7, _0xd6b015ff, new Vector2(_0xdb6cb8a8, _0xdb6cb8a8));
        Image _0x8b191c13 = _0x34155966.gameObject.AddComponent<Image>();
        _0x8b191c13.color = _0xd302664a;
        _0x8b191c13.raycastTarget = true;
        Button _0x2cb7f631 = _0x34155966.gameObject.AddComponent<Button>();
        _0x2cb7f631.targetGraphic = _0x8b191c13;
        _0x2cb7f631.transition = Selectable.Transition.None;
        Picture(_0x34155966, _0x08a571c7 + _0xb6e4e484._0x20ed4e95(new byte[4] { 143, 165, 169, 168 }, 198), _0x48963934, new Vector2(0.5f, 0.5f), new Vector2(_0xf410c4e8, _0xf410c4e8), _0x1293e1c4);
        return _0x2cb7f631;
    }

    /// <summary>
    /// A card row with a reserved indicator gutter (C.25). The pip column lives in
    /// <see cref = "GutterCentre"/> +/- <see cref = "GutterWidth"/>/2; every caption the
    /// caller adds starts at <see cref = "TextLeft"/> or further right.
    /// </summary>
    public static RectTransform Row(RectTransform _0x0cd81ebf, string _0x80695304, Vector2 _0xd15b3242, Vector2 _0x72db6819, Color _0x0f8197e3, Color _0xe4ce3329, Sprite _0xb8a9d6e8)
    {
        RectTransform _0x26b89929 = Node(_0x0cd81ebf, _0x80695304, _0xd15b3242, _0x72db6819);
        Image _0x863f5951 = _0x26b89929.gameObject.AddComponent<Image>();
        _0x863f5951.color = _0x0f8197e3;
        _0x863f5951.raycastTarget = false;
        if (_0xb8a9d6e8 != null)
        {
            _0x863f5951.sprite = _0xb8a9d6e8;
            _0x863f5951.type = Image.Type.Sliced;
            _0x863f5951.pixelsPerUnitMultiplier = 2.6f;
        }

        Plate(_0x26b89929, _0x80695304 + _0xb6e4e484._0x20ed4e95(new byte[4] { 113, 80, 83, 81 }, 52), new Vector2(0f, 0.5f), new Vector2(6f, _0x72db6819.y - 22f), _0xe4ce3329, null).rectTransform.anchoredPosition = new Vector2(14f, 0f);
        return _0x26b89929;
    }

    /// <summary>A hairline divider, for stat strips and sheet edges.</summary>
    public static Image Rule(RectTransform _0xdc79f08e, string _0x9f988254, Vector2 _0xb99e5d4e, Vector2 _0xbcd7aeec, Color _0xc35c8d2b)
    {
        return Plate(_0xdc79f08e, _0x9f988254, _0xb99e5d4e, _0xbcd7aeec, _0xc35c8d2b, null);
    }

    /// <summary>Width of that gutter. Nothing but pips may occupy it.</summary>
    public const float GutterWidth = 56f;
    /// <summary>Canvas reference width; every x below is in these units.</summary>
    public const float CanvasW = 1242f;
    /// <summary>
    /// A rounded chip: plate, border tint, caption. Returns the Button so the caller
    /// wires it; the border Image is the second child so the caption still sits last.
    /// </summary>
    public static Button Chip(RectTransform _0x15538048, string _0x2671c2ed, TMP_FontAsset _0x7345f43d, string _0xa0bbfff6, Vector2 _0xbae9dc82, Vector2 _0x0204f90a, Color _0x9795c7c7, Color _0xc122f22c, Color _0x1a0cdda5, float _0x5bd6e88a, float _0x9ac2f33e, Sprite _0x70663fe8)
    {
        RectTransform _0xaeef3d54 = Node(_0x15538048, _0x2671c2ed, _0xbae9dc82, _0x0204f90a);
        Image _0x6dab3f3d = _0xaeef3d54.gameObject.AddComponent<Image>();
        _0x6dab3f3d.color = _0x9795c7c7;
        _0x6dab3f3d.raycastTarget = true;
        if (_0x70663fe8 != null)
        {
            _0x6dab3f3d.sprite = _0x70663fe8;
            _0x6dab3f3d.type = Image.Type.Sliced;
            _0x6dab3f3d.pixelsPerUnitMultiplier = 2.6f;
        }

        Button _0x223d0a77 = _0xaeef3d54.gameObject.AddComponent<Button>();
        _0x223d0a77.targetGraphic = _0x6dab3f3d;
        _0x223d0a77.transition = Selectable.Transition.None;
        Plate(_0xaeef3d54, _0x2671c2ed + _0xb6e4e484._0x20ed4e95(new byte[4] { 19, 52, 45, 36 }, 65), new Vector2(0.5f, 0f), new Vector2(_0x0204f90a.x - 28f, 5f), _0xc122f22c, null).rectTransform.anchoredPosition = new Vector2(0f, 10f);
        Caption(_0xaeef3d54, _0x2671c2ed + _0xb6e4e484._0x20ed4e95(new byte[5] { 123, 86, 85, 82, 91 }, 55), _0x7345f43d, _0xa0bbfff6, new Vector2(0.5f, 0.5f), new Vector2(_0x0204f90a.x - 28f, _0x0204f90a.y * 0.6f), _0x5bd6e88a, _0x9ac2f33e, _0x1a0cdda5, TextAlignmentOptions.Center);
        return _0x223d0a77;
    }

    /// <summary>
    /// Left edge of the text column: gutter right edge + a 46-unit gap. Every label in
    /// a row is placed so that anchoredPosition.x - sizeDelta.x/2 is at least this, so
    /// the two columns can never share an x-band however the row is laid out (C.25).
    /// </summary>
    public const float TextLeft = GutterCentre + (GutterWidth * 0.5f) + 46f;
    /// <summary>Canvas reference height; every y below is in these units.</summary>
    public const float CanvasH = 2688f;
}

internal static class _0xb6e4e484
{
    internal static string _0x20ed4e95(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}