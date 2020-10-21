using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycleAddConfig
{
    public List<object> Objects;
    
    public void Add()
    {
        Objects.Add(ConfigMgr.Instance);
        Objects.Add(new InitCustomAtrribute());
        Objects.Add(PlanesSpriteMgr.Instance);
    }
}
