using TMPro;
using UnityEngine;

/// <summary>
/// Every label this game creates goes through here.
///
/// Stage 5c3 (enforce-text-contrast) reads SCENES and PREFABS. Labels built from C# at
/// runtime exist in no file, so nothing the pipeline does protects them - the outline
/// and the wrapping rules are this class's job (C.10).
///
/// Three things are applied to every label, with no exceptions:
///   - word wrapping OFF and every break placed by hand as an explicit \n, so the same
///     string gives the same number of lines on every device;
///   - autosize ON with a floor that is still readable. Autosize shrinks a line that
///     does not fit all the way down to fontSizeMin, so the MINIMUM is the size that
///     really ships. Every floor in this project is >= 30, because verify-text-size
///     measures against a 1080-wide reference while this canvas is 1242 wide;
///   - a per-label material instance whose outline contrasts with the face. Reading
///     fontMaterial creates the instance; the shared asset is never touched.
/// </summary>
public static class _0xe91c2331
{
    /// <summary>
    /// Colour, size band, wrapping and outline in one call. Sizes are in canvas units
    /// of the 1242x2688 reference, and <paramref name = "min"/> is the one that ships.
    /// </summary>
    public static void Apply(TMP_Text _0xf7dddca9, Color _0xaffa69ff, float _0x5bfe180d, float _0xb3d8b26e)
    {
        if (_0xf7dddca9 == null)
            return;
        _0xf7dddca9.color = _0xaffa69ff;
        _0xf7dddca9.textWrappingMode = TextWrappingModes.NoWrap;
        _0xf7dddca9.overflowMode = TextOverflowModes.Overflow;
        _0xf7dddca9.enableAutoSizing = true;
        _0xf7dddca9.fontSizeMin = _0xb3d8b26e < 30f ? 30f : _0xb3d8b26e;
        _0xf7dddca9.fontSizeMax = _0x5bfe180d;
        _0xf7dddca9.fontSize = _0x5bfe180d;
        ApplyOutline(_0xf7dddca9, _0xaffa69ff);
    }

    public const float OutlineWidth = 0.16f;
    /// <summary>
    /// Give a label a readable outline for its own face colour. A light face gets the
    /// dark ink outline, a dark face gets the cream one - never dark on dark (C.14).
    /// </summary>
    public static void ApplyOutline(TMP_Text _0x14764474, Color _0x93e078df)
    {
        if (_0x14764474 == null)
            return;
        Material _0x6dc4bc3d = _0x14764474.fontMaterial;
        if (_0x6dc4bc3d == null)
            return;
        float _0x262d75bc = (0.299f * _0x93e078df.r) + (0.587f * _0x93e078df.g) + (0.114f * _0x93e078df.b);
        _0x6dc4bc3d.SetColor(ShaderUtilities.ID_OutlineColor, _0x262d75bc < 0.5f ? _0xecf6b76b.TextPrimary : _0xecf6b76b.Outline);
        _0x6dc4bc3d.SetFloat(ShaderUtilities.ID_OutlineWidth, OutlineWidth);
    }

    /// <summary>
    /// The only place a multi-line string is assigned. Line breaks are authored here,
    /// never left to the engine, and a scene file cannot carry a real newline anyway.
    /// </summary>
    public static void SetText(TMP_Text _0x1ba939b4, string _0xdc457313)
    {
        if (_0x1ba939b4 == null)
            return;
        _0x1ba939b4.text = _0xdc457313;
    }
}