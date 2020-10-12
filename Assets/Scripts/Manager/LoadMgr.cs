using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadMgr : NormalSingleton<LoadMgr>,ILoader
{
    private ILoader _loader;
    public LoadMgr()
    {
        _loader = new ResourceLoader();
    }

    public GameObject LoadPath(string path, Transform parent = null)
    {
        GameObject tmp = _loader.LoadPath(path, parent);
        return tmp;
    }

    public void LoadConfig(string path, Action<object> completed)
    {
        _loader.LoadConfig(path,completed);
    }
}
