using System;
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

    public static int day = 0;

    float endOfDay;

    public List<GameObject> customers = new List<GameObject>();

    public static Queue<GameObject> expandQueue = new Queue<GameObject>();
    public static Queue<GameObject> removeQueue = new Queue<GameObject>();

    private void Update()
    {
        Update_Time();
        Check_Customer_Queue();
        Check_End_Of_Day();
    }

    public void New_Cabinet()
    {
        day = 0;
        Start_New_Day();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    public void Start_Timer(float timerSec)
    {
        endOfDay = Time.time + timerSec;
    }
    public void Save_Progress()
    {
        SaveData progress = current_Progress();
        string destination = Application.persistentDataPath + GlobalVariables.DATAPATH + GlobalVariables.DATAFILE;
        SaveLoad.Save_Data(destination, progress);
    }

    public void Load_Progress()
    {
        SaveData progress = current_Progress();
        string destination = Application.persistentDataPath + GlobalVariables.DATAPATH + GlobalVariables.DATAFILE;
        SaveLoad.Load_Data(destination, progress);
        if (progress != null)
            Load_Day(progress);
    }

    SaveData current_Progress()
    {
        Customer[] customersData = new Customer[customers.Count];
        for (int i = 0; i < customers.Count; i++)
        {
            customersData[i] = customers[i].GetComponent<CustomerCard>().Convert_Customer();
        }
        float deltaTime = endOfDay - Time.time;
        return new SaveData(day, deltaTime, customersData);
    }

    void Start_New_Day()
    {
        ++day;
        lang.Set_Day();
        Start_Timer();
        Spawn_Customers();
    }

    void Load_Day(SaveData saveData)
    {
        day = saveData.day;
        Spawn_Customers(saveData.customers);
        Start_Timer(saveData.deltaTime);
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
        if (expandQueue.Count > 0)
            Expand_Customer(expandQueue.Dequeue());
        if (removeQueue.Count > 0)
            Remove_Customer(removeQueue.Dequeue());
    }

    void Spawn_Customers()
    {
        Clear_Queue();
        foreach (Transform place in places)
        {
            GameObject clone =  Instantiate(GlobalVariables.CUSTOMERPREFAB, place);
            customers.Add(clone);
            int[] customerCode = lang.Generate_Customer_Code();
            clone.GetComponent<CustomerCard>().Construct(lang.Get_Texts_By_Code(customerCode), customerCode);
        }
    }

    void Spawn_Customers(Customer[] customersData)
    {
        Clear_Queue();
        for (int i = 0; i < customersData.Length; i++)
        {
            GameObject clone = Instantiate(GlobalVariables.CUSTOMERPREFAB, places[i]);
            customers.Add(clone);
            clone.GetComponent<CustomerCard>().Construct(customersData[i], lang.Get_Texts_By_Code(customersData[i].customerCode));
        }
    }

    void Clear_Queue()
    {
        foreach (GameObject customer in customers)
        {
            Destroy(customer);
        }
        customers.Clear();
        expandQueue.Clear();
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
        CustomerCard card = customer.GetComponent<CustomerCard>();
        expandedCustomerCard.Expand_Customer(customer, card.Convert_Customer(), lang.Get_Texts_By_Code(card.customerCode));
    }

    void Remove_Customer(GameObject customer)
    {
        customers.Remove(customer);
        Update_Customers_Position();
        Destroy(customer);
    }
}
