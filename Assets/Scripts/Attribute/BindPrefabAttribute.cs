using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AttributeUsage(AttributeTargets.Class)]
public class BindPrefabAttribute : Attribute
{
    public string Path { get; }
    public int Priority { get; }

    public BindPrefabAttribute(string path,int priority)
    {
        this.Path = path;
        this.Priority = priority;
    }
}
