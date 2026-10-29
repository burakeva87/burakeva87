using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class _0xc7dd557f : MonoBehaviour
{
    private float _0x3a906d3e;
    private List<string> _0x24691623 = new();
    private void Update()
    {
        int _0x4ce9d3fc = 1;
        if (this._0x24691623.Count > 0)
        {
            string _0xc49c699d = this._0xc6bd63f9.text;
            foreach (string _0xe894a676 in this._0x24691623)
                while (_0xc49c699d.Contains(_0xe894a676))
                    _0xc49c699d = _0xc49c699d.Replace(_0xe894a676, "");
            _0x4ce9d3fc = _0xc49c699d.Length;
        }
        else
        {
            _0x4ce9d3fc = this._0xc6bd63f9.text.Length;
        }

        float _0x63cbd4e1 = Mathf.Clamp(this._0x3a906d3e + this._0x4913a79b * _0x4ce9d3fc, this._0xec0bc999, this._0xe8e44491);
        if (!Mathf.Approximately(this._0x230880f4.aspectRatio, _0x63cbd4e1))
            this._0x230880f4.aspectRatio = _0x63cbd4e1;
    }

    private float _0x4913a79b = 0.6f;
    private float _0xec0bc999 = 1.5f;
    private AspectRatioFitter _0x230880f4;
    private float _0xe8e44491 = 4;
    private TMP_Text _0xc6bd63f9;
}