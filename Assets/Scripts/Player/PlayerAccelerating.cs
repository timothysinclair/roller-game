using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccelerating : PlayerState
{
    public GameObject leftBooster;
    public GameObject rightBooster;
    public GameObject thrusterLoop;

    private bool effectsActive = false;

    public override void OnAwake()
    {
        
    }

    public override void OnEnter()
    {
        ActivateEffects();
    }

    public override void OnExit()
    {
        DeactivateEffects();
    }

    public override void OnFixedUpdate()
    {
        if (!Active) { return; }

    }

    public override void OnMove(float steering, float accelInput, bool isGrounded)
    {
        if (!Active) { return; }
        
        // If braking or not on ground, deactivate effects but leave accelerating inputs
        if (movementController.brakingState.Active || !isGrounded || movementController.driftingState.Active) 
        { 
            accelInput = 0.0f;

            if (effectsActive) { DeactivateEffects(); }
        }
        // If accelerating on the ground again, activate effects if they're not active
        else if (accelInput > 0.4f && isGrounded)
        {
            if (!effectsActive) { ActivateEffects(); }
        }

        float accelMultiplier = (isGrounded) ? 1.0f : playerSettings.airAcceleration;

        Vector3 moveVector = accelInput * playerSettings.moveForce * Time.fixedDeltaTime * transform.forward * accelMultiplier;
        rigidBody.AddForce(moveVector, ForceMode.Impulse);
    }

    private void ActivateEffects()
    {
        leftBooster.SetActive(true);
        rightBooster.SetActive(true);
        thrusterLoop.SetActive(true);
        effectsActive = true;
        playerAnimations.accelerating = true;
    }

    private void DeactivateEffects()
    {
        leftBooster.SetActive(false);
        rightBooster.SetActive(false);
        thrusterLoop.SetActive(false);
        effectsActive = false;
        playerAnimations.accelerating = false;
    }

    public override void OnUpdate()
    {
        if (!Active) { return; }

    }
}
