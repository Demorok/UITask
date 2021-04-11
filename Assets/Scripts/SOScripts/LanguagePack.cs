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
    public string mainMenuNewCabinet;
    public string mainMenuLoadCabinet;
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

    public string veryHighGraphicsQuality;
    public string highGraphicsQuality;
    public string mediumGraphicsQuality;
    public string lowGraphicsQuality;

    #endregion

    #endregion

    #region Cabinet
    [Header("Cabinet")]

    public string cabinetTitle;
    public string cabinetDay;
    public string cabinetSkipDay;
    public string cabinetSave;
    public string cabinetMainMenu;

    public string[] customerNames;
    public string[] customerSurnames;
    public string[] customerPhrases;

    #endregion

    public string Mapping(string value)
    {
        string result;
        switch (value)
        {
            case GlobalVariables.VERYHIGHQUALITYMAPPING:
                result = veryHighGraphicsQuality;
                break;
            case GlobalVariables.HIGHQUALITYMAPPING:
                result = highGraphicsQuality;
                break;
            case GlobalVariables.MEDIUMQUALITYMAPPING:
                result = mediumGraphicsQuality;
                break;
            case GlobalVariables.LOWQUALITYMAPPING:
                result = lowGraphicsQuality;
                break;
            default:
                result = value;
                break;
        }
        return result;
    }

    public string Unmapping(string value)
    {
        if (value == veryHighGraphicsQuality)
            return GlobalVariables.VERYHIGHQUALITYMAPPING;
        else if (value == highGraphicsQuality)
            return GlobalVariables.HIGHQUALITYMAPPING;
        else if (value == mediumGraphicsQuality)
            return GlobalVariables.MEDIUMQUALITYMAPPING;
        else if (value == lowGraphicsQuality)
            return GlobalVariables.LOWQUALITYMAPPING;
        else return value;
    }
}
