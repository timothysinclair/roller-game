using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerSettings", order = 1)]
public class PlayerSettings : ScriptableObject
{
    [Header("Movement Variables")]

    [Tooltip("The amount of force applied to the skater every frame they are holding accelerate")]
    public float moveForce = 1.0f;
    public float jumpForce = 2.0f;
    public float turningForce = 1.0f;
    public float driftTurningForce = 1.0f;
    public float brakingMultiplier = 1.0f;
    public float maxSpeed = 20.0f;
    [Range(0.0f, 1.0f)] public float airAcceleration = 0.0f;
    [Range(0.0f, 1.0f)] public float steerHelper = 0.0f;

    [Header("Friction Variables")]
    public AnimationCurve forwardFriction;
    public AnimationCurve sidewaysFriction;

    [Header("Gravity/Jumping Variables")]
    public float normalGravity = 40.0f;

    [Tooltip("Applied while the player is holding the jump button")]
    public float jumpingGravity = 15.0f;

    [Tooltip("How many frames the player can still jump for if they fall off an edge")]
    public int extraJumpFrames = 10;

    [Header("Ground Checking")]
    public LayerMask groundLayers = -1;
    public float groundCheckDistance = 1.0f;
    public float groundCheckRadius = 0.3f;

    [Header("Ground Snapping")]
    public float groundSnapDistance = 1.0f;
    public float maxSnapSpeed = 5.0f;
}
