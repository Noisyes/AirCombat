using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    private void Awake()
    {
        InitCustomAtrribute.Init();
        LoadMgr.Instance.LoadPrefab("Prefab/StartView",transform);
    }
}
