using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ExpandedCustomerCardLanguage))]
public class ExpandedCustomerCard : CustomerCard
{
    GameObject customerCard;

    float currentTimeScale;

    ExpandedCustomerCardLanguage expandedCardLanguage;

    private void Awake()
    {
        expandedCardLanguage = GetComponent<ExpandedCustomerCardLanguage>();
    }

    public void Construct(Customer customer, GameObject ethalon)
    {
        Pause();
        body.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERBODIESPATH + customer.bodySpriteName);
        face.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERFACESPATH + customer.faceSpriteName);
        hair.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERHAIRSPATH + customer.hairSpriteName);
        kit.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERKITSPATH + customer.kitSpriteName);
        customerCode = customer.customerCode;
        expandedCardLanguage.Update_Name_By_Code();
        expandedCardLanguage.Update_Phrase_By_Code();
        customerCard = ethalon;
    }

    public void Close_Card()
    {
        Destroy(customerCard);
        Continue();
        Destroy(gameObject);
    }

    void Pause()
    {
        currentTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    void Continue()
    {
        Time.timeScale = currentTimeScale;
    }
}
