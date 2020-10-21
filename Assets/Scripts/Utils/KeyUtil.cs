using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUtil
{
    public static string CreateKey(int id, string s)
    {
        return id + s;
    }
    public static string ConvertName(string oldName)
    {
        string newName = oldName.Substring(0, 1).ToUpper() + oldName.Substring(1);
        return newName;
    }
    
    public static string GetNewKey(PropertyItem.ItemKey key,string _key)
    {
        var id = GameStateMgr.Instance.selectedID;
        string newKey = KeyUtil.CreateKey(id, _key + key);
        return newKey;
    }
}
