﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IData
{
    T Get<T>(string key);
    void Set<T>(string key, T value);
    void Clear(string key);
    void ClearAll();
    bool Contains(string key);
    object GetObject(string key);
    void SetObject(string key, object value);
}
