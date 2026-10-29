using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The stake control: five fixed steps, clamped at both ends, with a reason whenever a
/// step is refused.
///
/// A REFUSED STEP STILL ANSWERS (C.7). Raising the bet past the reserve does not just
/// do nothing - the readout shakes and an inline note says why. At the ends of the
/// ladder the button dims and goes non-interactable, so the limit is visible before it
/// is reached rather than discovered by tapping.
/// </summary>
public sealed class _0x1f01910a : MonoBehaviour
{
    private void _0x49c908a0(string _0xa9fd11cc)
    {
        if (this._0x44b06345 == null)
            return;
        this._0x44b06345.text = _0xa9fd11cc;
        _0xe91c2331.Apply(this._0x44b06345, _0xa9fd11cc.Length == 0 ? _0xecf6b76b.TextSoft : _0xecf6b76b.TealLight, 34f, 30f);
    }

    private Image _0x6269bf02;
    private TMP_Text _0x9e9bf85e;
    private Image _0xdf25b1d4;
    private Button _0x6d280f0e;
    /// <summary>Redraw the value and both end states.</summary>
    public void _0x48dc48e8()
    {
        int _0xa1774336 = _0x43ed7f14._0x99cdb961;
        int[] _0x47dbcb1a = _0x43ed7f14._0x6dee615f;
        if (this._0x9e9bf85e != null)
            this._0x9e9bf85e.text = _0x43ed7f14.Money(_0x47dbcb1a[_0xa1774336]);
        bool _0x209edb24 = _0xa1774336 > 0;
        bool _0x7e262b5b = _0xa1774336 < _0x47dbcb1a.Length - 1;
        if (this._0x5e5b19fb != null)
            this._0x5e5b19fb.interactable = _0x209edb24;
        if (this._0x6d280f0e != null)
            this._0x6d280f0e.interactable = _0x7e262b5b;
        if (this._0xdf25b1d4 != null)
            this._0xdf25b1d4.color = _0x209edb24 ? _0xecf6b76b.Surface2 : _0xecf6b76b.Inactive;
        if (this._0x6269bf02 != null)
            this._0x6269bf02.color = _0x7e262b5b ? _0xecf6b76b.Surface2 : _0xecf6b76b.Inactive;
    }

    /// <summary>Lay the stepper out, centred on <paramref name = "y"/> in canvas units.</summary>
    public void _0xf010ec6d(RectTransform _0x48dd2c51, TMP_FontAsset _0xe7726109, Sprite _0x3f2e57e0, float _0x90a3acf0)
    {
        if (_0x48dd2c51 == null)
            return;
        this._0x5e5b19fb = _0x2bfe8fd8.Cta(_0x48dd2c51, _0x79600eaf._0x8bc9b899(new byte[7] { 34, 5, 20, 36, 15, 23, 14 }, 96), _0xe7726109, _0x79600eaf._0x8bc9b899(new byte[1] { 158 }, 179), _0x2bfe8fd8.At(421f, _0x90a3acf0), new Vector2(ButtonSize, ButtonSize), _0xecf6b76b.Surface2, _0xecf6b76b.TextPrimary, 56f, 40f, _0x3f2e57e0);
        this._0xdf25b1d4 = this._0x5e5b19fb.targetGraphic as Image;
        this._0x5e5b19fb.onClick.AddListener(() => this._0xeb33f16a(-1));
        this._0x8144c4e1 = _0x2bfe8fd8.Node(_0x48dd2c51, _0x79600eaf._0x8bc9b899(new byte[10] { 21, 50, 35, 5, 50, 54, 51, 56, 34, 35 }, 87), _0x2bfe8fd8.At(621f, _0x90a3acf0), new Vector2(ReadoutW, ButtonSize));
        Image _0x33cf192d = this._0x8144c4e1.gameObject.AddComponent<Image>();
        _0x33cf192d.sprite = _0x3f2e57e0;
        _0x33cf192d.type = Image.Type.Sliced;
        _0x33cf192d.pixelsPerUnitMultiplier = 2.4f;
        _0x33cf192d.color = _0xecf6b76b.Fade(_0xecf6b76b.Surface3, 0.95f);
        _0x33cf192d.raycastTarget = false;
        this._0x9e9bf85e = _0x2bfe8fd8.Caption(this._0x8144c4e1, _0x79600eaf._0x8bc9b899(new byte[8] { 120, 95, 78, 108, 91, 86, 79, 95 }, 58), _0xe7726109, _0x79600eaf._0x8bc9b899(new byte[2] { 55, 50 }, 2), new Vector2(0.5f, 0.5f), new Vector2(ReadoutW - 30f, 64f), 52f, 38f, _0xecf6b76b.Gold, TextAlignmentOptions.Center);
        this._0x6d280f0e = _0x2bfe8fd8.Cta(_0x48dd2c51, _0x79600eaf._0x8bc9b899(new byte[5] { 92, 123, 106, 75, 110 }, 30), _0xe7726109, _0x79600eaf._0x8bc9b899(new byte[1] { 35 }, 8), _0x2bfe8fd8.At(821f, _0x90a3acf0), new Vector2(ButtonSize, ButtonSize), _0xecf6b76b.Surface2, _0xecf6b76b.TextPrimary, 56f, 40f, _0x3f2e57e0);
        this._0x6269bf02 = this._0x6d280f0e.targetGraphic as Image;
        this._0x6d280f0e.onClick.AddListener(() => this._0xeb33f16a(1));
        _0x2bfe8fd8.Caption(_0x48dd2c51, _0x79600eaf._0x8bc9b899(new byte[8] { 151, 176, 161, 153, 180, 183, 176, 185 }, 213), _0xe7726109, _0x79600eaf._0x8bc9b899(new byte[5] { 58, 61, 40, 34, 44 }, 105), _0x2bfe8fd8.At(621f, _0x90a3acf0 + 86f), new Vector2(400f, 46f), 34f, 30f, _0xecf6b76b.TextSoft, TextAlignmentOptions.Center);
        this._0x44b06345 = _0x2bfe8fd8.Caption(_0x48dd2c51, _0x79600eaf._0x8bc9b899(new byte[7] { 129, 166, 183, 141, 172, 183, 166 }, 195), _0xe7726109, string.Empty, _0x2bfe8fd8.At(621f, _0x90a3acf0 - 80f), new Vector2(760f, 48f), 34f, 30f, _0xecf6b76b.TealLight, TextAlignmentOptions.Center);
        this._0x48dc48e8();
    }

