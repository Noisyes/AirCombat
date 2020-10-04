using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : ILoader
{
    public GameObject LoadPath(string path, Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab, parent);
    }
}
