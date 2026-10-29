using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0x1c663eb9 : MonoBehaviour
{
    private IEnumerator _0xca19ee0a()
    {
        this._0x190ffae3();
        while (!this.IsGameEnd && this.TimeLeft > 0 && _0x764d1f95.Instance._0xcbbb701e == this.CurrentGameIndex)
        {
            yield return new WaitForSeconds(1f);
            if (_0x764d1f95.Instance._0x22fda617)
            {
                if (this.IsGameEnd)
                    break;
                this.TimeLeft--;
                this._0x190ffae3();
            }
        }

        if (!this.IsGameEnd)
            this._0x5c6dac73();
    }

    public void _0xf349f167()
    {
        _0x764d1f95.Instance._0xe0dcc721(true);
        _0x764d1f95.Instance._0x3b3b6907(_0x778394b0._0xb8e5a259.SCENE_0);
    }

    public List<Button> PauseButtons = new();
    private void _0xe6103f25()
    {
        if (_0x4b23f399.Instance.IsCheckScoreEnabled)
            this.ScoreText.ForEach(_0x72c7577f => _0x72c7577f.text = $"{this.ScoreCurrent}/{this._0x690336c6}");
        else
            this.ScoreText.ForEach(_0x72c7577f => _0x72c7577f.text = $"{this.ScoreCurrent}");
    }

    public void _0xee502e7c()
    {
        if (!this.IsGameEnd)
        {
            this._0x1590ef9d();
            _0x764d1f95.IsAfterLevelComplete = true;
            _0x764d1f95.IsAfterLevelFailed = false;
            _0xd406fa7a _0xdc3a3704 = _0x74b7eccd.Instance._0xd6ae9299(_0x778394b0._0xb75f6257.WIN).GetComponent<_0xd406fa7a>();
            if (_0x4b23f399.Instance.IsCheckScoreEnabled)
                _0xdc3a3704.ContentMainText.text = $"{this.ScoreCurrent}/{this._0x690336c6}";
            else
                _0xdc3a3704.ContentMainText.text = $"{this.ScoreCurrent}";
            if (_0x4b23f399.Instance.IsBestScoreEnabled)
            {
                if (this.ScoreCurrent > _0x778394b0._0x17f70ae0._0x7d96fa30)
                    _0x778394b0._0x17f70ae0._0x7d96fa30 = this.ScoreCurrent;
                _0xdc3a3704.ContentAdditionalText.text = $"{_0x778394b0._0x17f70ae0._0x7d96fa30}";
            }
            else
            {
                _0xdc3a3704.ContentAdditionalText.text = $"{this._0xaf4b4365}";
                _0x778394b0._0x17f70ae0._0x7d96fa30 += this._0xaf4b4365;
            }

            if (_0x4b23f399.Instance.IsLevelIncrementOnWin)
                ++_0x764d1f95._0x2606e40e._0xea5c058b;
            _0x74b7eccd.Instance._0x3d0d66ed(_0x778394b0._0xb75f6257.WIN);
        }
    }

    private void _0x190ffae3()
    {
        this.TimerText.ForEach(_0x72c7577f => _0x72c7577f.text = TimeSpan.FromSeconds(this.TimeLeft).ToString(_0x7d13e86d._0xa7ecfc65(new byte[6] { 34, 34, 19, 117, 60, 60 }, 79)));
    }

    public void _0x5c6dac73()
    {
        if (_0x4b23f399.Instance.IsOnlyWinGameEndEnabled)
            this._0xee502e7c();
        if (!this.IsGameEnd)
        {
            this._0x1590ef9d();
            _0x764d1f95.IsAfterLevelComplete = false;
            _0x764d1f95.IsAfterLevelFailed = true;
            _0xd406fa7a _0x2603a90b = _0x74b7eccd.Instance._0xd6ae9299(_0x778394b0._0xb75f6257.LOSE).GetComponent<_0xd406fa7a>();
            if (_0x4b23f399.Instance.IsCheckScoreEnabled)
                _0x2603a90b.ContentMainText.text = $"{this.ScoreCurrent}/{this._0x690336c6}";
            else
                _0x2603a90b.ContentMainText.text = $"{this.ScoreCurrent}";
            _0x2603a90b.ContentAdditionalText.text = $"{0}";
            _0x778394b0._0x17f70ae0._0x7d96fa30 += 0;
            _0x74b7eccd.Instance._0x3d0d66ed(_0x778394b0._0xb75f6257.LOSE);
        }
    }

    [HideInInspector]
    public int TimeLeft;
    public void _0x979aaeee(int scoreToAdd)
    {
        if (!this.IsGameEnd)
        {
            this.ScoreCurrent += scoreToAdd;
            this._0xe6103f25();
            this._0xa9d3f736();
        }
    }

    public List<TMP_Text> ScoreText = new();
    private int _0x690336c6 => this.CustomTargetScore + _0x764d1f95._0x2606e40e._0xea5c058b * 10;

    public List<Button> HomeButtons = new();
    private void _0xa9d3f736()
    {
        if (this.ScoreCurrent > _0x764d1f95._0x2606e40e._0x8de9c9bc)
            _0x764d1f95._0x2606e40e._0x8de9c9bc = this.ScoreCurrent;
        if (_0x4b23f399.Instance.IsCheckScoreEnabled)
            if (this.ScoreCurrent >= this._0x690336c6)
                this._0xee502e7c();
    }

    [HideInInspector]
    public int ScoreCurrent;
    private int _0xaf4b4365 => this.ScoreCurrent;

    public List<TMP_Text> LevelNumberText = new();
    private void Awake()
    {
        _0xcdeda723 = this.gameObject.GetComponent<_0x1c663eb9>();
    }

    private int _0xb4af37d1 => this.CustomTimeInitial + _0x764d1f95._0x2606e40e._0xea5c058b * 10;

    [HideInInspector]
    public bool IsGameEnd;
    public int CustomTargetScore = 10;
    public List<TMP_Text> TimerText = new();
    private void _0xaa8cbf5e()
    {
        if (this.ScoreCurrent >= this._0x690336c6)
            this._0xee502e7c();
        else
            this._0x5c6dac73();
    }

    public List<TMP_Text> SubtitleText = new();
    public int CustomTimeInitial = 30;
    [HideInInspector]
    public int CurrentGameIndex;
    private static _0x1c663eb9 _0xcdeda723;
    private void Start()
    {
        this.IsGameEnd = false;
        this.TimeLeft = this._0xb4af37d1;
        this.CurrentGameIndex = _0x764d1f95.Instance._0xcbbb701e;
        foreach (Button _0xa00cac21 in this.HomeButtons)
            _0xa00cac21.onClick.AddListener(() =>
            {
                this._0xf349f167();
            });
        foreach (Button _0x80a625e9 in this.PauseButtons)
            _0x80a625e9.onClick.AddListener(() =>
            {
                _0x764d1f95.Instance._0xe0dcc721(false);
                _0x74b7eccd.Instance._0x3d0d66ed(_0x778394b0._0xb75f6257.PAUSE);
            });
        this._0xe6103f25();
        this.LevelNumberText.ForEach(_0x72c7577f => _0x72c7577f.text = $"LVL {_0x764d1f95._0x2606e40e._0xea5c058b + 1}");
        if (_0x4b23f399.Instance.IsTimerEnabled)
        {
            this._0x190ffae3();
            this.StartCoroutine(this._0xca19ee0a());
        }
    }

    private void _0x1590ef9d()
    {
        this.IsGameEnd = true;
        _0x764d1f95.IsAfterLevelComplete = true;
    }
}

internal static class _0x7d13e86d
{
    internal static string _0xa7ecfc65(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}