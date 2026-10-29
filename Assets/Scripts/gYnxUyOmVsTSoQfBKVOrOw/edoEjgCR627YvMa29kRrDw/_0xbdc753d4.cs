using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class _0xbdc753d4 : MonoBehaviour
{
    private new Camera _0x13acf61a;
    private Vector3 _0xa826a231 { get; set; }
    private Vector3 _0x3511671f { get; set; }
    private Vector3 _0x48107bb8 { get; set; }

    private void OnDrawGizmos()
    {
        Gizmos.color = this._0x45eea6ce;
        Matrix4x4 _0x09dc971e = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, Vector3.one);
        if (this._0x13acf61a.orthographic)
        {
            float _0xbf4da1c9 = this._0x13acf61a.farClipPlane - this._0x13acf61a.nearClipPlane;
            float _0x4a5a8aff = (this._0x13acf61a.farClipPlane + this._0x13acf61a.nearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, _0x4a5a8aff), new Vector3(this._0x13acf61a.orthographicSize * 2 * this._0x13acf61a.aspect, this._0x13acf61a.orthographicSize * 2, _0xbf4da1c9));
        }
        else
        {
            Gizmos.DrawFrustum(Vector3.zero, this._0x13acf61a.fieldOfView, this._0x13acf61a.farClipPlane, this._0x13acf61a.nearClipPlane, this._0x13acf61a.aspect);
        }

        Gizmos.matrix = _0x09dc971e;
    }

    private Vector3 _0x8df0de1b { get; set; }

    private float _0xc9616017 = 1;
    private Vector3 _0x87009b78 { get; set; }

    private static _0xbdc753d4 _0x0d1febf5;
    private void _0xd44b154e()
    {
        float _0x1d89a70e, _0x796f8a3d, _0x086a8930, _0x487fcf6f;
        if (this._0x8be598dd == _0x5281a3a2.Landscape)
            this._0x13acf61a.orthographicSize = 1f / this._0x13acf61a.aspect * this._0xc9616017 / 2f;
        else
            this._0x13acf61a.orthographicSize = this._0xc9616017 / 2f;
        this._0x4358ad32 = 2f * this._0x13acf61a.orthographicSize;
        this._0x382eb2f5 = this._0x4358ad32 * this._0x13acf61a.aspect;
        float _0x51752c97 = this._0x13acf61a.transform.position.x;
        float _0x31c8e90d = this._0x13acf61a.transform.position.y;
        _0x1d89a70e = _0x51752c97 - this._0x382eb2f5 / 2;
        _0x796f8a3d = _0x51752c97 + this._0x382eb2f5 / 2;
        _0x086a8930 = _0x31c8e90d + this._0x4358ad32 / 2;
        _0x487fcf6f = _0x31c8e90d - this._0x4358ad32 / 2;
        this._0x8df0de1b = new Vector3(_0x1d89a70e, _0x487fcf6f, 0);
        this._0x92103698 = new Vector3(_0x51752c97, _0x487fcf6f, 0);
        this._0xa826a231 = new Vector3(_0x796f8a3d, _0x487fcf6f, 0);
        this._0x87009b78 = new Vector3(_0x1d89a70e, _0x31c8e90d, 0);
        this._0x3511671f = new Vector3(_0x51752c97, _0x31c8e90d, 0);
        this._0x01e3a8c7 = new Vector3(_0x796f8a3d, _0x31c8e90d, 0);
        this._0x377b561f = new Vector3(_0x1d89a70e, _0x086a8930, 0);
        this._0x48107bb8 = new Vector3(_0x51752c97, _0x086a8930, 0);
        this._0x4378d2bc = new Vector3(_0x796f8a3d, _0x086a8930, 0);
    }

    //public bool executeInUpdate;
    private float _0x382eb2f5 { get; set; }

    public enum _0x5281a3a2
    {
        Landscape,
        Portrait
    }

    private Vector3 _0x4378d2bc { get; set; }

    private _0x5281a3a2 _0x8be598dd = _0x5281a3a2.Portrait;
    private void Awake()
    {
        this._0x13acf61a = this.GetComponent<Camera>();
        _0x0d1febf5 = this;
        this._0xd44b154e();
    }

    private Vector3 _0x377b561f { get; set; }
    private float _0x4358ad32 { get; set; }
    private Vector3 _0x01e3a8c7 { get; set; }

    private Color _0x45eea6ce = Color.white;
    private Vector3 _0x92103698 { get; set; }
}