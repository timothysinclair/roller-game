using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrifting : PlayerState
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

    }

    public override void OnMove(float steering, float accelInput, bool isGrounded)
    {
        base.OnMove(steering, accelInput, isGrounded);

        playerAnimations.drifting = Active;

        if (Mathf.Abs(steering) > 0.1f) { playerAnimations.driftIsRight = (steering >= 0.0f); }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }
}
