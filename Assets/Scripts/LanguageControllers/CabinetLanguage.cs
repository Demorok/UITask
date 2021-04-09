using UnityEngine;
using UnityEngine.UI;

public class CabinetLanguage : LanguageController
{
    [SerializeField] Text cabinetTitle;
    [SerializeField] Text day;
    [SerializeField] Text skipDay;

    protected override void Reload()
    {
        base.Reload();

        cabinetTitle.text = currentPack.cabinetTitle;
        day.text = currentPack.cabinetDay + " " + CustomerQueue.day;
        skipDay.text = currentPack.cabinetSkipDay;
    }

    public string Get_Random_Name()
    {
        string randomName = currentPack.customerNames[Random.Range(0, currentPack.customerNames.Length)];
        string randomSurname = currentPack.customerSurnames[Random.Range(0, currentPack.customerSurnames.Length)];
        return randomName + " " + randomSurname;
    }

    public string Get_Random_Phrase()
    {
        return currentPack.customerPhrases[Random.Range(0, currentPack.customerPhrases.Length)];
    }

    public void Set_Day()
    {
        day.text = currentPack.cabinetDay + " " + CustomerQueue.day;
    }
}
