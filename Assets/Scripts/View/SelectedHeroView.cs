using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[BindPrefab(Paths.SELECTEDHERO_VIEW,Const.BIND_PREFAB_PRIORITY_VIEW)]
public class SelectedHeroView : ViewBase
{
    protected override void InitChild()
    {
        UIUtil.Get("OK/Start").AddListener(() =>
        {
            //todo:切换到选择英雄界面;
        });
        UIUtil.Get("Exit").AddListener(() =>
        {
            Application.Quit();
        });
        UIUtil.Get("Strengthen").AddListener(() =>
        {
            UIMgr.Instance.Show(Paths.STRENGTHEN_VIEW);
        });
        UIUtil.Get("Heros").GO.AddComponent<SelectHero>();
    }
}
