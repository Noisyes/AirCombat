using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[BindPrefab(Paths.SELECTEDHERO_VIEW)]
public class SelectedHeroView : ViewBase
{
    public override void Init()
    {
        base.Init();
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
            //todo:切换到强化界面
        });
        UIUtil.Get("Heros").GO.AddComponent<SelectHero>();
    }
}
