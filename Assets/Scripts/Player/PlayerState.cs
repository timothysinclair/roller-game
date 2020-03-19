using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    protected PlayerSettings playerSettings;
    protected PlayerAnimations playerAnimations;
    protected Rigidbody rigidBody;
    protected PlayerMovementController movementController;
    protected PlayerScore playerScore;

    public abstract void OnEnter();
    public abstract void OnExit();

    public abstract void OnAwake();
    public abstract void OnUpdate();
    public abstract void OnFixedUpdate();

    public abstract void OnMove(float steering, float accelInput, bool isGrounded);
    
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
        playerScore = GetComponent<PlayerScore>();

        OnAwake();
    }
}
