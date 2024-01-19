using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static void Save()
    {
        PlayerData _savedData = new PlayerData();
        _savedData.SavedScore = GameManager.Instance.Score;
        string _json = JsonUtility.ToJson(_savedData);
        File.WriteAllText(Application.dataPath + "/saveFile.json", _json);
        Debug.Log(_json);
    }

    public static string Load()
    {
        if (File.Exists(Application.dataPath + "/saveFile.json"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/saveFile.json");
            return saveString;
        }
        else
        {
            return null;
        }
    }
}

public class PlayerData
{
    public float SavedScore;
}
