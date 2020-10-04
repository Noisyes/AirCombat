using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMgr : NormalSingleton<LoadMgr>
{
    private ILoader _loader;
    public LoadMgr()
    {
        _loader = new ResourceLoader();
    }

    GameObject LoadPrefab(string path, Transform parent = null)
    {
       return  _loader.LoadPath(path, parent);
    }
}
