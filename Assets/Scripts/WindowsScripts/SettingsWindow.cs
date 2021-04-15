using UnityEngine;
using Animations;

public class SettingsWindow : Window
{
    static float currentScale;
    static GameObject window;

    public override void Call_Window(Transform parent)
    {
        window = Instantiate(GlobalVariables.SETTINGSPREFAB, parent);
        currentScale = Time.timeScale;
        window.Open_Window_X(() => Time.timeScale = 0);
    }

    public override void Close_Window()
    {
        Time.timeScale = currentScale;
        window.Destroy_Window_X();
    }
}
