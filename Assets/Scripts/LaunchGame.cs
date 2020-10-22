using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    private void Awake()
    {
        DataMgr.Instance.ClearAll();
        IInit lifeCycle = LifeCycleMgr.Instance;
        lifeCycle.Init();
        UIMgr.Instance.Show(Paths.START_VIEW);
    }
}
