using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewBase : MonoBehaviour,IView
{
    private UIUtil _uiUtil;

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
        
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
