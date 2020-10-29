using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRoot : ViewBase
{
    public enum levels
    {
        totalLevels,
        eachRow,
        Count
    }
    private TaskPool<int> _taskPool;
    private IReader reader;
    protected override void InitChild()
    {
        _taskPool = new TaskPool<int>();
        reader = ReaderMgr.Instance.GetReader(Paths.INITLEVLES);
        //_taskPool.Add(GetTotalLevels);
        //_taskPool.Add(GetEachRow);
        for (levels i = 0; i < levels.Count; i++)
        {
            string name = i.ToString();
            _taskPool.Add((id) =>
            {
                reader[name].Get<int>((data) =>
                {
                    _taskPool.AddValue(id,data,onComplete);
                });
            });
        }
        _taskPool.Execute();
    }

    private void onComplete(int[] list)
    {
        if (list.Length != (int)levels.Count)
        {
            Debug.LogError("数量不对劲");
            return;
        }

        int totalCount = list[(int) levels.totalLevels];
        int eachRow = list[(int) levels.eachRow];
        SpawnItem(eachRow,totalCount);
    }

    private void SpawnItem(int eachRow,int totalCount)
    {
        GameObject go;
        LevelItem levelItem;
        for (int i = 0; i < totalCount; i++)
        {
            go = LoadMgr.Instance.LoadPath(Paths.LEVEL_ITEM,transform);
            levelItem = go.AddComponent<LevelItem>();
            levelItem.InitData(i,eachRow);
        }
    }
}
