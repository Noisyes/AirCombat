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
        ShowAll(topView);
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
            List<Type> types = BindUtil.GetType(path);
            if (types != null)
            {
                AddTypeComponent(viewGO,types);
                InitComponents(viewGO);
                AddUpdateListener(viewGO);
                
                IView view = viewGO.GetComponent<IView>();
                if (view != null)
                {
                    _views.Add(path,view);
                    return view;
                }
                else
                {
                    Debug.LogError("当前脚本没有继承IView");
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

    private void AddTypeComponent(GameObject viewGO,List<Type> types)
    {
        foreach (Type type in types)
        {
            viewGO.AddComponent(type);
            Debug.LogError("挂载上了 脚本名称："+type.Name);
        }
    }

    private void InitComponents(GameObject viewGO)
    {
        IInit[] inits = viewGO.GetComponents<IInit>();
        foreach (var init in inits)
        {
            init.Init();
        }
    }

    private void AddUpdateListener(GameObject viewGO)
    {
        var controller = viewGO.GetComponent<IController>();
        foreach (IUpdate update in viewGO.GetComponents<IUpdate>())
        {
            Debug.LogError(update.GetType().Name);
            controller?.AddUpdateListener(update.UpdateFunc);
        }
    }

    public void Back()
    {
        if (_uiStack.Count <= 1)
            return;
        string topPath = _uiStack.Pop();
        HideAll(_views[topPath]);

        topPath = _uiStack.Peek();
        ShowAll(_views[topPath]);
    }

    private void ShowAll(IView view)
    {
        foreach (IShow show in view.GetTrans().GetComponents<IShow>())
        {
            show.Show();
        }
    }
    private void HideAll(IView view)
    {
        foreach (IHide hide in view.GetTrans().GetComponents<IHide>())
        {
            hide.Hide();
        }
    }
}
