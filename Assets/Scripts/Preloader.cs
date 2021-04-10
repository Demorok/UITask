using System.IO;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    [SerializeField] GameObject startScreen;
    [SerializeField] UserSettings userSettings;

    public static Sprite[] bodies;
    public static Sprite[] faces;
    public static Sprite[] hairs;
    public static Sprite[] kits;

    private void Awake()
    {
        Load_User_Settings();
        Load_Customer_Constructor();
        Create_Save_Directory();
        startScreen.SetActive(true);
        SoundRecorder.Play_Music(GlobalVariables.MAINMENUMUSIC);
    }

    void Create_Save_Directory()
    {
        Directory.CreateDirectory(Application.persistentDataPath + GlobalVariables.DATAPATH);
    }

    void Load_User_Settings()
    {
        string destination = Application.persistentDataPath + GlobalVariables.SETTINGSPATH;
        SaveLoad.Load_Data(destination, userSettings);

        QualitySettings.SetQualityLevel(userSettings.qualityPresetValue, true);
    }

    void Load_Customer_Constructor()
    {
        bodies = Resources.LoadAll<Sprite>(GlobalVariables.CUSTOMERBODIES);
        faces = Resources.LoadAll<Sprite>(GlobalVariables.CUSTOMERFACES);
        hairs = Resources.LoadAll<Sprite>(GlobalVariables.CUSTOMERHAIRS);
        kits = Resources.LoadAll<Sprite>(GlobalVariables.CUSTOMERKITS);
    }
}
