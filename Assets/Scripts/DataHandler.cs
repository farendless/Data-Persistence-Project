using System.IO;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public static DataHandler instance;

    public int bestScore;
    public string fromUser;
    public string currentUser;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string fromUser;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.fromUser = currentUser;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            fromUser = data.fromUser;
        }
    }
}
