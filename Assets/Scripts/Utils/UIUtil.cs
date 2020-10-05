using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUtil : MonoBehaviour
{
    public void Init()
    {

    }
}

public class UIUtilData : MonoBehaviour
{
    public GameObject GO { get; private set; }
    public RectTransform RectTrans { get; private set; }
    public Button Btn { get; private set; }
    public Text Text { get; private set; }
    public Image Img { get; private set; }

    public UIUtilData(RectTransform transform)
    {
        RectTrans = transform;
        GO = RectTrans.gameObject;
        Btn = RectTrans.GetComponent<Button>();
        Text = RectTrans.GetComponent<Text>();
        Img = RectTrans.GetComponent<Image>();
    }
    public void AddListener(Action action)
    {
        if (Btn != null)
        {
            Btn.onClick.AddListener(()=>action());
        }
        else
        {
            Debug.LogError("当前物体没有button组件， 物体名称为 :" + GO.name);
        }
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
}
