using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dresses the three pops this game uses: PAUSE (6), WIN (7) and LOSE (8).
///
/// THE POPS ARE THE FACE OF A RESULT (C.3), so none of them ships with template copy.
/// Every one gets its own header, body and detail line in this game's words, its own
/// caption on every action button, and the template's own "Score:" style placeholders
/// are either filled with a metric this game really has or left switched off.
///
/// EVERY LABEL IS A SERIALIZED REFERENCE, NOT A SEARCH (C.1 / C.17). Walking
/// GetComponentsInChildren&lt;Button&gt; returns the close cross FIRST, so captioning by
/// traversal order is how a pause card ends up with three buttons all saying RESUME;
/// and telling the cross apart by its driver fails here too, because the pause cross
/// carries the same SetPhysicsRunButton the RESUME button does. The scene therefore
/// hands every label, icon and button to this component by fileID, which is the one
/// binding obfuscation cannot break.
///
/// WHAT EACH BUTTON DOES IS FIXED BY THE TEMPLATE DRIVER ON IT, and the captions below
/// are written to match it:
///   BOT_BTNS_RIGHT  LoadSceneButton IsLoadCurrentScene -> a fresh vault session
///   BOT_BTNS_LEFT   LoadSceneButton LoadSceneId 0      -> back to the lobby
///   PAUSE right     SetPhysicsRunButton + hide pops    -> resume this one
///   TOP_BTNS RIGHT  hide pops (close cross, no caption)
///
/// A POP ALSO HAS TO STOP THE RUN. The template's ShowPopButton only shows the card;
/// nothing halts the game behind it, so the attract spin would keep rolling under a
/// PAUSED sign. Raising a pop therefore clears the running flag here, and the template
/// RESUME button sets it back.
/// </summary>
public sealed class _0x9cafad81 : MonoBehaviour
{
    /// <summary>
    /// Captions, colours and the close crosses are set once, here, so a card is already
    /// dressed the first time it is raised rather than a frame later. Set-up lives in
    /// Start and never in Awake: the template builds its own singletons in Awake and the
    /// order between them is undefined (C.59).
    /// </summary>
    private void Start()
    {
        this._0x37ba5f53(this._winTopButtons, this._winHeader, this._winBody, this._winDetail, this._winReserveLabel, this._winPrimaryLabel, this._winSecondaryLabel, this._winCloseLabel, this._winCloseIcon, _0x7b276cfd._0xf993b6bf(new byte[13] { 200, 223, 203, 210, 202, 190, 221, 204, 223, 221, 213, 219, 218 }, 158), _0x7b276cfd._0xf993b6bf(new byte[10] { 231, 228, 253, 250, 148, 245, 243, 245, 253, 250 }, 180), _0x7b276cfd._0xf993b6bf(new byte[5] { 102, 101, 104, 104, 115 }, 42));
        this._0x37ba5f53(this._loseTopButtons, this._loseHeader, this._loseBody, this._loseDetail, this._loseReserveLabel, this._losePrimaryLabel, this._loseSecondaryLabel, this._loseCloseLabel, this._loseCloseIcon, _0x7b276cfd._0xf993b6bf(new byte[16] { 172, 160, 166, 161, 207, 189, 170, 188, 170, 189, 185, 170, 207, 163, 160, 184 }, 239), _0x7b276cfd._0xf993b6bf(new byte[14] { 68, 72, 75, 75, 66, 68, 83, 39, 85, 66, 65, 78, 75, 75 }, 7), _0x7b276cfd._0xf993b6bf(new byte[5] { 13, 14, 3, 3, 24 }, 65));
        this._0x37ba5f53(this._pauseTopButtons, this._pauseHeader, this._pauseBody, null, null, this._pausePrimaryLabel, this._pauseSecondaryLabel, this._pauseCloseLabel, this._pauseCloseIcon, _0x7b276cfd._0xf993b6bf(new byte[13] { 200, 223, 223, 214, 201, 186, 213, 212, 186, 210, 213, 214, 222 }, 154), _0x7b276cfd._0xf993b6bf(new byte[6] { 228, 243, 229, 227, 251, 243 }, 182), _0x7b276cfd._0xf993b6bf(new byte[5] { 56, 59, 54, 54, 45 }, 116));
        if (this._losePrimaryButton != null)
            this._losePrimaryButton.onClick.AddListener(() => this._0x0f0e0b74());
    }

