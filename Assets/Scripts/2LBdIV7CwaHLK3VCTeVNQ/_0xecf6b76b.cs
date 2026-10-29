using UnityEngine;

/// <summary>
/// Every colour the vault uses, in one place.
///
/// EVERY TEXT COLOUR HERE IS LIGHT ON PURPOSE (C.14). All captions share one font
/// material, and that material carries one dark outline (Outline, #120B20). A dark
/// face against a dark outline merges into a blot that no backing can rescue, which
/// is how PLAY once read as FLAY. So Ground / DeepInk / Surface1..3 / Inactive are
/// BACKING colours and are never passed as a text colour; TextPrimary, TextSecondary,
/// TextMuted, Gold, Teal, TealLight and Cream are the only ones that may be.
///
/// Declaration order matters (C.52): every plain literal is declared first and every
/// derived value last. String encryption turns consts into runtime-initialised fields
/// and then reorders declarations, so a derived value that reads a literal declared
/// below it would initialise to null and kill the type for the whole process.
/// </summary>
public static class _0xecf6b76b
{
    public static readonly Color Outline = new Color(0.0706f, 0.0431f, 0.1255f, 1f);
    public static readonly Color Track = new Color(0.1647f, 0.1020f, 0.2784f, 1f);
    public static readonly Color Surface3 = new Color(0.1020f, 0.0627f, 0.1882f, 1f);
    public static readonly Color TextMuted = new Color(0.4941f, 0.4275f, 0.6588f, 1f);
    public static readonly Color DeepInk = new Color(0.0196f, 0.0078f, 0.0627f, 1f);
    public static readonly Color TextSecondary = new Color(0.7882f, 0.7216f, 0.9098f, 1f);
    public static readonly Color PrimaryBright = new Color(0.6588f, 0.3333f, 0.9686f, 1f);
    public static readonly Color Surface2 = new Color(0.1412f, 0.0824f, 0.2510f, 1f);
    public static readonly Color BarTrack = Fade(Track, 0.90f);
    // ---- plain literals (no dependency on anything in this file) ----------------
    public static readonly Color Ground = new Color(0.0902f, 0.0627f, 0.1529f, 1f);
    public static readonly Color Inactive = new Color(0.2902f, 0.2275f, 0.4314f, 1f);
    public static readonly Color ShadowBand = Fade(DeepInk, 0.45f);
    public static readonly Color Danger = new Color(0.7059f, 0.1882f, 0.2275f, 1f);
    public static readonly Color Gold = new Color(0.9804f, 0.8000f, 0.0824f, 1f);
    public static readonly Color Hairline = Fade(Gold, 0.85f);
    public static readonly Color TextSoft = new Color(0.6157f, 0.5451f, 0.7686f, 1f);

    public static readonly Color BevelBottom = Fade(DeepInk, 0.45f);
    public static readonly Color Card = new Color(0.1216f, 0.0784f, 0.2196f, 1f);
    /// <summary>The four room trims, by room index 0..3. Decorative only.</summary>
    public static Color RoomTrim(int _0x494ad836)
    {
        if (_0x494ad836 <= 0)
            return Primary;
        if (_0x494ad836 == 1)
            return Gold;
        if (_0x494ad836 == 2)
            return PrimaryBright;
        return TealLight;
    }
    public static readonly Color TealLight = new Color(0.3686f, 0.9176f, 0.8314f, 1f);
    public static readonly Color SplashVeil = new Color(0.0431f, 0.0235f, 0.0902f, 1f);

    public static readonly Color TextPrimary = new Color(1.0000f, 0.9686f, 0.9294f, 1f);

    public static readonly Color GlowStrip = Fade(Gold, 0.55f);
    /// <summary>The backdrop tint each room gives the lobby sheet.</summary>
    public static Color RoomTint(int _0xefb28373)
    {
        if (_0xefb28373 <= 0)
            return Ground;
        if (_0xefb28373 == 1)
            return Surface1;
        if (_0xefb28373 == 2)
            return new Color(0.1176f, 0.0627f, 0.2196f, 1f);
        return new Color(0.0706f, 0.1020f, 0.1804f, 1f);
    }
    public static readonly Color Teal = new Color(0.0784f, 0.7216f, 0.6510f, 1f);
    /// <summary>Same hue, a different alpha. Never used to build a TEXT colour.</summary>
    public static Color Fade(Color _0xe6c21399, float _0x3e6ba20c)
    {
        return new Color(_0xe6c21399.r, _0xe6c21399.g, _0xe6c21399.b, _0x3e6ba20c);
    }
    public static readonly Color GoldLight = new Color(1.0000f, 0.9137f, 0.6392f, 1f);
    public static readonly Color BevelTop = Fade(GoldLight, 0.35f);
    // ---- derived values: every one of these READS a literal declared above -------
    public static readonly Color Scrim = Fade(DeepInk, 0.78f);
    public static readonly Color GoldDeep = new Color(0.7255f, 0.5765f, 0.1020f, 1f);
    public static readonly Color Surface1 = new Color(0.1098f, 0.0706f, 0.2000f, 1f);
    public static readonly Color SheetTint = Fade(Surface1, 0.96f);
    public static readonly Color Primary = new Color(0.4275f, 0.1569f, 0.8510f, 1f);
    public static readonly Color ChipBorder = Fade(Primary, 0.80f);
}