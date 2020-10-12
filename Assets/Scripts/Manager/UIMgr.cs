using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class UIMgr : NormalSingleton<UIMgr>
{
    private Stack<string> _uiStack = new Stack<string>();
    private Dictionary<string,IView> _views = new Dictionary<string, IView>();
    private Canvas _canvas;
    public Canvas CurCanvas
    {
        get
        {
            if (_canvas == null)
            {
                _canvas = Object.FindObjectOfType<Canvas>();
            }
            if (_canvas == null)
            {
                Debug.LogError("当前场景没有Canvas");
                return null;
            }
            return _canvas;
        }
    }
    public IView Show(string path)
    {
        if (_uiStack.Count > 0)
        {
            string topPath = _uiStack.Peek();
            _views[topPath].Hide();
        }

        IView topView =  InitView(path);
        topView.Show();
        _uiStack.Push(path);
        return topView;
    }

    private IView InitView(string path)
    {
        if (_views.ContainsKey(path))
        {
            return _views[path];
        }
        else
        {
            var viewGO = LoadMgr.Instance.LoadPath(path, CurCanvas.transform);
            Type type = BindUtil.GetType(path);
            IView view;
            if (type != null)
            {
                view = viewGO.AddComponent(type) as IView;
                if (view != null)
                {
                    view.Init();
                    _views.Add(path,view);
                    Debug.LogError("挂载上了 脚本名称："+ type.Name);
                    return view;
                }
                else
                {
                    Debug.LogError("当前脚本没有继承IView" + type.Name);
                    return null;
                }
            }
            else
            {
                Debug.LogError("没有挂载上脚本");
                return null;
            }
        }
    }

    public void Back()
    {
        if (_uiStack.Count <= 1)
            return;
        string topPath = _uiStack.Pop();
        _views[topPath].Hide();

        topPath = _uiStack.Peek();
        _views[topPath].Show();
    }
}
