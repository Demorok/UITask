using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerQueue : MonoBehaviour
{
    [SerializeField] Transform[] places;
    [SerializeField] ExpandedCustomerCard expandedCustomerCard;
    [SerializeField] CabinetLanguage lang;

    [SerializeField] Text dayMinutes;
    [SerializeField] Text daySeconds;
    [SerializeField] float minutesInDay;

    public static int day = 1;

    float endOfDay;

    List<GameObject> customers = new List<GameObject>();

    public static Queue<GameObject> destructQueue = new Queue<GameObject>();

    private void Start()
    {
        Spawn_Customers();
        Start_Timer();
    }

    private void Update()
    {
        Update_Time();
        Check_Customer_Queue();
        Check_End_Of_Day();
    }

    public void Start_New_Day()
    {
        ++day;
        lang.Set_Day();
        Start_Timer();
        Spawn_Customers();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    void Update_Time()
    {
        float timeLeft = endOfDay - Time.time;
        int minutes = (int)(timeLeft / 60);
        int seconds = (int)(timeLeft % 60);
        string sec = seconds.ToString().Length > 1 ? seconds.ToString() : "0" + seconds.ToString();
        dayMinutes.text = minutes.ToString();
        daySeconds.text = sec;
    }

    void Check_End_Of_Day()
    {
        if (endOfDay - Time.time <= 0 || customers.Count == 0)
        {
            Start_New_Day();
        }
    }

    void Start_Timer()
    {
        endOfDay = Time.time + minutesInDay * 60;
    }

    void Check_Customer_Queue()
    {
        try
        {
            Expand_Customer(destructQueue.Dequeue());
        }
        catch
        {
            return;
        }
    }

    void Spawn_Customers()
    {
        Clear_Queue();
        foreach (Transform place in places)
        {
            GameObject clone =  Instantiate(GlobalVariables.CUSTOMERPREFAB, place);
            customers.Add(clone);
            clone.GetComponent<CustomerCard>().Construct(lang.Get_Random_Name(), lang.Get_Random_Phrase());
        }
    }

    void Clear_Queue()
    {
        foreach (GameObject customer in customers)
        {
            Destroy(customer);
        }
        customers.Clear();
        destructQueue.Clear();
    }

    void Update_Customers_Position()
    {
        for(int i = 0; i < customers.Count; i++)
        {
            customers[i].transform.position = places[i].position;
        }
    }

    void Expand_Customer(GameObject customer)
    {
        Pause();
        expandedCustomerCard.Expand_Customer(customer.GetComponent<CustomerCard>().Convert_Customer());
        Remove_Customer(customer);
    }

    void Remove_Customer(GameObject customer)
    {
        customers.Remove(customer);
        Update_Customers_Position();
        Destroy(customer);
    }
}
