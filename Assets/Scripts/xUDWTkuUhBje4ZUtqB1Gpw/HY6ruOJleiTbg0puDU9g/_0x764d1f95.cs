using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static _0x778394b0;

public class _0x764d1f95 : MonoBehaviour
{
    public static bool IsAfterLevelComplete;
    public Button DeleteProgressDataButton;
    public void _0xe67233a4()
    {
        this._0x3b3b6907(SceneManager.GetActiveScene().buildIndex);
    }

    private void _0x67652e17()
    {
        IsAfterLevelComplete = true;
        Instance._0x3b3b6907(_0xb8e5a259.SCENE_0);
    }

    public void _0xf0e847b3()
    {
        foreach (_0x2731f174 _0x17f4fc81 in this.MoneyCountContainers)
            _0x17f4fc81._0x9420056c();
    }

    private void _0x5a1a800b(Transform _0x83ee1b1d)
    {
        Transform[] _0xee73d92a = _0x83ee1b1d.GetComponentsInChildren<Transform>();
        foreach (Transform _0xee8ae401 in _0xee73d92a)
            if (_0xee8ae401 != null && DOTween.IsTweening(_0xee8ae401))
            {
                if (this._0x22fda617)
                    DOTween.Play(_0xee8ae401);
                else
                    DOTween.Pause(_0xee8ae401);
            }
    }

    public void _0x4c2c9632()
    {
        _0x2606e40e._0x31ee9a9a = true;
    }

    public Canvas MainCanvas;
    public void _0xe0dcc721(bool _0x00bdfc62)
    {
        this._0x22fda617 = _0x00bdfc62;
        this._0x0918d346(!this._0x22fda617);
        Physics2D.simulationMode = this._0x22fda617 ? SimulationMode2D.FixedUpdate : SimulationMode2D.Script;
        if (this.EnvironmentWithTweensToToggle != null)
            this._0x5a1a800b(this.EnvironmentWithTweensToToggle);
    }

    public bool _0x22fda617 { get; private set; }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x764d1f95>();
        this.RootGameObject = GameObject.FindWithTag(_0x982ca472._0x802581db(new byte[4] { 84, 105, 105, 114 }, 6));
        if (this._0xcbbb701e == _0xb8e5a259.SCENE_0)
            this._0xe0dcc721(true);
        else
            this._0xe0dcc721(false);
        this.MoneyCountContainers = this.RootGameObject.GetComponentsInChildren<_0x2731f174>(true).ToList();
    }

    public static bool IsAfterLevelFailed = false;
    public static _0xb76ba2c4 _0x2606e40e => _0xb76ba2c4.ALL_SCENES_SETTING_SINGLETONS[Instance._0xcbbb701e];
    private static _0xb76ba2c4 _0x280fe1b8 => _0xb76ba2c4.ALL_SCENES_SETTING_SINGLETONS[0];

    private static _0xb76ba2c4 GAME_INDEX_SETTINGS(int _0x560759e4)
    {
        return _0xb76ba2c4.ALL_SCENES_SETTING_SINGLETONS[_0x560759e4];
    }

    private static void MakeGrid(List<RectTransform> _0x33c170c4, AspectRatioFitter _0x9eaf0eb4, float _0x190df1c9, int _0x4a6839e3, int _0x9dc8b9a9)
    {
        _0x9eaf0eb4.aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
        _0x9eaf0eb4.aspectRatio = _0x190df1c9;
        foreach (RectTransform _0xe28065ed in _0x33c170c4)
        {
            int _0x55e063cb = _0xe28065ed.transform.GetSiblingIndex();
            _0xe28065ed.anchorMin = new Vector3(Mathf.FloorToInt((float)_0x55e063cb % _0x4a6839e3) * (1f / _0x4a6839e3), (_0x9dc8b9a9 - (Mathf.FloorToInt((float)_0x55e063cb / _0x4a6839e3) % _0x9dc8b9a9 + 1f)) * (1f / _0x9dc8b9a9));
            _0xe28065ed.anchorMax = new Vector3(Mathf.FloorToInt((float)_0x55e063cb % _0x4a6839e3 + 1f) * (1f / _0x4a6839e3), (_0x9dc8b9a9 - Mathf.FloorToInt((float)_0x55e063cb / _0x4a6839e3) % _0x9dc8b9a9) * (1f / _0x9dc8b9a9));
            _0xe28065ed.offsetMin = Vector2.zero;
            _0xe28065ed.offsetMax = Vector2.zero;
        }
    }

    public void _0x3b3b6907(int _0xd2b03dce)
    {
        //if (SceneManager.GetActiveScene().buildIndex == sceneIndex)
        //    AdsInitializer.Instance?.ShowAd();
        this.StartCoroutine(this._0x3367ec84(_0xd2b03dce));
    }

    private static void ExitGame()
    {
        Application.Quit();
    }

    public Transform Environment;
    private IEnumerator _0xd9f7115f(string _0x602e3c92)
    {
        _0xd5e1760c.Instance._0x14f99188(_0x147ecbe6.SPLASH);
        //AudioController.Instance.SaveLastMusicTimes();
        AsyncOperation _0xb909e138 = SceneManager.LoadSceneAsync(_0x602e3c92);
        while (!_0xb909e138.isDone)
            yield return null;
    }

    private void _0x0918d346(bool _0xace23f9f)
    {
        Rigidbody2D[] _0x86abdcd5 = this.RootGameObject.GetComponentsInChildren<Rigidbody2D>(true);
        foreach (Rigidbody2D _0x21742f7e in _0x86abdcd5)
            if (_0xace23f9f)
                _0x21742f7e.constraints = RigidbodyConstraints2D.FreezeAll;
            else
                _0x21742f7e.constraints = RigidbodyConstraints2D.None;
    }

    private IEnumerator _0x3367ec84(int _0x78764306)
    {
        _0xd5e1760c.Instance._0x14f99188(_0x147ecbe6.SPLASH);
        AsyncOperation _0x764e6942 = SceneManager.LoadSceneAsync(_0x78764306);
        while (!_0x764e6942.isDone)
            yield return null;
    }

    public Button ShowResetTutorialButton;
    public int _0xcbbb701e => SceneManager.GetActiveScene().buildIndex;

    public Transform EnvironmentWithTweensToToggle;
    private void Start()
    {
        if (this._0xcbbb701e != _0xb8e5a259.SCENE_0)
            Screen.orientation = ScreenOrientation.Portrait;
        this.DeleteProgressDataButton?.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteAll();
            //AudioController.Instance.UpdateMusics();
            //AudioController.Instance.UpdateSfxes();
            Instance._0x3b3b6907(_0xb8e5a259.SCENE_0);
        });
        this.ShowResetTutorialButton?.onClick.AddListener(() =>
        {
            _0x2606e40e._0x31ee9a9a = false;
            _0x74b7eccd.Instance._0xff4088b7();
            _0xd5e1760c.Instance._0x14f99188(_0x147ecbe6.TUTORIAL0);
        });
    }

    [HideInInspector]
    public List<_0x2731f174> MoneyCountContainers = new();
    [HideInInspector]
    public GameObject RootGameObject; // tag - "Root"
    public static _0x764d1f95 Instance;
}

internal static class _0x982ca472
{
    internal static string _0x802581db(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}