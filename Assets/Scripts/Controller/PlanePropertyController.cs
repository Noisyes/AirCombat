using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePropertyController : ControllerBase
{
    public override void InitChild()
    {
       AddComponent();
    }

    private void AddComponent()
    {
        for (PlaneProperty.Property i = 0; i < PlaneProperty.Property.COUNT; i++)
        {
            var trans = transform.GetChild((int) i).transform;
            var controller = trans.gameObject.AddComponent<PropertyItemController>();
            controller.Init(i.ToString());
        }
    }
}
