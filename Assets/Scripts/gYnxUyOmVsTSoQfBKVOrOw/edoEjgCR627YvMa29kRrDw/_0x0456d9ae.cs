using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class _0x0456d9ae : MonoBehaviour
{
    private static void ApplySafeAreaToAll()
    {
        for (int _0x5ac4be60 = 0; _0x5ac4be60 < _0x2eec6ae5.Count; _0x5ac4be60++)
            _0x2eec6ae5[_0x5ac4be60]._0x414ac849();
    }

    private void Start()
    {
    }

    private static void OrientationChanged()
    {
        _0x2c3bf021 = Screen.orientation;
        _0xb849e6e4.x = Screen.width;
        _0xb849e6e4.y = Screen.height;
        _0x34611d10 = Screen.safeArea;
        ApplySafeAreaToAll();
        _0x37a60952.Invoke();
    }

    private RectTransform _0x7ac09903;
    private Vector2 _0xeb73af12;
    private RectTransform _0x0b84d59b;
    private void Awake()
    {
        if (!_0x2eec6ae5.Contains(this))
            _0x2eec6ae5.Add(this);
        this._0xc357ea3e = this.GetComponent<Canvas>();
        this._0x4c9062e9 = this.GetComponent<CanvasScaler>();
        if (this._0x4c9062e9 != null)
            this._0xeb73af12 = this._0x4c9062e9.referenceResolution;
        this._0x7ac09903 = this.GetComponent<RectTransform>();
        this._0x0b84d59b = this.transform.Find(_0xa7e3441b._0xfd64238c(new byte[8] { 105, 91, 92, 95, 123, 72, 95, 91 }, 58)) as RectTransform;
        if (!_0x6a554cbc)
        {
            _0x2c3bf021 = Screen.orientation;
            _0xb849e6e4.x = Screen.width;
            _0xb849e6e4.y = Screen.height;
            _0x34611d10 = Screen.safeArea;
            _0x6a554cbc = true;
        }

        this._0x414ac849();
    }

    private CanvasScaler _0x4c9062e9;
    private void OnDestroy()
    {
        if (_0x2eec6ae5 != null && _0x2eec6ae5.Contains(this))
            _0x2eec6ae5.Remove(this);
    }

    private static readonly List<_0x0456d9ae> _0x2eec6ae5 = new();
    private static Rect _0x34611d10 = Rect.zero;
    private static void ResolutionChanged()
    {
        _0xb849e6e4.x = Screen.width;
        _0xb849e6e4.y = Screen.height;
        _0x34611d10 = Screen.safeArea;
        ApplySafeAreaToAll();
        _0x37a60952.Invoke();
    }

    private static void SafeAreaChanged()
    {
        _0x34611d10 = Screen.safeArea;
        ApplySafeAreaToAll();
    }

    private static Vector2 _0xb849e6e4 = Vector2.zero;
    private void _0x414ac849()
    {
        if (this._0x0b84d59b == null)
            return;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        if (screenWidth <= 0f || screenHeight <= 0f)
            return;
        Rect _0xa89c9002 = Screen.safeArea;
        Vector2 _0x2bbe3f8d = _0xa89c9002.position;
        Vector2 _0x4c4ce35c = _0xa89c9002.position + _0xa89c9002.size;
        _0x2bbe3f8d.x /= screenWidth;
        _0x2bbe3f8d.y /= screenHeight;
        _0x4c4ce35c.x /= screenWidth;
        _0x4c4ce35c.y /= screenHeight;
        this._0x0b84d59b.anchorMin = _0x2bbe3f8d;
        this._0x0b84d59b.anchorMax = _0x4c4ce35c;
        this._0x0b84d59b.offsetMin = Vector2.zero;
        this._0x0b84d59b.offsetMax = Vector2.zero;
        if (this._0x4c9062e9 == null)
            return;
        Vector2 _0x75444e09 = _0x4c4ce35c - _0x2bbe3f8d;
        float _0xa3ad8299 = 2f - _0x75444e09.x;
        float _0xeb65e316 = 2f - _0x75444e09.y;
        this._0x4c9062e9.referenceResolution = this._0xeb73af12 * new Vector2(_0xa3ad8299, _0xeb65e316);
    }

    private static bool _0x6a554cbc;
    private static ScreenOrientation _0x2c3bf021 = ScreenOrientation.LandscapeLeft;
    private void Update()
    {
        if (_0x2eec6ae5.Count == 0 || _0x2eec6ae5[0] != this)
            return;
        if (Application.isMobilePlatform && Screen.orientation != _0x2c3bf021)
            OrientationChanged();
        if (Screen.safeArea != _0x34611d10)
            SafeAreaChanged();
        if (Screen.width != _0xb849e6e4.x || Screen.height != _0xb849e6e4.y)
            ResolutionChanged();
    }

    private Canvas _0xc357ea3e;
    private static UnityEvent _0x37a60952 = new();
}

internal static class _0xa7e3441b
{
    internal static string _0xfd64238c(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}