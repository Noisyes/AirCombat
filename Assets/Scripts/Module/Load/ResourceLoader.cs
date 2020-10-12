using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

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

    public void LoadConfig(string path, Action<object> completed)
    {
        CoroutineMgr.Instance.ExecuteOnce(Config(path,completed));
    }

    private IEnumerator Config(string path, Action<object> completed)
    {
        if(Application.platform != RuntimePlatform.Android)
            path = "file://" + path;
        WWW www = new WWW(path);
        yield return www;
        if (www.error != null)
        {
            Debug.LogError("www加载错误，路径"+path);
            yield break;
        }
        completed?.Invoke(www.text);
        Debug.Log("www加载成功，路径"+path);
    }
}
