using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public static class ExtendUtil
{
    public static RectTransform Rect(this Transform trans)
    {
        return trans.GetComponent<RectTransform>();
    }

    public static void SetJsonData(this DataMgr dataMgr, string newKey,JsonData data)
    {
        IJsonWrapper jsonWrapper = data;
        switch (data.GetJsonType())
        {
            case JsonType.None:
                Debug.LogError("当前jsondata为空");
                break;
            case JsonType.Object:
                SetObjectData(newKey,data);
                break;
            case JsonType.Array:
                Debug.LogError("当前jsondata为数组");
                break;
            case JsonType.String:
                DataMgr.Instance.Set(newKey,jsonWrapper.GetString());
                break;
            case JsonType.Int:
                DataMgr.Instance.Set(newKey,jsonWrapper.GetInt());
                break;
            case JsonType.Long:
                DataMgr.Instance.Set(newKey,(int)jsonWrapper.GetLong());
                break;
            case JsonType.Double:
                DataMgr.Instance.Set(newKey,(float)jsonWrapper.GetDouble());
                break;
            case JsonType.Boolean:
                Debug.LogError("当前jsondata为bool类型");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static void SetObjectData(string oldKey, JsonData data)
    {
        foreach (string dataKey in data.Keys)
        {
            if (!DataMgr.Instance.Contains(oldKey + dataKey))
            {
                DataMgr.Instance.SetJsonData(oldKey + dataKey,data[dataKey]);
            }
        }
    }

    public static object DefaultForType(this Type type)
    {
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }

    public static void AddButtonAction(this Transform trans, string path, Action action)
    {
        var transform =  trans.Find(path);
        if (transform == null)
        {
            Debug.LogError("没有找到对应路径的按钮,路径："+path);
        }
        else
        {
            var button = transform.GetComponent<Button>();
            if (button == null)
            {
                Debug.LogError("当前物体上没有button组件,名称:"+transform.name);
            }
            else
            {
                button.onClick.AddListener(() => action?.Invoke());
            }
        }
    }
}
