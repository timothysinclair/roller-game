using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private SkatingController controller;

    // Input
    private InputMaster controls;
    private float steeringInput = 0.0f;
    private float accelInput = 0.0f;
    public const float lAnalogStickDeadzone = 0.5f;

    private void Awake()
    {
        controller = GetComponent<SkatingController>();

        // Input setup
        controls = new InputMaster();
        controls.Player.Enable();
        controls.Player.Steering.performed += ctx => steeringInput = ctx.ReadValue<float>();
        controls.Player.AcceleratePress.performed += _ => accelInput = 1.0f;
        controls.Player.AccelerateRelease.performed += _ => accelInput = 0.0f;
        controls.Player.JumpPress.performed += _ => { controller.Jump(); controller.UpdateJumpInput(true); };
        controls.Player.JumpRelease.performed += _ => controller.UpdateJumpInput(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        // Deadzone
        if (Mathf.Abs(steeringInput) <= lAnalogStickDeadzone) { steeringInput = 0.0f; }

        controller.Move(steeringInput, accelInput);
    }
}
