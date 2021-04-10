using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public const string SETTINGSPATH = "/settings.cfg";

    public const string DATAPATH = "/SaveData";
    public const string DATAFILE = "/data.sav";

    public const string CUSTOMERBODIES = "Sprites/Customers/Bodies/";
    public const string CUSTOMERFACES = "Sprites/Customers/Faces/";
    public const string CUSTOMERHAIRS = "Sprites/Customers/Hairs/";
    public const string CUSTOMERKITS = "Sprites/Customers/Kits/";

    public static GameObject CUSTOMERPREFAB = Resources.Load<GameObject>("Prefabs/Customer");
    public static GameObject SETTINGSPREFAB = Resources.Load<GameObject>("Prefabs/Settings");

    public static AudioClip MAINMENUMUSIC = Resources.Load<AudioClip>("Sounds/Music/MainMenu");
    public static AudioClip CABINETMUSIC = Resources.Load<AudioClip>("Sounds/Music/Cabinet");
    public static AudioClip CLICKEFFECT = Resources.Load<AudioClip>("Sounds/Effects/click");
    public static AudioClip SAVEEFFECT = Resources.Load<AudioClip>("Sounds/Effects/save");

}
