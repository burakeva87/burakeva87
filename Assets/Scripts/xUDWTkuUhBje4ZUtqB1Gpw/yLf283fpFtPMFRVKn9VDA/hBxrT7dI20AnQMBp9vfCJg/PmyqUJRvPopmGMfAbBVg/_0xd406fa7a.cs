using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0xd406fa7a : MonoBehaviour
{
    public GameObject Content;
    public Ease ease = Ease.OutSine;
    public void Show()
    {
        this.Content.SetActive(true);
        if ((DOTween.TweensByTarget(this.Content.transform)?.Count ?? 0) > 0)
            DOTween.Kill(this.Content.transform, true);
        if (this.IsOnlyYScale)
            this.Content.transform.DOScaleY(1f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
            {
            });
        else
            this.Content.transform.DOScale(1f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
            {
            });
    }

    public TMP_Text ContentAdditionalText;
    public TMP_Text ContentHeaderText;
    public Image ContentImage;
    private void Awake()
    {
        this.Content.SetActive(true);
        if (this.IsScaledDownOnAwake)
            this._0x616f9d90();
    }

    public static void HideAllPops()
    {
        _0x74b7eccd.Instance._0xff4088b7();
    }

    private void _0x616f9d90()
    {
        DOTween.Kill(this.Content.transform, true);
        if (this.IsOnlyYScale)
            this.Content.transform.DOScaleY(0f, 0.01f);
        else
            this.Content.transform.DOScale(0f, 0.01f);
        this.Content.SetActive(false);
    }

    public TMP_Text ContentMainText;
    private void Start()
    {
    // Content.SetActive(false);
    }

    public float scaleDuration = 0.4f;
    private bool _0xccef6cd5 => this.Content.transform.localScale.x > 0.5f && this.Content.transform.localScale.y > 0.5f;

    public bool IsOnlyYScale;
    public bool IsScaledDownOnAwake = true;
    public void _0x93df3fe5()
    {
        if (this.Content.gameObject.activeSelf)
        {
            DOTween.Kill(this.Content.transform, true);
            if (this.IsOnlyYScale)
                this.Content.transform.DOScaleY(0f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
                {
                    this.Content.SetActive(false);
                });
            else
                this.Content.transform.DOScale(0f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
                {
                    this.Content.SetActive(false);
                });
        }
    }
}