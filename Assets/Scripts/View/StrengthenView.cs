using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[BindPrefab(Paths.STRENGTHEN_VIEW)]
public class StrengthenView : ViewBase
{
    protected override void InitChild()
    {
        UIUtil.Get("Switchplayer").GO.AddComponent<SwitchPlayer>();
    }
}
