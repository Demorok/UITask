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
