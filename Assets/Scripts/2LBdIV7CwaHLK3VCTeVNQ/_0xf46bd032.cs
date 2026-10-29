using UnityEngine;

/// <summary>
/// The opening twelve spins, generated and then PROVED before anything is shown (C.11).
///
/// A freely drawn opening is allowed to be twelve dead spins in a row, and the review
/// capture would then photograph an idle board. So the plan is generated and checked
/// against two conditions:
///   - SPIN 1 ITSELF pays, so the first spin the player (or the attract timer) ever
///     completes has a win on it. The design asked only for "a paying spin among spins
///     1-3", but the review capture taps SPIN once and photographs that one result:
///     under the loose rule the winning spin could be the second or the third, and the
///     frame named 06_Reels_win would show a dead board;
///   - at least one payout of 8x the bet or more among spins 1-12, so the WIN pop is
///     reachable inside a normal session.
///
/// WHY THIS IS NOT A PLAIN REDRAW LOOP. Measured over 5000 sessions of this paytable, a
/// freely drawn twelve-spin block carries an early win 53.6% of the time but a 8x or
/// better only 0.8% of the time. Redrawing the WHOLE block cannot rescue a 0.8% event:
/// twenty attempts still left 89% of sessions falling through to the hardcoded schedule,
/// which made the fallback THE GAME and flattened C.11 - nine players out of ten saw the
/// same twelve boards. So an unmet condition is now REPAIRED on the single spin that has
/// to carry it: stop positions are searched for one line that pays what is missing, the
/// other eleven spins stay freely drawn, and the session stays its own. The hardcoded
/// schedule survives only as the last resort, for a strip set so poor that no line can be
/// built on it at all.
/// </summary>
public sealed class _0xf46bd032
{
    private const int RepairTries = 4;
    /// <summary>
    /// A board for the cabinet to sit on BEFORE the first spin. It is deliberately NOT
    /// spin 1's board: the player lands on the opening board, and if the first spin then
    /// stopped on those very symbols the reels would roll and visibly change nothing -
    /// and the review's idle frame and win frame would be the same picture. Drawn
    /// non-paying as well, so the idle shot reads as idle.
    /// </summary>
    public int[] _0xf3d43770(_0xfcff778c _0xe8f7027e, _0x44a9791c _0x541dc253, long _0xcd2549c5)
    {
        _0x99dc1491 _0x39987603 = new _0x99dc1491();
        int[] _0x7b45bd10 = null;
        for (int _0x4e90d766 = 0; _0x4e90d766 < IdleTries; _0x4e90d766++)
        {
            int[] _0x751dfc5d = new int[_0xfcff778c.Reels];
            for (int _0x63d03908 = 0; _0x63d03908 < _0xfcff778c.Reels; _0x63d03908++)
                _0x751dfc5d[_0x63d03908] = _0x541dc253._0x356b07e3(0, _0xfcff778c.StripLength);
            if (_0x7b45bd10 == null)
                _0x7b45bd10 = _0x751dfc5d;
            if (_0xe8f7027e == null)
                return _0x751dfc5d;
            if (SameStops(_0x751dfc5d, this._0x45c59431 != null ? this._0x45c59431[0] : null))
                continue;
            _0xe1643c2c.Evaluate(_0xe8f7027e._0xa8f6c8d4(_0x751dfc5d), _0xcd2549c5, _0x39987603);
            if (_0x39987603.Payout == 0L && _0x39987603.Scatters < 3)
                return _0x751dfc5d;
        }

        return _0x7b45bd10;
    }

