using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineItem
{
    public enum CoroutineState
    {
        WAITTING,
        RUNNING,
        PAUSE,
        STOP,
    }
    public CoroutineState State { get; set; }

    public IEnumerator Body(IEnumerator it)
    {
        while (State == CoroutineState.WAITTING)
        {
            yield return null;
        }

        while (State == CoroutineState.RUNNING)
        {
            while (State == CoroutineState.PAUSE)
            {
                yield return null;
            }

            if (it != null && it.MoveNext())
            {
                yield return it.Current;
            }
            else
            {
                State = CoroutineState.STOP;
            }
        }
    }
}
