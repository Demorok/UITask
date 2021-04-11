using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CustomerCard))]
public class CustomerCardLanguage : LanguageController
{
    [SerializeField] protected Text customerName;

    CustomerCard customerCard;

    protected override void Awake()
    {
        customerCard = GetComponent<CustomerCard>();
        base.Awake();
    }

    protected override void Reload()
    {
        base.Reload();
        Update_Name_By_Code();
    }

    public void Update_Name_By_Code()
    {
        if (customerCard.customerCode.Length == 0)
            return;
        string name = currentPack.customerNames[customerCard.customerCode[0]];
        string surname = currentPack.customerSurnames[customerCard.customerCode[1]];
        customerName.text = string.Format("{0} {1}", name, surname);
    }

    public int[] Generate_Customer_Code()
    {
        int randomNameCode = Random.Range(0, currentPack.customerNames.Length);
        int randomSurnameCode = Random.Range(0, currentPack.customerSurnames.Length);
        int randomPhraseCode = Random.Range(0, currentPack.customerPhrases.Length);
        return new int[] { randomNameCode, randomSurnameCode, randomPhraseCode };
    }
}
