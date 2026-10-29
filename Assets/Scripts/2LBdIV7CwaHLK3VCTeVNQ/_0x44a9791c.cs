using UnityEngine;

/// <summary>
/// The one source of randomness in this game.
///
/// System.Random, never UnityEngine.Random: the Unity one is global state, so two
/// systems drawing from it start steering each other and "the same seed" stops meaning
/// the same thing (C.11).
///
/// No constructor (C.59) - build it with Init and keep the seed, so a run can be
/// reproduced from the log line the director writes.
/// </summary>
public sealed class _0x44a9791c
{
    public int _0x7921f476
    {
        get
        {
            return this._0xf5f9e6a9;
        }
    }

    public int _0x356b07e3(int _0x243f3098, int _0x0b39f512)
    {
        if (_0x0b39f512 <= _0x243f3098)
            return _0x243f3098;
        return this._0x08bff909.Next(_0x243f3098, _0x0b39f512);
    }

    public float _0x42ab2dce()
    {
        return (float)this._0x08bff909.NextDouble();
    }

    /// <summary>
    /// Derive this attempt's seed. Two large primes keep consecutive sessions and
    /// consecutive spins far apart instead of one step apart.
    /// </summary>
    public _0x44a9791c _0xfb3266dd(int _0xc15aac92, int _0x861e9bd6)
    {
        this._0xf5f9e6a9 = (_0xc15aac92 * 7919) ^ (_0x861e9bd6 * 104729);
        this._0x08bff909 = new System.Random(this._0xf5f9e6a9);
        return this;
    }

    private int _0xf5f9e6a9 = 1;
    /// <summary>Pick an index from a weight table. Weights need not be normalised.</summary>
    public int _0xdd5ceb99(int[] _0x31e82e52)
    {
        if (_0x31e82e52 == null || _0x31e82e52.Length == 0)
            return 0;
        int _0x0b65682b = 0;
        for (int _0xbd7eccc9 = 0; _0xbd7eccc9 < _0x31e82e52.Length; _0xbd7eccc9++)
            _0x0b65682b += _0x31e82e52[_0xbd7eccc9] > 0 ? _0x31e82e52[_0xbd7eccc9] : 0;
        if (_0x0b65682b <= 0)
            return 0;
        int _0x433d3d3c = this._0x356b07e3(0, _0x0b65682b);
        for (int _0xd1fd9c5d = 0; _0xd1fd9c5d < _0x31e82e52.Length; _0xd1fd9c5d++)
        {
            int w = _0x31e82e52[_0xd1fd9c5d] > 0 ? _0x31e82e52[_0xd1fd9c5d] : 0;
            if (_0x433d3d3c < w)
                return _0xd1fd9c5d;
            _0x433d3d3c -= w;
        }

        return _0x31e82e52.Length - 1;
    }

    private System.Random _0x08bff909 = new System.Random(1);
    /// <summary>Distinct draws without replacement, used for the mission set.</summary>
    public int[] _0x54b9e660(int _0xfed8418b, int _0x140f2eb9)
    {
        int _0x333c6771 = _0x140f2eb9 < _0xfed8418b ? _0x140f2eb9 : _0xfed8418b;
        int[] _0xee29e482 = new int[_0xfed8418b];
        for (int _0x4995864c = 0; _0x4995864c < _0xfed8418b; _0x4995864c++)
            _0xee29e482[_0x4995864c] = _0x4995864c;
        this._0x779a9e7f(_0xee29e482);
        int[] _0xbd606a71 = new int[_0x333c6771];
        for (int _0x2cf4c442 = 0; _0x2cf4c442 < _0x333c6771; _0x2cf4c442++)
            _0xbd606a71[_0x2cf4c442] = _0xee29e482[_0x2cf4c442];
        return _0xbd606a71;
    }

    /// <summary>Fisher-Yates, in place.</summary>
    public void _0x779a9e7f(int[] _0xec202482)
    {
        if (_0xec202482 == null)
            return;
        for (int _0x73682f17 = _0xec202482.Length - 1; _0x73682f17 > 0; _0x73682f17--)
        {
            int _0xed086cbe = this._0x356b07e3(0, _0x73682f17 + 1);
            int _0x2f16088e = _0xec202482[_0x73682f17];
            _0xec202482[_0x73682f17] = _0xec202482[_0xed086cbe];
            _0xec202482[_0xed086cbe] = _0x2f16088e;
        }
    }
}