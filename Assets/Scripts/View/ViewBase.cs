using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class ViewBase : MonoBehaviour,IView
{
    private UIUtil _uiUtil;
    private List<IViewInit> _viewInits;
    private List<IViewShow> _viewShows;
    private List<IViewHide> _viewHides;
    private List<IViewUpdate> _viewUpdates;

    protected UIUtil UIUtil
    {
        get
        {
            if (_uiUtil == null)
            {
                _uiUtil = gameObject.AddComponent<UIUtil>();
                _uiUtil.Init();
            }

            return _uiUtil;
        }
    }
    public virtual void Init()
    {
        //初始化子类和预制体
        InitChild();
        LoadInterface();
        
        //初始化子类的数据
        InitSubView();
        InitUpdateView();
        
        //添加当前viewbase下所有子类的update函数
        //UpdateAction();
    }

    private void InitSubView()
    {
        foreach (IViewInit viewInit in _viewInits)
        {
            viewInit.Init();
        }
    }

    protected abstract void InitChild();
    

    public virtual void Show()
    {
        gameObject.SetActive(true);
        foreach (IViewShow viewShow in _viewShows)
        {
            viewShow.Show();
        }
    }

    public virtual void Hide()
    {
        foreach (IViewHide viewHide in _viewHides)
        {
            viewHide.Hide();
        }
        gameObject.SetActive(false);
    }

    private void LoadInterface()
    {
        _viewInits = new List<IViewInit>();
        _viewShows = new List<IViewShow>();
        _viewHides = new List<IViewHide>();
        InitInterface(_viewInits);
        InitInterface(_viewShows);
        InitInterface(_viewHides);
    }
    private void InitInterface<T>(List<T> list)
    {
        T viewInterface = default(T);
        foreach (Transform transformChild in transform)
        {
            viewInterface = transformChild.GetComponent<T>();
            if(viewInterface!=null)
                list.Add(viewInterface);
        }
    }
    

    public virtual void UpdateFunc()
    {
        foreach (IViewUpdate viewUpdate in _viewUpdates)
        {
            viewUpdate.UpdateFunc();
        }
    }

    public Transform GetTrans()
    {
        return transform;
    }

    private void InitUpdateView()
    {
        _viewUpdates = transform.GetComponentsInChildren<IViewUpdate>().ToList();
        foreach (var viewUpdate in _viewUpdates)
        {
            Debug.LogError(viewUpdate.GetType().Name);
        }
        _viewUpdates.Remove(this);
    }
    
}
