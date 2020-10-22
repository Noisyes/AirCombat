using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMgr : NormalSingleton<GameStateMgr>
{
    public int selectedID { get; set; }

    public int selectedLevel
    {
        get
        {
            var key = KeyUtil.CreateKey(GameStateMgr.Instance.selectedID, DataKeys.Planes.LEVEL);
            return DataMgr.Instance.Get<int>(key);
        }
    }

    public int GetMoney(string type)
    {
        int money = 0;
        switch (type)
        {
            case DataKeys.STAR:
                money = DataMgr.Instance.Get<int>(DataKeys.STAR);
                break;
            case DataKeys.DIAMOND:
                money = DataMgr.Instance.Get<int>(DataKeys.DIAMOND);
                break;
            default:
                Debug.LogError("当前没有这种类型得货币");
                break;
        }

        return money;
    }

    public void SetMoney(string type, int value)
    {
        switch (type)
        {
            case DataKeys.STAR:
                DataMgr.Instance.Set(DataKeys.STAR,value);
                break;
            case DataKeys.DIAMOND:
                DataMgr.Instance.Set(DataKeys.DIAMOND,value);
                break;
            default:
                Debug.LogError("当前没有这种类型得货币");
                break;
        }
    }

}
