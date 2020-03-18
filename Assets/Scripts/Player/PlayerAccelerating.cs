using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccelerating : PlayerState
{
    public GameObject leftBooster;
    public GameObject rightBooster;
    public GameObject thrusterLoop;

    public override void OnEnter()
    {
        leftBooster.SetActive(true);
        rightBooster.SetActive(true);
        thrusterLoop.SetActive(true);
    }

    public override void OnExit()
    {
        leftBooster.SetActive(false);
        rightBooster.SetActive(false);
        thrusterLoop.SetActive(false);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }
}
