using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LanguageController : MonoBehaviour
{
    [SerializeField]
    protected UserSettings userSettings;

    [SerializeField]
    protected LanguagePack[] languagePacks;

    protected LanguagePack currentPack;

    protected virtual void Awake()
    {
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
        foreach (LanguagePack pack in languagePacks)
        {
            if (pack.packName == userSettings.languagePack)
            {
                currentPack = pack;
                break;
            }
        }
    }
}
