using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[BindPrefab(Paths.STRENGTHEN_VIEW)]
public class StrengthenView : ViewBase
{
    protected override void InitChild()
    {
        SwitchPlayer switchPlayer = UIUtil.Get("Switchplayer").GO.AddComponent<SwitchPlayer>();
        PlaneProperty property = UIUtil.Get("Property").GO.AddComponent<PlaneProperty>();
    }
}
