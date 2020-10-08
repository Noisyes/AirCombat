using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class JsonReader : IReader
{
    private JsonData _data;
    private JsonData _curData;
    public IReader this[string key]
    {
        get
        {
            _curData = _data[key];
            return this;
        }
    }

    public IReader this[int key]
    {
        get
        {
            _curData = _curData[key];
            return this;
        }
    }

    public void Get<T>(Action<T> callBack)
    {
        T data = GetValue<T>(_curData);
        callBack?.Invoke(data);
        ResetData();
    }

    private T GetValue<T>(JsonData data)
    {
        
    }

    private void ResetData()
    {
        _curData = _data;
    }

    public void SetData(object data)
    {
        if (data is string)
        {
            _data = JsonMapper.ToObject(data as string);
            ResetData();
        }
        else
        {
            Debug.LogError("不是Json类型的数据");
        }
    }
}
