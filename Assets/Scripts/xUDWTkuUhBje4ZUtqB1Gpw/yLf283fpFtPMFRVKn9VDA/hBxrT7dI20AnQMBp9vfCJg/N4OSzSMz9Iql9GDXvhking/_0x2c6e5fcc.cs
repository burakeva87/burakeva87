using UnityEngine;
using UnityEngine.UI;

public class _0x2c6e5fcc : MonoBehaviour
{
    private void Start()
    {
        this.Button.onClick.AddListener(() => _0x764d1f95.Instance._0xe0dcc721(this.IsPhysicsRunOnClick));
    }

    public bool IsPhysicsRunOnClick;
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    public Button Button;
}