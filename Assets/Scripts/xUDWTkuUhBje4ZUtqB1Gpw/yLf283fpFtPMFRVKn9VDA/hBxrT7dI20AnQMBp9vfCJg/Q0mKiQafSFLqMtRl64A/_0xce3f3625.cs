using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0xce3f3625 : MonoBehaviour
{
    public Ease Ease = Ease.OutSine;
    private void _0x88712f82()
    {
        if (this.OuterBackground != null)
        {
            Image _0x7aacdcd7 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0x7aacdcd7, true);
            _0x7aacdcd7.DOFade(1f, this.ScaleDuration / 2f);
        }
    }

    private void _0x62117d46()
    {
        if (this.OuterBackground != null)
        {
            Image _0xda225010 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0xda225010, true);
            _0xda225010.DOFade(0f, this.ScaleDuration);
        }
    }

    public TMP_Text MainText;
    public void Show()
    {
        this._0x88712f82();
        if (this.Content != null)
        {
            DOTween.Kill(this.Content.transform, true);
            this.Content.SetActive(true);
            this.Content.transform.DOScale(1f, this.ScaleDuration).SetEase(this.Ease).OnComplete(() =>
            {
                _0xd5e1760c.Instance._0x881640a0(_0xd5e1760c.Instance.CurrentPanelIndex);
            });
        }
    }

    public bool IsScaledDownOnAwake = true;
    public void _0x3b47647a()
    {
        this._0x62117d46();
        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.DOScale(0f, this.ScaleDuration).SetEase(this.Ease).OnComplete(() =>
        {
            this.Content.SetActive(false);
        });
    }

    private void _0xb0fc71be()
    {
        if (this.OuterBackground != null)
        {
            Image _0x735b4a7f = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0x735b4a7f, true);
            _0x735b4a7f.DOFade(1f, 0f);
        }
    }

    private void _0x74494786()
    {
        if (this.OuterBackground != null)
        {
            Image _0xc4f55696 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0xc4f55696, true);
            _0xc4f55696.DOFade(0f, 0.01f);
        }

        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.DOScale(0f, 0.01f);
    }

    private void Awake()
    {
        this.Content.SetActive(true);
        if (this.OuterBackground != null)
            this.OuterBackground.gameObject.SetActive(true);
        if (this.IsScaledDownOnAwake)
            this._0x74494786();
    }

    public TMP_Text HeaderText;
    public void _0x6760f5c1()
    {
        this._0xb0fc71be();
        this.Content.SetActive(true);
        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.localScale = Vector3.one;
        _0xd5e1760c.Instance._0x881640a0(_0xd5e1760c.Instance.CurrentPanelIndex);
    }

    private bool _0x9e3aa598 => this.Content.transform.localScale.x > 0.5f && this.Content.transform.localScale.y > 0.5f;

    public GameObject Content;
    public GameObject OuterBackground;
    public float ScaleDuration = 0.4f;
}