    [SerializeField]
    private TMP_Text _winPrimaryLabel;
    private void OnDestroy()
    {
        DOTween.Kill(this);
    }

    /// <summary>COIN RESERVE LOW - the free refill, the only recoverable dead end.</summary>
    public void _0x80961811(int _0x19f6f372)
    {
        this._0x11cf19f4 = _0x19f6f372;
        _0xe91c2331.SetText(this._loseBody, _0x7b276cfd._0xf993b6bf(new byte[30] { 241, 237, 224, 133, 237, 234, 240, 246, 224, 133, 247, 224, 227, 236, 233, 233, 246, 133, 252, 234, 240, 247, 133, 247, 224, 246, 224, 247, 243, 224 }, 165));
        _0xe91c2331.SetText(this._loseDetail, _0x7b276cfd._0xf993b6bf(new byte[1] { 123 }, 80) + _0x43ed7f14.Money(_0x19f6f372) + _0x7b276cfd._0xf993b6bf(new byte[16] { 31, 121, 118, 124, 107, 118, 112, 113, 126, 115, 31, 124, 112, 118, 113, 108 }, 63));
        this._0x80b5d878(_0x778394b0._0xb75f6257.LOSE);
    }

    [SerializeField]
    private TMP_Text _winSecondaryLabel;
    private int _0x11cf19f4;
    [SerializeField]
    private TMP_Text _winCloseLabel;
    [SerializeField]
    private Image _loseCloseIcon;
    [SerializeField]
    private GameObject _loseTopButtons;
    /// <summary>VAULT CRACKED - a payout worth interrupting the reels for.</summary>
    public void _0xdff67613(long payout, string _0xd680a64a)
    {
        _0xe91c2331.SetText(this._winBody, _0x7b276cfd._0xf993b6bf(new byte[7] { 247, 230, 254, 232, 242, 243, 135 }, 167) + _0x43ed7f14.Money(payout) + _0x7b276cfd._0xf993b6bf(new byte[6] { 254, 157, 145, 151, 144, 141 }, 222));
        _0xe91c2331.SetText(this._winDetail, _0xd680a64a);
        this._0x80b5d878(_0x778394b0._0xb75f6257.WIN);
    }

    [SerializeField]
    private TMP_Text _loseSecondaryLabel;
    [SerializeField]
    private TMP_Text _losePrimaryLabel;
    [SerializeField]
    private TMP_Text _winBody;
    [SerializeField]
    private TMP_Text _pauseBody;
    [SerializeField]
    private GameObject _winTopButtons;
    /// <summary>
    /// One card. Every reference is optional, so the pause card - which has no results
    /// row at all on this template - passes null for the two lines it does not own.
    /// </summary>
    private void _0x37ba5f53(GameObject _0xe2f72e6c, TMP_Text _0xa0f905c6, TMP_Text _0x192cc2ee, TMP_Text _0xe1329683, TMP_Text _0x52163af5, TMP_Text _0x8f307c28, TMP_Text _0x5f366304, TMP_Text _0xfb4a3dce, Image _0x16e7efe1, string _0x37e697fa, string _0x9474cc6c, string _0xb711ffb4)
    {
        if (_0xe2f72e6c != null)
            _0xe2f72e6c.SetActive(true);
        this.Show(_0xa0f905c6, _0x37e697fa, _0xecf6b76b.TextPrimary, 72f, 48f);
        this.Show(_0x192cc2ee, string.Empty, _0xecf6b76b.Gold, 56f, 40f);
        this.Show(_0xe1329683, string.Empty, _0xecf6b76b.TextSecondary, 44f, 34f);
        this.Show(_0x52163af5, _0x7b276cfd._0xf993b6bf(new byte[12] { 78, 66, 68, 67, 45, 95, 72, 94, 72, 95, 91, 72 }, 13), _0xecf6b76b.TextSoft, 36f, 30f);
        this.Show(_0x8f307c28, _0x9474cc6c, _0xecf6b76b.TextPrimary, 44f, 34f);
        this.Show(_0x5f366304, _0xb711ffb4, _0xecf6b76b.TextPrimary, 44f, 34f);
        // The cross carries the icon and NOTHING else (C.17): a caption on it is how a
        // pause card ends up with two buttons both saying RESUME.
        if (_0xfb4a3dce != null)
        {
            _0xfb4a3dce.text = string.Empty;
            _0xfb4a3dce.gameObject.SetActive(false);
        }

        if (_0x16e7efe1 != null && this._closeIcon != null)
        {
            _0x16e7efe1.sprite = this._closeIcon;
            _0x16e7efe1.type = Image.Type.Simple;
            _0x16e7efe1.preserveAspect = true;
            _0x16e7efe1.color = _0xecf6b76b.Gold;
            _0x16e7efe1.raycastTarget = false;
            _0x16e7efe1.gameObject.SetActive(true);
        }
    }

