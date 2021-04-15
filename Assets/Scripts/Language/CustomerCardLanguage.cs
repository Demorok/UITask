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
        string name = currentPack.Get_Names_by_Sex(customerCard.customerCode[0])[customerCard.customerCode[1]];
        string surname = currentPack.Get_Surnames_by_Sex(customerCard.customerCode[0])[customerCard.customerCode[2]];
        customerName.text = string.Format("{0} {1}", name, surname);
    }

    public int[] Generate_Customer_Code()
    {
        int sex = Random.Range(0,2);
        int randomNameCode = Random.Range(0, currentPack.Get_Names_by_Sex(sex).Length);
        int randomSurnameCode = Random.Range(0, currentPack.Get_Surnames_by_Sex(sex).Length);
        int randomPhraseCode = Random.Range(0, currentPack.customerPhrases.Length);
        return new int[] { sex, randomNameCode, randomSurnameCode, randomPhraseCode };
    }
}
