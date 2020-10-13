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

    public T LoadData<T>(string path) where T : Object
    {
        T data = Resources.Load<T>(path);
        if (data == null)
        {
         Debug.LogError("当前没有可以加载的数据，路径:"+path);   
        }
        return data;
    }

    public T[] LoadAllData<T>(string path) where T : Object
    {
        T[] datas = Resources.LoadAll<T>(path);
        if (datas == null || datas.Length <= 0)
        {
            Debug.LogError("当前没有可以加载的数据，路径:"+path);
            return null;
        }
        return datas;
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
