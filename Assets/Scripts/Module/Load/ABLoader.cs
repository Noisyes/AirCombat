using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
