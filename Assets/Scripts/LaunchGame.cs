using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    private void Awake()
    {
        InitCustomAtrribute.Init();
        UIMgr.Instance.Show(Paths.START_VIEW);
        JsonReader  jsonReader = new JsonReader();
        string _json = "{'planes':[{'planeId':1,'level':2,'fireRate':0.8}]}";

        jsonReader["planes"][0]["fireRate"].Get<float>((value)=>{Debug.LogError(value);});
        jsonReader["planes"][0]["level"].Get<float>((value)=>{Debug.LogError(value);});
        jsonReader.SetData(_json);
    }
}
