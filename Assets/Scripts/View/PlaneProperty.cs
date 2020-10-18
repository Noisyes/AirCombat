using System;
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

    private List<PropertyItem> _propertyItems ;
    protected override void InitChild()
    {
        _propertyItems = new List<PropertyItem>();
        for (Property i = 0; i < Property.COUNT; i++)
        {
            GameObject go = LoadMgr.Instance.LoadPath(Paths.PROPERTY_ITEM, this.transform);
            var init = go.AddComponent<PropertyItem>();
            _propertyItems.Add(init);
            init.Init(i.ToString());
        }
    }
    
}
