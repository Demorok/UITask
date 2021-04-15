using UnityEngine;

public abstract class Window : MonoBehaviour
{
    protected static float timeScale;
    public virtual void Call_Window(Transform parent)
    {
        timeScale = Time.timeScale;
        Time.timeScale = 1;
    }
    public virtual void Close_Window()
    {
        Time.timeScale = timeScale;
    }
}
