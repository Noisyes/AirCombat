using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyItem : MonoBehaviour
{
    private static int _id = -1;
    private string _key;
    private IReader _reader;
    public enum ItemKey
    {
        name,
        value,
        cost,
        grouth,
        COUNT
    }

    public void Init(string key)
    {
        _key = key;
        _id++;
        UpdatePos();
    }

    private void UpdatePos()
    {
        RectTransform rectTransform = transform.Rect();
        rectTransform.anchoredPosition -= rectTransform.rect.height * _id*Vector2.up;
    }

    public void UpdateID(int id)
    {
        IReader planes = ReaderMgr.Instance.GetReader(Paths.INITPLANE);
        _reader =  planes["planes"][id][_key];
    }
}
