using UnityEngine;
using UnityEngine.UI;

public class MainMenuLanguage : LanguageController
{
    [SerializeField] Text mainMenuTitle;
    [SerializeField] Text mainMenuNewCabinet;
    [SerializeField] Text mainMenuLoadCabinet;
    [SerializeField] Text mainMenuSettings;
    [SerializeField] Text mainMenuExit;

    protected override void Reload()
    {
        base.Reload();

        mainMenuTitle.text = currentPack.mainMenuTitle;
        mainMenuNewCabinet.text = currentPack.mainMenuNewCabinet;
        mainMenuLoadCabinet.text = currentPack.mainMenuLoadCabinet;
        mainMenuSettings.text = currentPack.mainMenuSettings;
        mainMenuExit.text = currentPack.mainMenuExit;
    }
}
