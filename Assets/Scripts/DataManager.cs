using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string BestUserName;
        public int BestScore;
    }

    public static DataManager Instance;

    public string UserName;

    public string BestUserName;

    public int BestScore = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadRecord();
    }

    public void SaveRecord(int score)
    {
        SaveData data = new()
        {
            BestUserName = UserName,
            BestScore = score
        };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestUserName = data.BestUserName;
            BestScore = data.BestScore;
        }
    }
}
