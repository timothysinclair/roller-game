using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    public abstract void OnEnter();
    public virtual void OnUpdate()
    {
        if (!active) { return; }
    }
    public virtual void OnFixedUpdate()
    {
        if (!active) { return; }
    }
    public abstract void OnExit();
    
    private bool active = false;
    public bool Active
    {
        get { return active; }
        set
        {
            if (value != active)
            {
                if (value) { OnEnter(); }
                else { OnExit(); }
            }

            active = value;
        }
    }
}
