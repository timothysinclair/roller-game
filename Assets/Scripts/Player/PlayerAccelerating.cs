using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccelerating : PlayerState
{
    public GameObject[] effects;

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

    public override void OnMove(float steering, float accelInput, bool isGrounded, float boostInput)
    {
        if (!Active) { return; }
        
        // If braking or not on ground, deactivate effects but leave accelerating inputs
        if (movementController.brakingState.Active || !isGrounded) 
        { 
            accelInput = 0.0f;

            if (effectsActive) { DeactivateEffects(); }
        }
        // If accelerating on the ground again, activate effects if they're not active
        else if (accelInput > 0.4f && isGrounded)
        {
            if (!effectsActive) { ActivateEffects(); }
        }

        // Only add force if not over normal max speed
        if (!(rigidBody.velocity.magnitude > movementController.maxSpeed))
        {
            float accelMultiplier = (isGrounded) ? 1.0f : playerSettings.airAcceleration;

            Vector3 moveVector = accelInput * playerSettings.moveForce * Time.fixedDeltaTime * transform.forward * accelMultiplier;
            rigidBody.AddForce(moveVector, ForceMode.Impulse);
        }
    }

    private void ActivateEffects()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].SetActive(true);
        }

        effectsActive = true;
        playerAnimations.accelerating = true;
    }

    private void DeactivateEffects()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].SetActive(false);
        }

        effectsActive = false;
        playerAnimations.accelerating = false;
    }

    public override void OnUpdate()
    {
        if (!Active) { return; }

    }
}
