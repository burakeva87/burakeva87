using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _0xa7d1bd6f : MonoBehaviour
{
    public int LoadSceneId;
    private void Start()
    {
        if (this.IsLoadCurrentScene)
            this.Button.onClick.AddListener(() =>
            {
                _0x764d1f95.Instance._0x3b3b6907(SceneManager.GetActiveScene().buildIndex);
            });
        else
            this.Button.onClick.AddListener(() => _0x764d1f95.Instance._0x3b3b6907(this.LoadSceneId));
    }

    public Button Button;
    public bool IsLoadCurrentScene;
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }
}