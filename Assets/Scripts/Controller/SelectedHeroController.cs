using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[BindPrefab(Paths.SELECTEDHERO_VIEW,Const.BIND_PREFAB_PRIORITY_CONTROLLER)]
public class SelectedHeroController : ControllerBase
{
    public override void InitChild()
    {
        transform.Find("Heros").gameObject.AddComponent<SelectHeroController>();
        transform.AddButtonAction("OK/Start", () =>
        {
            //todo::/todo:切换到选择英雄界面;
        });
        transform.AddButtonAction("Exit", () =>
        {
            Application.Quit();
        });
        transform.AddButtonAction("Strengthen", () =>
        {
            UIMgr.Instance.Show(Paths.STRENGTHEN_VIEW);
        });
    }
}