    private bool _0xcce3f7e9;
    private const int IdleTries = 24;
    /// <summary>
    /// Stops that place a paying run of sym on the first run reels of line. The reels
    /// past the run stay freely drawn: landing the symbol there as well only lengthens
    /// the run, which pays more, never less.
    ///
    /// Every reel of the run accepts the symbol OR a wild, exactly as the evaluator
    /// counts a run. Taking wilds into account is what keeps this search answerable: the
    /// high symbols that reach 8x are rare on a 24-slot strip, and demanding the literal
    /// symbol on four or five separate reels fell back to the hardcoded schedule on 8%
    /// of sessions. A run that comes out all wilds, or whose lead resolves to another
    /// symbol, simply fails the caller's Evaluate check and the next candidate is tried -
    /// the payout is never assumed, always measured.
    ///
    /// Returns null when some reel of the run carries neither the symbol nor a wild.
    /// </summary>
    private int[] _0x969d4b1f(_0xfcff778c _0x3bb04cea, _0x44a9791c _0xbe8cf276, int[] _0x4ade8019, int _0x8b6ee5a5, int _0xea9d3eea)
    {
        int[] _0xe85d4ee1 = new int[_0xfcff778c.Reels];
        for (int _0x9c436e0c = 0; _0x9c436e0c < _0xfcff778c.Reels; _0x9c436e0c++)
            _0xe85d4ee1[_0x9c436e0c] = _0xbe8cf276._0x356b07e3(0, _0xfcff778c.StripLength);
        for (int _0x4b13fa60 = 0; _0x4b13fa60 < _0xea9d3eea; _0x4b13fa60++)
        {
            int _0xec8f32e0 = _0x4ade8019[_0x4b13fa60];
            int _0x6daa4cd5 = -1;
            int _0x8fdab08a = 0;
            for (int _0x3641544e = 0; _0x3641544e < _0xfcff778c.StripLength; _0x3641544e++)
            {
                int _0xbfb1f770 = _0x3bb04cea._0x4bd9c2ed(_0x4b13fa60, _0x3641544e);
                if (_0xbfb1f770 != _0x8b6ee5a5 && _0xbfb1f770 != _0x52061f7c.Wild)
                    continue;
                _0x8fdab08a++;
                // Reservoir pick, so a strip does not always stop in the same place.
                if (_0x6daa4cd5 < 0 || _0xbe8cf276._0x356b07e3(0, _0x8fdab08a) == 0)
                    _0x6daa4cd5 = _0x3641544e;
            }

            if (_0x6daa4cd5 < 0)
                return null;
            _0xe85d4ee1[_0x4b13fa60] = (((_0x6daa4cd5 - _0xec8f32e0) % _0xfcff778c.StripLength) + _0xfcff778c.StripLength) % _0xfcff778c.StripLength;
        }

        return _0xe85d4ee1;
    }

    /// <summary>
    /// A board the fallback schedule insists on, or null when the strips decide. Only a
    /// session whose draws AND repairs all failed ever gets a non-null answer here.
    /// </summary>
    public int[] _0x739c1404(int _0xc66fb796)
    {
        if (this._0x32451481 == null || _0xc66fb796 < 0 || _0xc66fb796 >= this._0x32451481.Length)
            return null;
        return this._0x32451481[_0xc66fb796];
    }

