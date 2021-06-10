using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string currentName;
    public string highScoreName;
    public int highScore;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveHighScore() // stores name savedata
    {
        SaveData data = new SaveData();
        data.name = highScoreName;
        data.score = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore() // loads name savedata
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.score;
            highScoreName = data.name;
        }
    }
}
