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

    [SerializeField] CustomerQueue customerQueue;

    protected override void Reload()
    {
        base.Reload();

        cabinetTitle.text = currentPack.cabinetTitle;
        cabinetDay.text = currentPack.cabinetDay + " " + CustomerQueue.day;
        cabinetSkipDay.text = currentPack.cabinetSkipDay;
        cabinetSave.text = currentPack.cabinetSave;
        cabinetMainMenu.text = currentPack.cabinetMainMenu;
        Update_Customers();
    }

    public int[] Generate_Customer_Code()
    {
        int randomNameCode = Random.Range(0, currentPack.customerNames.Length);
        int randomSurnameCode = Random.Range(0, currentPack.customerSurnames.Length);
        int randomPhraseCode = Random.Range(0, currentPack.customerPhrases.Length);
        return new int[] { randomNameCode, randomSurnameCode, randomPhraseCode };
    }

    public string[] Get_Texts_By_Code(int[] customerCode)
    {
        if (currentPack.packName != userSettings.languagePack)
            Reload();

        string name = currentPack.customerNames[customerCode[0]];
        string surname = currentPack.customerSurnames[customerCode[1]];
        string phrase = currentPack.customerPhrases[customerCode[2]];
        return new string[] { name + " " + surname, phrase };
    }

    public void Update_Customers()
    {
        foreach(GameObject customer in customerQueue.customers)
        {
            CustomerCard card = customer.GetComponent<CustomerCard>();
            card.Update_Customer(Get_Texts_By_Code(card.customerCode));
        }
    }

    public void Set_Day()
    {
        cabinetDay.text = currentPack.cabinetDay + " " + CustomerQueue.day;
    }
}
