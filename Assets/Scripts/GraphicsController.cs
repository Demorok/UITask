using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsController : MonoBehaviour
{
    [SerializeField]
    Slider shadowQualitySlider;

    [SerializeField]
    Slider shadowResolutionSlider;

    [SerializeField]
    Dropdown resolutionDropdown;

    [SerializeField]
    Dropdown qualityDropdown;

    [SerializeField]
    Toggle fullScreen;

    [SerializeField]
    Button confirmButton;

    [SerializeField]
    GraphicsQualityPreset[] graphicsQualityPresets;

    [SerializeField]
    UserSettings userSettings;

    CustomGraphicsQualityPreset customPreset;
    int customPresetValue;

    GraphicsQualityPreset currentPreset;

    bool switchingPreset;
    bool customEdit;

    static Resolution[] RESOLUTIONS = new Resolution[]
    {
        new Resolution(1280, 720),
        new Resolution(1600, 900),
        new Resolution(1920, 1080),
    };

    static ShadowQuality[] SHADOWQUALITIES = new ShadowQuality[]
        {
            ShadowQuality.Disable,
            ShadowQuality.HardOnly,
            ShadowQuality.All
        };
    static ShadowResolution[] SHADOWRESOUTIONS = new ShadowResolution[]
        {
            ShadowResolution.Low,
            ShadowResolution.Medium,
            ShadowResolution.High,
            ShadowResolution.VeryHigh
        };

    private void Awake()
    {
        Initialise();
        Set_User_Settings();
    }

    void Initialise()
    {
        Load_User_Settings();
        shadowQualitySlider.maxValue = SHADOWQUALITIES.Length - 1;
        shadowResolutionSlider.maxValue = SHADOWRESOUTIONS.Length - 1;

        List<string> resolutionsList = new List<string>();
        foreach(Resolution res in RESOLUTIONS)
        {
            resolutionsList.Add(res.ToString());
        }
        resolutionDropdown.AddOptions(resolutionsList);

        List<string> presetsList = new List<string>();

        for(int i = 0; i< graphicsQualityPresets.Length; i++)
        {
            GraphicsQualityPreset preset = graphicsQualityPresets[i];
            presetsList.Add(preset.Get_presetName());
            if (preset.GetType() == typeof(CustomGraphicsQualityPreset))
            {
                customPresetValue = i;
                customPreset = (CustomGraphicsQualityPreset)preset;
            }
        }
        qualityDropdown.AddOptions(presetsList);
        Load_Custom_Preset();
        Set_Current_Preset();
    }

    void Set_Current_Preset()
    {
        if (userSettings.graphicsQuality == customPreset.Get_presetName())
            currentPreset = customPreset;
        else
            for (int i = 0; i < graphicsQualityPresets.Length; i++)
            {
                if (userSettings.graphicsQuality == graphicsQualityPresets[i].Get_presetName())
                {
                    currentPreset = customPreset;
                    break;
                }
            }
    }

    void Set_User_Settings()
    {
        if (userSettings.graphicsQuality == customPreset.Get_presetName())
            qualityDropdown.value = customPresetValue;
        else
            for (int i = 0; i < graphicsQualityPresets.Length; i++)
            {
                if (userSettings.graphicsQuality == graphicsQualityPresets[i].Get_presetName())
                {
                    qualityDropdown.value = i;
                    break;
                }
                else if (i == graphicsQualityPresets.Length - 1)
                    qualityDropdown.value = 0;
            }
        Confirm_Changes();
        Save_User_Settings();
    }

    public void Confirm_Changes()
    {
        QualitySettings.shadows = SHADOWQUALITIES[(int)shadowQualitySlider.value];
        QualitySettings.shadowResolution = SHADOWRESOUTIONS[(int)shadowResolutionSlider.value];

        Resolution res = RESOLUTIONS[resolutionDropdown.value];
        Screen.SetResolution(res.width, res.height, fullScreen.isOn);

        if (qualityDropdown.value == customPresetValue)
        {
            Change_Custom_Preset();
            userSettings.graphicsQuality = customPreset.Get_presetName();
            currentPreset = customPreset;
        }
        else
        {
            currentPreset = graphicsQualityPresets[qualityDropdown.value];
            userSettings.graphicsQuality = currentPreset.Get_presetName();
        }

        Save_User_Settings();
        confirmButton.gameObject.SetActive(false);
    }

    public void Preset_Changed()
    {
        if (customEdit)
            return;
        confirmButton.gameObject.SetActive(true);
        Switch_Preset();
    }

    public void Custom_Changes_Made()
    {
        if (switchingPreset)
            return;
        customEdit = true;
        qualityDropdown.value = customPresetValue;
        confirmButton.gameObject.SetActive(true);
        customEdit = false;
    }

    void Switch_Preset()
    {
        switchingPreset = true;
        GraphicsQualityPreset preset = graphicsQualityPresets[qualityDropdown.value];
        shadowQualitySlider.value = Mathf.Min(preset.Get_shadowQualityValue(), shadowQualitySlider.maxValue);
        shadowResolutionSlider.value = Mathf.Min(preset.Get_shadowResolutionValue(), shadowResolutionSlider.maxValue);
        resolutionDropdown.value = preset.Get_resolutionValue();
        switchingPreset = false;
    }

    void Change_Custom_Preset()
    {
        customPreset.Set_resolutionValue(resolutionDropdown.value);
        customPreset.Set_shadowQualityValue((int)shadowQualitySlider.value);
        customPreset.Set_shadowResolutionValue((int)shadowResolutionSlider.value);
        Save_Custom_Preset();
    }

    void Save_User_Settings()
    {
        Debug.Log("save user settings");
        string destination = Application.persistentDataPath + "/settings.cfg";
        SaveLoad.Save_Data(destination, userSettings);
    }

    void Load_User_Settings()
    {
        string destination = Application.persistentDataPath + "/settings.cfg";
        Debug.Log("load user settings");
        SaveLoad.Load_Data(destination, userSettings);
    }

    void Save_Custom_Preset()
    {
        Debug.Log("save custom preset");
        string destination = Application.persistentDataPath + "/custom.graph";
        SaveLoad.Save_Data(destination, customPreset);
    }

    void Load_Custom_Preset()
    {
        Debug.Log("load custom preset");
        string destination = Application.persistentDataPath + "/custom.graph";
        SaveLoad.Load_Data(destination, customPreset);
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

