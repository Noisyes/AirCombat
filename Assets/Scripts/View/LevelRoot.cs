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
        
    }
}
