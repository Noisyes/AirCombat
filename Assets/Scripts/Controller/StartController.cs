using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[BindPrefab(Paths.START_VIEW,Const.BIND_PREFAB_PRIORITY_CONTROLLER)]
public class StartController : ControllerBase
{
    public override void InitChild()
    {
        transform.AddButtonAction("Start", () =>
        {
            UIMgr.Instance.Show(Paths.SELECTEDHERO_VIEW);
        });
    }
}
