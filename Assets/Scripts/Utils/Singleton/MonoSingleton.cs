using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject(typeof(T).Name);
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<T>();
            }
            return _instance;
        }
    }
}
