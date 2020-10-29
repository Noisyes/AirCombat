using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataKeys : MonoBehaviour
{
    public const string STAR = "Star";
    public const string DIAMOND = "Diamond";
    public const string NAME = "name";
    public const string PASSLEVELS = "passlevels";
    public class Planes
    {
        public const string LEVEL = "level";
        public const string PLANE_ID = "planeID";
        public const string UPGRADES = "upgrades";
        public const string COEFFICIENT = UPGRADES + "coefficient";
        public const string MAX = UPGRADES + "Max";
        public const string COST_UNIT = "costUnit";
    }
    
}
