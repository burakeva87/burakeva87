using UnityEngine;
using UnityEngine.UI;

public class _0x2db1666c : MonoBehaviour
{
    public bool IsTutorialEndPanel;
    public Button NextTutorialButton;
    public int EndTutorialPanelIndex = 1;
    public int NextTutorialPanelIndex;
    private void Start()
    {
        if (this.NextTutorialButton != null)
        {
            if (this.IsTutorialEndPanel)
            {
                this.NextTutorialButton.onClick.AddListener(() => _0xd5e1760c.Instance._0x14f99188(this.EndTutorialPanelIndex));
                this.NextTutorialButton.onClick.AddListener(() => _0x764d1f95.Instance._0x4c2c9632());
            }
            else
            {
                this.NextTutorialButton.onClick.AddListener(() => _0xd5e1760c.Instance._0x14f99188(this.NextTutorialPanelIndex));
            }
        }

        if (this.TutorialEndButton != null)
        {
            this.TutorialEndButton.onClick.AddListener(() => _0xd5e1760c.Instance._0x14f99188(this.EndTutorialPanelIndex));
            this.TutorialEndButton.onClick.AddListener(() => _0x764d1f95.Instance._0x4c2c9632());
        }
    }

    public Button TutorialEndButton;
}