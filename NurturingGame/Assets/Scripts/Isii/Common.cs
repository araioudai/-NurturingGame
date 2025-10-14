using System;
using System.Collections.Generic;

public class Common
{
    #region PlayerData
    /// <summary>
    /// 職業ハンドル
    /// </summary>
    [Serializable]
    public enum JobHandle
    {
        Knight,
        Mage,
        Fighter,
        Thief,
        Gambler
    }

    /// <summary>
    /// 追加ステータス json用クラス
    /// </summary>
    [Serializable]
    public class Status
    {
        public int HP;
        public int MP;
        public int POW;
        public int INT;
        public int DEF;
        public int AGI;
        public int LUK;
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
        public Status firstStatus;
        public Status addStatus;
        public int statusPoints;
        //public List<string> skills;
    }

    #endregion

    //////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// データ保存用
    /// </summary>
    [Serializable]
    public class SaveData
    {
        public int currentPlayerNo;
        public int PlayerNoCount;
        public List<PlayerData> playerData = new();
    }



    //////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// 設定データ
    /// </summary>
    #region SettingData
    // データ
    public static string settingFilePath = "Setting.json";
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

    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Title用
    /// </summary>
    public enum TitleSceneState
    {
        Title,
        PlayGame,
        Setting,
        Exit
    }

}
