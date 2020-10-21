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
    }

    private void UpdatePos()
    {
        RectTransform rectTransform = transform.Rect();
        rectTransform.anchoredPosition -= rectTransform.rect.height * _itemID*Vector2.up;
    }
    
    private int GetValue(string key)
    {
        return DataMgr.Instance.Get<int>(key);
    }
    
    private void UpdateData(int planeID)
    {
        for (ItemKey i = 0; i < ItemKey.grouth; i++)
        {
            string itemName = KeyUtil.ConvertName(i.ToString());
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
        slider.maxValue = GetValue(KeyUtil.GetNewKey(ItemKey.maxvalue,_key));
        slider.value = DataMgr.Instance.Get<int>(KeyUtil.GetNewKey(ItemKey.value,_key));
    }



    public void UpdateFunc()
    {
        UpdatePlaneID(GameStateMgr.Instance.selectedID);
    }

    public void Show()
    {
        UpdatePlaneID(DataMgr.Instance.Get<int>(DataKeys.PLANE_ID));
    }

    private void UpdatePlaneID(int id)
    {
        UpdateData(id);
        UpdateSlider();
    }
}
