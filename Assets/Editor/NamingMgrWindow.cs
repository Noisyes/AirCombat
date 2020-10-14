using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class NamingMgrWindow : EditorWindow
{
    private static Dictionary<string,string>  _nameDic = new Dictionary<string, string>();
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<NamingMgrWindow>();
    }

    private void OnGUI()
    {
        GUILayout.Label("资源名称管理器");
        NamingMgrData.UpdateDic();
        foreach (KeyValuePair<FolderData,List<string>> pair in NamingMgrData.NamingDic)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("文件夹路径:");
            GUILayout.Label(pair.Key.Path);
            GUILayout.Label("命名规范");
            GUILayout.Label(pair.Key.NameTip);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            foreach (string s in pair.Value)
            {
                GUILayout.BeginVertical();
                Texture2D texture2D = AssetDatabase.LoadAssetAtPath<Texture2D>(s);
                GUILayout.Box(texture2D,GUILayout.Height(80),GUILayout.Width(80));
                string name = Path.GetFileNameWithoutExtension(s);
                if (!_nameDic.ContainsKey(name))
                    _nameDic[name] = name;
                GUILayout.BeginHorizontal();
                _nameDic[name]= GUILayout.TextField(_nameDic[name], GUILayout.Width(40));
                if (GUILayout.Button("提交", GUILayout.Width(40)))
                {
                    if (_nameDic[name] != name)
                    {
                        RenameFileName(name,_nameDic[name],s);
                        _nameDic.Remove(name);
                    }
                    AssetDatabase.Refresh();
                }
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();
        }

    }

    private void RenameFileName(string sourceName, string destName, string path)
    {
        string newPath = path.Replace(sourceName, destName);
        if (File.Exists(newPath)|| newPath == path)
        {
            Debug.LogError("当前文件名已经存在");
        }
        else
        {
            File.Move(path,newPath);
        }
    }
}

public class NamingMgrData
{
    public static Dictionary<FolderData,List<string>> NamingDic = new Dictionary<FolderData, List<string>>();

    public static void Add(FolderData folderData, string name)
    {
        if (!NamingDic.ContainsKey(folderData))
        {
            NamingDic[folderData] = new List<string>();
        }
        NamingDic[folderData].Add(name);
    }

    public static void UpdateDic()
    {
        foreach (KeyValuePair<FolderData,List<string>> keyValuePair in NamingDic)
        {
            for (int i = 0; i < keyValuePair.Value.Count; i++)
            {
                string s = keyValuePair.Value[i];
                if (!File.Exists(s))
                {
                    keyValuePair.Value.Remove(keyValuePair.Value[i]);
                    i--;
                }
            }
        }
    }
}

public class FolderData
{
    public string Path;
    public string NameTip;
}