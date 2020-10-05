using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindUtil
{
    private static Dictionary<string,Type> BindDic = new Dictionary<string, Type>();

    public static void Bind(string path, Type type)
    {
        if (!BindDic.ContainsKey(path))
        {
            BindDic.Add(path, type);
        }
        else
        {
            Debug.LogError("重复绑定特性");
        }
    }

    public static Type GetType(string path)
    {
        if (BindDic.ContainsKey(path))
        {
            return BindDic[path];
        }
        else
        {
            Debug.LogError("脚本绑定字典没有关键字");
            return null;
        }
    }
}
