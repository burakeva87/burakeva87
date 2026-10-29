using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The symbol album and the session's three missions.
///
/// TWO BANDS, NEVER ONE (C.25). A mission row carries a progress pip on the left and
/// text to its right. TextAlignmentOptions.Left aligns text INSIDE its rectangle and
/// leaves the rectangle where it was put, so a text rect that starts under the pip
/// column overlaps the pips while the code still reads "left aligned". Every caption
/// here starts at VaultUi.TextLeft, which is the gutter's right edge plus a 46-unit
/// gap, and the assertion that keeps it true is written next to the numbers.
///
/// EMPTY STATE (rule G). A fresh install has nothing sealed. The grid is then replaced
/// by a themed message rather than twelve empty tiles or, worse, a blank area.
/// </summary>
public sealed class _0x243e0d9e : MonoBehaviour
{
    private const float RowH = 104f;
    private const int Rows = 4;
    private RectTransform _0xe35373dd;
    private _0x42c1db03 _0x9dd6b5bf;
    private void _0xc2a5897b(RectTransform _0xb8f55ddc)
    {
        RectTransform _0x7ea85f53 = _0x2bfe8fd8.Node(_0xb8f55ddc, _0x76eb2b5f._0xa4f16f03(new byte[10] { 201, 228, 234, 253, 229, 205, 229, 248, 252, 241 }, 136), _0x2bfe8fd8.At(621f, GridY), new Vector2(1060f, 560f));
        Image _0x53b3db58 = _0x7ea85f53.gameObject.AddComponent<Image>();
        _0x53b3db58.color = _0xecf6b76b.Fade(_0xecf6b76b.Surface3, 0.9f);
        _0x53b3db58.sprite = this._0x9dd6b5bf._0x3fb723e6;
        _0x53b3db58.type = Image.Type.Sliced;
        _0x53b3db58.pixelsPerUnitMultiplier = 2.4f;
        _0x53b3db58.raycastTarget = false;
        _0x2bfe8fd8.Caption(_0x7ea85f53, _0x76eb2b5f._0xa4f16f03(new byte[10] { 25, 49, 44, 40, 37, 8, 53, 40, 48, 57 }, 92), this._0x9dd6b5bf._0xe4f31537, _0x76eb2b5f._0xa4f16f03(new byte[20] { 127, 126, 17, 98, 101, 126, 127, 116, 98, 17, 98, 116, 112, 125, 116, 117, 17, 104, 116, 101 }, 49), new Vector2(0.5f, 0.6f), new Vector2(940f, 80f), 44f, 34f, _0xecf6b76b.TextPrimary, TextAlignmentOptions.Center);
        _0x2bfe8fd8.Caption(_0x7ea85f53, _0x76eb2b5f._0xa4f16f03(new byte[9] { 103, 79, 82, 86, 91, 106, 75, 76, 86 }, 34), this._0x9dd6b5bf._0xe4f31537, _0x76eb2b5f._0xa4f16f03(new byte[32] { 70, 69, 92, 91, 53, 65, 93, 80, 53, 71, 80, 80, 89, 70, 53, 65, 90, 53, 90, 69, 80, 91, 53, 65, 93, 80, 53, 84, 89, 87, 64, 88 }, 21), new Vector2(0.5f, 0.38f), new Vector2(940f, 70f), 34f, 30f, _0xecf6b76b.TextSoft, TextAlignmentOptions.Center);
    }

