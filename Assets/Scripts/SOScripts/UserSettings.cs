using UnityEngine;

[CreateAssetMenu(fileName = "new User Settings", menuName = "User Settings", order = 55), System.Serializable]
public class UserSettings : ScriptableObject
{
    public SoundSettings soundSettings;
    public int qualityPresetValue;
    public int resolutionValue;
    public bool fullScreen;
    public string languagePack;
}
