using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Animations;
using System.Collections;

public class CustomerQueue : MonoBehaviour
{
    [SerializeField] Transform[] places;
    [SerializeField] Transform spawner;
    [SerializeField] Text dayMinutes;
    [SerializeField] Text daySeconds;
    [SerializeField] float minutesInDay;

    public static int day = 0;

    float endOfDay;

    public List<GameObject> customers { get; private set; } = new List<GameObject>();
    public static Queue<GameObject> removeQueue = new Queue<GameObject>();

    bool start = false;

    private void Update()
    {
        if (!start)
            return;
        Update_Time();
        Check_Customer_Queue();
        Check_End_Of_Day();
    }

    public void New_Cabinet()
    {
        start = true;
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
    void Start_Timer()
    {
        endOfDay = Time.time + minutesInDay * 60;
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

    public void Start_New_Day()
    {
        ++day;
        Start_Timer();
        Spawn_Customers();
    }

    public void Clear_Queue()
    {
        StopCoroutine("Update_Customers_Position_Coroutine");
        foreach (GameObject customer in customers)
        {
            customer.Stop_Ainmation();
            Destroy(customer);
        }
        customers.Clear();
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

    void Load_Day(SaveData saveData)
    {
        start = true;
        day = saveData.day;
        Spawn_Customers(saveData.customers);
        Start_Timer(saveData.deltaTime);
    }

    void Update_Time()
    {
        int timeLeft = Mathf.CeilToInt(endOfDay - Time.time);
        int minutes = timeLeft / 60;
        int seconds = timeLeft % 60;
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

    void Check_Customer_Queue()
    {
        if (removeQueue.Count > 0)
            Remove_Customer(removeQueue.Dequeue());
    }

    void Spawn_Customers()
    {
        Clear_Queue();
        for (int i = 0; i < places.Length; i++)
        {
            GameObject clone =  Instantiate(GlobalVariables.CUSTOMERPREFAB, spawner);
            customers.Add(clone);
            clone.GetComponent<CustomerCard>().Construct();
        }
        Update_Customers_Position();
    }

    void Spawn_Customers(Customer[] customersData)
    {
        Clear_Queue();
        for (int i = 0; i < customersData.Length; i++)
        {
            GameObject clone = Instantiate(GlobalVariables.CUSTOMERPREFAB, spawner);
            customers.Add(clone);
            clone.GetComponent<CustomerCard>().Construct(customersData[i]);
        }
        Update_Customers_Position();
    }

    void Update_Customers_Position()
    {
        StartCoroutine("Update_Customers_Position_Coroutine");
    }

    void Remove_Customer(GameObject customer)
    {
        customers.Remove(customer);
        Destroy(customer);
        Update_Customers_Position();
    }

    IEnumerator Update_Customers_Position_Coroutine()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            customers[i].MoveObject(places[i].position);
            yield return new WaitForSeconds(0.1f);
        }
            
    }
}
