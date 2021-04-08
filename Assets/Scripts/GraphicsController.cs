using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsController : MonoBehaviour
{
    [SerializeField] Dropdown resolutionDropdown;
    [SerializeField] Dropdown qualityDropdown;
    [SerializeField] Toggle fullScreen;
    [SerializeField] Button confirmButton;

    [SerializeField] UserSettings userSettings;

    static Resolution[] RESOLUTIONS = new Resolution[]
    {
        new Resolution(1280, 720),
        new Resolution(1600, 900),
        new Resolution(1920, 1080),
    };

    private void Awake()
    {
        Initialise();
    }

    void Initialise()
    {
        List<string> resolutionsList = new List<string>();
        foreach(Resolution res in RESOLUTIONS)
        {
            resolutionsList.Add(res.ToString());
        }
        resolutionDropdown.AddOptions(resolutionsList);

        List<string> presetsList = new List<string>();

        foreach(string name in QualitySettings.names)
        {
            presetsList.Add(name);
        }
        qualityDropdown.AddOptions(presetsList);

        Set_User_Settings();
    }

    void Set_User_Settings()
    {
        qualityDropdown.value = userSettings.qualityPresetValue;
        resolutionDropdown.value = userSettings.resolutionValue;
        fullScreen.isOn = userSettings.fullScreen;
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
        Resolution res = RESOLUTIONS[resolutionDropdown.value];
        Screen.SetResolution(res.width, res.height, fullScreen.isOn);
        QualitySettings.SetQualityLevel(qualityDropdown.value, true);

        Update_User_Settings();
        confirmButton.gameObject.SetActive(false);
    }

    public void Changes_Made()
    {
        confirmButton.gameObject.SetActive(true);
    }

    void Save_User_Settings()
    {
        string destination = Application.persistentDataPath + GlobalVariables.SETTINGSPATH;
        SaveLoad.Save_Data(destination, userSettings);
    }
}
class Resolution
{
    public int width, height;

    public Resolution (int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public override string ToString()
    {
        return width.ToString() + "x" + height.ToString();
    }
}

