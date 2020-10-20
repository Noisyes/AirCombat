using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMgr : NormalSingleton<GameStateMgr>
{
    private int _selectedID;
    public int selectedID
    {
        get
        {
            _selectedID = DataMgr.Instance.Get<int>(DataKeys.PLANE_ID);
            return _selectedID;
        }
        set
        {
            _selectedID = value;
        }
    }
}
