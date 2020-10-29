using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelItem : ViewBase
{
    public int _id;
    public int EachRow { get; private set; }
    private int _leftOffset = 20;
    private int _rowOffset = 2;
    private int _colOffset = 2;

    protected override void InitChild()
    {
        
    }

    public void InitData(int id, int eachRow)
    {
        _id = id;
        EachRow = eachRow;
        var pos = GetPos();
        SetPos(pos);
        SetMask(checkPass());
        SetLevelText();
    }

    private Vector2 GetPos()
    {
        int x = _id / EachRow;
        int y = _id % EachRow;
        return new Vector2(x,y);
    }

    private void SetPos(Vector2 pos)
    {
        int offset = pos.x % 2 == 0 ? _leftOffset : 0;
        RectTransform rect = transform.Rect();
        int height = (int) (rect.rect.height * transform.localScale.y);
        int width = (int) (rect.rect.width* transform.localScale.x);
        double x = offset + width * 0.5 + (width + _colOffset) * pos.y;
        double y = height * 0.5 + (width + _rowOffset) * pos.x;
        rect.localPosition = new Vector2((float)x,(float)-y);
    }

    private bool checkPass()
    {
        int passed = -1;
        if (DataMgr.Instance.Contains(DataKeys.PASSLEVELS))
        {
            passed = DataMgr.Instance.Get<int>(DataKeys.PASSLEVELS);
        }
        return _id <= passed + 1;
    }

    private void SetMask(bool isPassed)
    {
        UIUtil.Get("Mask").GO.SetActive(!isPassed);
    }

    private void SetLevelText()
    {
        UIUtil.Get("Mask/Text").SetText(_id+1);
    }
}
