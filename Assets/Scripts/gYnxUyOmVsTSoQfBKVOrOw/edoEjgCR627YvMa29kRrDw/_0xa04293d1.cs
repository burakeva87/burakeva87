using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class _0xa04293d1 : MonoBehaviour
{
    private void Update()
    {
        if (_0xe8756320[0] != this)
            return;
        if (Application.isMobilePlatform && Screen.orientation != _0x19505a80)
            OrientationChanged();
        if (Screen.safeArea != _0x26dfe9c5)
            SafeAreaChanged();
        if (Screen.width != _0x25e825bf.x || Screen.height != _0x25e825bf.y)
            ResolutionChanged();
    }

    private void OnDestroy()
    {
        if (_0xe8756320 != null && _0xe8756320.Contains(this))
            _0xe8756320.Remove(this);
    }

    private RectTransform _0xbbd67c50;
    private Canvas _0x4af5dfc3;
    private static void OrientationChanged()
    {
        _0x19505a80 = Screen.orientation;
        _0x25e825bf.x = Screen.width;
        _0x25e825bf.y = Screen.height;
        _0x034db68a.Invoke();
    }

    private RectTransform _0x5d6f291b;
    private static Rect _0x26dfe9c5 = Rect.zero;
    private static UnityEvent _0x034db68a = new();
    private static void ResolutionChanged()
    {
        _0x25e825bf.x = Screen.width;
        _0x25e825bf.y = Screen.height;
        _0x034db68a.Invoke();
    }

    private static Vector2 _0x25e825bf = Vector2.zero;
    private static ScreenOrientation _0x19505a80 = ScreenOrientation.LandscapeLeft;
    private void Awake()
    {
        if (!_0xe8756320.Contains(this))
            _0xe8756320.Add(this);
        this._0x4af5dfc3 = this.GetComponent<Canvas>();
        this._0xbbd67c50 = this.GetComponent<RectTransform>();
        this._0x5d6f291b = this.transform.Find(_0x3c54663f._0x065a6646(new byte[8] { 215, 229, 226, 225, 197, 246, 225, 229 }, 132)) as RectTransform;
        if (!_0x731b8465)
        {
            _0x19505a80 = Screen.orientation;
            _0x25e825bf.x = Screen.width;
            _0x25e825bf.y = Screen.height;
            _0x26dfe9c5 = Screen.safeArea;
            _0x731b8465 = true;
        }

        this._0x42fb9ba1();
    }

    private static void SafeAreaChanged()
    {
        _0x26dfe9c5 = Screen.safeArea;
        for (int _0xcfb97782 = 0; _0xcfb97782 < _0xe8756320.Count; _0xcfb97782++)
            _0xe8756320[_0xcfb97782]._0x42fb9ba1();
    }

    private void _0x42fb9ba1()
    {
        if (this._0x5d6f291b == null)
            return;
        Rect _0xe141e75e = Screen.safeArea;
        Vector2 _0x880065c5 = _0xe141e75e.position;
        Vector2 _0x13d64efb = _0xe141e75e.position + _0xe141e75e.size;
        _0x880065c5.x /= this._0x4af5dfc3.pixelRect.width;
        _0x880065c5.y /= this._0x4af5dfc3.pixelRect.height;
        _0x13d64efb.x /= this._0x4af5dfc3.pixelRect.width;
        _0x13d64efb.y /= this._0x4af5dfc3.pixelRect.height;
        this._0x5d6f291b.anchorMin = _0x880065c5;
        this._0x5d6f291b.anchorMax = _0x13d64efb;
    }

    private static readonly List<_0xa04293d1> _0xe8756320 = new();
    private static bool _0x731b8465;
}

internal static class _0x3c54663f
{
    internal static string _0x065a6646(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}