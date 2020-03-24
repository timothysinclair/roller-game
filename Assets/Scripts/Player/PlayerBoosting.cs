using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBoosting : PlayerState
{
    public GameObject[] effects;
    public Image boostBarFilled;

    private bool effectsActive = false;
    private float currentBoost = 0.0f;
    public float Boost
    {
        get { return currentBoost; }
        set
        {
            float newBoostValue = Mathf.Clamp(value, 0.0f, playerSettings.maxBoost);
            float delta = newBoostValue - currentBoost;
            currentBoost = newBoostValue;
            OnBoostAmountChanged(delta);
        }
    }

    public override void OnAwake()
    {
        currentBoost = playerSettings.maxBoost;
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

        if (Boost <= 0.001f && effectsActive)
        {
            DeactivateEffects();
        }
        else if (Boost > 0.001f && !effectsActive)
        {
            ActivateEffects();
        }

        if (Boost <= 0.001f) { return; }

        //if (boostInput > 0.0f && isGrounded)
        //{
        //    if (!effectsActive) { ActivateEffects(); }
        //}

        Vector3 boostVector = boostInput * playerSettings.boostForce * Time.fixedDeltaTime * transform.forward;
        rigidBody.AddForce(boostVector, ForceMode.Impulse);
        Boost -= Time.deltaTime;
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

    private void OnBoostAmountChanged(float delta)
    {
        boostBarFilled.fillAmount = (currentBoost / playerSettings.maxBoost);
    }
}
