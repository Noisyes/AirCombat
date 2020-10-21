using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public abstract class ControllerBase : MonoBehaviour,IController
{
    private Action _updateAction;
    private List<IControllerInit> _inits;
    private List<IControllerShow> _shows;
    private List<IControllerUpdate> _updates;
    private List<IControllerHide> _hides;
    public  virtual void Init()
    {
        InitChild();
        InitInterface();
        InitComponents();
        AddUpdateActionToButton();
    }

    public abstract void InitChild();

    private void LoadInterface<T>(List<T> list)
    {
        T item = default(T);
        foreach (Transform trans in transform)
        {
             item = trans.GetComponent<T>();
            if(item!=null)
                list.Add(item);
        }
    }

    private void InitInterface()
    {
        _inits = new List<IControllerInit>();
        _shows = new List<IControllerShow>();
        _updates = new List<IControllerUpdate>();
        _hides = new List<IControllerHide>();
        LoadInterface(_inits);
        LoadInterface(_shows);
        LoadInterface(_updates);
        LoadInterface((_hides));
    }

    private void InitComponents()
    {
        foreach (var init in _inits)
        {
            init.Init();
        }
    }

    public virtual void Show()
    {
        foreach (var controllerShow in _shows)
        {
            controllerShow.Show();
        }
    }
    

    public virtual void Hide()
    {
        foreach (var controllerHide in _hides)
        {
            controllerHide.Hide();
        }
    }

    public virtual void AddUpdateListener(Action action)
    {
        _updateAction += action;
    }
    
    

    public virtual void UpdateFunc()
    {
        
        foreach (IControllerUpdate controllerUpdate in _updates)
        {
            controllerUpdate.UpdateFunc();
        }
    }
    
    private void AddUpdateActionToButton()
    {
        var buttons = GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            button.onClick.AddListener(()=>{_updateAction?.Invoke();});
            _updateAction?.Invoke();
        }
    }
}
