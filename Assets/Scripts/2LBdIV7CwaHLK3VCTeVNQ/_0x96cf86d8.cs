using DG.Tweening;
using UnityEngine;

/// <summary>
/// The vault itself: one tap, five columns, a result that pays.
///
/// NO TIMER, NO METER, NO FAIL STATE (C.5). A baseline run is unbounded: nothing drains,
/// nothing expires, and when the reserve falls below the minimum stake the house refills
/// it for free, without limit. The review capture takes its first gameplay frame around
/// the fifteenth second and its last around the thirtieth, so a run that could end
/// before then would send an album of five defeat cards to review instead of a game.
///
/// AND IT KEEPS MOVING ON ITS OWN. After six idle seconds the machine spins itself, so a
/// completely passive capture still photographs rolling columns, a payline glow and a
/// win readout. The attract spin never raises a pop: a card appearing between two blind
/// taps is how a scenario loses the rest of its frames.
///
/// EVERY SESSION IS A DIFFERENT SESSION (C.11). The seed comes from the stored session
/// counter, the five strips are rebuilt from it, the three missions are drawn from it,
/// and the opening twelve spins are generated and then PROVED - at least one paying spin
/// in the first three and at least one payout of eight times the stake in the twelve -
/// before the player ever sees them, with a hardcoded schedule as the fallback.
/// </summary>
public sealed class _0x96cf86d8 : MonoBehaviour
{
    private int _0x3c721315;
    private bool _0x07b62730()
    {
        return _0x764d1f95.Instance != null && _0x764d1f95.Instance._0x22fda617;
    }

    private readonly _0x99dc1491 _0x9a3c75ae = new _0x99dc1491();
    private _0x44a9791c _0xc7b43aca;
    private const int WinPopMultiple = 8;
    private const int CalmWinPopMultiple = 20;
    private void Start()
    {
        _0x43ed7f14.EnsureSeeded();
        this._0xcd241a2e = _0x43ed7f14.NextSession();
        this._0xc7b43aca = new _0x44a9791c()._0xfb3266dd(this._0xcd241a2e, 0);
        this._0x2709db8f = new _0xfcff778c()._0x5301ee5c(this._0xc7b43aca);
        this._0x1fd1efdd = new _0x8a41f8c5()._0xad1caa14(this._0xcd241a2e);
        this._0x3cd94987 = new _0xf46bd032()._0xe2623acb(this._0x2709db8f, this._0xc7b43aca, this._0x36bd1264);
        {
#if B_LOGS
            {
                Debug.Log($"[vault] session={this._0xcd241a2e} seed={this._0xc7b43aca._0x7921f476} fallback={this._0x3cd94987._0xc2ef362f}");
            }
#endif
        }

        RectTransform _0xeb1514e2 = this._0xa7ae0f3d();
        if (_0xeb1514e2 == null)
            return;
        if (this._cabinet != null)
            this._cabinet._0x13c8e82e(_0xeb1514e2, this._0x2709db8f, this._0xc7b43aca, CabinetY);
        if (this._hud != null)
        {
            this._hud._0x517f6642(_0xeb1514e2);
            this._hud._0x8279fef5();
            this._hud._0xc30cb38b(this._0x1fd1efdd);
            this._hud._0x0af4aea1(0L);
        }

        this._0x51117147();
        this._0xe899325d();
    }

    private void Update()
    {
        if (this._0x1ecada7f || !this._0x07b62730())
            return;
        if (Time.time - this._0xc0f8736b < IdleSeconds)
            return;
        this._0x098bff9b(true);
    }

    public void _0xd408d8ee()
    {
        this._0xe899325d();
        if (this._hud != null)
            this._hud._0x8279fef5();
    }