    private void _0xeb33f16a(int _0xaf5340c3)
    {
        if (this._director != null)
            this._director._0xe899325d();
        if (this._director != null && !this._director._0x2a02c4be)
        {
            this._0x49c908a0(_0x79600eaf._0x8bc9b899(new byte[27] { 121, 101, 104, 13, 127, 104, 104, 97, 126, 13, 108, 127, 104, 13, 126, 121, 100, 97, 97, 13, 127, 98, 97, 97, 100, 99, 106 }, 45));
            return;
        }

        int[] _0x0d3d8a38 = _0x43ed7f14._0x6dee615f;
        int _0x9ca1a6d2 = Mathf.Clamp(_0x43ed7f14._0x99cdb961 + _0xaf5340c3, 0, _0x0d3d8a38.Length - 1);
        int _0xbe8a184b = _0x0d3d8a38[_0x9ca1a6d2];
        if (_0xbe8a184b > _0x43ed7f14._0x0432624b)
        {
            this._0x49c908a0(_0x79600eaf._0x8bc9b899(new byte[16] { 210, 211, 200, 188, 217, 210, 211, 201, 219, 212, 188, 223, 211, 213, 210, 207 }, 156));
            if (this._0x8144c4e1 != null)
                this._0x8144c4e1.DOShakePosition(0.25f, 14f, 18, 70f).SetLink(this._0x8144c4e1.gameObject);
            return;
        }

        _0x43ed7f14._0x0c1a0cea = _0xbe8a184b;
        this._0x49c908a0(string.Empty);
        this._0x48dc48e8();
        if (this._director != null)
            this._director._0xd408d8ee();
        if (this._0x8144c4e1 != null)
            this._0x8144c4e1.DOPunchScale(Vector3.one * 0.08f, 0.22f, 6, 0.7f).SetLink(this._0x8144c4e1.gameObject);
    }

    private TMP_Text _0x44b06345;
    [SerializeField]
    private _0x96cf86d8 _director;
    private const float ReadoutW = 260f;
    private Button _0x5e5b19fb;
    private RectTransform _0x8144c4e1;
    private void OnDestroy()
    {
        DOTween.Kill(this);
    }

    private const float ButtonSize = 104f;
}

internal static class _0x79600eaf
{
    internal static string _0x8bc9b899(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}