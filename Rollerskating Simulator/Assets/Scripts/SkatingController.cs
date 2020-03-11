using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SkatingController : MonoBehaviour
{
    // PUBLIC //
    [Header("Movement Variables")]

    [Tooltip("The amount of force applied to the skater every frame they are holding accelerate")]
    public float moveForce = 1.0f;
    public float jumpForce = 2.0f;
    // Only counts horizontal speed
    public float maxSpeed = 20.0f;
    public float steeringSensitivity = 1.0f;

    [Header("Drag Variables")]
    public float movingDrag = 0.5f;
    public float stationaryDrag = 0.9f;
    public float airDrag = 0.0f;

    [Header("Gravity/Jumping Variables")]
    public float normalGravity = 10.0f;

    [Tooltip("Applied while the player is holding the jump button")]
    public float jumpingGravity = 5.0f;

    [Tooltip("How many frames the player can still jump for if they fall off an edge")]
    private int extraJumpFrames = 2;

    [Header("Ground Checking")]
    public LayerMask groundLayers = -1;
    public float groundCheckDistance = 1.0f;
    public float groundCheckRadius = 0.3f;


    // PRIVATE //

    // Multiplies all drag
    private float dragCoefficient = 10.0f;
    private float currentDrag = 0.0f;

    private bool isGrounded = false;
    private Rigidbody rigidBody;
    private bool jumpInput = false;


    private List<bool> groundedFrames;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();


        groundedFrames = new List<bool>(extraJumpFrames);
        for (int i = 0; i < extraJumpFrames; i++)
        {
            groundedFrames.Add(true);
        }
    }

    private void FixedUpdate()
    {
        // Decided gravity value
        float gravityValue = (jumpInput) ? jumpingGravity : normalGravity;

        // Apply gravity
        rigidBody.AddForce(Vector3.down * gravityValue, ForceMode.Impulse);
    }

    private void Update()
    {
        CheckGrounded();
        UpdateGroundedFrames();
    }

    // Updates the state of the jump input - to apply appropriate gravity
    public void UpdateJumpInput(bool didJump)
    {
        jumpInput = didJump;
    }

    // Moves the skater based on inputs (CALL IN FIXED UPDATE)
    public void Move(float steering, float accelInput)
    {
        // Normalise steering and acceleration inputs
        steering = Mathf.Clamp(steering, -1.0f, 1.0f);
        accelInput = Mathf.Clamp(accelInput, 0.0f, 1.0f);

        if (accelInput > 0.1f)
        {
            accelInput = 1.0f;
        }

        // Add force to player
        Vector3 moveVector = accelInput * moveForce * Time.fixedDeltaTime * transform.forward;
        Debug.Log("Applied moveVector of " + moveVector);
        rigidBody.AddForce(moveVector, ForceMode.Impulse);

        // Rotate player
        transform.Rotate(Vector3.up * steering * steeringSensitivity);

        ApplyDrag(accelInput > 0.01f);
        CapSpeed();
    }

    private void ApplyDrag(bool accelInput)
    {
        currentDrag = accelInput ? movingDrag : stationaryDrag;
        if (!isGrounded) { currentDrag = airDrag; }

        // Ignore vertical velocity for drag
        var currentVelocity = rigidBody.velocity;
        currentVelocity.y = 0.0f;

        // Apply drag
        rigidBody.AddForce(-currentVelocity * currentDrag * dragCoefficient * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    private void CapSpeed()
    {
        Vector3 skaterSpeed = rigidBody.velocity;
        float verticalSpeed = skaterSpeed.y;
        skaterSpeed.y = 0.0f;

        // Cap horizontal speed
        if (skaterSpeed.magnitude > maxSpeed)
        {
            skaterSpeed = skaterSpeed.normalized * maxSpeed;
        }

        // Restore vertical speed
        skaterSpeed.y = verticalSpeed;
        rigidBody.velocity = skaterSpeed;
    }

    public void Jump()
    {
        // If on the ground, or just left the ground, jump
        if (isGrounded || CanLenientJump())
        {
            // HEY // Might need to change this later to use the surface normal rather than just up
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(transform.position + Vector3.down * groundCheckDistance, groundCheckRadius, groundLayers, QueryTriggerInteraction.Ignore);
    }

    private void UpdateGroundedFrames()
    {
        if (groundedFrames.Capacity <= 0) { return; }

        // Move all frames along one in the list
        for (int i = groundedFrames.Capacity - 1; i > 0; i--)
        {
            groundedFrames[i] = groundedFrames[i - 1];
        }

        // Add new frame to list
        groundedFrames[0] = isGrounded;
    }

    // Checks if player is allowed a lenient jump
    private bool CanLenientJump()
    {
        bool lenientJump = false;

        for (int i = 0; i < groundedFrames.Capacity; i++)
        {
            if (groundedFrames[i]) { lenientJump = true; break; }
        }

        return lenientJump;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = (isGrounded) ? Color.green : Color.red;

        Gizmos.DrawWireSphere(transform.position + Vector3.down * groundCheckDistance, groundCheckRadius);
    }
}
