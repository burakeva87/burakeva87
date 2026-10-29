using TMPro;
using UnityEngine;
using static _0x778394b0;

public class _0x2731f174 : MonoBehaviour
{
    public void _0x9420056c()
    {
        this.MoneyCountText.text = _0x17f70ae0._0x7d96fa30.ToString();
    }

    public TMP_Text MoneyCountText;
    private void Start()
    {
        if (this.MoneyCountText == null)
        {
            TMP_Text _0x90dfcf84;
            if (this.gameObject.TryGetComponent(out _0x90dfcf84))
                this.MoneyCountText = _0x90dfcf84;
        }

        this._0x9420056c();
    }
}