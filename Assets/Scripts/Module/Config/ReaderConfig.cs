using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaderConfig
{
    private static Dictionary<string, Func<IReader>> _readerDic = new Dictionary<string, Func<IReader>>()
    {
        {".json", () => new JsonReader()},
    };

    public static IReader GetReader(string path)
    {
        foreach (var reader in _readerDic)
        {
            if (path.Contains(reader.Key))
            {
                return reader.Value();
            }
        }
        Debug.LogError("没有当前文件后缀的读取器 文件名路径: "+path);
        return null;
    }
}
