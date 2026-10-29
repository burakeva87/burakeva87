using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class _0x6b13ac62 : MonoBehaviour
{
    private Touch? _0xd89203a8(Bounds _0x37a32806)
    {
        if (!_0x764d1f95.Instance._0x22fda617)
            return null;
        foreach (Touch _0x73a6cc27 in Touch.activeTouches)
            if (!_0x73a6cc27.ended)
            {
                Vector3 _0x732c2f86 = Camera.main.ScreenToWorldPoint(_0x73a6cc27.screenPosition);
                Vector3 _0x7dd0cffd = new(_0x732c2f86.x, _0x732c2f86.y, _0x37a32806.center.z);
                if (_0x37a32806.Contains(_0x7dd0cffd) && this._0xd931a474(_0x73a6cc27))
                    return _0x73a6cc27;
            }

        return null;
    }

    private Touch? _0xf8ca4261()
    {
        if (!_0x764d1f95.Instance._0x22fda617)
            return null;
        foreach (Touch _0xf39836a4 in Touch.activeTouches)
            if (!_0xf39836a4.ended)
                if (this._0xd931a474(_0xf39836a4))
                    return _0xf39836a4;
        return null;
    }

    private bool _0xd57c5c58(Touch? _0x01007c2c, Bounds _0x0b47b8fe, TouchPhase _0x9e5d4941)
    {
        if (!_0x764d1f95.Instance._0x22fda617)
        {
            _0x01007c2c = null;
            return false;
        }

        if (_0x01007c2c != null)
            if (_0x01007c2c.Value.phase == _0x9e5d4941)
            {
                Vector3 _0xe521dfb5 = Camera.main.ScreenToWorldPoint(_0x01007c2c.Value.screenPosition);
                Vector3 _0x735b8195 = new(_0xe521dfb5.x, _0xe521dfb5.y, _0x0b47b8fe.center.z);
                if (_0x0b47b8fe.Contains(_0x735b8195) && this._0xd931a474(_0x01007c2c.Value))
                    return true;
            }

        return false;
    }

    private void _0x5c9a42cf(Touch? _0xf4e110d0)
    {
        if (!_0x764d1f95.Instance._0x22fda617)
        {
            _0xf4e110d0 = null;
            return;
        }

        int _0x78eb3b8a = _0xf4e110d0.Value.touchId;
        _0xf4e110d0 = Touch.activeTouches.FirstOrDefault(_0xa992cdf1 => _0xa992cdf1.touchId == _0x78eb3b8a);
        if (!this._0xd931a474(_0xf4e110d0.Value))
            _0xf4e110d0 = null;
    }

    private Touch? _0x84f8b633(Bounds _0x337f8728)
    {
        if (!_0x764d1f95.Instance._0x22fda617)
            return null;
        foreach (Touch _0x4792fb76 in Touch.activeTouches)
            if (_0x4792fb76.ended)
            {
                Vector3 _0x8d31a65d = Camera.main.ScreenToWorldPoint(_0x4792fb76.screenPosition);
                Vector3 _0x76de9795 = new(_0x8d31a65d.x, _0x8d31a65d.y, _0x337f8728.center.z);
                if (_0x337f8728.Contains(_0x76de9795) && this._0xd931a474(_0x4792fb76))
                    return _0x4792fb76;
            }

        return null;
    }

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        _0x1def8fd4 = this.gameObject.GetComponent<_0x6b13ac62>();
    }

    private Touch? _0xf53abea7()
    {
        if (!_0x764d1f95.Instance._0x22fda617)
            return null;
        foreach (Touch _0x21405dbc in Touch.activeTouches)
            if (_0x21405dbc.ended)
                if (this._0xd931a474(_0x21405dbc))
                    return _0x21405dbc;
        return null;
    }

    private static _0x6b13ac62 _0x1def8fd4;
    public BoxCollider2D CameraTouchBounds;
    private bool _0xd931a474(Touch? _0x2eb3c4d0)
    {
        if (!_0x2eb3c4d0.HasValue)
            return false;
        Vector3 _0xdde9d7c3 = Camera.main.ScreenToWorldPoint(_0x2eb3c4d0.Value.screenPosition);
        Vector3 _0xd8a524cb = _0xdde9d7c3;
        _0xd8a524cb.z = this.CameraTouchBounds.transform.position.z;
        if (this.CameraTouchBounds.bounds.Contains(_0xd8a524cb))
            return true;
        _0x2eb3c4d0 = null;
        return false;
    }

    private Touch? _0xfa554091(Bounds _0xe0710739, TouchPhase _0xb7ef361b)
    {
        if (!_0x764d1f95.Instance._0x22fda617)
            return null;
        foreach (Touch _0x7f1c8f5a in Touch.activeTouches)
            if (_0x7f1c8f5a.phase == _0xb7ef361b)
            {
                Vector3 _0x1722bd99 = Camera.main.ScreenToWorldPoint(_0x7f1c8f5a.screenPosition);
                Vector3 _0x5c650215 = new(_0x1722bd99.x, _0x1722bd99.y, _0xe0710739.center.z);
                if (_0xe0710739.Contains(_0x5c650215) && this._0xd931a474(_0x7f1c8f5a))
                    return _0x7f1c8f5a;
            }

        return null;
    }
}