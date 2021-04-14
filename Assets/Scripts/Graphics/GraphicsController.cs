using UnityEngine;
using UnityEngine.UI;

public class GraphicsController : MonoBehaviour
{
    [SerializeField] Dropdown resolutionDropdown;
    [SerializeField] Dropdown qualityDropdown;
    [SerializeField] Toggle fullScreen;
    [SerializeField] Button confirmButton;

    UserSettings userSettings;

    bool setUserSettings;

    private void Awake()
    {
        userSettings = GlobalVariables.SOUSERSETTINGS;
        Set_User_Settings();
    }

    void Set_User_Settings()
    {
        setUserSettings = true;
        qualityDropdown.value = userSettings.qualityPresetValue;
        resolutionDropdown.value = userSettings.resolutionValue;
        fullScreen.isOn = userSettings.fullScreen;
        setUserSettings = false;
    }

    void Update_User_Settings()
    {
        userSettings.qualityPresetValue = qualityDropdown.value;
        userSettings.resolutionValue = resolutionDropdown.value;
        userSettings.fullScreen = fullScreen.isOn;
        Save_User_Settings();
    }

    public void Confirm_Changes()
    {
        Resolution res = GlobalVariables.RESOLUTIONS[resolutionDropdown.value];
        Screen.SetResolution(res.width, res.height, fullScreen.isOn);
        QualitySettings.SetQualityLevel(qualityDropdown.value, true);
        Update_User_Settings();
        confirmButton.gameObject.SetActive(false);
    }

    public void Changes_Made()
    {
        if (setUserSettings)
            return;
        confirmButton.gameObject.SetActive(true);
        SoundRecorder.Play_Effect(GlobalVariables.CLICKEFFECT);
    }

    void Save_User_Settings()
    {
        string destination = Application.persistentDataPath + GlobalVariables.SETTINGSPATH;
        SaveLoad.Save_Data(destination, userSettings);
    }
}

