using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycleMgr : MonoSingleton<LifeCycleMgr>,IInit
{
    private LifeCycleAddConfig AddConfig;
    void IInit.Init()
    {
        AddConfig = new LifeCycleAddConfig();
        AddConfig.Objects = new List<object>();
        AddConfig.Add();
        InitObjects();

        LifeCycleConfig._lifeCycleFuncs[LifeCycleType.Init]();
    }
    private void InitObjects()
    {
        foreach (object obj in AddConfig.Objects)
        {
            foreach (KeyValuePair<LifeCycleType, ILifeCycle> lifeCycle in LifeCycleConfig._lifeCycle)
            {
                lifeCycle.Value.Add(obj);
            }
        }
    }
}

public interface ILifeCycle
{
    void Add(object obj);
    void Execute<T>(Action<T> action);
}

public class LifeCycle<T> :ILifeCycle
{
    private List<object> _objects;
    
    public LifeCycle()
    {
        _objects = new List<object>();
    }

    public void Add(object obj)
    {
        if (obj is T)
        {
            _objects.Add(obj);
        }
    }

    public void Execute<T1>(Action<T1> action)
    {
        foreach (var obj in _objects)
        {
            action((T1)obj);
        }
    }
}
