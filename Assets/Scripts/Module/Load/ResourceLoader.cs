using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : ILoader
{
    public GameObject LoadPath(string path, Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab == null)
        {
            Debug.LogError("没有找到对应路径的预制体 路径为：" + path);
        }
        return Object.Instantiate(prefab, parent);
        
    }
}
