using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static _0x778394b0;

public class _0x74b7eccd : MonoBehaviour
{
    public void _0x8a33190b()
    {
        this.LastPopIndexes.RemoveAll(_0x5c94eb29 => _0x5c94eb29 == this.CurrentPopIndex);
        if (this.LastPopIndexes.Count <= 0)
            this._0xff4088b7();
        else
            this._0x3d0d66ed(this.LastPopIndexes.Last());
    }

    public void _0x3d0d66ed(int _0x5be60f68)
    {
        this.CurrentPopIndex = _0x5be60f68;
        this.LastPopIndexes.Add(this.CurrentPopIndex);
        this._0xf3531076(true);
        this._0x5061335c();
        this.Pops[_0x5be60f68].Show();
        foreach (GameObject _0x2845e0f8 in this.GameObjectsToHide)
            _0x2845e0f8.SetActive(false);
    }

    private void _0xf3531076(bool _0x5e4422af = false)
    {
        for (int _0x62fdfef9 = 0; _0x62fdfef9 < this.Pops.Count; ++_0x62fdfef9)
            if (this.Pops[_0x62fdfef9] != null && !(_0x62fdfef9 == this.CurrentPopIndex && _0x5e4422af))
                this.Pops[_0x62fdfef9]._0x93df3fe5();
    }

    public List<GameObject> GameObjectsToHide;
    private void _0x5061335c()
    {
        this.BlurBackground.gameObject.SetActive(true);
    }

    public _0xd406fa7a _0xd6ae9299(int _0x9080fe91)
    {
        return this.Pops[_0x9080fe91];
    }

    private void Start()
    {
        this.BackgroundHidden();
        foreach (_0xd406fa7a _0xba720b9d in this.Pops)
            if (_0xba720b9d != null)
                _0xba720b9d.gameObject.SetActive(true);
    }

    private void _0x9105c476()
    {
        this.Invoke(nameof(this.BackgroundHidden), this.ScaleDuration);
    }

    private void BackgroundHidden()
    {
        this.BlurBackground.gameObject.SetActive(false);
    }

    public void _0xff4088b7()
    {
        this.LastPopIndexes.Clear();
        this._0xf3531076();
        foreach (GameObject _0x0800b7d6 in this.GameObjectsToHide)
            if (_0x0800b7d6 != null)
                _0x0800b7d6.SetActive(true);
        this._0x9105c476();
    }

    public List<int> LastPopIndexes = new();
    public List<_0xd406fa7a> Pops;
    public GameObject BlurBackground;
    public static _0x74b7eccd Instance;
    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x74b7eccd>();
    }

    public int CurrentPopIndex;
    public float ScaleDuration = 0.4f;
}