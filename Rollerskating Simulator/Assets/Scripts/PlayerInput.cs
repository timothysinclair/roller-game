using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private SkatingController controller;

    // Temp input stuff
    private float steeringInput = 0.0f;
    private float accelInput = 0.0f;

    private void Awake()
    {
        controller = GetComponent<SkatingController>();
    }

    // Update is called once per frame
    void Update()
    {
        steeringInput = Input.GetAxis("Horizontal");
        accelInput = (Input.GetKey(KeyCode.W)) ? 1.0f : 0.0f;

        bool jumpInput = Input.GetKeyDown(KeyCode.Space);
        controller.UpdateJumpInput(jumpInput);

        if (jumpInput)
        {
            controller.Jump();
        }
    }

    private void FixedUpdate()
    {
        controller.Move(steeringInput, accelInput);
    }
}
