using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CoroutineController
{
    private MonoBehaviour _mono;
    private CoroutineItem _coroutine;
    private IEnumerator _it;
    private static int _id;
    private Coroutine _tmpCoroutine = null;
    public int ID { get; private set; }
    public CoroutineController(MonoBehaviour mono, IEnumerator it)
    {
        _mono = mono;
        _it = it;
        _coroutine = new CoroutineItem();
        SetId();
    }
    public void Start()
    {
        _coroutine.State = CoroutineItem.CoroutineState.RUNNING;
        _tmpCoroutine = _mono.StartCoroutine(_coroutine.Body(_it));
    }
    public void Pause()
    {
        _coroutine.State = CoroutineItem.CoroutineState.PAUSE;
    }
    public void Stop()
    {
        _coroutine.State = CoroutineItem.CoroutineState.STOP;
    }

    public void Continue()
    {
        _coroutine.State = CoroutineItem.CoroutineState.RUNNING;
    }

    public void ReStart()
    {
        if(_tmpCoroutine != null)
            _mono.StopCoroutine(_tmpCoroutine);
        Start();
    }

    private void SetId()
    {
        ID = _id++;
    }
}
