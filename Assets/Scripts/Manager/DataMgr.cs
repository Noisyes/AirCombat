using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr : NormalSingleton<DataMgr>,IData
{
    private IData _data;

    public DataMgr()
    {
        _data = new PlayerPrefsData();
    }

    public T Get<T>(string key)
    {
        return _data.Get<T>(key);
    }

    public void Set<T>(string key, T value)
    {
        _data.Set<T>(key,value);
    }

    public void Clear(string key)
    {
        _data.Clear(key);
    }

    public void ClearAll()
    {
        _data.ClearAll();
    }

    public bool Contains(string key)
    {
        return _data.Contains(key);
    }

    public object GetObject(string key)
    {
        return _data.GetObject(key);
    }

    public void SetObject(string key, object value)
    {
        _data.SetObject(key, value);
    }
}
