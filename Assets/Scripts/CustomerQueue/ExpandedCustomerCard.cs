using UnityEngine;
using Animations;

[RequireComponent(typeof(ExpandedCustomerCardLanguage))]
public class ExpandedCustomerCard : CustomerCard
{
    [SerializeField] GameObject card;

    GameObject customerCard;
    float currentTimeScale;

    ExpandedCustomerCardLanguage exCardLanguage;

    private void Awake()
    {
        ñardLanguage = GetComponent<ExpandedCustomerCardLanguage>();
        exCardLanguage = (ExpandedCustomerCardLanguage)ñardLanguage;
    }

    public void Construct(Customer customer, GameObject ethalon)
    {
        card.Open_Window_X(() => Pause());
        Construct(customer);
        exCardLanguage.Update_Phrase_By_Code();
        customerCard = ethalon;
    }

    public void Close_Card()
    {
        customerCard.GetComponent<CustomerCard>().Remove_Customer();
        Continue();
        card.Destroy_Window_X(() => Destroy(gameObject));
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
