using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeroItem : ViewBase
{   
    private Color _defaultColor = Color.gray;
    private Color _selectColor = Color.white;
    private float _lastTime;
    private Image _image;
    private Hero _hero;
    
    public void Unselect()
    {
        _image.DOColor(_defaultColor, _lastTime);
    }

    private void Select()
    {
        _image.DOKill();
        _image.DOColor(_selectColor, _lastTime);
    }

    public override void UpdateFunc()
    {
        base.UpdateFunc();
        if (_hero == GameStateMgr.Instance.hero)
        {
            Select();
        }
        else
        {
            Unselect();
        }
    }

    protected override void InitChild()
    {
        _image = transform.GetComponent<Image>();
        _hero = (Hero) Enum.Parse(typeof(Hero), _image.name);
        Unselect();
    }
}
