using UnityEngine;
using UnityEngine.UI;

public class MainMenuLanguage : LanguageController
{
    [SerializeField]
    Text mainMenuTitle;

    [SerializeField]
    Text mainMenuCabinet;

    [SerializeField]
    Text mainMenuSettings;

    [SerializeField]
    Text mainMenuExit;

    protected override void Reload()
    {
        base.Reload();

        mainMenuTitle.text = currentPack.mainMenuTitle;
        mainMenuCabinet.text = currentPack.mainMenuCabinet;
        mainMenuSettings.text = currentPack.mainMenuSettings;
        mainMenuExit.text = currentPack.mainMenuExit;
    }
}