    private const float Cell = 190f;
    private void _0x806b9ca9(RectTransform _0x061d82eb, _0x42c1db03 _0xeab803e0)
    {
        _0x8a41f8c5 _0x4b552b58 = new _0x8a41f8c5()._0xad1caa14(_0x43ed7f14._0x71107a07);
        _0x2bfe8fd8.Caption(_0x061d82eb, _0x76eb2b5f._0xa4f16f03(new byte[12] { 51, 23, 13, 13, 23, 17, 16, 42, 23, 10, 18, 27 }, 126), _0xeab803e0._0xe4f31537, _0x76eb2b5f._0xa4f16f03(new byte[16] { 14, 24, 14, 14, 20, 18, 19, 125, 16, 20, 14, 14, 20, 18, 19, 14 }, 93), _0x2bfe8fd8.At(621f, 740f), new Vector2(1060f, 56f), 38f, 30f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Center);
        // Two columns that never share x-space. Gutter: 86 +/- 28. Text column starts at
        // 160 and is 760 wide, so its right edge is 920 and the card body is 1060 - the
        // check that matters is anchoredPosition.x - sizeDelta.x/2 >= 138 for every label.
        const float _0x6d28a398 = 760f;
        float _0xbe215ca4 = _0x2bfe8fd8.TextLeft + (_0x6d28a398 * 0.5f);
        float[] _0xcbfff4cd =
        {
            640f,
            520f,
            400f
        };
        for (int _0xe0181d0f = 0; _0xe0181d0f < _0x8a41f8c5.Active; _0xe0181d0f++)
        {
            bool _0xa3149da4 = _0x4b552b58 != null && _0x4b552b58._0x96100be9(_0xe0181d0f);
            RectTransform _0xac7eb641 = _0x2bfe8fd8.Row(_0x061d82eb, _0x76eb2b5f._0xa4f16f03(new byte[7] { 28, 56, 34, 34, 56, 62, 63 }, 81) + _0xe0181d0f, _0x2bfe8fd8.At(621f, _0xcbfff4cd[_0xe0181d0f]), new Vector2(RowW, RowH), _0xecf6b76b.Card, _0xa3149da4 ? _0xecf6b76b.Teal : _0xecf6b76b.Fade(_0xecf6b76b.Primary, 0.6f), _0xeab803e0._0x3fb723e6);
            // the pip column, alone in its gutter
            float _0xab215f2c = _0x4b552b58._0x033526df(_0xe0181d0f) <= 0 ? 1f : (float)_0x4b552b58._0xc489bb65(_0xe0181d0f) / _0x4b552b58._0x033526df(_0xe0181d0f);
            for (int _0xbe54cb16 = 0; _0xbe54cb16 < 3; _0xbe54cb16++)
            {
                bool _0x6c0b5048 = _0xab215f2c >= (_0xbe54cb16 + 1) / 3f;
                _0x2bfe8fd8.Plate(_0xac7eb641, _0x76eb2b5f._0xa4f16f03(new byte[3] { 100, 93, 68 }, 52) + _0xbe54cb16, new Vector2(0f, 0.5f), new Vector2(_0x2bfe8fd8.GutterWidth, 14f), _0x6c0b5048 ? _0xecf6b76b.Gold : _0xecf6b76b.Inactive, _0xeab803e0._0x3fb723e6).rectTransform.anchoredPosition = new Vector2(_0x2bfe8fd8.GutterCentre, 30f - (_0xbe54cb16 * 30f));
            }

            _0x2bfe8fd8.Caption(_0xac7eb641, _0x76eb2b5f._0xa4f16f03(new byte[11] { 231, 195, 217, 217, 195, 197, 196, 254, 207, 210, 222 }, 170) + _0xe0181d0f, _0xeab803e0._0xe4f31537, _0x4b552b58._0x6cd9fbe5(_0xe0181d0f), new Vector2(0f, 0.5f), new Vector2(_0x6d28a398, 52f), 38f, 30f, _0xa3149da4 ? _0xecf6b76b.TealLight : _0xecf6b76b.TextPrimary, TextAlignmentOptions.Left).rectTransform.anchoredPosition = new Vector2(_0xbe215ca4, 26f);
            _0x2bfe8fd8.Caption(_0xac7eb641, _0x76eb2b5f._0xa4f16f03(new byte[15] { 197, 225, 251, 251, 225, 231, 230, 216, 250, 231, 239, 250, 237, 251, 251 }, 136) + _0xe0181d0f, _0xeab803e0._0xe4f31537, _0xa3149da4 ? _0x76eb2b5f._0xa4f16f03(new byte[8] { 254, 242, 240, 237, 241, 248, 233, 248 }, 189) : _0x4b552b58._0xed03db4b(_0xe0181d0f), new Vector2(0f, 0.5f), new Vector2(_0x6d28a398, 46f), 34f, 30f, _0xa3149da4 ? _0xecf6b76b.TealLight : _0xecf6b76b.TextSoft, TextAlignmentOptions.Left).rectTransform.anchoredPosition = new Vector2(_0xbe215ca4, -26f);
        }
    }

    /// <summary>Lay the tab out inside the sheet body.</summary>
    public void _0xbc201cb2(_0x42c1db03 _0x3239732b, RectTransform _0xc40a09a3)
    {
        this._0x9dd6b5bf = _0x3239732b;
        this._0xe35373dd = _0xc40a09a3;
        if (_0x3239732b == null || _0xc40a09a3 == null)
            return;
        int _0xb616d14f = _0x43ed7f14._0xa18ae110;
        _0x2bfe8fd8.Caption(_0xc40a09a3, _0x76eb2b5f._0xa4f16f03(new byte[13] { 173, 128, 142, 153, 129, 191, 153, 142, 152, 133, 152, 128, 137 }, 236), _0x3239732b._0xe4f31537, _0x76eb2b5f._0xa4f16f03(new byte[7] { 190, 168, 172, 161, 168, 169, 205 }, 237) + _0xb616d14f + _0x76eb2b5f._0xa4f16f03(new byte[3] { 218, 213, 218 }, 250) + _0x43ed7f14.AlbumSlots, _0x2bfe8fd8.At(621f, 1640f), new Vector2(1060f, 60f), 44f, 34f, _0xecf6b76b.TextSecondary, TextAlignmentOptions.Center);
        if (_0xb616d14f <= 0)
            this._0xc2a5897b(_0xc40a09a3);
        else
            this._0x12450819(_0xc40a09a3, _0x3239732b);
        this._0x806b9ca9(_0xc40a09a3, _0x3239732b);
    }

