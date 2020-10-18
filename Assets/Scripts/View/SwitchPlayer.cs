using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : ViewBase
{
    private int _id;
    private Dictionary<int, List<Sprite>> _spriteDictionary;
    protected override void InitChild()
    {
        UIUtil.Get("Left").AddListener(()=>OnSwitchBtn(ref _id,-1));
        UIUtil.Get("Right").AddListener(()=>OnSwitchBtn(ref _id,1));
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

    public override void Show()
    {
        base.Show();
        _id = DataMgr.Instance.Get<int>(DataKeys.PLANE_ID);
        LoadSprites(Paths.PLAYER);
        OnSwitchBtn(ref _id,0);
    }

    private void OnSwitchBtn(ref int id,int direction)
    {
        UpdateID(ref id,direction);
        UpdateSprite(ref id);
        GameStateMgr.Instance.selectedID = id;
    }

    private void UpdateID(ref int id, int direction)
    {
        int min = 0;
        int max = _spriteDictionary[id].Count;
        id = (id + direction) % max;
        if (id < 0) id = max - 1;
    }
    

    private void UpdateSprite(ref int id)
    {
        int level = DataMgr.Instance.Get<int>(DataKeys.LEVELS);
        UIUtil.Get("Icon").SetSprite(_spriteDictionary[id][level]);
    }
}
