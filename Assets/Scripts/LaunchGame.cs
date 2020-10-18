using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    private void Awake()
    {
        ConfigMgr.Instance.Init();
        InitCustomAtrribute.Init();
        UIMgr.Instance.Show(Paths.START_VIEW);
    }
}
