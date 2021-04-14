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

    protected CustomerCardLanguage ñardLanguage;

    private void Awake()
    {
        ñardLanguage = GetComponent<CustomerCardLanguage>();
    }

    public void Construct(Customer customer)
    {
        customerCode = customer.customerCode;
        body.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERBODIESPATH + customer.bodySpriteName);
        face.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERFACESPATH + customer.faceSpriteName);
        hair.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERHAIRSPATH + GlobalVariables.SEXHAIRPATH[customerCode[0]] + customer.hairSpriteName);
        kit.sprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERKITSPATH + GlobalVariables.SEXKITPATH[customerCode[0]] + customer.kitSpriteName);
        ñardLanguage.Update_Name_By_Code();
    }

    public void Construct()
    {
        customerCode = ñardLanguage.Generate_Customer_Code();
        Sprite[] hairs = GlobalVariables.CUSTOMERHAIRS[customerCode[0]];
        Sprite[] kits = GlobalVariables.CUSTOMERKITS[customerCode[0]];

        body.sprite = GlobalVariables.CUSTOMERBODIES[Random.Range(0, GlobalVariables.CUSTOMERBODIES.Length)];
        face.sprite = GlobalVariables.CUSTOMERFACES[Random.Range(0, GlobalVariables.CUSTOMERFACES.Length)];
        hair.sprite = hairs[Random.Range(0, hairs.Length)];
        kit.sprite = kits[Random.Range(0, kits.Length)];

        ñardLanguage.Update_Name_By_Code();
    }

    public void Expand()
    {
        GameObject expandedCard = Instantiate(GlobalVariables.EXPANDEDCUSTOMERPREFAB, gameObject.transform.parent.parent.parent); //Cabinet transform
        expandedCard.GetComponent<ExpandedCustomerCard>().Construct(Convert_Customer(), gameObject);
    }

    public void Remove_Customer()
    {
        CustomerQueue.removeQueue.Enqueue(gameObject);
    }

    public Customer Convert_Customer()
    {
        return new Customer(body.sprite.name, face.sprite.name, hair.sprite.name, kit.sprite.name, customerCode);
    }
}
