using DG.Tweening;
using System.IO;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    UserSettings userSettings;

    private void Awake()
    {
        userSettings = GlobalVariables.SOUSERSETTINGS;
        Load_User_Settings();
        Create_Save_Directory();
        SoundRecorder.Play_Music(GlobalVariables.MAINMENUMUSIC);
        DOTween.Init(true, false, LogBehaviour.ErrorsOnly);
        GetComponent<Window>().Call_Window(gameObject.transform);
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
