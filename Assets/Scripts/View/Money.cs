using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : ViewBase
{
    protected override void InitChild()
    {
       
    }

    public override void UpdateFunc()
    {
        base.UpdateFunc();
        UIUtil.Get("Star/BG/Text").SetText(DataMgr.Instance.Get<int>(DataKeys.STAR).ToString());
        UIUtil.Get("Diamond/BG/Text").SetText(DataMgr.Instance.Get<int>(DataKeys.DIAMOND).ToString());
    }
}
