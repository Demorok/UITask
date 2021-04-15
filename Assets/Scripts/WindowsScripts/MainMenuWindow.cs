using Animations;
using UnityEngine;

public class MainMenuWindow : Window
{
    static GameObject window;

    public override void Call_Window(Transform parent)
    {
        window = Instantiate(GlobalVariables.MAINMENUPREFAB, parent.parent);
        window.Open_Window_X();
    }

    public override void Close_Window()
    {
        Destroy(window);
    }
}
