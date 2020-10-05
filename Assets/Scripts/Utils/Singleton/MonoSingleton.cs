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
                _instance = FindObjectOfType<T>();
                if(_instance == null)
                {
                    Debug.LogError($"没有找到mono类单例，当前类型T为:{typeof(T).Name}");
                    return null;
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if(_instance ==null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
