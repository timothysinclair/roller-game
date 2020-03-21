﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovementController movementController;
    private Rigidbody rigidBody;
    private PlayerCombatController combatController;

    // Input
    private InputMaster controls;
    private float steeringInput = 0.0f;
    private float accelInput = 0.0f;
    private float boostInput = 0.0f;
    public const float lAnalogStickDeadzone = 0.5f;

    private void Awake()
    {
        movementController = GetComponent<PlayerMovementController>();
        combatController = GetComponent<PlayerCombatController>();

        // Input setup
        controls = new InputMaster();
        controls.Player.Enable();

        // Movement
        controls.Player.Steering.performed += ctx => Steering(ctx.ReadValue<float>());
        controls.Player.AcceleratePress.performed += _ => accelInput = 1.0f;
        controls.Player.AccelerateRelease.performed += _ => accelInput = 0.0f;
        controls.Player.JumpPress.performed += _ => { movementController.Jump(); movementController.UpdateJumpInput(true); };
        controls.Player.JumpRelease.performed += _ => movementController.UpdateJumpInput(false);
        controls.Player.BrakePress.performed += _ => movementController.brakingState.Active = true;
        controls.Player.BrakeRelease.performed += _ => movementController.brakingState.Active = false;
        controls.Player.DriftPress.performed += _ => movementController.driftingState.Active = true;
        controls.Player.DriftRelease.performed += _ => movementController.driftingState.Active = false;
        controls.Player.Grind.performed += _ => { movementController.grindingState.TryGrind(); };
        controls.Player.BoostPress.performed += _ => boostInput = 1.0f;
        controls.Player.BoostRelease.performed += _ => boostInput = 0.0f;

        // Combat
        controls.Player.Attack.performed += _ => combatController.BasicAttack();

        // Cursor
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        // Deadzone
        if (Mathf.Abs(steeringInput) <= lAnalogStickDeadzone) { steeringInput = 0.0f; }
        movementController.Move(steeringInput, accelInput, boostInput);
    }

    private void Steering(float steeringValue)
    {
        steeringInput = steeringValue;
    }
}
