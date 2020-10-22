using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[BindPrefab(Paths.STRENGTHEN_VIEW,Const.BIND_PREFAB_PRIORITY_CONTROLLER)]
public class StrengthenController : ControllerBase
{
    public override void InitChild()
    {
        transform.Find("Switchplayer").gameObject.AddComponent<SwitchPlayerController>();
        transform.Find("Property").gameObject.AddComponent<PlanePropertyController>();
        transform.AddButtonAction("Upgrades/Upgrades",Upgrades);
        transform.AddButtonAction("Back",UIMgr.Instance.Back);
    }
    private void Upgrades()
    {
        var key = KeyUtil.CreateKey(GameStateMgr.Instance.selectedID,
            DataKeys.Planes.UPGRADES + DataKeys.Planes.COST_UNIT);
        var type = DataMgr.Instance.Get<string>(key);
        key = KeyUtil.CreateKey(GameStateMgr.Instance.selectedID, DataKeys.Planes.UPGRADES + GameStateMgr.Instance.selectedLevel);
        var cost = DataMgr.Instance.Get<int>(key);
        int money = GameStateMgr.Instance.GetMoney(type);
        key = KeyUtil.CreateKey(GameStateMgr.Instance.selectedID, DataKeys.Planes.MAX);
        var levelMax = DataMgr.Instance.Get<int>(key);
        if ( GameStateMgr.Instance.selectedLevel < levelMax && cost<=money)
        {
            GameStateMgr.Instance.SetMoney(type,money-cost);
            DoUpgrades();
        }
    }
    

    private void DoUpgrades()
    {
        var key = KeyUtil.CreateKey(GameStateMgr.Instance.selectedID,DataKeys.Planes.COEFFICIENT);
        var cofficient = DataMgr.Instance.Get<int>(key);
        var levels = GameStateMgr.Instance.selectedLevel;
        levels++;
        DataMgr.Instance.Set(key,levels);
        
        ChangePropertyValue(cofficient,PlaneProperty.Property.attack, PropertyItem.ItemKey.value);
        ChangePropertyValue(cofficient,PlaneProperty.Property.attack, PropertyItem.ItemKey.grouth);
        ChangePropertyValue(cofficient,PlaneProperty.Property.attack, PropertyItem.ItemKey.maxvalue);
        ChangePropertyValue(cofficient,PlaneProperty.Property.life, PropertyItem.ItemKey.value);
        ChangePropertyValue(cofficient,PlaneProperty.Property.life, PropertyItem.ItemKey.grouth);
        ChangePropertyValue(cofficient,PlaneProperty.Property.life, PropertyItem.ItemKey.maxvalue);
    }
    private void ChangePropertyValue(int cofficient,PlaneProperty.Property property,PropertyItem.ItemKey itemKey)
    {
        var key = KeyUtil.GetNewKey(itemKey, property.ToString());
        var value = DataMgr.Instance.Get<int>(key);
        value *= cofficient;
        DataMgr.Instance.Set(key,value);
    }
}
