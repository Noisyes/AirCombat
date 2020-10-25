using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HeroItemController : ControllerBase
{
    private Hero _hero;
    public override void InitChild()
    {
        string heroName = transform.GetComponent<Image>().name;
        transform.GetComponent<Button>().onClick.AddListener(Select);
        _hero = (Hero)Enum.Parse(typeof(Hero), heroName);
    }

    private void Select()
    {
        GameStateMgr.Instance.hero = _hero;
    }
}
