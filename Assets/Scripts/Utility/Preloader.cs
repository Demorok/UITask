using DG.Tweening;
using System.IO;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    [SerializeField] GameObject startScreen;

    UserSettings userSettings;

    private void Awake()
    {
        userSettings = GlobalVariables.SOUSERSETTINGS;
        Load_User_Settings();
        Create_Save_Directory();
        startScreen.SetActive(true);
        SoundRecorder.Play_Music(GlobalVariables.MAINMENUMUSIC);
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly);
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
}
