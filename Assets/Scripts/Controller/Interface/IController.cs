using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController : IControllerInit,IControllerShow,IControllerUpdate,IControllerHide
{
    void AddUpdateListener(Action action);
}
