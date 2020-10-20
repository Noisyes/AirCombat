using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : ViewBase
{
    protected override void InitChild()
    {
    }
    

    public override void Show()
    {
        base.Show();
       // UpdateSprite();
    }


    public override void UpdateFunc()
    {
        base.UpdateFunc();
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        var id = GameStateMgr.Instance.selectedID;
        int level = DataMgr.Instance.Get<int>(DataKeys.LEVELS);
        UIUtil.Get("Icon").SetSprite(PlanesSpriteMgr.Instance[id,level]);
    }
}
