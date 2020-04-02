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
    public float driftTurningSpeed = 5.0f;
    [Range(0.0f, 1.0f)] public float airAcceleration = 0.0f;
    [Range(0.0f, 1.0f)] public float steerHelper = 0.5f;
    [Range(0.0f, 1.0f)] public float driftSteerHelper = 0.5f;

    [Header("Drag variables")]
    public float movingDrag = 0.5f;
    public float stationaryDrag = 0.9f;
    public float airDrag = 0.0f;
    public float brakeDrag = 0.75f;
    public float driftDrag = 0.2f;

    [Header("Gravity/Jumping Variables")]
    public float normalGravity = 10.0f;

    [Tooltip("Applied while the player is holding the jump button")]
    public float jumpingGravity = 5.0f;

    [Tooltip("How many frames the player can still jump for if they fall off an edge")]
    public int extraJumpFrames = 2;

    [Header("Ground Checking")]
    public LayerMask groundLayers = -1;
    public float groundCheckDistance = 1.0f;
    public float groundCheckRadius = 0.3f;

    [Header("Ground Snapping")]
    public float groundSnapDistance = 1.0f;
    public float maxSnapSpeed = 5.0f;

    [Header("Braking Bool")]
    public bool braking = false;
    public bool forcedBraking = false;
    public bool drifting = false;

    // PRIVATE //

    // Multiplies all drag
    private float dragCoefficient = 10.0f;
    private float currentDrag = 0.0f;
    private Vector3 contactNormal;

    private bool isGrounded = false;
    private Rigidbody rigidBody;
    private bool jumpInput = false;
    private int framesSinceGrounded = 0;
    private int framesSinceJump = 0;
    private float oldYRotation;

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
        framesSinceGrounded += 1;
        framesSinceJump += 1;

        // Decided gravity value
        float gravityValue = (jumpInput) ? jumpingGravity : normalGravity;

        // Apply gravity
        rigidBody.AddForce(Vector3.down * gravityValue * Time.fixedDeltaTime, ForceMode.Impulse);

        if (isGrounded || SnapToGround())
        {
            framesSinceGrounded = 0;
        }
        else
        {
            contactNormal = Vector3.up;
        }

        SurfaceAlignment();
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

        

        float accelMultiplier = (isGrounded) ? 1.0f : airAcceleration;
        // float anotherAccelMultiplier = (drifting) ? 0.3f : 1.0f;

        // Add force to player
        Vector3 moveVector = accelInput * moveForce * Time.fixedDeltaTime * transform.forward * accelMultiplier;// * anotherAccelMultiplier;
        rigidBody.AddForce(moveVector, ForceMode.Impulse);

        // Rotate player
        float sensitivity = (drifting) ? driftTurningSpeed : steeringSensitivity;
        transform.Rotate(Vector3.up * steering * sensitivity);

        SteerHelper();
        ApplyDrag(accelInput > 0.01f);
        CapSpeed();

        
    }

    private void ApplyDrag(bool accelInput)
    {
        if (!accelInput && (!braking && !forcedBraking && !drifting)) { currentDrag = stationaryDrag; }
        else
        {
            if (!isGrounded) { currentDrag = airDrag; }
            else if (braking || forcedBraking) { currentDrag = brakeDrag; }
            else if (drifting) { currentDrag = (accelInput) ? movingDrag + driftDrag : driftDrag; }
            else { currentDrag = movingDrag; }
        }

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
            framesSinceJump = 0;
        }
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(transform.position + -transform.up * groundCheckDistance, groundCheckRadius, groundLayers, QueryTriggerInteraction.Ignore);
        
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

    private void SurfaceAlignment()
    {
        Quaternion rot = Quaternion.FromToRotation(transform.up, contactNormal) * transform.rotation;

        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.fixedDeltaTime * 5.0f);


    }

    private void OnCollisionEnter(Collision collision)
    {
        EvaluateCollision(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        EvaluateCollision(collision);
    }

    // Called on collision enter and stay
    private void EvaluateCollision(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector3 normal = collision.GetContact(i).normal;

            contactNormal = normal;
        }
    }

    private bool SnapToGround()
    {
        // Don't try to snap if off ground for more than 1 frame
        if (framesSinceGrounded > 1 || framesSinceJump <= 4)
        {
            return false;
        }

        RaycastHit hit;

        // If ground isn't close to us, don't try to snap
        if (!Physics.Raycast(transform.position, -contactNormal, out hit, groundSnapDistance, groundLayers))
        {
            return false;
        }

        contactNormal = hit.normal;
        Vector3 currentVelocity = rigidBody.velocity;
        float speed = currentVelocity.magnitude;
        if (speed > maxSnapSpeed) { return false; }

        float dot = Vector3.Dot(currentVelocity, hit.normal);
        if (dot > 0.0f)
        {
            currentVelocity = (currentVelocity - hit.normal * dot).normalized * speed;
            rigidBody.velocity = currentVelocity;
        }

        return true;
    }

    private void SteerHelper()
    {
        forcedBraking = false;

        if (rigidBody.velocity.magnitude < 0.1f) { return; }

        if (!isGrounded || framesSinceJump < 4) { return; }

        Vector3 forwardVec = transform.forward.normalized;
        Vector3 velocity = rigidBody.velocity;

        float dot = Vector3.Dot(forwardVec, velocity.normalized);
        float helper = (drifting) ? steerHelper : driftSteerHelper;
        float angleDiff = Mathf.Acos(dot) * helper;

        if (Mathf.Abs(dot) > 0.5f)
        {
            if (dot < 0.0f) { forwardVec = -transform.forward; }

            Vector3 newVelocity = Vector3.RotateTowards(velocity, forwardVec, angleDiff, 9999999.0f);
            newVelocity = newVelocity.normalized * velocity.magnitude;

            rigidBody.velocity = newVelocity;
        }
        else
        {
            // Brake
            forcedBraking = true;
        }

    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) { return; }

        Gizmos.color = (isGrounded) ? Color.green : Color.red;

        Gizmos.DrawWireSphere(transform.position + -transform.up * groundCheckDistance, groundCheckRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + contactNormal * 2.0f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + -transform.up * groundSnapDistance);
    }
}