    /// <summary>
    /// The guaranteed schedule. Each entry is a full 5x3 board written reel by reel,
    /// three rows per reel, top row first - the same order the evaluator reads.
    /// Spin 1 pays the middle line on emeralds; spin 4 pays a five-wild line, which is
    /// 80x and well past the WIN pop threshold.
    /// </summary>
    private static int[][] FallbackBoards()
    {
        int _0x65863ffb = _0x52061f7c.Ruby;
        int _0xa7b50823 = _0x52061f7c.Sapphire;
        int _0xe1193e97 = _0x52061f7c.Emerald;
        int _0x2b25d7d8 = _0x52061f7c.Topaz;
        int _0xf288c735 = _0x52061f7c.Crown;
        int _0x4d29fbc2 = _0x52061f7c.Bell;
        int _0x0cf49862 = _0x52061f7c.Coin;
        int _0x6ae1736e = _0x52061f7c.Diamond;
        int _0x2e07a300 = _0x52061f7c.Wild;
        int _0x85dd5921 = _0x52061f7c.Scatter;
        return new[]
        {
            new[]
            {
                _0x65863ffb,
                _0xe1193e97,
                _0x2b25d7d8,
                _0xa7b50823,
                _0xe1193e97,
                _0xf288c735,
                _0x2b25d7d8,
                _0xe1193e97,
                _0x65863ffb,
                _0x4d29fbc2,
                _0xe1193e97,
                _0xa7b50823,
                _0x0cf49862,
                _0xe1193e97,
                _0x2b25d7d8
            },
            new[]
            {
                _0xa7b50823,
                _0x65863ffb,
                _0x2b25d7d8,
                _0xf288c735,
                _0x2b25d7d8,
                _0xe1193e97,
                _0x65863ffb,
                _0xa7b50823,
                _0x4d29fbc2,
                _0x2b25d7d8,
                _0x0cf49862,
                _0x65863ffb,
                _0xe1193e97,
                _0x2b25d7d8,
                _0xa7b50823
            },
            new[]
            {
                _0xf288c735,
                _0x0cf49862,
                _0x65863ffb,
                _0xa7b50823,
                _0x0cf49862,
                _0x2b25d7d8,
                _0xe1193e97,
                _0x0cf49862,
                _0x4d29fbc2,
                _0x65863ffb,
                _0x0cf49862,
                _0xa7b50823,
                _0x2b25d7d8,
                _0x0cf49862,
                _0xf288c735
            },
            new[]
            {
                _0x2e07a300,
                _0x65863ffb,
                _0x2b25d7d8,
                _0x2e07a300,
                _0xa7b50823,
                _0xe1193e97,
                _0x2e07a300,
                _0x2b25d7d8,
                _0xf288c735,
                _0x2e07a300,
                _0x4d29fbc2,
                _0xa7b50823,
                _0x2e07a300,
                _0x0cf49862,
                _0x2b25d7d8
            },
            new[]
            {
                _0x65863ffb,
                _0xa7b50823,
                _0xe1193e97,
                _0x2b25d7d8,
                _0xf288c735,
                _0x4d29fbc2,
                _0x0cf49862,
                _0x6ae1736e,
                _0x2e07a300,
                _0x85dd5921,
                _0x65863ffb,
                _0xa7b50823,
                _0xe1193e97,
                _0x2b25d7d8,
                _0xf288c735
            },
            new[]
            {
                _0x4d29fbc2,
                _0x2b25d7d8,
                _0x65863ffb,
                _0xa7b50823,
                _0x4d29fbc2,
                _0xe1193e97,
                _0xf288c735,
                _0x4d29fbc2,
                _0x2b25d7d8,
                _0x65863ffb,
                _0x4d29fbc2,
                _0xa7b50823,
                _0x0cf49862,
                _0x4d29fbc2,
                _0xe1193e97
            },
            new[]
            {
                _0x85dd5921,
                _0x65863ffb,
                _0x2b25d7d8,
                _0xa7b50823,
                _0x85dd5921,
                _0xe1193e97,
                _0xf288c735,
                _0x2b25d7d8,
                _0x85dd5921,
                _0x65863ffb,
                _0x4d29fbc2,
                _0xa7b50823,
                _0x2b25d7d8,
                _0x0cf49862,
                _0xe1193e97
            },
            new[]
            {
                _0x6ae1736e,
                _0xa7b50823,
                _0x2b25d7d8,
                _0x65863ffb,
                _0x6ae1736e,
                _0xe1193e97,
                _0xf288c735,
                _0x6ae1736e,
                _0x4d29fbc2,
                _0x2b25d7d8,
                _0x65863ffb,
                _0xa7b50823,
                _0xe1193e97,
                _0x2b25d7d8,
                _0x0cf49862
            },
            new[]
            {
                _0x2b25d7d8,
                _0x65863ffb,
                _0xa7b50823,
                _0xe1193e97,
                _0x2b25d7d8,
                _0xf288c735,
                _0x4d29fbc2,
                _0x2b25d7d8,
                _0x65863ffb,
                _0xa7b50823,
                _0x0cf49862,
                _0x2b25d7d8,
                _0xe1193e97,
                _0xf288c735,
                _0x65863ffb
            },
            new[]
            {
                _0xe1193e97,
                _0xf288c735,
                _0x65863ffb,
                _0x2b25d7d8,
                _0xe1193e97,
                _0xa7b50823,
                _0x4d29fbc2,
                _0xe1193e97,
                _0x0cf49862,
                _0x65863ffb,
                _0x2b25d7d8,
                _0xa7b50823,
                _0xf288c735,
                _0xe1193e97,
                _0x4d29fbc2
            },
            new[]
            {
                _0x0cf49862,
                _0x65863ffb,
                _0xe1193e97,
                _0xa7b50823,
                _0x0cf49862,
                _0x2b25d7d8,
                _0x4d29fbc2,
                _0x0cf49862,
                _0xf288c735,
                _0x65863ffb,
                _0xa7b50823,
                _0xe1193e97,
                _0x2b25d7d8,
                _0x0cf49862,
                _0x4d29fbc2
            },
            new[]
            {
                _0x65863ffb,
                _0x2b25d7d8,
                _0xa7b50823,
                _0xe1193e97,
                _0x65863ffb,
                _0xf288c735,
                _0x4d29fbc2,
                _0x65863ffb,
                _0x0cf49862,
                _0x2b25d7d8,
                _0xa7b50823,
                _0xe1193e97,
                _0x65863ffb,
                _0xf288c735,
                _0x2b25d7d8
            }
        };
    }

