using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[BindPrefab(Paths.STRENGTHEN_VIEW,Const.BIND_PREFAB_PRIORITY_VIEW)]
public class StrengthenView : ViewBase
{
    protected override void InitChild()
    {
        SwitchPlayer switchPlayer = UIUtil.Get("Switchplayer").GO.AddComponent<SwitchPlayer>();
        PlaneProperty property = UIUtil.Get("Property").GO.AddComponent<PlaneProperty>();
        UIUtil.Get("Money").GO.AddComponent<Money>();
    }

    public override void UpdateFunc()
    {
        base.UpdateFunc();
        InitLevelView();
    }

    private void InitLevelView()
    {
        var key = KeyUtil.CreateKey(GameStateMgr.Instance.selectedID, DataKeys.Planes.UPGRADES + DataKeys.NAME);
        UIUtil.Get("Upgrades/Text").SetText(DataMgr.Instance.Get<string>(key));
        key = KeyUtil.CreateKey(GameStateMgr.Instance.selectedID, DataKeys.Planes.LEVEL);
        var levels = DataMgr.Instance.Get<int>(key);
        key = KeyUtil.CreateKey(GameStateMgr.Instance.selectedID, DataKeys.Planes.UPGRADES + levels);
        var cost = DataMgr.Instance.Get<int>(key);
        UIUtil.Get("Upgrades/Upgrades/Text").SetText(cost);
    }
}
