using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _0x53779211 : MonoBehaviour
{
    public void _0xce8f3a25()
    {
        this._0xe366e7e5?.Pause();
    }

    public void _0xbdd7d0ab()
    {
        this._0xe366e7e5?.Kill();
        this.AnimationSlider.value = _0xb2310962 ? this.SecondPassSliderValue : 0.05f;
    }

    public float FirstAnimationTime = 10.0f;
    public float SecondPassSliderValue = 0.5f;
    public GameObject Background;
    public Slider AnimationSlider;
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == _0x778394b0._0xb8e5a259.SCENE_0 && !_0xb2310962)
        {
            this._0x2dae5deb();
        }
        else
        {
            this._0xfa4e44c0();
        }
    }

    public void _0x4df4c6bb()
    {
        this._0xe366e7e5?.Play();
    }

    public void _0xfa4e44c0()
    {
        this._0xbdd7d0ab();
        bool _0xc60aa55a = _0xb2310962;
        this._0xe366e7e5 = DOTween.Sequence().Append(DOTween.To(() => this.AnimationSlider.value, _0x7a457d1f => this.AnimationSlider.value = _0x7a457d1f, _0xc60aa55a ? 1f : this.SecondPassSliderValue, this.DefaultAnimationTime)).SetEase(Ease.Linear);
        _0xb2310962 = !_0xb2310962;
    }

    public float DefaultAnimationTime = 0.4f;
    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x53779211>();
    }

    private void _0x2dae5deb()
    {
        this.AnimationSlider.value = 0.05f;
        _0xb2310962 = !_0xb2310962;
        this._0xe366e7e5 = DOTween.Sequence().Append(DOTween.To(() => this.AnimationSlider.value, _0x7a457d1f => this.AnimationSlider.value = _0x7a457d1f, 1f, this.FirstAnimationTime)).SetEase(Ease.Linear).OnComplete(() =>
        {
            _0x1ef2fa0a._0x479f85c3?._0x526bd6c6();
        });
    }

    public GameObject Content;
    public GameObject Error;
    private static bool _0xb2310962 = false;
    public void _0x014cc000()
    {
        {
#if B_LOGS
            {
                Debug.Log($"[Test] Animate Force");
            }
#endif
        }

        this._0xe366e7e5?.Kill();
        if (AnimationSlider != null)
            this.AnimationSlider.value = 1f;
        _0xb2310962 = false;
    }

    public static _0x53779211 Instance;
    private Sequence _0xe366e7e5;
}