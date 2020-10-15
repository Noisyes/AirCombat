using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEditor;
using UnityEngine;

public static class ExtendUtil
{
    public static RectTransform Rect(this Transform trans)
    {
        return trans.GetComponent<RectTransform>();
    }

    public static void Set(this DataMgr dataMgr, JsonData data)
    {
        switch (data.GetJsonType())
        {
            case JsonType.None:
                Debug.LogError("当前jsondata为空");
                break;
            case JsonType.Object:
                break;
            case JsonType.Array:
                break;
            case JsonType.String:
                break;
            case JsonType.Int:
                break;
            case JsonType.Long:
                break;
            case JsonType.Double:
                break;
            case JsonType.Boolean:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
