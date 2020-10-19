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
        maxvalue,
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
        string key = GetNewKey(ItemKey.value);
        Transform ts = transform.Find(ConvertName(ItemKey.value.ToString()));
        var value = GetValue(key);
        key = GetNewKey(ItemKey.grouth);
        var grouth = GetValue(key);
        value += grouth;
        value = Mathf.Clamp(value, 0, GetValue(GetNewKey(ItemKey.maxvalue)));
        DataMgr.Instance.SetObject(GetNewKey(ItemKey.value),value);
    }

    private string GetNewKey(ItemKey key)
    {
        var id = GameStateMgr.Instance.selectedID;
        string newKey = KeyUtil.CreateKey(id, _key + key);
        return newKey;
    }

    private int GetValue(string key)
    {
        return DataMgr.Instance.Get<int>(key);
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
            }
            else
            {
                Debug.LogError("预制体属性名称错误");
            }
        }
    }

    private void UpdateSlider()
    {
        var slider = transform.Find("Slider").GetComponent<Slider>();
        slider.minValue = 0;
        slider.maxValue = GetValue(GetNewKey(ItemKey.maxvalue));
        slider.value = DataMgr.Instance.Get<int>(GetNewKey(ItemKey.value));
    }

    private string ConvertName(string oldName)
    {
        string newName = oldName.Substring(0, 1).ToUpper() + oldName.Substring(1);
        return newName;
    }

    public void UpdateView()
    {
        UpdateData(GameStateMgr.Instance.selectedID);
        UpdateSlider();
    }

    public void Show()
    {
        var id  = DataMgr.Instance.Get<int>(DataKeys.PLANE_ID);
        UpdateData(id);
        UpdateSlider();
    }
}
