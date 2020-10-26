using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[BindPrefab(Paths.LEVELS_VIEW,Const.BIND_PREFAB_PRIORITY_CONTROLLER)]
public class LevelsController : ControllerBase
{
    public override void InitChild()
    {
        transform.Find("level").gameObject.AddComponent<LevelsRootController>();
    }
}
