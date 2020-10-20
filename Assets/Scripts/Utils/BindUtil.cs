using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindUtil
{
    private static Dictionary<string,HashSet<Type>> BindDic = new Dictionary<string, HashSet<Type>>();

    public static void Bind(string path, Type type)
    {
        if (!BindDic.ContainsKey(path))
        {
            BindDic.Add(path, new HashSet<Type>());
        }

        BindDic[path].Add(type);
    }

    public static HashSet<Type> GetType(string path)
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