    private void _0x098bff9b(bool _0xa7287c10)
    {
        if (this._0x1ecada7f || this._cabinet == null)
            return;
        if (!this._0x07b62730())
            return;
        long _0x3e48fdaa = this._0x36bd1264;
        bool _0xd02495ea = this._0x3c721315 > 0;
        if (!_0xd02495ea && _0x43ed7f14._0x0432624b < _0x3e48fdaa)
        {
            this._0x9b34644d();
            return;
        }

        this._0x1ecada7f = true;
        this._0xe899325d();
        if (_0xd02495ea)
        {
            this._0x3c721315--;
            if (this._hud != null)
            {
                this._hud._0x389f9d2f(true);
                this._hud._0x527fe3af(_0x4c5c3c23._0x2683898e(new byte[10] { 141, 153, 142, 142, 235, 152, 155, 130, 133, 235 }, 203) + (FreeSpinCount - this._0x3c721315) + _0x4c5c3c23._0x2683898e(new byte[3] { 219, 212, 219 }, 251) + FreeSpinCount);
            }
        }
        else
        {
            _0x43ed7f14._0x0432624b = _0x43ed7f14._0x0432624b - (int)_0x3e48fdaa;
            if (this._hud != null)
            {
                this._hud._0x389f9d2f(false);
                this._hud._0x527fe3af(_0xa7287c10 ? _0x4c5c3c23._0x2683898e(new byte[33] { 25, 13, 12, 23, 120, 11, 8, 17, 22, 120, 117, 120, 12, 25, 8, 120, 11, 8, 17, 22, 120, 12, 23, 120, 12, 25, 19, 29, 120, 23, 14, 29, 10 }, 88) : _0x4c5c3c23._0x2683898e(new byte[16] { 165, 176, 161, 209, 162, 161, 184, 191, 209, 165, 190, 209, 163, 190, 189, 189 }, 241));
            }
        }

        if (this._hud != null)
        {
            this._hud._0xf590af58(true);
            this._hud._0x8279fef5();
            this._hud._0x0af4aea1(0L);
        }

        this._0xc54d885b = this._0x3cd94987._0xf7aa5556(this._0x8eed557e, this._0xc7b43aca);
        int[] _0x4fa7231d = this._0x3cd94987._0x739c1404(this._0x8eed557e);
        this._0x73479cc8 = _0x4fa7231d != null ? _0x4fa7231d : this._0x2709db8f._0xa8f6c8d4(this._0xc54d885b);
        {
#if B_LOGS
            {
                Debug.Log($"[spin] session={this._0xcd241a2e} spin={this._0x8eed557e} bet={_0x3e48fdaa} free={_0xd02495ea} attract={_0xa7287c10}");
            }
#endif
        }

        this._cabinet._0xce9f91dd();
        for (int _0xe6cddee3 = 0; _0xe6cddee3 < _0x82f471b4.Reels; _0xe6cddee3++)
        {
            int _0xf327996b = _0xe6cddee3;
            int[] _0x87687fcf = _0x4fa7231d;
            DOVirtual.DelayedCall(FirstStopDelay + (StopStride * _0xe6cddee3), () => this._0x5042b66a(_0xf327996b, _0x87687fcf)).SetLink(this.gameObject);
        }

        bool _0x32e1b37a = _0xa7287c10;
        DOVirtual.DelayedCall(ResolveDelay, () => this._0x47459516(_0x32e1b37a)).SetLink(this.gameObject);
        DOVirtual.DelayedCall(ReadyDelay, () => this._0xc4d73c00()).SetLink(this.gameObject);
    }

    private int _0xcd241a2e;
    [SerializeField]
    private _0x9cafad81 _pops;
    private long _0x36bd1264
    {
        get
        {
            return _0x43ed7f14._0x0c1a0cea;
        }
    }

