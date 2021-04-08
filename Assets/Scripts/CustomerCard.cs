using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerCard : MonoBehaviour
{
    [SerializeField] Image body;
    [SerializeField] Image face;
    [SerializeField] Image hair;
    [SerializeField] Image kit;
    [SerializeField] Text customerName;

    string customerPhrase;

    public void Construct(Customer customer)
    {
        Sprite bodySprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERBODIES + customer.bodySpriteName);
        Sprite faceSprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERFACES + customer.faceSpriteName);
        Sprite hairSprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERHAIRS + customer.hairSpriteName);
        Sprite kitSprite = Resources.Load<Sprite>(GlobalVariables.CUSTOMERKITS + customer.kitSpriteName);

        body.sprite = bodySprite;
        face.sprite = faceSprite;
        hair.sprite = hairSprite;
        kit.sprite = kitSprite;
        customerName.text = customer.customerName;
        customerPhrase = customer.customerPhrase;
    }

    public void Construct()
    {
        body.sprite = Preloader.bodies[Random.Range(0, Preloader.bodies.Length)];
        face.sprite = Preloader.faces[Random.Range(0, Preloader.faces.Length)];
        hair.sprite = Preloader.hairs[Random.Range(0, Preloader.hairs.Length)];
        kit.sprite = Preloader.kits[Random.Range(0, Preloader.kits.Length)];

        //generate name + phrase
    }

    public Customer Convert_Customer()
    {
        return new Customer(body.sprite.name, face.sprite.name, hair.sprite.name, kit.sprite.name, customerName.text, customerPhrase);
    }
}

[System.Serializable]
public class Customer
{
    public string bodySpriteName;
    public string faceSpriteName;
    public string hairSpriteName;
    public string kitSpriteName;
    public string customerName;
    public string customerPhrase;

    public Customer(string bodySpriteName, string faceSpriteName, string hairSpriteName, string kitSpriteName, string customerName, string customerPhrase)
    {
        this.bodySpriteName = bodySpriteName;
        this.faceSpriteName = faceSpriteName;
        this.hairSpriteName = hairSpriteName;
        this.kitSpriteName = kitSpriteName;
        this.customerName = customerName;
        this.customerPhrase = customerPhrase;
    }
}
