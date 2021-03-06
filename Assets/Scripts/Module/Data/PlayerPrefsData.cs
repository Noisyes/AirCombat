﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Object = System.Object;

public class PlayerPrefsData : IData
{
    private Dictionary<Type, Func<string, object>> _dataGetter = new Dictionary<Type, Func<string, object>>
    {
        {typeof(int),(key) => PlayerPrefs.GetInt(key,default(int))},
        {typeof(float),(key) => PlayerPrefs.GetFloat(key,default(float))},
        {typeof(string),(key) => PlayerPrefs.GetString(key,default(string))},


        
    };
    private Dictionary<Type, Action<string,object>> _dataSetter = new Dictionary<Type, Action<string, object>>
    {
        {typeof(int),(key,value) => PlayerPrefs.SetInt(key,(int)value)},
        {typeof(string),(key,value) => PlayerPrefs.SetString(key,(string)value)},
        {typeof(float),(key,value) => PlayerPrefs.SetFloat(key,(float)value)},
        
    };
    public T Get<T>(string key)
    {
        Type type = typeof(T);
        var convert = TypeDescriptor.GetConverter(type);
        if (_dataGetter.ContainsKey(type))
        {
            return (T) convert.ConvertTo(_dataGetter[type](key), type);
        }
        else
        {
            Debug.LogError("没有当前数据类型的方法 当前数据类型名" + type.Name);
            return default(T);
        }
    }

    public void Set<T>(string key, T value)
    {
        Type type = typeof(T);
        if (_dataSetter.ContainsKey(type))
        {
            _dataSetter[type]?.Invoke(key,value);
        }
        else
        {
            Debug.LogError("当前没有此数据类型的数据加载器 数据 key: "+ key +"value: "+value);
        }
    }

    public void Clear(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    public void ClearAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public bool Contains(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public object GetObject(string key)
    {
        if (Contains(key))
        {
            foreach (KeyValuePair<Type,Func<string,object>> pair in _dataGetter)
            {
                Type type = pair.Key;
                object oj = type.DefaultForType();
                object tmp = pair.Value(key);
                if (!Equals(pair.Value(key),oj))
                {
                    return pair.Value(key);
                }
            }
            return null;
        }
        return null;
    }

    public void SetObject(string key, object value)
    {
        bool isSuccess = false;
        foreach (KeyValuePair<Type,Action<string,object>> valuePair in _dataSetter)
        {
            if (valuePair.Key == value.GetType())
            {
                valuePair.Value(key,value);
                isSuccess = true;
            }
        }
        if (!isSuccess)
        {
            Debug.LogError("当前的数据类型不对劲");
        }
    }
}