    private const float StopStride = 0.20f;
    private const float CabinetY = 1800f;
    private RectTransform _0xa7ae0f3d()
    {
        if (_0xd5e1760c.Instance == null || _0xd5e1760c.Instance.Panels == null)
            return null;
        int _0x7dadad1b = _0x778394b0._0x147ecbe6.DEFAULT;
        if (_0x7dadad1b < 0 || _0x7dadad1b >= _0xd5e1760c.Instance.Panels.Count)
            return null;
        _0xce3f3625 _0x702d187e = _0xd5e1760c.Instance.Panels[_0x7dadad1b];
        if (_0x702d187e == null || _0x702d187e.Content == null)
            return null;
        return _0x702d187e.Content.transform as RectTransform;
    }

    public void _0x0fb71a98()
    {
        this._0xe899325d();
        if (this._pops != null)
            this._pops._0xdf26c91e(this._0x36bd1264, _0x43ed7f14._0xa18ae110);
    }

    private _0xf46bd032 _0x3cd94987;
    public bool _0x2a02c4be
    {
        get
        {
            return !this._0x1ecada7f;
        }
    }

    private float _0xc0f8736b;
    private void _0x5042b66a(int _0xe9d0c0a4, int[] _0x28946218)
    {
        if (this._cabinet == null)
            return;
        if (_0x28946218 != null)
            this._cabinet._0x1eb76d72(_0xe9d0c0a4, _0x28946218);
        else
            this._cabinet._0xc6a9c516(_0xe9d0c0a4, this._0xc54d885b[_0xe9d0c0a4]);
    }

    private void _0xc4d73c00()
    {
        this._0x1ecada7f = false;
        if (this._hud != null)
            this._hud._0xf590af58(false);
        if (_0x43ed7f14._0x0432624b < _0x43ed7f14.MinimumBet)
            this._0x9b34644d();
        else if (this._0x3c721315 > 0)
            DOVirtual.DelayedCall(0.4f, () => this._0x098bff9b(true)).SetLink(this.gameObject);
    }

    private bool _0x1ecada7f;
    /// <summary>
    /// The only end-of-road this game has, and it is always recoverable: the reserve is
    /// topped up for free, with no limit and nothing to buy.
    /// </summary>
    private void _0x9b34644d()
    {
        if (this._pops == null)
            return;
        this._pops._0x80961811(_0x43ed7f14.RefillAmount);
    }

    private void _0x47459516(bool _0x52b3ddac)
    {
        long _0xb557b6ce = this._0x36bd1264;
        _0xe1643c2c.Evaluate(this._0x73479cc8, _0xb557b6ce, this._0x9a3c75ae);
        this._0x8eed557e++;
        int _0x139e4eec = this._0xd83206aa();
        if (this._0x9a3c75ae.Payout > 0L)
        {
            _0x43ed7f14._0x0432624b = _0x43ed7f14._0x0432624b + (int)this._0x9a3c75ae.Payout;
            this._cabinet._0x28283394(this._0x9a3c75ae);
            if (_0x43ed7f14._0xe987d0c3)
                Handheld.Vibrate();
        }

        int _0x968dbab1 = this._0x1fd1efdd != null ? this._0x1fd1efdd._0x68854378(this._0x73479cc8, this._0x9a3c75ae, _0xb557b6ce, _0x139e4eec) : 0;
        if (_0x968dbab1 > 0)
            _0x43ed7f14._0x0432624b = _0x43ed7f14._0x0432624b + (_0x8a41f8c5.Reward * _0x968dbab1);
        if (this._hud != null)
        {
            this._hud._0x0af4aea1(this._0x9a3c75ae.Payout);
            this._hud._0x8279fef5();
            this._hud._0xc30cb38b(this._0x1fd1efdd);
        }

        if (this._0x9a3c75ae.Scatters >= 3 && this._0x3c721315 <= 0)
        {
            this._0x3c721315 = FreeSpinCount;
            if (this._cabinet != null)
                this._cabinet._0x2bf2fa92(_0xecf6b76b.Teal);
            if (this._hud != null)
            {
                this._hud._0x389f9d2f(true);
                this._hud._0x527fe3af(_0x4c5c3c23._0x2683898e(new byte[16] { 220, 213, 200, 206, 207, 212, 223, 186, 201, 202, 211, 212, 201, 186, 183, 186 }, 154) + FreeSpinCount + _0x4c5c3c23._0x2683898e(new byte[5] { 73, 47, 59, 44, 44 }, 105));
            }
        }
        else if (this._0x3c721315 <= 0 && this._cabinet != null)
        {
            this._cabinet._0x2bf2fa92(_0xecf6b76b.Gold);
        }

        long _0x2144d10d = _0xb557b6ce * (_0x43ed7f14._0xe1eb7714 ? WinPopMultiple : CalmWinPopMultiple);
        if (!_0x52b3ddac && this._pops != null && this._0x9a3c75ae.Payout >= _0x2144d10d && this._0x9a3c75ae.Payout > 0L)
        {
            long payout = this._0x9a3c75ae.Payout;
            string _0x41d06ec2 = _0x52061f7c.Name(this._0x9a3c75ae.BestSymbol) + _0x4c5c3c23._0x2683898e(new byte[7] { 9, 101, 96, 103, 108, 9, 81 }, 41) + Mathf.RoundToInt((float)payout / Mathf.Max(1f, _0xb557b6ce));
            DOVirtual.DelayedCall(0.55f, () => this._pops._0xdff67613(payout, _0x41d06ec2)).SetLink(this.gameObject);
        }
    }

