using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ReaderMgr : NormalSingleton<ReaderMgr>
{
    private Dictionary<string,IReader> _readerDic = new Dictionary<string, IReader>();

    public IReader GetReader(string path)
    {
        IReader reader = null;
        if (_readerDic.ContainsKey(path))
        {
            reader = _readerDic[path];
        }
        else
        {
            reader = ReaderConfig.GetReader(path);
            LoadMgr.Instance.LoadConfig(path,(data)=>{reader.SetData(data);});
            if(reader != null)
                _readerDic.Add(path,reader);
            else
            {
                Debug.LogError("未获取到对应的Reader , path:" + path);
            }
        }
        return reader;
    }
}
