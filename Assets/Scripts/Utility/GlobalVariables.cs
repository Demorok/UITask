using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public const string SETTINGSPATH = "/settings.cfg";

    public const string DATAPATH = "/SaveData";
    public const string DATAFILE = "/data.sav";

    public const string CUSTOMERBODIESPATH = "Sprites/Customers/Bodies/";
    public const string CUSTOMERFACESPATH = "Sprites/Customers/Faces/";
    public const string CUSTOMERHAIRSPATH = "Sprites/Customers/Hairs/";
    public const string CUSTOMERKITSPATH = "Sprites/Customers/Kits/";

    public static GameObject CUSTOMERPREFAB = Resources.Load<GameObject>("Prefabs/Customer");
    public static GameObject EXPANDEDCUSTOMERPREFAB = Resources.Load<GameObject>("Prefabs/ExpandedCustomer");
    public static GameObject SETTINGSPREFAB = Resources.Load<GameObject>("Prefabs/Settings");

    public static AudioClip MAINMENUMUSIC = Resources.Load<AudioClip>("Sounds/Music/MainMenu");
    public static AudioClip CABINETMUSIC = Resources.Load<AudioClip>("Sounds/Music/Cabinet");
    public static AudioClip CLICKEFFECT = Resources.Load<AudioClip>("Sounds/Effects/click");
    public static AudioClip SAVEEFFECT = Resources.Load<AudioClip>("Sounds/Effects/save");

    public static List<LanguagePack> SOLANGUAGEPACKS = new List<LanguagePack>(Resources.LoadAll<LanguagePack>("ScriptableObjects/LanguagePacks"));
    public static UserSettings SOUSERSETTINGS = Resources.Load<UserSettings>("ScriptableObjects/UserSettings/UserSettings");

    //CustomerCards sprites
    public static Sprite[] CUSTOMERBODIES = Resources.LoadAll<Sprite>(CUSTOMERBODIESPATH);
    public static Sprite[] CUSTOMERFACES = Resources.LoadAll<Sprite>(CUSTOMERFACESPATH);
    public static Sprite[] CUSTOMERHAIRS = Resources.LoadAll<Sprite>(CUSTOMERHAIRSPATH);
    public static Sprite[] CUSTOMERKITS = Resources.LoadAll<Sprite>(CUSTOMERKITSPATH);

    public static Resolution[] RESOLUTIONS = new Resolution[]
    {
            new Resolution(1280, 720),
            new Resolution(1600, 900),
            new Resolution(1920, 1080),
    };

    //Language Settings Mapping
    public const string VERYHIGHQUALITYMAPPING = "Very High";
    public const string HIGHQUALITYMAPPING = "High";
    public const string MEDIUMQUALITYMAPPING = "Medium";
    public const string LOWQUALITYMAPPING = "Low";
}
