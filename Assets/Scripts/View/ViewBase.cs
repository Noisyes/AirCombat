using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewBase : MonoBehaviour,IView
{
    private UIUtil _uiUtil;
    private HashSet<ViewBase> _views;

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
        InitChild();
        GetViewSets();
        foreach (ViewBase viewBase in _views)
        {
            viewBase.Init();
        }
    }

    protected abstract void InitChild();

    public virtual void Show()
    {
        gameObject.SetActive(true);
        foreach (ViewBase viewBase in _views)
        {
            viewBase.Show();
        }
    }

    public virtual void Hide()
    {
        foreach (ViewBase viewBase in _views)
        {
            viewBase.Hide();
        }
        gameObject.SetActive(false);
    }

    private void GetViewSets()
    {
        ViewBase views = null;
        _views = new HashSet<ViewBase>();
        foreach (Transform trans in transform)
        {
            views = trans.GetComponent<ViewBase>();
            if (views != null)
                _views.Add(views);
        }
    }
}
