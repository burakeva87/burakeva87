using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static _0x778394b0;

public class _0xd5e1760c : MonoBehaviour
{
    private void _0xb3209d8f()
    {
        this._0x0eaaac15(_0x147ecbe6.SPLASH);
        if (_0x764d1f95.Instance._0xcbbb701e == _0xb8e5a259.SCENE_0)
        {
        }
        else
        {
            this.Invoke(nameof(this.SwitchSplash), _0x53779211.Instance.DefaultAnimationTime);
        }
    }

    private void _0x43d8afe0(int _0x79eb4bb8)
    {
        this.LastPanelIndexes.Add(_0x79eb4bb8);
        this.CurrentPanelIndex = _0x79eb4bb8;
        for (int _0xaad00631 = 0; _0xaad00631 < this.Panels.Count; _0xaad00631++)
            if (_0xaad00631 != _0x79eb4bb8 && this.Panels[_0xaad00631] != null)
                this.Panels[_0xaad00631]._0x3b47647a();
    }

    public static _0xd5e1760c Instance;
    public bool IsShowSplashOnStart = true;
    private void SwitchSplash()
    {
        if (_0x4b23f399.Instance.IsTutorialEnabled && !_0x764d1f95._0x2606e40e._0x31ee9a9a)
            this._0x14f99188(_0x147ecbe6.TUTORIAL0);
        else
            this._0x14f99188(_0x147ecbe6.DEFAULT);
    }

    private void Start()
    {
        this._0xb3209d8f();
    }

    public void _0x14f99188(int _0x96a902bb)
    {
        this._0x7b85f639(_0x96a902bb);
        this._0xe1d7c729(_0x96a902bb);
        this.CurrentPanelIndex = _0x96a902bb;
        this.Panels[_0x96a902bb].Show();
    }

    public void _0x28e404a3()
    {
        this.LastPanelIndexes.RemoveAll(_0x5c94eb29 => _0x5c94eb29 == this.CurrentPanelIndex);
        int _0x521fd29f = this.LastPanelIndexes.Last();
        this._0xe1d7c729(_0x521fd29f);
        this._0x43d8afe0(_0x521fd29f);
        this.CurrentPanelIndex = _0x521fd29f;
        this.Panels[_0x521fd29f].Show();
    }

    private void _0x0eaaac15(int _0xaf94c582)
    {
        this._0x7b85f639(_0xaf94c582);
        this._0xe1d7c729(_0xaf94c582);
        this.CurrentPanelIndex = _0xaf94c582;
        this.Panels[_0xaf94c582]._0x6760f5c1();
    }

    private void _0xe1d7c729(int _0x6983d3ea)
    {
        if (_0x6983d3ea == _0x147ecbe6.SPLASH)
            _0x53779211.Instance._0xbdd7d0ab();
        if (_0x764d1f95.Instance._0xcbbb701e == _0xb8e5a259.SCENE_0)
        {
        }
    }

    public void _0x881640a0(int _0x15654a4d)
    {
        if (_0x15654a4d == _0x147ecbe6.SPLASH && _0x764d1f95.Instance._0xcbbb701e != _0xb8e5a259.SCENE_0)
            _0x53779211.Instance._0xfa4e44c0();
        if (_0x764d1f95.Instance._0xcbbb701e != _0xb8e5a259.SCENE_0)
        {
            if (_0x15654a4d == _0x147ecbe6.SPLASH || _0x15654a4d == _0x147ecbe6.TUTORIAL0)
                _0x764d1f95.Instance._0xe0dcc721(false);
            else if (_0x15654a4d == _0x147ecbe6.DEFAULT)
                _0x764d1f95.Instance._0xe0dcc721(true);
        }
    }

    public float StaticBlurMaterialInitialValue;
    private void _0x7b85f639(int _0xa4a90da9)
    {
        this.LastPanelIndexes.Add(_0xa4a90da9);
        this.CurrentPanelIndex = _0xa4a90da9;
        for (int _0x16473f2a = 0; _0x16473f2a < this.Panels.Count; _0x16473f2a++)
            if (_0x16473f2a != _0xa4a90da9 && this.Panels[_0x16473f2a] != null)
                this.Panels[_0x16473f2a]._0x3b47647a();
    }

    public float ScaleDuration = 0.4f;
    public List<_0xce3f3625> Panels;
    [HideInInspector]
    public List<int> LastPanelIndexes = new()
    {
        1
    };
    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0xd5e1760c>();
    }

    private _0xce3f3625 _0xc3942d5e(int _0x7202d046)
    {
        return this.Panels[_0x7202d046];
    }

    public int CurrentPanelIndex;
}