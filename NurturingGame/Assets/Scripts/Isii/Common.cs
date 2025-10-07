using System;
using System.Collections.Generic;
using Unity.Jobs;

public class Common
{
    #region PlayerData
    /// <summary>
    /// 職業ハンドル
    /// </summary>
    [Serializable]
    public enum JobHandle
    {
        None,
        Warrior,
        Mage,
        Archer
    }

    /// <summary>
    /// ステータス json用クラス
    /// </summary>
    [Serializable]
    public class Status
    {
        public int HP;
        public int MP;
        public int ATK;
        public int DEF;
        public int INT;
        public int AGI;
    }

    /// <summary>
    /// プレイヤーデータ json用クラス
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        public string name;
        public JobHandle job;
        public int level;
        public int exp;
        public Status status;
        public int statusPoints;
        //public List<string> skills;
    }

    #endregion

//////////////////////////////////////////////////////////////////////////////




    /// <summary>
    /// 設定データ
    /// </summary>
    #region SettingData
    // データ
    public static string settingFilePath = "Setting.json";
    public static string playerFilePath = "Player.json";
    public SettingData settingData;
    public PlayerData playerData;

    /// <summary>
    /// 設定データ json用クラス
    /// </summary>
    [Serializable]
    public class SettingData
    {
        public float bgmVolume = 0.5f; // BGM音量 (0.0 - 1.0)
        public float seVolume = 0.5f;  // SE音量 (0.0 - 1.0)
        public bool isFullScreen = false; // フルスクリーンモード
        //public int resolutionIndex = 0; // 解像度インデックス
    }




    #endregion








}
