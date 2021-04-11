using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CustomerCardLanguage))]
public class CustomerCard : MonoBehaviour
{
    [SerializeField] protected Image body;
    [SerializeField] protected Image face;
    [SerializeField] protected Image hair;
    [SerializeField] protected Image kit;
    public int[] customerCode;

    CustomerCardLanguage customerCardLanguage;

    private void Awake()
    {
        customerCardLanguage = GetComponent<CustomerCardLanguage>();
    }

    public void Construct(Customer customer)
    {
        body.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERBODIESPATH + customer.bodySpriteName);
        face.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERFACESPATH + customer.faceSpriteName);
        hair.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERHAIRSPATH + customer.hairSpriteName);
        kit.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERKITSPATH + customer.kitSpriteName);
        customerCode = customer.customerCode;
        customerCardLanguage.Update_Name_By_Code();
    }

    public void Construct()
    {
        body.sprite = GlobalVariables.CUSTOMERBODIES[Random.Range(0, GlobalVariables.CUSTOMERBODIES.Length)];
        face.sprite = GlobalVariables.CUSTOMERFACES[Random.Range(0, GlobalVariables.CUSTOMERFACES.Length)];
        hair.sprite = GlobalVariables.CUSTOMERHAIRS[Random.Range(0, GlobalVariables.CUSTOMERHAIRS.Length)];
        kit.sprite = GlobalVariables.CUSTOMERKITS[Random.Range(0, GlobalVariables.CUSTOMERKITS.Length)];
        customerCode = customerCardLanguage.Generate_Customer_Code();
        customerCardLanguage.Update_Name_By_Code();
    }

    public void Expand()
    {
        GameObject expandedCard = Instantiate(GlobalVariables.EXPANDEDCUSTOMERPREFAB, gameObject.transform.parent.parent.parent); //Cabinet transform
        expandedCard.GetComponent<ExpandedCustomerCard>().Construct(Convert_Customer(), gameObject);
    }

    private void OnDestroy()
    {
        CustomerQueue.removeQueue.Enqueue(gameObject);
    }

    public Customer Convert_Customer()
    {
        return new Customer(body.sprite.name, face.sprite.name, hair.sprite.name, kit.sprite.name, customerCode);
    }
}
