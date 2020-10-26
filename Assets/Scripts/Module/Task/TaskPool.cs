using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPool
{
    public int ID { get; set; } = -1;
    private int Cnt { get; set; } = -1;
    public object[] _List;
    public int Capacity { get; set; } = 100;
    public TaskPool()
    {
        _queue = new Queue<Action<int>>();
    }
    private Queue<Action<int>> _queue;

    public void Add(Action<int> item)
    {
        ID++;
        _queue.Enqueue(item);
    }

    public void Execute()
    {
        _List = new object[ID+1];
        while (_queue.Count > 0)
        {
            var top = _queue.Peek();
            top?.Invoke(ID);
            _queue.Dequeue();
        }
    }

    public void AddValue(int id,object data,Action<object[]> onComplte)
    {
        _List[id] = data;
        Cnt++;
        if (Cnt == ID)
        {
            onComplte?.Invoke(_List);
        }
        else
        {
            Debug.LogError("执行次数有问题");
        }
    }
}

public class TaskPool<T>
{
    public int ID { get; set; } = -1;
    private int Cnt { get; set; } = -1;
    public T[] _List;
    public int Capacity { get; set; } = 100;
    public TaskPool()
    {
        _queue = new Queue<Action<int>>();
    }
    private Queue<Action<int>> _queue;

    public void Add(Action<int> item)
    {
        ID++;
        _queue.Enqueue(item);
    }

    public void Execute()
    {
        int id = -1;
        _List = new T[ID+1];
        while (_queue.Count > 0)
        {
            id++;
            var top = _queue.Peek();
            top?.Invoke(id);
            _queue.Dequeue();
        }
    }

    public void AddValue(int id,T data,Action<T[]> onComplte)
    {
        _List[id] = data;
        Cnt++;
        if (Cnt == ID)
        {
            onComplte?.Invoke(_List);
        }
        else if(Cnt>ID)
        {
            Debug.LogError("执行次数有问题");
        }
    }
}