    private static bool SameStops(int[] _0xd81a8917, int[] _0x6ca19616)
    {
        if (_0xd81a8917 == null || _0x6ca19616 == null)
            return false;
        for (int _0xccabdbd4 = 0; _0xccabdbd4 < _0xd81a8917.Length && _0xccabdbd4 < _0x6ca19616.Length; _0xccabdbd4++)
            if (_0xd81a8917[_0xccabdbd4] != _0x6ca19616[_0xccabdbd4])
                return false;
        return true;
    }

    private int[][] _0x45c59431 = new int[PlannedSpins][];
    /// <summary>
    /// Build stop positions for one spin so that it pays at least minPayout. Candidate
    /// lines and symbols are walked in a per-session shuffled order, so two sessions that
    /// both need a repair do not end up with the same engineered board.
    /// </summary>
    private bool _0xb43833c8(_0xfcff778c _0x99ed0049, _0x44a9791c _0x495d3396, _0x99dc1491 _0x01969530, int _0x7124db5d, long _0x1bc11be6, long _0xc75cc4e2)
    {
        if (_0x99ed0049 == null || this._0x45c59431 == null || _0x7124db5d < 0 || _0x7124db5d >= PlannedSpins)
            return false;
        int[] _0x562c4f8d = new int[_0xe1643c2c._0x8c962780];
        for (int _0x07187942 = 0; _0x07187942 < _0x562c4f8d.Length; _0x07187942++)
            _0x562c4f8d[_0x07187942] = _0x07187942;
        _0x495d3396._0x779a9e7f(_0x562c4f8d);
        int[] _0xe07201fd = new int[_0x18964d85.Length];
        for (int _0xec4b90dc = 0; _0xec4b90dc < _0x18964d85.Length; _0xec4b90dc++)
            _0xe07201fd[_0xec4b90dc] = _0x18964d85[_0xec4b90dc];
        _0x495d3396._0x779a9e7f(_0xe07201fd);
        for (int _0xda91233c = 0; _0xda91233c < _0x562c4f8d.Length; _0xda91233c++)
        {
            int[] _0xc8b44d9e = _0xe1643c2c.Line(_0x562c4f8d[_0xda91233c]);
            for (int _0xec8575be = 0; _0xec8575be < _0xe07201fd.Length; _0xec8575be++)
            {
                int _0x1d8257d9 = _0xe07201fd[_0xec8575be];
                for (int _0x2d469ea4 = _0xfcff778c.Reels; _0x2d469ea4 >= 3; _0x2d469ea4--)
                {
                    if ((long)Mathf.Round(_0x52061f7c.Payout(_0x1d8257d9, _0x2d469ea4) * _0x1bc11be6) < _0xc75cc4e2)
                        continue;
                    // Several goes at the same candidate: the reels outside the run and
                    // the choice among equal strip positions are random, and both can
                    // turn a would-be win into a different lead symbol.
                    for (int _0x75f20438 = 0; _0x75f20438 < RepairTries; _0x75f20438++)
                    {
                        int[] _0xe18722f3 = this._0x969d4b1f(_0x99ed0049, _0x495d3396, _0xc8b44d9e, _0x1d8257d9, _0x2d469ea4);
                        if (_0xe18722f3 == null)
                            break;
                        _0xe1643c2c.Evaluate(_0x99ed0049._0xa8f6c8d4(_0xe18722f3), _0x1bc11be6, _0x01969530);
                        if (_0x01969530.Payout < _0xc75cc4e2)
                            continue;
                        this._0x45c59431[_0x7124db5d] = _0xe18722f3;
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public const int PlannedSpins = 12;
    private int[][] _0x9e72cf11(_0x44a9791c _0x665a55f6)
    {
        int[][] _0xd756755b = new int[PlannedSpins][];
        for (int _0x378fa6fa = 0; _0x378fa6fa < PlannedSpins; _0x378fa6fa++)
        {
            int[] _0x17b73f8d = new int[_0xfcff778c.Reels];
            for (int _0xfc48941f = 0; _0xfc48941f < _0xfcff778c.Reels; _0xfc48941f++)
                _0x17b73f8d[_0xfc48941f] = _0x665a55f6._0x356b07e3(0, _0xfcff778c.StripLength);
            _0xd756755b[_0x378fa6fa] = _0x17b73f8d;
        }

        return _0xd756755b;
    }

    /// <summary>
    /// Spin 1 pays. Not "one of the first three" - the capture photographs a single
    /// spin, so the guarantee has to sit on the one it photographs.
    /// </summary>
    private bool _0xafe1cb3e(_0xfcff778c _0x259f1c19, _0x99dc1491 _0x142841c8, long _0x9104b6b9)
    {
        if (_0x259f1c19 == null || this._0x45c59431 == null || this._0x45c59431[0] == null)
            return false;
        _0xe1643c2c.Evaluate(_0x259f1c19._0xa8f6c8d4(this._0x45c59431[0]), _0x9104b6b9, _0x142841c8);
        return _0x142841c8.Payout > 0L || _0x142841c8.Scatters >= 3;
    }

    /// <summary>True when one spin had to be built rather than drawn.</summary>
    public bool _0xfe076cfe
    {
        get
        {
            return this._0xcce3f7e9;
        }
    }

    private int[][] _0x32451481;
    /// <summary>
    /// The stop positions for a planned spin, or a fresh draw once the plan runs out.
    /// </summary>
    public int[] _0xf7aa5556(int _0x4a41b5a9, _0x44a9791c _0x64d28260)
    {
        if (_0x4a41b5a9 >= 0 && _0x4a41b5a9 < PlannedSpins && this._0x45c59431 != null && this._0x45c59431[_0x4a41b5a9] != null)
            return this._0x45c59431[_0x4a41b5a9];
        int[] _0x16bc36a4 = new int[_0xfcff778c.Reels];
        for (int _0xe7d4f7ad = 0; _0xe7d4f7ad < _0xfcff778c.Reels; _0xe7d4f7ad++)
            _0x16bc36a4[_0xe7d4f7ad] = _0x64d28260._0x356b07e3(0, _0xfcff778c.StripLength);
        return _0x16bc36a4;
    }

    public _0xf46bd032 _0xe2623acb(_0xfcff778c _0xcab4b7f2, _0x44a9791c _0xf40ecde8, long _0x13d1f00a)
    {
        _0x99dc1491 _0x94541075 = new _0x99dc1491();
        this._0x07a9a24b = false;
        this._0xcce3f7e9 = false;
        this._0x32451481 = null;
        this._0x45c59431 = this._0x9e72cf11(_0xf40ecde8);
        for (int _0x9304cbc2 = 0; _0x9304cbc2 < MaxAttempts && !this._0xdf494a00(_0xcab4b7f2, _0x94541075, _0x13d1f00a); _0x9304cbc2++)
            this._0x45c59431 = this._0x9e72cf11(_0xf40ecde8);
        // Whatever the draws left unmet is BUILT, not re-rolled.
        if (_0xcab4b7f2 != null && !this._0xdf494a00(_0xcab4b7f2, _0x94541075, _0x13d1f00a))
        {
            if (!this._0xafe1cb3e(_0xcab4b7f2, _0x94541075, _0x13d1f00a))
            {
                if (this._0xb43833c8(_0xcab4b7f2, _0xf40ecde8, _0x94541075, 0, _0x13d1f00a, 1L))
                    this._0xcce3f7e9 = true;
            }

            if (!this._0x0f92aa75(_0xcab4b7f2, _0x94541075, _0x13d1f00a))
            {
                // Kept out of spins 1-3 so this repair cannot overwrite the early win.
                int _0xfe63af08 = _0xf40ecde8._0x356b07e3(3, PlannedSpins);
                if (this._0xb43833c8(_0xcab4b7f2, _0xf40ecde8, _0x94541075, _0xfe63af08, _0x13d1f00a, _0x13d1f00a * 8L))
                    this._0xcce3f7e9 = true;
            }
        }

        if (!this._0xdf494a00(_0xcab4b7f2, _0x94541075, _0x13d1f00a))
        {
            this._0x07a9a24b = true;
            this._0x32451481 = FallbackBoards();
        }

        {
#if B_LOGS
            {
                Debug.Log($"[plan] repair={this._0xcce3f7e9} fallback={this._0x07a9a24b} bet={_0x13d1f00a}");
            }
#endif
        }

        return this;
    }

    private const int MaxAttempts = 6;
    public bool _0xc2ef362f
    {
        get
        {
            return this._0x07a9a24b;
        }
    }

    /// <summary>
    /// Symbols a repair may aim a line at: Ruby..Diamond. These are the LEAD symbols
    /// only - a wild still counts inside the run (see StopsForLine), it just never gets
    /// picked as the thing being aimed for, because a line pays on the first non-wild
    /// symbol from the left (PaylineEvaluator.LeadSymbol) and aiming at the wild would
    /// make the payout depend on whatever the other reels happened to land on. The
    /// scatter is absent because it never pays a line at all.
    /// </summary>
    private static readonly int[] _0x18964d85 =
    {
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7
    };
    private bool _0xdf494a00(_0xfcff778c _0xdc744b3c, _0x99dc1491 _0xbaf36162, long _0x1853b07f)
    {
        return this._0xafe1cb3e(_0xdc744b3c, _0xbaf36162, _0x1853b07f) && this._0x0f92aa75(_0xdc744b3c, _0xbaf36162, _0x1853b07f);
    }

    private bool _0x0f92aa75(_0xfcff778c _0x7ab0f687, _0x99dc1491 _0xd31cbed9, long _0xc1d08d3c)
    {
        if (_0x7ab0f687 == null || this._0x45c59431 == null)
            return false;
        for (int _0x46429875 = 0; _0x46429875 < PlannedSpins; _0x46429875++)
        {
            _0xe1643c2c.Evaluate(_0x7ab0f687._0xa8f6c8d4(this._0x45c59431[_0x46429875]), _0xc1d08d3c, _0xd31cbed9);
            if (_0xd31cbed9.Payout >= _0xc1d08d3c * 8L)
                return true;
        }

        return false;
    }

    private bool _0x07a9a24b;
}