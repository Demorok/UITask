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
        currentTimeScale = Time.timeScale;
        Time.timeScale = 1;
        card.Open_Window_X(() => Pause());
        Construct(customer);
        exCardLanguage.Update_Phrase_By_Code();
        customerCard = ethalon;
    }

    public void Close_Card()
    {
        Time.timeScale = 1;
        customerCard.GetComponent<CustomerCard>().Remove_Customer();
        card.Destroy_Window_X(() => Continue());
    }

    void Pause()
    {
        Time.timeScale = 0;
    }

    void Continue()
    {
        Time.timeScale = currentTimeScale;
        Destroy(gameObject);
    }
}
