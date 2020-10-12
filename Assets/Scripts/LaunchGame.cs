using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    private void Awake()
    {
        InitCustomAtrribute.Init();
        UIMgr.Instance.Show(Paths.START_VIEW);
         
        var reader = ReaderMgr.Instance.GetReader(Paths.INITPLANE);
        reader["planes"][0]["fireRate"].Get<float>((num)=>Debug.LogError(num));
    }
}
