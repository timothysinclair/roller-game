using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrifting : PlayerState
{
    public override void OnAwake()
    {

    }

    public override void OnEnter()
    {
        playerAnimations.drifting = true;
    }

    public override void OnExit()
    {
        playerAnimations.drifting = false;
    }

    public override void OnFixedUpdate()
    {
        if (!Active) { return; }
    }

    public override void OnMove(float steering, float accelInput, bool isGrounded, float boostInput)
    {
        if (!Active) { return; }

        if (Mathf.Abs(steering) > 0.1f) { playerAnimations.driftIsRight = (steering >= 0.0f); }
    }

    public override void OnUpdate()
    {
        if (!Active) { return; }

    }
}
