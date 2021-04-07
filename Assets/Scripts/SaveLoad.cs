using UnityEngine;
using System.IO;
using System;

public class SaveLoad : MonoBehaviour
{
    public static void Save_Data(string destination, object data)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(destination, false, System.Text.Encoding.UTF8))
            {
                string json = JsonUtility.ToJson(data);
                Debug.Log("json" + json);
                sw.Write(json);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public static void Load_Data(string destination, object data)
    {
        if (!File.Exists(destination))
            return;
        string json;
        try
        {
            using (StreamReader sr = new StreamReader(destination, System.Text.Encoding.UTF8))
            {
                json = sr.ReadToEnd();
                Debug.Log("json" + json);
            }
            JsonUtility.FromJsonOverwrite(json, data);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
