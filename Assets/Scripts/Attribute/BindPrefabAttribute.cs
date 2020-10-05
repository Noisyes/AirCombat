using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AttributeUsage(AttributeTargets.Class)]
public class BindPrefabAttribute : Attribute
{
    public string Path { get; private set; }

    public BindPrefabAttribute(string path)
    {
        this.Path = path;
    }
}
