using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ExpandedCustomerCard))]
public class ExpandedCustomerCardLanguage : CustomerCardLanguage
{
    [SerializeField] protected Text customerPhrase;

    ExpandedCustomerCard expandedCustomerCard;

    protected override void Awake()
    {
        expandedCustomerCard = GetComponent<ExpandedCustomerCard>();
        base.Awake();
    }

    protected override void Reload()
    {
        base.Reload();
        Update_Phrase_By_Code();
    }

    public void Update_Phrase_By_Code()
    {
        if (expandedCustomerCard.customerCode.Length == 0)
            return;
        customerPhrase.text = currentPack.customerPhrases[expandedCustomerCard.customerCode[3]];
    }
}
