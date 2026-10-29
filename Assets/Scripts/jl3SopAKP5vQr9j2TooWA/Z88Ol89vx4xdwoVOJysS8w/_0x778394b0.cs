using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class _0x778394b0
{
    public static class _0xb75f6257
    {
        public static readonly int PAUSE = 6;
        public static readonly int WIN = 7;
        public static readonly int LOSE = 8;
    }

    public static class _0x17f70ae0
    {
        public static int _0x7d96fa30
        {
            get
            {
                if (!PlayerPrefs.HasKey(_0xdd499eef._0xe105f1bc(new byte[5] { 233, 197, 195, 196, 217 }, 170)))
                    PlayerPrefs.SetInt(_0xdd499eef._0xe105f1bc(new byte[5] { 131, 175, 169, 174, 179 }, 192), 0);
                return PlayerPrefs.GetInt(_0xdd499eef._0xe105f1bc(new byte[5] { 32, 12, 10, 13, 16 }, 99));
            }

            set
            {
                PlayerPrefs.SetInt(_0xdd499eef._0xe105f1bc(new byte[5] { 74, 102, 96, 103, 122 }, 9), value);
                _0x764d1f95.Instance._0xf0e847b3();
            }
        }
    }

    public static class _0x147ecbe6
    {
        public static readonly int SPLASH = 0;
        public static readonly int DEFAULT = 1;
        public static readonly int EMPTY = 2;
        public static readonly int TUTORIAL0 = 13;
        public static readonly int TUTORIAL1 = 14;
        public static readonly int TUTORIAL2 = 15;
        public static readonly int TUTORIAL3 = 16;
        public static readonly int TUTORIAL4 = 17;
        public static readonly int TUTORIAL5 = 18;
        public static readonly int TUTORIAL6 = 19;
    }

    public static class _0xb8e5a259
    {
        public static readonly int SCENE_0 = 0;
        public static readonly int SCENE_1 = 1;
    }

    public class _0xb76ba2c4
    {
        private static readonly _0xb76ba2c4 _0x81e6b75c = new();
        public static readonly _0xb76ba2c4[] ALL_SCENES_SETTING_SINGLETONS =
        {
            _0x81e6b75c,
            _0x81e6b75c,
            _0x81e6b75c,
        };
        private int _0x82f649d3 => 0;
        private int _0x13fa56f5 => 10;
        private string _0x3083f597 => _0xdd499eef._0xe105f1bc(new byte[4] { 91, 115, 120, 99 }, 22);
        private string _0x319d400e => _0xdd499eef._0xe105f1bc(new byte[8] { 191, 182, 165, 182, 191, 136, 195, 142 }, 243);

        private int _0x8399e07f
        {
            get
            {
                if (!PlayerPrefs.HasKey(_0xdd499eef._0xe105f1bc(new byte[25] { 101, 83, 84, 84, 67, 72, 82, 97, 74, 73, 68, 71, 74, 101, 78, 71, 86, 82, 67, 84, 111, 72, 66, 67, 94 }, 38)))
                    PlayerPrefs.SetInt(_0xdd499eef._0xe105f1bc(new byte[25] { 160, 150, 145, 145, 134, 141, 151, 164, 143, 140, 129, 130, 143, 160, 139, 130, 147, 151, 134, 145, 170, 141, 135, 134, 155 }, 227), 0);
                return PlayerPrefs.GetInt(_0xdd499eef._0xe105f1bc(new byte[25] { 124, 74, 77, 77, 90, 81, 75, 120, 83, 80, 93, 94, 83, 124, 87, 94, 79, 75, 90, 77, 118, 81, 91, 90, 71 }, 63));
            }

            set => PlayerPrefs.SetInt(_0xdd499eef._0xe105f1bc(new byte[25] { 238, 216, 223, 223, 200, 195, 217, 234, 193, 194, 207, 204, 193, 238, 197, 204, 221, 217, 200, 223, 228, 195, 201, 200, 213 }, 173), value);
        }

        public int _0xea5c058b
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0x3083f597}CurrentLevelIndex"))
                    PlayerPrefs.SetInt($"{this._0x3083f597}CurrentLevelIndex", 0);
                return PlayerPrefs.GetInt($"{this._0x3083f597}CurrentLevelIndex");
            }

            set => PlayerPrefs.SetInt($"{this._0x3083f597}CurrentLevelIndex", value);
        }

        public int _0x8de9c9bc
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0x3083f597}BestScore"))
                    this._0x8de9c9bc = 0;
                return PlayerPrefs.GetInt($"{this._0x3083f597}BestScore");
            }

            set => PlayerPrefs.SetInt($"{this._0x3083f597}BestScore", value);
        }

        public bool _0x31ee9a9a
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0x3083f597}IsGameTutorPassed"))
                    PlayerPrefs.SetInt($"{this._0x3083f597}IsGameTutorPassed", Convert.ToInt32(false));
                return PlayerPrefs.GetInt($"{this._0x3083f597}IsGameTutorPassed") == 1;
            }

            set => PlayerPrefs.SetInt($"{this._0x3083f597}IsGameTutorPassed", Convert.ToInt32(value));
        }
    }
}

internal static class _0xdd499eef
{
    internal static string _0xe105f1bc(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}