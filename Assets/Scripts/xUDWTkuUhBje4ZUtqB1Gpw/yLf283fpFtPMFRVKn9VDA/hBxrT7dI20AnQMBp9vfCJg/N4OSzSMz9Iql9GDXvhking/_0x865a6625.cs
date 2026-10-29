using UnityEngine;
using UnityEngine.UI;

public class _0x865a6625 : MonoBehaviour
{
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    private void Start()
    {
        if (this.IsShowLastPop)
            this.Button.onClick.AddListener(() =>
            {
                _0x74b7eccd.Instance._0x8a33190b();
            });
        else if (this.IsHideAllPops)
            this.Button.onClick.AddListener(() => _0x74b7eccd.Instance._0xff4088b7());
        else
            this.Button.onClick.AddListener(() => _0x74b7eccd.Instance._0x3d0d66ed(this.PopToShowIndex));
    }

    public Button Button;
    public bool IsShowLastPop;
    public bool IsHideAllPops;
    public int PopToShowIndex;
}