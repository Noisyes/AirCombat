using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHero : ViewBase
{
    // Start is called before the first frame update
    
    protected override void InitChild()
    {
        foreach (Transform trans in transform)
        {
            trans.gameObject.AddComponent<HeroItem>();
        }
    }
}
