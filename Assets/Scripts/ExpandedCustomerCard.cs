using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandedCustomerCard : MonoBehaviour
{
    [SerializeField] CustomerQueue manager;
    [SerializeField] Transform customerPlace;
    [SerializeField] Text customerPhrase;

    GameObject queuedCard;
    GameObject customerCard;

    public void Expand_Customer(GameObject ethalon, Customer customer, string[] data)
    {
        gameObject.SetActive(true);
        customerCard = Instantiate(GlobalVariables.CUSTOMERPREFAB, customerPlace);
        customerCard.GetComponent<CustomerCard>().Construct(customer, data);
        customerPhrase.text = data[1];
        queuedCard = ethalon;
    }

    public void Close_Card()
    {
        manager.Continue();
        Destroy(customerCard);
        gameObject.SetActive(false);
        CustomerQueue.removeQueue.Enqueue(queuedCard);
    }
}
