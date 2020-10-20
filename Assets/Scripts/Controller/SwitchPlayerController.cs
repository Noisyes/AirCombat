using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerController : ControllerBase
{
    private int _id;

    public override void InitChild()
    {
        _id = DataMgr.Instance.Get<int>(DataKeys.PLANE_ID);
        transform.AddButtonAction("Left", () =>
        {
            OnSwitchBtn(ref _id, -1);
        });
        transform.AddButtonAction("Right", () =>
        {
            OnSwitchBtn(ref _id, 1);
        });
    }
    private void OnSwitchBtn(ref int id,int direction)
    {
        UpdateID(ref id,direction);
        GameStateMgr.Instance.selectedID = id;
    }

    private void UpdateID(ref int id, int direction)
    {
        int min = 0;
        int max = PlanesSpriteMgr.Instance.Count;
        id = (id + direction) % max;
        if (id < 0) id = max - 1;
    }
}
