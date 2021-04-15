using UnityEngine;
using Animations;

public class CabinetWindow : Window
{
    static GameObject window;
    CustomerQueue queue;
    public override void Call_Window(Transform parent)
    {
        base.Call_Window(parent);
        window = Instantiate(GlobalVariables.CABINETPREFAB, parent.parent);
        queue = window.GetComponent<CustomerQueue>();
        window.Open_Window_X(() => queue.New_Cabinet());
    }

    public void Load_Window(Transform parent)
    {
        base.Call_Window(parent);
        window = Instantiate(GlobalVariables.CABINETPREFAB, parent.parent);
        queue = window.GetComponent<CustomerQueue>();
        window.Open_Window_X(() => queue.Load_Progress());
    }

    public override void Close_Window()
    {
        queue = window.GetComponent<CustomerQueue>();
        queue.Clear_Queue();
        Time.timeScale = 1;
        Destroy(window);
    }
}
