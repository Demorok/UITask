using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Language Pack", menuName = "Language Pack", order = 53)]
public class LanguagePack : ScriptableObject
{
    public string packName;

    #region MainMenu

    [Header("Main menu")]

    public string mainMenuTitle;
    public string mainMenuCabinet;
    public string mainMenuSettings;
    public string mainMenuExit;

    #endregion

    #region SettingsMenu

    [Header("Settings")]

    public string settingsTitle;

    #region SoundTab

    public string settingsSoundTab;
    public string settingsEffectsVolume;
    public string settingsMusicVolume;

    #endregion

    #region GraphicsTab

    public string settingsGraphicsTab;
    public string settingsQuality;
    public string settingsFullScreen;
    public string settingsResolution;
    public string settingsConfirm;

    #endregion

    #region LanguageTab

    public string settingsLanguageTab;
    public string settingsLanguage;

    #endregion

    public string settingsBack;

    #region GraphicsQualityMapping

    [Header("Graphics Quality Mapping")]

    public string highGraphicsQuality;
    public string mediumGraphicsQuality;
    public string lowGraphicsQuality;
    public string veryHighGraphicsQuality;

    #endregion

    #endregion

    #region Cabinet
    [Header("Cabinet")]

    public string cabinetTitle;
    public string cabinetDay;
    public string cabinetSkipDay;

    public string[] customerNames;
    public string[] customerSurnames;
    public string[] customerPhrases;

    #endregion

    public string Mapping(string value)
    {
        string result;
        switch (value)
        {
            case "High":
                result = highGraphicsQuality;
                break;
            case "Medium":
                result = mediumGraphicsQuality;
                break;
            case "Low":
                result = lowGraphicsQuality;
                break;
            case "Very High":
                result = veryHighGraphicsQuality;
                break;
            default:
                result = value;
                break;
        }
        return result;
    }

    public string Unmapping(string value)
    {
        if (value == highGraphicsQuality)
            return "High";
        else if (value == mediumGraphicsQuality)
            return "Medium";
        else if (value == lowGraphicsQuality)
            return "Low";
        else if (value == veryHighGraphicsQuality)
            return "Very High";
        else return value;
    }
}
