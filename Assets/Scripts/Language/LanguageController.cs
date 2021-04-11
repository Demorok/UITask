using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LanguageController : MonoBehaviour
{
    protected UserSettings userSettings;    
    protected List<LanguagePack> languagePacks;
    protected LanguagePack currentPack;

    protected virtual void Awake()
    {
        userSettings = GlobalVariables.SOUSERSETTINGS;
        languagePacks = GlobalVariables.SOLANGUAGEPACKS;
        Reload();
    }

    void Update()
    {
        if (currentPack.packName != userSettings.languagePack)
            Reload();
    }

    protected virtual void Reload()
    {
        Set_Language_Pack();
    }
    void Set_Language_Pack()
    {
        currentPack = languagePacks.Find(pack => pack.packName == userSettings.languagePack);
    }
}
