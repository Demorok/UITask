using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
    static GameObject settings;
    static float currentScale;

    public static void Call_Settings(Transform transform)
    {
        settings = Instantiate<GameObject>(GlobalVariables.SETTINGSPREFAB, transform);
        currentScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public static void Close_Settings()
    {
        Destroy(settings);
        Time.timeScale = currentScale;
    }
}
