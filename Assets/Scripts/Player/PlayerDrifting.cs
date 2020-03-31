using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrifting : PlayerState
{
    public GameObject[] effects;
    public AudioSource driftLoop;

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

        if (Mathf.Abs(steering) > 0.1f) { playerAnimations.driftIsRight = (steering >= 0.0f); }

        if (movementController.brakingState.Active || !isGrounded)
        {
            if (effectsActive) { DeactivateEffects(); }
        }
        else if (isGrounded)
        {
            if (!effectsActive) { ActivateEffects(); }
        }
    }

    public override void OnUpdate()
    {
        if (!Active) { return; }

        float speed = rigidBody.velocity.magnitude;
        float quot = Mathf.Clamp(speed / movementController.boostingMaxSpeed, 0.0f, 1.0f);
        driftLoop.volume = Mathf.Lerp(0.25f, 1.0f, quot);
        driftLoop.pitch = Mathf.Lerp(0.5f, 1.0f, quot);
    }

    private void ActivateEffects()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].SetActive(true);
        }

        effectsActive = true;
        playerAnimations.drifting = true;
    }

    private void DeactivateEffects()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].SetActive(false);
        }

        effectsActive = false;
        playerAnimations.drifting = false;
    }
}
