using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItemContrller : ControllerBase
{
    private int _id;
    public override void InitChild()
    {
        _id = transform.GetSiblingIndex();
    }
}
