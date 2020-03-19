using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBraking : PlayerState
{
    public override void OnAwake()
    {

    }

    public override void OnEnter()
    {
        playerAnimations.braking = true;
    }

    public override void OnExit()
    {
        playerAnimations.braking = false;
    }

    public override void OnFixedUpdate()
    {
        if (!Active) { return; }
    }

    public override void OnUpdate()
    {
        if (!Active) { return; }

    }

    public override void OnMove(float steering, float accelInput, bool isGrounded)
    {
        if (!Active) { return; }
        if (!isGrounded) { return; }

        Vector3 brakeVector = -rigidBody.velocity * Time.fixedDeltaTime * playerSettings.brakingMultiplier;
        rigidBody.AddForce(brakeVector, ForceMode.Impulse);
    }
}
