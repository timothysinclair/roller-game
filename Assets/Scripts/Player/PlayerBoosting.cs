using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoosting : PlayerState
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

        //if (boostInput > 0.0f && isGrounded)
        //{
        //    if (!effectsActive) { ActivateEffects(); }
        //}

        Vector3 boostVector = boostInput * playerSettings.boostForce * Time.fixedDeltaTime * transform.forward;
        rigidBody.AddForce(boostVector, ForceMode.Impulse);
    }

    public override void OnUpdate()
    {
        if (!Active) { return; }
    }

    private void ActivateEffects()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].SetActive(true);
        }

        effectsActive = true;
    }

    private void DeactivateEffects()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].SetActive(false);
        }

        effectsActive = false;
    }
}
