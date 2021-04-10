using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SettingsLanguage : LanguageController
{
    [SerializeField] Dropdown languageDropdown;

    [SerializeField] Dropdown qualityDropdown;

    [SerializeField] Text settingsTitle;

    [SerializeField] Text settingsBack;

    #region SoundTab
    [Header("Sound Tab")]

    [SerializeField]
    Text settingsSoundTab;

    [SerializeField]
    Text settingsEffectsVolume;

    [SerializeField]
    Text settingsMusicVolume;

    #endregion

    #region GraphicsTab
    [Header("Graphics Tab")]

    [SerializeField]
    Text settingsGraphicsTab;

    [SerializeField]
    Text settingsQuality;

    [SerializeField]
    Text settingsFullScreen;

    [SerializeField]
    Text settingsResolution;

    [SerializeField]
    Text settingsConfirm;

    #endregion

    #region LanguageTab
    [Header("Language Tab")]

    [SerializeField]
    Text settingsLanguageTab;

    [SerializeField]
    Text settingsLanguage;

    #endregion

    bool initialise;

    protected override void Awake()
    {
        Initialise();
        base.Awake();
    }

    void Initialise()
    {
        initialise = true;
        List<string> languagePacksList = new List<string>();
        foreach(LanguagePack pack in languagePacks)
        {
            languagePacksList.Add(pack.packName);
        }
        languageDropdown.AddOptions(languagePacksList);

        Set_User_Settings();
        initialise = false;
    }

    void Set_User_Settings()
    {
        for (int i = 0; i < languageDropdown.options.Count; i++)
        {
            if (languageDropdown.options[i].text == userSettings.languagePack)
            {
                languageDropdown.value = i;
                return;
            }
        }
    }

    protected override void Reload()
    {
        base.Reload();

        settingsTitle.text = currentPack.settingsTitle;
        settingsBack.text = currentPack.settingsBack;

        settingsSoundTab.text = currentPack.settingsSoundTab;
        settingsEffectsVolume.text = currentPack.settingsEffectsVolume;
        settingsMusicVolume.text = currentPack.settingsMusicVolume;

        settingsGraphicsTab.text = currentPack.settingsGraphicsTab;
        settingsQuality.text = currentPack.settingsQuality;
        settingsFullScreen.text = currentPack.settingsFullScreen;
        settingsResolution.text = currentPack.settingsResolution;
        settingsConfirm.text = currentPack.settingsConfirm;

        settingsLanguageTab.text = currentPack.settingsLanguageTab;
        settingsLanguage.text = currentPack.settingsLanguage;

        foreach (Dropdown.OptionData data in qualityDropdown.options)
        {
            data.text = currentPack.Mapping(data.text);
        }
        qualityDropdown.RefreshShownValue();
    }

    public void Change_Language()
    {
        if (initialise)
            return;
        foreach (Dropdown.OptionData data in qualityDropdown.options)
        {
            data.text = currentPack.Unmapping(data.text);
        }
        userSettings.languagePack = languagePacks[languageDropdown.value].packName;
        Save_User_Settings();
        SoundRecorder.Play_Effect(GlobalVariables.CLICKEFFECT);
    }

    void Save_User_Settings()
    {
        string destination = Application.persistentDataPath + GlobalVariables.SETTINGSPATH;
        SaveLoad.Save_Data(destination, userSettings);
    }
}
