using System.IO;
using UnityEngine;
using static Common;

public class DataManager : MonoBehaviour
{
    #region プライベート変数
    [SerializeField] private PlayerData playerData;

    // test
    [SerializeField] int testStatusNo = 0;

    #endregion

    #region パブリック変数

    #endregion








    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadPlayerData();
        Debug.Log("Player Name: " + playerData.name);
        Debug.Log("Player Job: " + playerData.job);
        Debug.Log("Player Level: " + playerData.level);
        Debug.Log("Player EXP: " + playerData.exp);
        Debug.Log("Player HP: " + playerData.status.HP);
        Debug.Log("Player MP: " + playerData.status.MP);
        Debug.Log("Player ATK: " + playerData.status.ATK);
        Debug.Log("Player DEF: " + playerData.status.DEF);
        Debug.Log("Player INT: " + playerData.status.INT);
        Debug.Log("Player AGI: " + playerData.status.AGI);
        Debug.Log("Player Status Points: " + playerData.statusPoints);
        //foreach (var skill in playerData.skills)
        //{
        //    Debug.Log("Player Skill: " + skill);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // test
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayerData();
            Debug.Log("Player data saved.");
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            playerData.level += 1;
            playerData.statusPoints += 5; // レベルアップ時にステータスポイントを5増加
            SavePlayerData();
            Debug.Log("Player leveled up to " + playerData.level + ". Status points increased to " + playerData.statusPoints);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            string[] statuses = { "HP", "MP", "ATK", "DEF", "INT", "AGI" };
            if (testStatusNo >= 0 && testStatusNo < statuses.Length)
            {
                bool result = IncreaseStatus(statuses[testStatusNo]);
                if (result)
                {
                    Debug.Log(statuses[testStatusNo] + " increased successfully.");
                }
            }
            else
            {
                Debug.LogWarning("Invalid testStatusNo: " + testStatusNo);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            testStatusNo += 1;
            if (testStatusNo > 5) testStatusNo = 5;
            Debug.Log("Test status set to " + testStatusNo);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            testStatusNo -= 1;
            if (testStatusNo < 0) testStatusNo = 0;
            Debug.Log("Test status set to " + testStatusNo);
        }


    }

    void LoadPlayerData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, playerFilePath);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.LogWarning("Player data file not found: " + filePath);
            // 初期データを設定するなどの処理を行う
            playerData = new PlayerData
            {
                name = "Hero",
                job = JobHandle.Warrior,
                level = 1,
                exp = 0,
                status = new Status
                {
                    HP = 100,
                    MP = 50,
                    ATK = 10,
                    DEF = 5,
                    INT = 3,
                    AGI = 7
                },
                statusPoints = 0
                //skills = new List<string>()
            };
            SavePlayerData(); // 初期データを保存
        }
    }


    void SavePlayerData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, playerFilePath);
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(filePath, json);
    }

    // プレイヤーのステータスポイントを使用してステータスを上げるメソッド
    public bool IncreaseStatus(string statusName)
    {
        if (playerData.statusPoints <= 0)
        {
            Debug.LogWarning("Not enough status points.");
            return false;
        }

        switch (statusName)
        {
            case "HP":
                playerData.status.HP += 10; // HPを10増加
                break;
            case "MP":
                playerData.status.MP += 5; // MPを5増加
                break;
            case "ATK":
                playerData.status.ATK += 2; // ATKを2増加
                break;
            case "DEF":
                playerData.status.DEF += 2; // DEFを2増加
                break;
            case "INT":
                playerData.status.INT += 2; // INTを2増加
                break;
            case "AGI":
                playerData.status.AGI += 2; // AGIを2増加
                break;
            default:
                Debug.LogWarning("Invalid status name: " + statusName);
                return false;
        }

        playerData.statusPoints -= 1; // ステータスポイントを1減少
        SavePlayerData(); // データを保存
        Debug.Log(statusName + " increased. Remaining status points: " + playerData.statusPoints);
        return true;
    }



















}
