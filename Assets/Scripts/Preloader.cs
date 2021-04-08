using UnityEngine;

public class Preloader : MonoBehaviour
{
    [SerializeField] GameObject startScreen;
    [SerializeField] UserSettings userSettings;
    [SerializeField] AudioSource effectsSound;
    [SerializeField] AudioSource musicSound;

    public static Sprite[] bodies;
    public static Sprite[] faces;
    public static Sprite[] hairs;
    public static Sprite[] kits;

    private void Awake()
    {
        Load_User_Settings();
        Load_Customer_Constructor();
        startScreen.SetActive(true);
    }

    void Load_User_Settings()
    {
        string destination = Application.persistentDataPath + GlobalVariables.SETTINGSPATH;
        SaveLoad.Load_Data(destination, userSettings);

        QualitySettings.SetQualityLevel(userSettings.qualityPresetValue, true);
        effectsSound.volume = userSettings.soundSettings.effectsVolume;
        musicSound.volume = userSettings.soundSettings.musicVolume;
    }

    void Load_Customer_Constructor()
    {
        bodies = Resources.LoadAll<Sprite>(GlobalVariables.CUSTOMERBODIES);
        faces = Resources.LoadAll<Sprite>(GlobalVariables.CUSTOMERFACES);
        hairs = Resources.LoadAll<Sprite>(GlobalVariables.CUSTOMERHAIRS);
        kits = Resources.LoadAll<Sprite>(GlobalVariables.CUSTOMERKITS);
    }
}
