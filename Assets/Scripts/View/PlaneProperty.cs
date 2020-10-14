using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneProperty : ViewBase
{
    public enum Property
    {
        attack,
        fireRate,
        life,
        COUNT
    }
    
    protected override void InitChild()
    {
        for (Property i = 0; i < Property.COUNT; i++)
        {
            GameObject go = LoadMgr.Instance.LoadPath(Paths.PROPERTY_ITEM, this.transform);
            var init = go.AddComponent<PropertyItem>();
            init.Init(i.ToString());
        }
    }
}
