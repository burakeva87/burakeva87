using System.Collections.Generic;
using TMPro;
using UnityEngine;

// TmpContrastGuard.cs — staged into every Unity app by approve-pipeline-unity.sh
// (stage 5c3, rule C.14 in CLAUDE-unity.md). Do not edit the copy inside a project;
// edit scripts/lib/unity/TmpContrastGuard.cs.
//
// WHY: every TMP label gets an outline (C.10), and by default that outline is dark.
// A dark face colour on a dark outline merges into a smudge — the label is not
// readable on any backing (ANDROID-3627: PLAY drawn Deep #12151E on the #12151E
// outline read as a black blob). enforce-text-contrast.sh fixes colours SERIALISED
// in scenes/prefabs, but labels built at runtime from C# (UiKit.Cta, VaultUi.Caption,
// label.color = Palette.X ...) never reach a scene file, so that pass cannot see them.
//
// WHAT: after any TMP text is regenerated, compare its face colour with the outline
// colour of the material it actually renders with. Below WCAG 4.5:1 the face is
// blended toward white (dark outline) or black (light outline) until it reaches 7:1.
// Hue is kept; alpha is kept. A label whose outline was deliberately switched to a
// light colour (TextReadability-style per-label material) is measured against THAT
// outline, so intentionally dark text on a light rim is left alone. Labels without
// an outline are left alone too.
public sealed class _0x0e35f840 : MonoBehaviour
{
    private const float TargetRatio = 7f;
    private static float Linear(float _0xe9ed2483)
    {
        _0xe9ed2483 = Mathf.Clamp01(_0xe9ed2483);
        return _0xe9ed2483 <= 0.03928f ? _0xe9ed2483 / 12.92f : Mathf.Pow((_0xe9ed2483 + 0.055f) / 1.055f, 2.4f);
    }

    private void OnEnable()
    {
        if (this._0x0525efb0 == null)
            this._0x0525efb0 = _0x2b258f55 => this._0xa59fd512(_0x2b258f55);
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(this._0x0525efb0);
    }

    // The event fires from inside the canvas rebuild. Changing the colour right there
    // would re-dirty the graphic mid-rebuild, which Unity rejects — so queue it and
    // apply in LateUpdate, which runs before the next frame's rebuild.
    private void _0xa59fd512(Object _0xc5178b83)
    {
        TMP_Text _0x1433606b = _0xc5178b83 as TMP_Text;
        if (_0x1433606b != null)
            this._0x7c0f7d68.Add(_0x1433606b);
    }

    private static _0x0e35f840 _0x92dd08a3;
    // A lambda held in a field, never the bare method group: Plana renames the method
    // declaration but not a method-group reference (verify-unity-buttons.sh, CS0103).
    // The field keeps Add and Remove on the same delegate instance.
    private System.Action<Object> _0x0525efb0;
    private readonly List<TMP_Text> _0x261895d4 = new List<TMP_Text>();
    private const float MinOutlineWidth = 0.01f;
    private void LateUpdate()
    {
        if (this._0x7c0f7d68.Count == 0)
            return;
        this._0x261895d4.Clear();
        this._0x261895d4.AddRange(this._0x7c0f7d68);
        this._0x7c0f7d68.Clear();
        for (int _0xdbc5a54a = 0; _0xdbc5a54a < this._0x261895d4.Count; _0xdbc5a54a++)
            Fix(this._0x261895d4[_0xdbc5a54a]);
    }

    private const float MinRatio = 4.5f;
    // WCAG relative luminance of an sRGB colour, and the contrast ratio of two.
    private static float Luminance(Color _0x0756cf84)
    {
        return 0.2126f * Linear(_0x0756cf84.r) + 0.7152f * Linear(_0x0756cf84.g) + 0.0722f * Linear(_0x0756cf84.b);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Boot()
    {
        if (_0x92dd08a3 != null)
            return;
        GameObject _0x0ae47c82 = new GameObject(_0xc3e64911._0x5a470eb8(new byte[16] { 47, 22, 11, 56, 20, 21, 15, 9, 26, 8, 15, 60, 14, 26, 9, 31 }, 123));
        _0x0ae47c82.hideFlags = HideFlags.HideInHierarchy;
        DontDestroyOnLoad(_0x0ae47c82);
        _0x92dd08a3 = _0x0ae47c82.AddComponent<_0x0e35f840>();
    }

    private static float Ratio(Color _0x3d772d38, Color _0x448f4df9)
    {
        float _0x1140e148 = Luminance(_0x3d772d38);
        float _0xc195f703 = Luminance(_0x448f4df9);
        return (Mathf.Max(_0x1140e148, _0xc195f703) + 0.05f) / (Mathf.Min(_0x1140e148, _0xc195f703) + 0.05f);
    }

    private void OnDisable()
    {
        if (this._0x0525efb0 != null)
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(this._0x0525efb0);
    }

    private readonly HashSet<TMP_Text> _0x7c0f7d68 = new HashSet<TMP_Text>();
    private static void Fix(TMP_Text _0x27548db5)
    {
        if (_0x27548db5 == null || !_0x27548db5.isActiveAndEnabled)
            return;
        Material _0x252c4a31 = _0x27548db5.fontSharedMaterial;
        if (_0x252c4a31 == null || !_0x252c4a31.HasProperty(ShaderUtilities.ID_OutlineColor) || !_0x252c4a31.HasProperty(ShaderUtilities.ID_OutlineWidth))
            return;
        if (_0x252c4a31.GetFloat(ShaderUtilities.ID_OutlineWidth) < MinOutlineWidth)
            return;
        Color _0xc8dd6b93 = _0x27548db5.color;
        if (_0xc8dd6b93.a <= 0f)
            return;
        Color _0x87be2510 = _0x252c4a31.GetColor(ShaderUtilities.ID_OutlineColor);
        if (Ratio(_0xc8dd6b93, _0x87be2510) >= MinRatio)
            return;
        Color _0xa1fafd5c = Luminance(_0x87be2510) < 0.5f ? Color.white : Color.black;
        Color _0x27ba841d;
        if (Ratio(_0xa1fafd5c, _0x87be2510) < TargetRatio)
        {
            _0x27ba841d = _0xa1fafd5c;
        }
        else
        {
            // Smallest blend that reaches the target: contrast grows monotonically
            // with t, so a short bisection keeps as much of the hue as possible.
            float _0x152b10e0 = 0f;
            float _0x7b5ae8e6 = 1f;
            for (int _0xebbe42b8 = 0; _0xebbe42b8 < 20; _0xebbe42b8++)
            {
                float _0xec59a84d = (_0x152b10e0 + _0x7b5ae8e6) * 0.5f;
                if (Ratio(Color.Lerp(_0xc8dd6b93, _0xa1fafd5c, _0xec59a84d), _0x87be2510) >= TargetRatio)
                    _0x7b5ae8e6 = _0xec59a84d;
                else
                    _0x152b10e0 = _0xec59a84d;
            }

            _0x27ba841d = Color.Lerp(_0xc8dd6b93, _0xa1fafd5c, _0x7b5ae8e6);
        }

        _0x27ba841d.a = _0xc8dd6b93.a;
        _0x27548db5.color = _0x27ba841d;
    }
}

internal static class _0xc3e64911
{
    internal static string _0x5a470eb8(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}