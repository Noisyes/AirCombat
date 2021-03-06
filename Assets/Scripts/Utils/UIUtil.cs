﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUtil : MonoBehaviour
{
    private Dictionary<string, UIUtilData> UIDatas;
    public void Init()
    {
        UIDatas = new Dictionary<string, UIUtilData>();
        RectTransform rect = transform.GetComponent<RectTransform>();
        foreach (RectTransform rectTransform in rect)
        {
            UIDatas.Add(rectTransform.name,new UIUtilData(rectTransform));
        }
    }

    public UIUtilData Get(string name)
    {
        if (UIDatas.ContainsKey(name))
        {
            return UIDatas[name];
        }
        else
        {
            Transform rect = transform.Find(name);
            if (rect == null)
            {
                Debug.LogError("无法按照路径查找到物体， 路径为:" + name);
                return null;
            }
            else
            {
                UIDatas.Add(name,new UIUtilData(rect.GetComponent<RectTransform>()));
                return UIDatas[name];
            }
        }
    }
}

public class UIUtilData
{
    public GameObject GO { get; private set; }
    public RectTransform RectTrans { get; private set; }
    public Text Text { get; private set; }
    public Image Img { get; private set; }

    public UIUtilData(RectTransform transform)
    {
        RectTrans = transform;
        GO = RectTrans.gameObject;
        Text = RectTrans.GetComponent<Text>();
        Img = RectTrans.GetComponent<Image>();
    }

    public void SetSprite(Sprite sprite)
    {
        if (Img != null)
        {
            this.Img.sprite = sprite;
        }
        else
        {
            Debug.LogError("当前物体没有Image组件， 物体名称为 :" + GO.name);
        }
    }

    public void SetText<T>(T content)
    {
        SetText(content.ToString());
    }
    
    
    public void SetText(string content)
    {
        if (Text != null)
        {
            Text.text = content;
        }
        else
        {
            Debug.LogError("当前物体没有Text组件， 物体名称为 :" + GO.name);
        }
    }
}
