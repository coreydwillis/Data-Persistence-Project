using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UIElements;

public class SceneChanger : MonoBehaviour
{

    public static SceneChanger Instance;
    public int BestScore;
    public string PlayerName;
    public string BestPlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadVars();
    }

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string PlayerName;
        public string BestPlayerName;
    }

    public void SaveVars()
    {
        SaveData data = new SaveData();
        data.BestScore = BestScore;
        data.PlayerName = PlayerName;
        data.BestPlayerName = BestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadVars()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            PlayerName = data.PlayerName;
            BestPlayerName = data.BestPlayerName;
        }
    }
    static void Quit()
    {
        SceneChanger.Instance.SaveVars();
    }

    [RuntimeInitializeOnLoadMethod]
    static void RunOnStart()
    {
        Application.quitting += Quit;
    }
}
