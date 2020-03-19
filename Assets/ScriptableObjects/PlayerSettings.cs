using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Trick
{
    Kick1 = 0,
    Kick2,
    Kick3,
    Grind,
    EnemyHit,
    HalfSpin
};

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
    [Tooltip("Gravity used when attacking in the air")]
    public float jumpAttackGravity = 1.0f;

    [Header("Ground Checking")]
    public LayerMask groundLayers = -1;
    public float groundCheckDistance = 1.0f;
    public float groundCheckRadius = 0.3f;

    [Header("Ground Snapping")]
    public float groundSnapDistance = 1.0f;
    public float maxSnapSpeed = 5.0f;

    [Header("Attack Combo Times")]
    [Tooltip("Maximum time before the combo resets")]
    public float maxAttackTime = 0.5f;
    [Tooltip("Minimum time before a new combo can be triggered")]
    public float minPostAttackTime = 1.0f;

    [Header("Jump Attack")]
    [Tooltip("Time that jump hurt box will be active")]
    public float maxJumpHurtBoxTimer = 0.1f;
    [Tooltip("Maximum time the player has to hit the enemy once in the air")]
    public float maxTimeToHit = 1.0f;

    [Header("Trick Values")]
    public Dictionary<Trick, int> trickValues = new Dictionary<Trick, int>()
    {
        { Trick.HalfSpin, 10 },
        { Trick.Kick1, 10 },
        { Trick.Kick2, 20 },
        { Trick.Kick3, 30 },
        { Trick.Grind, 10 },
        { Trick.EnemyHit, 2 } // Divisor for kick value
    };
    public float halfSpinValue = 180.0f;
    public float fullSpinValue = 360.0f;
}