    [SerializeField]
    private TMP_Text _loseCloseLabel;
    /// <summary>
    /// COLLECT REFILL has to pay out as well as reopen the vault. The template driver on
    /// that button reloads the scene; this adds the coins first.
    /// </summary>
    private void _0x0f0e0b74()
    {
        if (this._0x11cf19f4 <= 0)
            this._0x11cf19f4 = _0x43ed7f14.RefillAmount;
        _0x43ed7f14._0x0432624b = _0x43ed7f14._0x0432624b + this._0x11cf19f4;
        this._0x11cf19f4 = 0;
    }

    [SerializeField]
    private Button _losePrimaryButton;
    [SerializeField]
    private Sprite _closeIcon;
    [SerializeField]
    private TMP_Text _loseBody;
    [SerializeField]
    private GameObject _pauseTopButtons;
    [SerializeField]
    private Image _pauseCloseIcon;
    [SerializeField]
    private TMP_Text _pauseSecondaryLabel;
    [SerializeField]
    private TMP_Text _loseHeader;
    [SerializeField]
    private TMP_Text _winHeader;
    /// <summary>
    /// Turn a template label into one of ours: switched on, in the palette, wrapping off
    /// and autosize on with a floor that still reads (C.10).
    /// </summary>
    private void Show(TMP_Text _0xef8b855f, string _0xbcc9f451, Color _0x64b802bd, float _0x9b5085bd, float _0x53338ebd)
    {
        if (_0xef8b855f == null)
            return;
        _0xef8b855f.gameObject.SetActive(true);
        _0xef8b855f.text = _0xbcc9f451;
        _0xe91c2331.Apply(_0xef8b855f, _0x64b802bd, _0x9b5085bd, _0x53338ebd);
    }

    [SerializeField]
    private TMP_Text _winDetail;
    [SerializeField]
    private TMP_Text _pauseCloseLabel;
    [SerializeField]
    private Image _winCloseIcon;
    [SerializeField]
    private TMP_Text _loseDetail;
    /// <summary>REELS ON HOLD - shown more often than either of the others.</summary>
    public void _0xdf26c91e(long _0xd7bdf201, int _0x5f8174c9)
    {
        _0xe91c2331.SetText(this._pauseBody, _0x7b276cfd._0xf993b6bf(new byte[4] { 199, 192, 209, 165 }, 133) + _0x43ed7f14.Money(_0xd7bdf201) + _0x7b276cfd._0xf993b6bf(new byte[18] { 141, 130, 141, 225, 228, 227, 232, 254, 141, 148, 167, 254, 232, 236, 225, 232, 233, 141 }, 173) + _0x5f8174c9 + _0x7b276cfd._0xf993b6bf(new byte[3] { 64, 79, 64 }, 96) + _0x43ed7f14.AlbumSlots);
        this._0x80b5d878(_0x778394b0._0xb75f6257.PAUSE);
    }

    [SerializeField]
    private TMP_Text _pausePrimaryLabel;
    private void _0x80b5d878(int _0x85236ec9)
    {
        if (_0x74b7eccd.Instance == null || _0x74b7eccd.Instance.Pops == null)
            return;
        if (_0x85236ec9 < 0 || _0x85236ec9 >= _0x74b7eccd.Instance.Pops.Count)
            return;
        if (_0x74b7eccd.Instance.Pops[_0x85236ec9] == null)
            return;
        if (_0x764d1f95.Instance != null)
            _0x764d1f95.Instance._0xe0dcc721(false);
        _0x74b7eccd.Instance._0x3d0d66ed(_0x85236ec9);
    }

    [SerializeField]
    private TMP_Text _pauseHeader;
    [SerializeField]
    private TMP_Text _winReserveLabel;
    [SerializeField]
    private TMP_Text _loseReserveLabel;
}

internal static class _0x7b276cfd
{
    internal static string _0xf993b6bf(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}