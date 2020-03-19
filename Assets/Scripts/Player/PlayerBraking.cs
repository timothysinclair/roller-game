using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBraking : PlayerState
{
    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        playerAnimations.braking = Active;

    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }

    public override void OnMove(float steering, float accelInput, bool isGrounded)
    {
        base.OnMove(steering, accelInput, isGrounded);
        if (!isGrounded) { return; }

        Vector3 brakeVector = -rigidBody.velocity * Time.fixedDeltaTime * playerSettings.brakingMultiplier;
        rigidBody.AddForce(brakeVector, ForceMode.Impulse);
    }
}
