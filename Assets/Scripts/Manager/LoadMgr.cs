using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadMgr : NormalSingleton<LoadMgr>
{
    private ILoader _loader;
    public LoadMgr()
    {
        _loader = new ResourceLoader();
    }

    public GameObject LoadPrefab(string path, Transform parent = null)
    {
        GameObject tmp = _loader.LoadPath(path, parent);
        Type type = BindUtil.GetType(path);
        if (type != null)
        {
            tmp.AddComponent(type);
            Debug.LogError("挂载上了 脚本名称："+ type.Name);
        }
        else
        {
            Debug.LogError("没有挂载上脚本");
        }
        return tmp;
    }
}
