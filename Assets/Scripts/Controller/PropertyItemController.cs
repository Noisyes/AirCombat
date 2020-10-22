using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PropertyItemController : ControllerBase
{
    private string _key;
    public override void InitChild()
    {
        InitButtonAction();
    }

    public  void Init(string key)
    {
        _key = key;
    }

    private void InitButtonAction()
    {
        transform.AddButtonAction("Add",AddAction);
    }

    private void AddAction()
    {
        var key = KeyUtil.CreateKey(_key + DataKeys.Planes.COST_UNIT);
        var type = DataMgr.Instance.Get<string>(key);
        int money = GameStateMgr.Instance.GetMoney(type);
        key = KeyUtil.GetNewKey(PropertyItem.ItemKey.cost, _key);
        var cost = DataMgr.Instance.Get<int>(key);
        if (cost <= money)
        {
            GameStateMgr.Instance.SetMoney(type,money-cost);
            ChangeData();
        }
    }

    private void ChangeData()
    {
        string key = KeyUtil.GetNewKey(PropertyItem.ItemKey.value,_key);
        Transform ts = transform.Find(KeyUtil.ConvertName(PropertyItem.ItemKey.value.ToString()));
        var value = GetValue(key);
        key = KeyUtil.GetNewKey(PropertyItem.ItemKey.grouth,_key);
        var grouth = GetValue(key);
        value += grouth;
        value = Mathf.Clamp(value, 0, GetValue(KeyUtil.GetNewKey(PropertyItem.ItemKey.maxvalue,_key)));
        DataMgr.Instance.SetObject(KeyUtil.GetNewKey(PropertyItem.ItemKey.value,_key),value);
    }


    private int GetValue(string key)
    {
        return DataMgr.Instance.Get<int>(key);
    }
    
    
}
