using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private NewSkatingController movementController;
    private Rigidbody rigidBody;
    private PlayerCombatController combatController;

    // Input
    private InputMaster controls;
    private float steeringInput = 0.0f;
    private float accelInput = 0.0f;
    public const float lAnalogStickDeadzone = 0.5f;

    private void Awake()
    {
        movementController = GetComponent<NewSkatingController>();
        combatController = GetComponent<PlayerCombatController>();

        // Input setup
        controls = new InputMaster();
        controls.Player.Enable();

        // Movement
        controls.Player.Steering.performed += ctx => steeringInput = ctx.ReadValue<float>();
        controls.Player.AcceleratePress.performed += _ => accelInput = 1.0f;
        controls.Player.AccelerateRelease.performed += _ => accelInput = 0.0f;
        controls.Player.JumpPress.performed += _ => { movementController.Jump(); movementController.UpdateJumpInput(true); };
        controls.Player.JumpRelease.performed += _ => movementController.UpdateJumpInput(false);
        controls.Player.BrakePress.performed += _ => movementController.braking = true;
        controls.Player.BrakeRelease.performed += _ => movementController.braking = false;
        controls.Player.DriftPress.performed += _ => movementController.drifting = true;
        controls.Player.DriftRelease.performed += _ => movementController.drifting = false;

        // Combat
        controls.Player.Attack.performed += _ => combatController.BasicAttack();

        // Cursor
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        // Deadzone
        if (Mathf.Abs(steeringInput) <= lAnalogStickDeadzone) { steeringInput = 0.0f; }
        movementController.Move(steeringInput, accelInput);
    }
}
