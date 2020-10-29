using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths
{
    public const string PREFAB_FOLDER = "Prefab/";
    public const string START_VIEW = PREFAB_FOLDER + "StartView";
    public const string DIALOGUE_VIEW = PREFAB_FOLDER + "Dialog";
    public const string SELECTEDHERO_VIEW = PREFAB_FOLDER + "SelectedHeroView";
    public const string STRENGTHEN_VIEW = PREFAB_FOLDER + "StrengthenView";
    public const string PROPERTY_ITEM = PREFAB_FOLDER + "PropertyItem";
    public const string LEVELS_VIEW = PREFAB_FOLDER + "LevelsView";
    public const string LEVEL_ITEM = PREFAB_FOLDER + "LevelItem";
    
    public static string STREAMINGASSET_FOLDER = Application.streamingAssetsPath + "/Config";
    public static string INITPLANE = STREAMINGASSET_FOLDER + "/InitPlanes.json";
    public static string INITLEVLES = STREAMINGASSET_FOLDER + "/InitLevels.json";
    
    public const string PICTURE = "Picture/";
    public const string PLAYER = PICTURE + "Player";
}
