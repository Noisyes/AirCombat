using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindUtil
{
    private static Dictionary<string,List<Type>> BindDic = new Dictionary<string, List<Type>>();
    private static Dictionary<Type,int> _priorityDic = new Dictionary<Type, int>();

    public static void Bind(BindPrefabAttribute data, Type type)
    {
        string path = data.Path;
        if (!BindDic.ContainsKey(path))
        {
            BindDic.Add(path, new List<Type>());
        }
        if (!BindDic[path].Contains(type))
        {
            BindDic[path].Add(type);
            _priorityDic.Add(type,data.Priority);
            BindDic[path].Sort(new BindCompare());
        }
        else
        {
            Debug.LogError("重复绑定脚本 脚本名字:"+type.Name);
        }
    }

    public static List<Type> GetType(string path)
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

    public class BindCompare : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {
            if (x == null) return 1;
            if (y == null) return -1;
            return _priorityDic[x] - _priorityDic[y];
        }
    }
}
