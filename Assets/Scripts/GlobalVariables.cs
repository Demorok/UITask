using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public const string SETTINGSPATH = "/settings.cfg";

    public const string CUSTOMERBODIES = "Sprites/Customers/Bodies/";
    public const string CUSTOMERFACES = "Sprites/Customers/Faces/";
    public const string CUSTOMERHAIRS = "Sprites/Customers/Hairs/";
    public const string CUSTOMERKITS = "Sprites/Customers/Kits/";

    public static GameObject CUSTOMERPREFAB = Resources.Load<GameObject>("Prefabs/Customer");
}
