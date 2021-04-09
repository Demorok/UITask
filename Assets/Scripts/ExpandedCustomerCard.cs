using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandedCustomerCard : MonoBehaviour
{
    [SerializeField] CustomerQueue manager;
    [SerializeField] Transform customerPlace;
    [SerializeField] Text customerPhrase;

    GameObject customerCard;

    public void Expand_Customer(Customer customer)
    {
        gameObject.SetActive(true);
        customerCard = Instantiate(GlobalVariables.CUSTOMERPREFAB, customerPlace);
        customerCard.GetComponent<CustomerCard>().Construct(customer);
        customerPhrase.text = customer.customerPhrase;
    }

    public void Close_Card()
    {
        manager.Continue();
        Destroy(customerCard);
        gameObject.SetActive(false);
    }
}
