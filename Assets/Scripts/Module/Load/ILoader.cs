﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader
{
    GameObject LoadPath(string path, Transform parent = null);
    void LoadConfig(string path, Action<object> completed);
    T LoadData<T>(string path) where T:UnityEngine.Object;
    T[] LoadAllData<T>(string path) where T:UnityEngine.Object;
}
