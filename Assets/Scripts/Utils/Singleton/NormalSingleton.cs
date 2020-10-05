using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSingleton<T> where T : class, new ()
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                T singleton = new T();
                if(singleton is MonoBehaviour)
                {
                    Debug.LogError("should use MonoBehaviourSingleton");
                }
                _instance = singleton;
            }
            return _instance;
        }
    }
}
