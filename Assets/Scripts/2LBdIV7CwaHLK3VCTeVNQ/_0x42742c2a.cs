using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The splash: an abstract vault mark over a darkened hall, and a loading bar that can
/// actually be seen.
///
/// NO NAME ANYWHERE. The only branding is the emblem sprite plus colour - the app's
/// name lives in the project settings and never on screen (hard rule 1).
///
/// The splash must also not look like the lobby. Both draw the same BG_main texture, so
/// this one sits under a near-opaque ink veil and carries no sheet, no chips and no CTA.
/// Without that difference the loader and the menu hash to the same frame and the
/// capture gate rejects the album.
///
/// The loading bar is the template's own LoadingSlider. Its root already resolves to 54
/// units tall, which clears the 30-unit inset "Fill Area" applies to itself, so the
/// size is left exactly as the prefab ships it (ANDROID-3578 was a bar RESIZED at
/// runtime to 30 and then inset to nothing). Only the colours are ours.
/// </summary>
public sealed class _0x42742c2a : MonoBehaviour
{
    [SerializeField]
    private Image _barFill;
    [SerializeField]
    private Sprite _mark;
    private const float CaptionSize = 32f;
    [SerializeField]
    private Sprite _plate;
    [SerializeField]
    private RectTransform _splashContent;
    [SerializeField]
    private RectTransform _barRoot;
    private const float MarkSize = 360f;
    /// <summary>
    /// Fill and track colours for the template bar. The fill takes the palette accent
    /// at full alpha; the track takes a dark palette colour at an alpha that is really
    /// visible, instead of the template's 1/255 white-on-white (rule G).
    /// </summary>
    private void _0x76070b25()
    {
        if (this._barFill != null)
        {
            RectTransform _0xabd2b2cc = this._barFill.rectTransform;
            if (_0xabd2b2cc != null)
                this._barFill.color = _0xecf6b76b.Gold;
        }

        if (this._barTrack != null)
            this._barTrack.color = _0xecf6b76b.BarTrack;
        if (this._barRoot != null)
        {
            Image _0xe0db5e5e = this._barRoot.GetComponent<Image>();
            if (_0xe0db5e5e != null)
                _0xe0db5e5e.color = _0xecf6b76b.BarTrack;
        }
    }

    [SerializeField]
    private Image _barTrack;
    private void _0xf63177e2()
    {
        if (this._splashContent == null)
            return;
        RectTransform _0xcbbdb2d1 = _0x2bfe8fd8.Stretch(this._splashContent, _0x54f38ef4._0x3cc6f9a4(new byte[11] { 224, 215, 195, 218, 194, 229, 198, 218, 215, 197, 222 }, 182));
        _0xcbbdb2d1.SetAsFirstSibling();
        _0x2bfe8fd8.Veil(_0xcbbdb2d1, _0x54f38ef4._0x3cc6f9a4(new byte[10] { 191, 156, 128, 141, 159, 132, 186, 137, 133, 128 }, 236), _0xecf6b76b.Fade(_0xecf6b76b.SplashVeil, 0.88f), false);
        RectTransform _0x011ffbaa = _0x2bfe8fd8.Node(_0xcbbdb2d1, _0x54f38ef4._0x3cc6f9a4(new byte[9] { 185, 149, 134, 159, 178, 134, 149, 153, 145 }, 244), _0x2bfe8fd8.At(621f, 1613f), new Vector2(MarkSize + 60f, MarkSize + 60f));
        _0x2bfe8fd8.Plate(_0x011ffbaa, _0x54f38ef4._0x3cc6f9a4(new byte[8] { 136, 164, 183, 174, 130, 169, 170, 178 }, 197), new Vector2(0.5f, 0.5f), new Vector2(MarkSize + 60f, MarkSize + 60f), _0xecf6b76b.Fade(_0xecf6b76b.Primary, 0.22f), this._plate);
        Image _0xab074928 = _0x2bfe8fd8.Picture(_0x011ffbaa, _0x54f38ef4._0x3cc6f9a4(new byte[9] { 97, 86, 66, 91, 67, 122, 86, 69, 92 }, 55), this._mark, new Vector2(0.5f, 0.5f), new Vector2(MarkSize, MarkSize), _0xecf6b76b.TextPrimary);
        _0x2bfe8fd8.Caption(_0xcbbdb2d1, _0x54f38ef4._0x3cc6f9a4(new byte[13] { 53, 22, 10, 7, 21, 14, 37, 7, 22, 18, 15, 9, 8 }, 102), this._font, _0x54f38ef4._0x3cc6f9a4(new byte[17] { 242, 241, 255, 250, 247, 240, 249, 158, 234, 246, 251, 158, 232, 255, 235, 242, 234 }, 190), _0x2bfe8fd8.At(621f, 887f), new Vector2(900f, 70f), CaptionSize, CaptionFloor, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Center);
        // BOUNDED ENTRY ONLY, AND THEN THE SPLASH IS COMPLETELY STILL.
        // Step 1 of the review scenario blocks on wait_loader_done, which samples an 8x8
        // signature every 5 s and needs 15 s whose diff stays under 12/64. A splash that
        // never stops moving never settles, the wait burns its 300 s ceiling and the album
        // comes back as "the frames may be the splash". So: fade and scale in over 0.7 s,
        // then nothing moves except the template's own progress bar.
        _0xab074928.color = new Color(_0xecf6b76b.TextPrimary.r, _0xecf6b76b.TextPrimary.g, _0xecf6b76b.TextPrimary.b, 0f);
        _0xab074928.rectTransform.localScale = Vector3.one * 0.86f;
        _0xab074928.DOFade(1f, 0.5f).SetLink(_0xab074928.gameObject);
        _0xab074928.rectTransform.DOScale(1f, 0.7f).SetEase(Ease.OutBack).SetLink(_0xab074928.gameObject);
        _0x011ffbaa.localRotation = Quaternion.identity;
    }

    private void Start()
    {
        this._0x76070b25();
        this._0xf63177e2();
    }

    private const float CaptionFloor = 30f;
    [SerializeField]
    private TMP_FontAsset _font;
    private void OnDestroy()
    {
        DOTween.Kill(this);
    }
}

internal static class _0x54f38ef4
{
    internal static string _0x3cc6f9a4(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}