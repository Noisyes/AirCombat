using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlanesSpriteMgr : NormalSingleton<PlanesSpriteMgr>,IInit
{
    private Dictionary<int, List<Sprite>> _spriteDictionary;

    public int Count
    {
        get
        {
            if (_spriteDictionary == null)
                LoadSprites(Paths.PLAYER);
            return _spriteDictionary.Count;
        }
    }

    public Sprite this[int key,int levels]
    {
        get
        {
            return GetSprite(key, levels);
        }
    }
    public void Init()
    {    
        LoadSprites(Paths.PLAYER);
    }
    private void LoadSprites(string path)
    {
        Sprite[] sprites = LoadMgr.Instance.LoadAllData<Sprite>(path);
        _spriteDictionary = new Dictionary<int, List<Sprite>>();
        foreach (Sprite sprite in sprites)
        {
            string[] idAndLevel = sprite.name.Split('_');
            int id = Int32.Parse(idAndLevel[0]);
            if (!_spriteDictionary.ContainsKey(id))
            {
                _spriteDictionary.Add(id,new List<Sprite>());
            }
            _spriteDictionary[id].Add(sprite);
        }
    }

    private Sprite GetSprite(int key, int levels)
    {
        if(_spriteDictionary == null)
            LoadSprites(Paths.PLAYER);
        if (!_spriteDictionary.ContainsKey(key) || _spriteDictionary[key].Count <= levels)
        {
            Debug.LogError("当前字典中没有对应的sprite");
            return null;
        }
        return _spriteDictionary[key][levels];
    }
}
