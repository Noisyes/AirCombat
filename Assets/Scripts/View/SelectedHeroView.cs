using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[BindPrefab(Paths.SELECTEDHERO_VIEW,Const.BIND_PREFAB_PRIORITY_VIEW)]
public class SelectedHeroView : ViewBase
{
    protected override void InitChild()
    {
        UIUtil.Get("Heros").GO.AddComponent<SelectHero>();
    }
}
