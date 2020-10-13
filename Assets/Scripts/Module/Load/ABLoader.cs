using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ABLoader : ILoader
{
    public GameObject LoadPath(string path, Transform parent = null)
    {
        throw new System.NotImplementedException();
    }

    public void LoadConfig(string path, Action<object> completed)
    {
        throw new NotImplementedException();
    }

    public T LoadData<T>(string path) where T : Object
    {
        throw new NotImplementedException();
    }

    public T[] LoadAllData<T>(string path) where T : Object
    {
        throw new NotImplementedException();
    }
}
