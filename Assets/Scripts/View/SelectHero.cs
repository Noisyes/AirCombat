using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHero : MonoBehaviour
{
    // Start is called before the first frame update
    private HeroItem[] _heroItems;
    void Start()
    {
        _heroItems = new HeroItem[transform.childCount];
        int i = 0;
        foreach (Transform trans in transform)
        {
            _heroItems[i] = trans.gameObject.AddComponent<HeroItem>();
            _heroItems[i].CallBack = ResetColor;
            i++;
        }
    }

    private void ResetColor()
    {
        foreach (HeroItem heroItem in _heroItems)
        {
            heroItem.Unselect();
        }
    }
}
