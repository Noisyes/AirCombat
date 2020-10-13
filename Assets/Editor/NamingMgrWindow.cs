using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NamingMgrWindow : EditorWindow
{
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<NamingMgrWindow>();
    }

    private void OnGUI()
    {
        GUILayout.Label("资源名称管理器");
        
    }
}

public class NamingMgrData
{
    public static Dictionary<string,List<Sprite>> NamingDic = new Dictionary<string, List<Sprite>>();
}
