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
        return tmp;
    }
}
