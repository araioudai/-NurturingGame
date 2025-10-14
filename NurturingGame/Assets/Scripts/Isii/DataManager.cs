using System.IO;
using UnityEngine;
using static Common;

public class DataManager : MonoBehaviour
{
    [SerializeField] private SaveData playerDataList;
    [SerializeField] private PlayerData currentPlayerData;

    [Header("設定")]
    [SerializeField, Range(0, 127)] private int playerNoCurrent = 0; // プレイヤー番号を指定するための変数
    [SerializeField] private JobHandle jobHandle; // 初期職業を指定するための変数
    [SerializeField] private string playerName = "UnityChan"; // プレイヤー名を指定するための変数


    void Start()
    {
        //LoadPlayerData();
    }

    void Update()
    {

    }

    public void LoadPlayerData()
    {
        Debug.Log("LoadPlayerData");
        string filePath = Path.Combine(Application.persistentDataPath, "Players.json");

        if (File.Exists(filePath))
        {
            Debug.Log("LoadPlayerData: " + filePath, this);

            string json = File.ReadAllText(filePath);
            playerDataList = JsonUtility.FromJson<SaveData>(json);
            if (playerDataList.PlayerNoCount > playerNoCurrent && playerNoCurrent >= 0 && playerDataList.playerData[playerNoCurrent] != null)
            {
                Debug.Log("PlayerNo: " + playerNoCurrent, this);
                currentPlayerData = playerDataList.playerData[playerNoCurrent];
            }
            else if (playerNoCurrent >= 0)
            {
                Debug.LogWarning("プレイヤーデータが存在しません: " + playerNoCurrent, this);

                // for (int i = 0; i < playerNoCurrent; i++)
                // {
                //     if (playerDataList.PlayerNoCount > i) continue;
                //     playerDataList.playerData.Add(null);
                //     Debug.LogWarning("プレイヤーデータが存在しません(NULL): " + i, this);
                // }

                PlayerDataCreate();
                playerDataList.playerData.Add(currentPlayerData);
                SavePlayerData(); // 初期データを保存
            }
            else
            {
                Debug.LogWarning("不明な値です: " + playerNoCurrent, this);
            }
        }
        else
        {
            Debug.LogWarning("プレイヤーデータファイルが見つかりません: " + filePath, this);
            PlayerDataCreate();

            // プレイヤーデータリストを初期化
            playerDataList = new SaveData
            {
                playerData = new System.Collections.Generic.List<PlayerData> { currentPlayerData }
            };

            SavePlayerData(); // 初期データを保存
        }


        // string filePath = Path.Combine(Application.persistentDataPath, "Player" + playerNo + ".json");
        // if (File.Exists(filePath))
        // {
        //     Debug.Log("LoadPlayerData: " + filePath);
        //     string json = File.ReadAllText(filePath);
        //     currentPlayerData = JsonUtility.FromJson<PlayerData>(json);
        // }
        // else
        // {
        //     string firstStatusPath = Resources.Load<TextAsset>($"JsonData/{jobHandle}").text;
        //     if (string.IsNullOrEmpty(firstStatusPath))
        //     {
        //         Debug.LogError("ジョブの初期ステータスデータの読み込みに失敗しました: " + jobHandle);
        //         return;
        //     }

        //     Debug.LogWarning("プレイヤーデータファイルが見つかりません: " + filePath);
        //     // 初期データを設定するなどの処理を行う
        //     currentPlayerData = new PlayerData
        //     {
        //         name = playerName,
        //         job = jobHandle,
        //         level = 1,
        //         exp = 0,
        //         firstStatus = JsonUtility.FromJson<Status>(firstStatusPath),
        //         addStatus = new Status(),
        //         statusPoints = 0
        //         //skills = new List<string>()
        //     };
        //     SavePlayerData(); // 初期データを保存
        // }
    }


    void PlayerDataCreate()
    {
        string firstStatusPath = Resources.Load<TextAsset>($"JsonData/{jobHandle}").text;
        if (string.IsNullOrEmpty(firstStatusPath))
        {
            Debug.LogError("ジョブの初期ステータスデータの読み込みに失敗しました: " + jobHandle, this);
            return;
        }

        // 初期データを設定するなどの処理を行う
        currentPlayerData = new PlayerData
        {
            name = playerName,
            job = jobHandle,
            level = 1,
            exp = 0,
            firstStatus = JsonUtility.FromJson<Status>(firstStatusPath),
            addStatus = new Status(),
            statusPoints = 0
            //skills = new List<string>()
        };
    }









    [ContextMenu("SavePlayerData")]
    void SavePlayerData()
    {
        Debug.Log("SavePlayerData");

        playerDataList.currentPlayerNo = playerNoCurrent;
        playerDataList.PlayerNoCount = playerDataList.playerData.Count;

        string filePath = Path.Combine(Application.persistentDataPath, "Players.json");
        string json = JsonUtility.ToJson(playerDataList, true);
        File.WriteAllText(filePath, json);

        //string filePath = Path.Combine(Application.persistentDataPath, "Player" + playerNo + ".json");
        // string json = JsonUtility.ToJson(currentPlayerData, true);
        // File.WriteAllText(filePath, json);
    }







}
