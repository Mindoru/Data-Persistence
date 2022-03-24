using System.IO;
using UnityEngine;

public static class SaveManager
{
    public static int BestScore;
    public static string BestScoreName;

    [System.Serializable]
    class SaveData
    {
        public int LevelScore;
        public string PlayerName;
    }
    
    public static void SaveScore(int score)
    {
        SaveData data = new SaveData();
        data.LevelScore = score;
        data.PlayerName = UIManager.Username;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bestscore.save", json);
    }

    public static dynamic[] LoadScore()
    {
        string path = Application.persistentDataPath + "/bestscore.save";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.LevelScore;
            BestScoreName = data.PlayerName;
        }
        dynamic[] allScore = {BestScoreName, BestScore};
        return allScore;
    }
}