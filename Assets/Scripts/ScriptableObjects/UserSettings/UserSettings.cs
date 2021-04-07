using UnityEngine;

[CreateAssetMenu(fileName = "new User Settings", menuName = "User Settings", order = 55), System.Serializable]
public class UserSettings : ScriptableObject
{
    public SoundSettings soundSettings;
    public string graphicsQuality;
    public string languagePack;
}
