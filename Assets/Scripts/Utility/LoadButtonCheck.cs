using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadButtonCheck : MonoBehaviour
{
    Button loadButton;
    string loadFile;

    void Start()
    {
        loadFile = Application.persistentDataPath + GlobalVariables.DATAPATH + GlobalVariables.DATAFILE;
        loadButton = GetComponent<Button>();
        Check_Load_Ability();
    }

    public void Check_Load_Ability()
    {
        if (File.Exists(loadFile))
            loadButton.interactable = true;
        else
            loadButton.interactable = false;
    }
}
