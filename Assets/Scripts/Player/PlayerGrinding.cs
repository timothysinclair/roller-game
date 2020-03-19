using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrinding : PlayerState
{
    private GrindRail currentRail = null;

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


    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }

    public void ChooseRail(GrindRail newRail)
    {

    }
}
