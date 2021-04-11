using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabinetLanguage : LanguageController
{
    [SerializeField] Text cabinetTitle;
    [SerializeField] Text cabinetDay;
    [SerializeField] Text cabinetSkipDay;
    [SerializeField] Text cabinetSave;
    [SerializeField] Text cabinetMainMenu;

    int currentDay = 0;

    protected override void Reload()
    {
        base.Reload();

        cabinetTitle.text = currentPack.cabinetTitle;
        cabinetDay.text = currentPack.cabinetDay + " " + CustomerQueue.day;
        cabinetSkipDay.text = currentPack.cabinetSkipDay;
        cabinetSave.text = currentPack.cabinetSave;
        cabinetMainMenu.text = currentPack.cabinetMainMenu;
    }

    void Update()
    {
        if (currentDay != CustomerQueue.day)
            Update_Day();
    }

    void Update_Day()
    {
        cabinetDay.text = currentPack.cabinetDay + " " + CustomerQueue.day;
        currentDay = CustomerQueue.day;
    }
}
