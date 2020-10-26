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
            UIMgr.Instance.Show(Paths.LEVELS_VIEW);
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
