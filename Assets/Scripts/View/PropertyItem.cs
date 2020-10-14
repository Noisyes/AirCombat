using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyItem : MonoBehaviour
{
    private string _key;
    private IReader _reader;
    public enum ItemKey
    {
        name,
        value,
        cost,
        grouth,
        COUNT
    }

    public void Init(string key)
    {
        _key = key;
    }

    public void UpdateID(int id)
    {
        IReader planes = ReaderMgr.Instance.GetReader(Paths.INITPLANE);
        _reader =  planes["planes"][id][_key];
    }
}
