using System;
using System.Collections.Generic;

public class LifeCycleConfig 
{
    public static Dictionary<LifeCycleType, ILifeCycle> _lifeCycle = new Dictionary<LifeCycleType, ILifeCycle>()
    {
        {LifeCycleType.Init, new LifeCycle<IInit>()},
        {LifeCycleType.Update, new LifeCycle<IUpdate>()},
    };
    
    public static Dictionary<LifeCycleType, Action> _lifeCycleFuncs = new Dictionary<LifeCycleType, Action>()
    {
        {LifeCycleType.Init, () =>
        {
            _lifeCycle[LifeCycleType.Init].Execute((IInit init) => { init?.Init(); });
        }},
        {LifeCycleType.Update, () =>
        {
            _lifeCycle[LifeCycleType.Update].Execute((IUpdate update) => { update?.UpdateFunc(); });
        }},
    };
}
public enum LifeCycleType
{
    Init,
    Update
}