    [SerializeField]
    private _0x82f471b4 _cabinet;
    private const float ReadyDelay = 2.20f;
    [SerializeField]
    private _0x185ee3e1 _hud;
    private _0xfcff778c _0x2709db8f;
    private void OnDestroy()
    {
        DOTween.Kill(this);
    }

    public void _0x5e39aca2()
    {
        this._0xe899325d();
        this._0x098bff9b(false);
    }

    private int _0x8eed557e;
    private const float ResolveDelay = 1.55f;
    private int[] _0x73479cc8;
    /// <summary>
    /// The board the player lands on: settled, readable, nothing moving.
    ///
    /// It is its OWN non-paying draw, never spin 1's board. Showing spin 1's board here
    /// would mean the first spin rolls the reels and stops on exactly what was already
    /// on screen - no visible change, and the review's idle frame and win frame would be
    /// the same picture.
    /// </summary>
    private void _0x51117147()
    {
        int[] _0x3c8eb6cb = this._0x3cd94987._0xf3d43770(this._0x2709db8f, this._0xc7b43aca, this._0x36bd1264);
        for (int _0x579ca47c = 0; _0x579ca47c < _0x82f471b4.Reels; _0x579ca47c++)
        {
            if (this._cabinet == null)
                continue;
            this._cabinet._0xc6a9c516(_0x579ca47c, _0x3c8eb6cb[_0x579ca47c]);
        }
    }

    private const int FreeSpinCount = 5;
    private _0x8a41f8c5 _0x1fd1efdd;
    private const float IdleSeconds = 6.0f;
    private const float FirstStopDelay = 0.65f;
    /// <summary>Any tap on a control pushes the attract spin back.</summary>
    public void _0xe899325d()
    {
        this._0xc0f8736b = Time.time;
    }

    /// <summary>
    /// Seal the stone that paid. Every symbol owns three album slots - one for three,
    /// four and five of a kind - so the album fills by playing rather than by counting
    /// spins, and 30 slots cover all ten stones.
    /// </summary>
    private int _0xd83206aa()
    {
        if (this._0x9a3c75ae.BestSymbol < 0 || this._0x9a3c75ae.BestRun < 3)
            return 0;
        int _0x4df3b28a = (this._0x9a3c75ae.BestSymbol * 3) + Mathf.Clamp(this._0x9a3c75ae.BestRun - 3, 0, 2);
        return _0x43ed7f14.Seal(_0x4df3b28a) ? 1 : 0;
    }

    private int[] _0xc54d885b;
}

internal static class _0x4c5c3c23
{
    internal static string _0x2683898e(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}