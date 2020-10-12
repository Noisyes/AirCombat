using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineMgr : MonoSingleton<CoroutineMgr>
{
    private Dictionary<int, CoroutineController> _controllers;

    public CoroutineMgr()
    {
        _controllers = new Dictionary<int, CoroutineController>();
    }

    public int Execute(IEnumerator it, bool isAuto = true)
    {
        CoroutineController tmpController = new CoroutineController(this, it);
        _controllers.Add(tmpController.ID, tmpController);
        if (isAuto)
            StartExecute(tmpController.ID);
        return tmpController.ID;
    }

    public void ExecuteOnce(IEnumerator it)
    {
        CoroutineController tmpController = new CoroutineController(this, it);
        tmpController.Start();
    }

    public void StartExecute(int id)
    {
        var controller = GetController(id);
        controller?.Start();
    }

    public void Pause(int id)
    {
        var controller = GetController(id);
        controller?.Pause();
    }

    public void ReStart(int id)
    {
        var controller = GetController(id);
        controller?.ReStart();
    }

    public void Continue(int id)
    {
        var controller = GetController(id);
        controller?.Continue();
    }

    public void Stop(int id)
    {
        var controller = GetController(id);
        controller?.Stop();
    }

    private CoroutineController GetController(int id)
    {
        if (_controllers.ContainsKey(id))
        {
            return _controllers[id];
        }
        else
        {
            Debug.LogError("不存在当前id的协程controller id:" + id);
            return null;
        }
    }
}
