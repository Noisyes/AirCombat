using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyItem : MonoBehaviour,IViewUpdate,IViewShow
{
    private static int _itemID = -1;
    private string _key;
    private IReader _reader;
    public enum ItemKey
    {
        name,
        value,
        cost,
        grouth,
    }

    public void Init(string key)
    {
        _key = key;
        _itemID++;
        UpdatePos();
        InitButtonAction();
    }

    private void UpdatePos()
    {
        RectTransform rectTransform = transform.Rect();
        rectTransform.anchoredPosition -= rectTransform.rect.height * _itemID*Vector2.up;
    }

    private void InitButtonAction()
    {
        transform.AddButtonAction("Add",AddAction);
    }

    private void AddAction()
    {
        /*var id = GameStateMgr.Instance.selectedID;
        string key = KeyUtil.CreateKey(id, _key + ItemKey.value);
        Transform ts = transform.Find(ConvertName(ItemKey.value.ToString()));
        float value = (int)DataMgr.Instance.GetObject(key);
        key = KeyUtil.CreateKey(id, _key + ItemKey.grouth);
        float grouth = (int)DataMgr.Instance.GetObject(key);
        value += grouth;*/
    }
    
    private void UpdateData(int planeID)
    {
        for (ItemKey i = 0; i < ItemKey.grouth; i++)
        {
            string itemName = ConvertName(i.ToString());
            Transform ts = transform.Find(itemName);
            if (ts != null)
            {
                string key = KeyUtil.CreateKey(planeID, _key + i);
                ts.GetComponent<Text>().text = DataMgr.Instance.GetObject(key).ToString();
                Debug.LogError("hh2");
            }
            else
            {
                Debug.LogError("预制体属性名称错误");
            }
        }
    }

    private string ConvertName(string oldName)
    {
        string newName = oldName.Substring(0, 1).ToUpper() + oldName.Substring(1);
        return newName;
    }

    public void UpdateView()
    {
        UpdateData(GameStateMgr.Instance.selectedID);
    }

    public void Show()
    {
        var id  = DataMgr.Instance.Get<int>(DataKeys.PLANE_ID);
        UpdateData(id);
    }
}
