using UnityEngine;
using Animations;

public class SettingsWindow : MonoBehaviour
{
    static GameObject settings;
    static float currentScale;

    public static void Call_Settings(Transform transform)
    {
        settings = Instantiate(GlobalVariables.SETTINGSPREFAB, transform);
        currentScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public static void Close_Settings()
    {
        Time.timeScale = currentScale;
        settings.Destroy_Window_X();
    }
}
