using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHeroController : ControllerBase
{
    public override void InitChild()
    {
        int i = 0;
        foreach (Transform trans in transform)
        {
            trans.gameObject.AddComponent<HeroItemController>();
        }
    }
}
