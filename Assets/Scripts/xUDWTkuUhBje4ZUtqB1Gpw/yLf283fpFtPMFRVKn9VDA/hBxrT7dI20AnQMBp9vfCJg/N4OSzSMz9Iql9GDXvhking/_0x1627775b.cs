using UnityEngine;
using UnityEngine.UI;

public class _0x1627775b : MonoBehaviour
{
    private void Start()
    {
        if (this._0xb4f116c4)
            this._0x9d379078.onClick.AddListener(() => _0xd5e1760c.Instance._0x28e404a3());
        else
            this._0x9d379078.onClick.AddListener(() => _0xd5e1760c.Instance._0x14f99188(this._0x7441d641));
    }

    private bool _0xb4f116c4;
    private void Awake()
    {
        if (this._0x9d379078 == null)
            if (!this.TryGetComponent(out this._0x9d379078))
                this._0x9d379078 = this.GetComponentInChildren<Button>();
    }

    private Button _0x9d379078;
    private int _0x7441d641;
}