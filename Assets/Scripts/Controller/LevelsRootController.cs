using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsRootController : ControllerBase
{
    public override void InitChild()
    {
        var reader = ReaderMgr.Instance.GetReader(Paths.INITLEVLES);
        reader["totalLevels"].Get<int>((data) =>
        {
            CoroutineMgr.Instance.ExecuteOnce(AddLevelItemController(data));
        });
        
    }

    IEnumerator AddLevelItemController(int Count)
    {
        yield return  new WaitUntil(() =>
        {
            return transform.childCount >= Count;
        });
        AddComponent();
    }
    
    private void AddComponent()
    {
        foreach (Transform trans in transform)
        {
            trans.gameObject.AddComponent<LevelItemContrller>();
        }
    }
}
