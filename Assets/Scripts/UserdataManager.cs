using System;
using System.IO;
using UnityEngine;

public class UserdataManager : MonoBehaviour
{
    public static UserdataManager Instance;

    public string CurrentUsername;
    public string HighScoreUsername;
    public int Score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadData();
    }

    [Serializable]
    private class HighScoreData
    {
        public string UserName;
        public int HighScore;
    }

    public void SaveData()
    {
        HighScoreData data = new HighScoreData();
        data.UserName = HighScoreUsername;
        data.HighScore = Score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public void LoadData() 
    {
        string pathToSave = Application.persistentDataPath + "/save.json";

        if(File.Exists(pathToSave))
        {
            string json = File.ReadAllText(pathToSave);

            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);
            HighScoreUsername = data.UserName;
            Score = data.HighScore;
        }
    }
}
