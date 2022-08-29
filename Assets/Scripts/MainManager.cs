using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;

    public string playerNameActual;
    public int maxScore;
    public string playerNameMaxScore;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerNameMaxScore;
        public int maxScore;
    }

    public void SaveDatas()
    {
        SaveData data = new SaveData();
        data.playerNameMaxScore = playerNameMaxScore;
        data.maxScore = maxScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadDatas()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerNameMaxScore = data.playerNameMaxScore;
            maxScore = data.maxScore;
        }
    }



}
