using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class InitCustomAtrribute:IInit
{
    public  void Init()
    {
        Assembly assembly = Assembly.GetAssembly(typeof(BindPrefabAttribute));
        Type[] types = assembly.GetTypes();
        foreach (Type type in types)
        {
            foreach (Attribute attribute in type.GetCustomAttributes(typeof(BindPrefabAttribute),true))
            {
                if (attribute is BindPrefabAttribute)
                {
                    var bindAttribute = attribute as BindPrefabAttribute;
                    BindUtil.Bind(bindAttribute,type);
                }
            }
        }
    }
}
