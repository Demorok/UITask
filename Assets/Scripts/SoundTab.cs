using UnityEngine;
using UnityEngine.UI;

public class SoundTab : MonoBehaviour
{    [SerializeField] Slider effectsVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] UserSettings userSettings;

    bool setUserSettings;

    private void Awake()
    {
        Set_User_Settings();
    }

    void Set_User_Settings()
    {
        setUserSettings = true;
        effectsVolumeSlider.value = userSettings.soundSettings.effectsVolume;
        musicVolumeSlider.value = userSettings.soundSettings.musicVolume;
        setUserSettings = false;
    }

    public void Change_Volume_Settings()
    {
        if (setUserSettings)
            return;
        userSettings.soundSettings.effectsVolume = effectsVolumeSlider.value;
        userSettings.soundSettings.musicVolume = musicVolumeSlider.value;
        SoundRecorder.Play_Effect(GlobalVariables.CLICKEFFECT);
    }


}

[System.Serializable]
public class SoundSettings
{
    [Range(0, 1f)] public float effectsVolume;
    [Range(0, 1f)] public float musicVolume;

    public SoundSettings(float effectsVolume, float musicVolume)
    {
        this.effectsVolume = effectsVolume;
        this.musicVolume = musicVolume;
    }
}
