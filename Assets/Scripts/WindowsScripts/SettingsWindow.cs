using UnityEngine;
using Animations;

public class SettingsWindow : Window
{
    static GameObject window;

    public override void Call_Window(Transform parent)
    {
        base.Call_Window(parent);
        window = Instantiate(GlobalVariables.SETTINGSPREFAB, parent);
        window.Open_Window_X(() => Time.timeScale = 0);
    }

    public override void Close_Window()
    {
        Time.timeScale = 1;
        window.Destroy_Window_X(() => base.Close_Window());
    }
}
