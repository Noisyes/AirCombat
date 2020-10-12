using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths
{
    public const string PREFAB_FOLDER = "Prefab/";
    public const string START_VIEW = PREFAB_FOLDER + "StartView";
    public const string SELECTEDHERO_VIEW = PREFAB_FOLDER + "SelectedHeroView";

    public static string STREAMINGASSET_FOLDER = Application.streamingAssetsPath + "/Config";
    public static string INITPLANE = STREAMINGASSET_FOLDER + "/InitPlanes.json";

}
