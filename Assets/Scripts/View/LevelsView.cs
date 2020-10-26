using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[BindPrefab(Paths.LEVELS_VIEW,Const.BIND_PREFAB_PRIORITY_VIEW)]
public class LevelsView : ViewBase
{
    protected override void InitChild()
    {
        UIUtil.Get("level").GO.AddComponent<LevelRoot>();
    }
}
