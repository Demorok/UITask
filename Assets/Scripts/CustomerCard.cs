using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerCard : MonoBehaviour
{
    [SerializeField] protected Image body;
    [SerializeField] protected Image face;
    [SerializeField] protected Image hair;
    [SerializeField] protected Image kit;
    [SerializeField] protected Text customerName;

    public int[] customerCode;

    public void Construct(Customer customer, string[] data)
    {
        Sprite bodySprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERBODIES + customer.bodySpriteName);
        Sprite faceSprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERFACES + customer.faceSpriteName);
        Sprite hairSprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERHAIRS + customer.hairSpriteName);
        Sprite kitSprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERKITS + customer.kitSpriteName);

        body.sprite = bodySprite;
        face.sprite = faceSprite;
        hair.sprite = hairSprite;
        kit.sprite = kitSprite;

        this.customerCode = customer.customerCode;

        Update_Customer(data);
    }

    public void Construct(string[] data, int[] customerCode)
    {
        body.sprite = Preloader.bodies[Random.Range(0, Preloader.bodies.Length)];
        face.sprite = Preloader.faces[Random.Range(0, Preloader.faces.Length)];
        hair.sprite = Preloader.hairs[Random.Range(0, Preloader.hairs.Length)];
        kit.sprite = Preloader.kits[Random.Range(0, Preloader.kits.Length)];
        Update_Customer(data);
        this.customerCode = customerCode;
    }

    public void Update_Customer(string[] data)
    {
        customerName.text = data[0];
    }

    public void Expand()
    {
        CustomerQueue.expandQueue.Enqueue(gameObject);
    }

    public Customer Convert_Customer()
    {
        return new Customer(body.sprite.name, face.sprite.name, hair.sprite.name, kit.sprite.name, customerCode);
    }
}

[System.Serializable]
public class Customer
{
    public string bodySpriteName;
    public string faceSpriteName;
    public string hairSpriteName;
    public string kitSpriteName;
    public int[] customerCode;

    public Customer(string bodySpriteName, string faceSpriteName, string hairSpriteName, string kitSpriteName, int[] customerCode)
    {
        this.bodySpriteName = bodySpriteName;
        this.faceSpriteName = faceSpriteName;
        this.hairSpriteName = hairSpriteName;
        this.kitSpriteName = kitSpriteName;
        this.customerCode = customerCode;
    }
}
