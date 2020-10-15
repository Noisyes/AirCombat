using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using LitJson;
using TMPro;
using UnityEngine;

public class JsonReader : IReader
{
    private JsonData _data;
    private JsonData _curData;
    private KeyQueue _keyQueue;
    private Queue<KeyQueue> _queues = new Queue<KeyQueue>();
    public IReader this[string key]
    {
        get
        {
            if (!SetKey(key))
            {
                _curData = _curData[key];
            }
            return this;
        }
    }

    private bool SetKey<T>(T key)
    {
        if (_data == null || _keyQueue != null)
        {
            if (_keyQueue == null)
                _keyQueue = new KeyQueue();
            Key keyValue = new Key();
            keyValue.Set(key);
            _keyQueue.EnQueue(keyValue);
            return true;
        }
        return false;
    }

    public IReader this[int key]
    {
        get
        {
            if (!SetKey(key))
            {
                _curData = _curData[key];
            }
            return this;
        }
    }

    public void Get<T>(Action<T> callBack)
    {
        if (_keyQueue != null)
        {
            _keyQueue.OnComplete((dataTmp) =>
            {
                T dataValue = GetValue<T>(dataTmp);
                callBack?.Invoke(dataValue);
                ResetData();
                return;
            });
            _queues.Enqueue(_keyQueue);
            _keyQueue = null;
            ExecuteKeyQueue();
            return;
        }
        T data = GetValue<T>(_curData);
        callBack?.Invoke(data);
        ResetData();
    }

    private void ExecuteKeyQueue()
    {
        if (_data == null) return;
        IReader tmpReader = null;
        foreach (KeyQueue keyQueue in _queues)
        {
            foreach (object keyValue in keyQueue)
            {
                if (keyValue is string)
                {
                    tmpReader = this[(string)keyValue];
                }
                else if (keyValue is int)
                {
                    tmpReader = this[(int) keyValue];
                }
                else
                {
                    Debug.LogError("key类型有误");
                }
            }
            keyQueue.Complete(_curData);
        }
    }

    private T GetValue<T>(JsonData data)
    {
        try
        {
            var convert = TypeDescriptor.GetConverter(typeof(T));
            if (convert.CanConvertTo(typeof(T)))
            {
                return (T) convert.ConvertTo(data.ToString(), typeof(T));
            }
            else
            {
                return (T)(object) data;
            }
        }
        catch
        {
            Debug.LogError("当前类型无法转换，类型为"+typeof(T));
            return default(T);
        }
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
            ExecuteKeyQueue();
        }
        else
        {
            Debug.LogError("不是Json类型的数据");
        }
    }

    public ICollection<string> Keys()
    {
        if (_curData == null)
        {
            return new List<string>();
        }

        return _curData.Keys;
    }
}

public class KeyQueue : IEnumerable
{
    private Queue<IKey> _keys = new Queue<IKey>();
    private Action<JsonData> _complete;
    public void EnQueue(IKey key)
    {
        _keys.Enqueue(key);
    }

    public void DeQueue()
    {
        _keys.Dequeue();
    }

    public void Clear()
    {
        _keys.Clear();
    }

    public void Complete(JsonData data)
    {
        _complete?.Invoke(data);
    }

    public void OnComplete(Action<JsonData> callBack)
    {
        _complete = callBack;
    }

    public IEnumerator GetEnumerator()
    {
        foreach (IKey key in _keys)
        {
            yield return key.Get();
        }
    }
}

public interface IKey
{
    void Set<T>(T val);
    object Get();
    Type KeyType { get; }
}

public class Key : IKey
{
    private object _key;
    public Type KeyType { get; private set; }
    public void Set<T>(T val)
    {
        _key = val;
    }

    public object Get()
    {
        return _key;
    }


}
