using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0xe0baf11c : MonoBehaviour
{
    private void Update()
    {
        this._0x4a10d44c();
    }

    private void _0x4a10d44c()
    {
        if (this._0xb17b1360.canvasRenderer.GetColor() != this._0xa20c4d09.canvasRenderer.GetColor())
            this._0xa20c4d09.canvasRenderer.SetColor(this._0xb17b1360.canvasRenderer.GetColor());
    }

    private Image _0xb17b1360;
    private TMP_Text _0xa20c4d09;
}