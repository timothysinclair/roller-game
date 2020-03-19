using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    protected PlayerSettings playerSettings;
    protected PlayerAnimations playerAnimations;
    protected Rigidbody rigidBody;
    protected PlayerMovementController movementController;

    public abstract void OnEnter();
    public abstract void OnExit();
    public virtual void OnUpdate()
    {
        if (!active) { return; }
    }
    public virtual void OnFixedUpdate()
    {
        if (!active) { return; }
    }

    public virtual void OnMove(float steering, float accelInput, bool isGrounded)
    {
        if (!active) { return; }
    }
    
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

    private void Awake()
    {
        playerSettings = Resources.Load<PlayerSettings>("ScriptableObjects/PlayerSettings");
        playerAnimations = FindObjectOfType<PlayerAnimations>();
        rigidBody = GetComponent<Rigidbody>();
        movementController = GetComponent<PlayerMovementController>();
    }
}