    /// <summary>Redraw after a spin or a reset changed what is sealed.</summary>
    public void _0x988ef387()
    {
        if (this._0x9dd6b5bf == null || this._0xe35373dd == null)
            return;
        for (int _0x86498cd8 = this._0xe35373dd.childCount - 1; _0x86498cd8 >= 0; _0x86498cd8--)
            Destroy(this._0xe35373dd.GetChild(_0x86498cd8).gameObject);
        this._0xbc201cb2(this._0x9dd6b5bf, this._0xe35373dd);
    }

    private const int Columns = 3;
    private void _0x12450819(RectTransform _0xb6b1eec3, _0x42c1db03 _0x21b4cfe6)
    {
        float _0x71ad7e7a = (Columns * Cell) + ((Columns - 1) * Gap);
        float _0xe0ec4268 = (Rows * Cell) + ((Rows - 1) * Gap);
        float _0x5a78edf2 = 621f - (_0x71ad7e7a * 0.5f) + (Cell * 0.5f);
        float _0x12a6aa6c = GridY + (_0xe0ec4268 * 0.5f) - (Cell * 0.5f);
        Sprite[] _0xf7898ec8 = _0x21b4cfe6._0xd1a712e2;
        for (int _0x9bd69a9a = 0; _0x9bd69a9a < Columns * Rows; _0x9bd69a9a++)
        {
            int _0x5c8b2d33 = _0x9bd69a9a % Columns;
            int _0xb17fcaac = _0x9bd69a9a / Columns;
            float _0x4a663692 = _0x5a78edf2 + (_0x5c8b2d33 * (Cell + Gap));
            float _0x899ca220 = _0x12a6aa6c - (_0xb17fcaac * (Cell + Gap));
            bool _0x2aa7b54a = _0x43ed7f14.IsSealed(_0x9bd69a9a);
            RectTransform _0xdf71f759 = _0x2bfe8fd8.Node(_0xb6b1eec3, _0x76eb2b5f._0xa4f16f03(new byte[9] { 220, 241, 255, 232, 240, 206, 241, 242, 233 }, 157) + _0x9bd69a9a, _0x2bfe8fd8.At(_0x4a663692, _0x899ca220), new Vector2(Cell, Cell));
            Image _0xbbc8ec09 = _0xdf71f759.gameObject.AddComponent<Image>();
            _0xbbc8ec09.color = _0x2aa7b54a ? _0xecf6b76b.Surface2 : _0xecf6b76b.Fade(_0xecf6b76b.Surface3, 0.95f);
            _0xbbc8ec09.sprite = _0x21b4cfe6._0x3fb723e6;
            _0xbbc8ec09.type = Image.Type.Sliced;
            _0xbbc8ec09.pixelsPerUnitMultiplier = 2.6f;
            _0xbbc8ec09.raycastTarget = false;
            _0x2bfe8fd8.Rule(_0xdf71f759, _0x76eb2b5f._0xa4f16f03(new byte[8] { 85, 106, 105, 114, 67, 98, 97, 99 }, 6), new Vector2(0.5f, 0f), new Vector2(Cell - 28f, 5f), _0x2aa7b54a ? _0xecf6b76b.Gold : _0xecf6b76b.Inactive);
            if (_0x2aa7b54a && _0xf7898ec8 != null && _0xf7898ec8.Length > 0)
            {
                Sprite _0xc0c3f033 = _0xf7898ec8[_0x9bd69a9a % _0xf7898ec8.Length];
                _0x2bfe8fd8.Picture(_0xdf71f759, _0x76eb2b5f._0xa4f16f03(new byte[7] { 61, 2, 1, 26, 47, 28, 26 }, 110), _0xc0c3f033, new Vector2(0.5f, 0.56f), new Vector2(Cell - 70f, Cell - 70f), Color.white);
            }
            else
            {
                _0x2bfe8fd8.Caption(_0xdf71f759, _0x76eb2b5f._0xa4f16f03(new byte[10] { 45, 18, 17, 10, 50, 17, 29, 21, 27, 26 }, 126), _0x21b4cfe6._0xe4f31537, _0x76eb2b5f._0xa4f16f03(new byte[6] { 83, 80, 92, 84, 90, 91 }, 31), new Vector2(0.5f, 0.5f), new Vector2(Cell - 40f, 54f), 32f, 30f, _0xecf6b76b.TextMuted, TextAlignmentOptions.Center);
            }
        }
    }

    private const float GridY = 1200f;
    private const float Gap = 14f;
    private const float RowW = 1060f;
}

internal static class _0x76eb2b5f
{
    internal static string _0xa4f16f03(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}