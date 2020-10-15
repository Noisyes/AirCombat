using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using LitJson;
using UnityEngine;

public class ConfigMgr  : NormalSingleton<ConfigMgr>
{
    public void Init()
    {
        IReader json = ReaderMgr.Instance.GetReader(Paths.INITPLANE);
        json["planes"].Get<JsonData>((data) =>
        {
            foreach (JsonData item in data)
            {
                foreach (var itemKey in item.Keys)
                {
                    if(itemKey == "planeId") continue;
                    string key = KeyUtil.CreateKey(int.Parse(data["planeId"].ToString()), itemKey);
                    if (!DataMgr.Instance.Contains(key))
                    {
                        DataMgr.Instance.Set(data[itemKey]);
                    }
                }
            }
        });
    }
}
