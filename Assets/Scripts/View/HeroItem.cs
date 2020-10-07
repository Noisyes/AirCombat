using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeroItem : MonoBehaviour
{   
    private Color _defaultColor = Color.gray;
    private Color _selectColor = Color.white;
    private float _lastTime;
    private Image _image;
    
    public Action CallBack { get; set; }

    private void Start()
    {
        _image = transform.GetComponent<Image>();
        transform.GetComponent<Button>().onClick.AddListener(Select);
        Unselect();
    }

    public void Unselect()
    {
        _image.DOColor(_defaultColor, _lastTime);
    }

    private void Select()
    {
        CallBack?.Invoke();
        _image.DOKill();
        _image.DOColor(_selectColor, _lastTime);
    }
}
