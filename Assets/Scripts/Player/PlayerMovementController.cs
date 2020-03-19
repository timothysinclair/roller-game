using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour
{
    // PUBLIC //
    [Header("References")]
    public PlayerDrifting driftingState;
    public PlayerBraking brakingState;
    public PlayerGrinding grindingState;
    public PlayerAccelerating acceleratingState;

    public PlayerAnimations playerAnimations;

    public bool useJumpAttackGravity = false;
    public bool tryBoost = false;

    // PRIVATE //

    private Vector3 contactNormal = Vector3.up;
    private bool isGrounded = false;
    private Rigidbody rigidBody;
    private bool jumpInput = false;
    private int framesSinceGrounded = 0;
    private int framesSinceJump = 0;
    private float currentFriction = 0.0f;
    private const float frictionCoefficient = 3.0f;
    private float currentTurningForce = 0.0f;

    private float curYAngle = 0.0f;
    private float prevYAngle = 0.0f;
    private float turnAngleTotal = 0.0f;
    private bool landedThisFrame = false;

    private List<bool> groundedFrames;

    private PlayerSettings playerSettings;
    private PlayerScore pScore;

    private void Awake()
    {
        pScore = GetComponent<PlayerScore>();
        playerSettings = Resources.Load<PlayerSettings>("ScriptableObjects/PlayerSettings");
        rigidBody = GetComponent<Rigidbody>();

        groundedFrames = new List<bool>(playerSettings.extraJumpFrames);
        for (int i = 0; i < playerSettings.extraJumpFrames; i++)
        {
            groundedFrames.Add(true);
        }
    }

    private void FixedUpdate()
    {
        framesSinceGrounded += 1;
        framesSinceJump += 1;

        grindingState.OnFixedUpdate();
        brakingState.OnFixedUpdate();
        driftingState.OnFixedUpdate();
        acceleratingState.OnFixedUpdate();

        if (grindingState.Active) { return; }

        // Decided gravity value
        float gravityValue = 0.0f;
        if (useJumpAttackGravity)
        {
            // Reset velocity
            rigidBody.velocity = Vector3.up * rigidBody.velocity.y;
            gravityValue = playerSettings.jumpAttackGravity;
        }
        else
        {
            gravityValue = (jumpInput) ? playerSettings.jumpingGravity : playerSettings.normalGravity;
        }

        // Apply gravity
        rigidBody.AddForce(Vector3.down * gravityValue * Time.fixedDeltaTime, ForceMode.Impulse);

        if (isGrounded || SnapToGround())
        {
            framesSinceGrounded = 0;
        }

        SurfaceAlignment();
    }

    private void Update()
    {
        grindingState.OnUpdate();
        brakingState.OnUpdate();
        driftingState.OnUpdate();
        acceleratingState.OnUpdate();

        CheckGrounded();
        UpdateGroundedFrames();
        CheckSpinning();
    }

    void CheckSpinning()
    {
        // Just hit the ground
        if (isGrounded && landedThisFrame)
        {
            turnAngleTotal = Mathf.Abs(turnAngleTotal);

            // Less than 180
            if (turnAngleTotal < playerSettings.halfSpinValue) { return; }

            int numSpins = Mathf.FloorToInt(turnAngleTotal / playerSettings.halfSpinValue);
            for (int i = 0; i < numSpins; i++)
            {
                pScore.AddTrick(Trick.HalfSpin);
            }

            GetComponent<PlayerCombatController>().timeSinceLastAttack = 10.0f;
        }
        else if (isGrounded) { return; }

        curYAngle = transform.rotation.eulerAngles.y;

        turnAngleTotal += Mathf.DeltaAngle(curYAngle, prevYAngle);

        prevYAngle = curYAngle;

        landedThisFrame = false;
    }

    public void UpdateJumpInput(bool didJump)
    {
        jumpInput = didJump;
    }

    public void Move(float steering, float accelInput)
    {
        // Normalise steering and acceleration inputs
        steering = Mathf.Clamp(steering, -1.0f, 1.0f);
        accelInput = Mathf.Clamp(accelInput, 0.0f, 1.0f);

        acceleratingState.Active = (accelInput > 0.4f && isGrounded);

        grindingState.OnMove(steering, accelInput, isGrounded);
        brakingState.OnMove(steering, accelInput, isGrounded);
        driftingState.OnMove(steering, accelInput, isGrounded);
        acceleratingState.OnMove(steering, accelInput, isGrounded);

        if (grindingState.Active) { return; }

        currentTurningForce = (driftingState.Active) ? playerSettings.driftTurningForce : playerSettings.turningForce;

        // Turn player
        Vector3 rotationTorque = steering * currentTurningForce * Time.fixedDeltaTime * Vector3.up;
        rigidBody.AddRelativeTorque(rotationTorque);

        SteerHelper();
        DetermineFriction();
        ApplyFriction();
        CapSpeed();

        playerAnimations.moving = (rigidBody.velocity.magnitude > 5.0f) ? true : false;
    }

    private void CapSpeed()
    {
        Vector3 skaterSpeed = rigidBody.velocity;
        float verticalSpeed = skaterSpeed.y;
        skaterSpeed.y = 0.0f;

        // If speed over max, cap speed
        if (skaterSpeed.magnitude > playerSettings.maxSpeed)
        {
            skaterSpeed = skaterSpeed.normalized * playerSettings.maxSpeed;
            skaterSpeed.y = verticalSpeed;
            rigidBody.velocity = skaterSpeed;
        }
    }

    private void DetermineFriction()
    {
        // No friction if in the air
        if (!isGrounded) { currentFriction = 0.0f; return; }

        float playerSpeed = rigidBody.velocity.magnitude;
        Vector3 projectedVelocity = ProjectedPlayerVelocity();

        float forwardAmount = projectedVelocity.magnitude * playerSettings.forwardFriction.Evaluate(playerSpeed);
        float sidewaysAmount = (1.0f - projectedVelocity.magnitude) * playerSettings.sidewaysFriction.Evaluate(playerSpeed);
        // Debug.Log("Forward friction: " + projectedVelocity.magnitude + " Sideways friction: " + (1.0f - projectedVelocity.magnitude));
        currentFriction = forwardAmount + sidewaysAmount;
    }

    // Returns normalised player velocity projected onto forward direction
    private Vector3 ProjectedPlayerVelocity()
    {
        // Get player information
        Vector3 playerVelocity = rigidBody.velocity;
        Vector3 playerDirection = transform.forward;

        Vector3 velocityProjected = Vector3.Project(playerVelocity.normalized, playerDirection);

        return velocityProjected;
    }

    private void ApplyFriction()
    {
        Vector3 currentVelocity = rigidBody.velocity;
        currentVelocity.y = 0.0f;

        Vector3 frictionForce = -currentVelocity * currentFriction * frictionCoefficient * Time.fixedDeltaTime;
        rigidBody.AddForce(frictionForce, ForceMode.Impulse);
    }

    private void SteerHelper()
    {
        // if (rigidBody.velocity.magnitude < 1.0f) { return; }

        if (!isGrounded || framesSinceJump < 4) { return; }

        Vector3 forwardVec = transform.forward.normalized;
        Vector3 velocity = rigidBody.velocity;

        float dot = Vector3.Dot(forwardVec, velocity.normalized);
        float angleDiff = Mathf.Acos(dot) * playerSettings.steerHelper;

        if (driftingState.Active) { angleDiff *= 0.25f; }

        // If not too side-on, apply steer helper
        if (Mathf.Abs(dot) > 0.75f)
        {
            if (dot < 0.0f) { forwardVec *= -1.0f; }

            Vector3 newVelocity = Vector3.RotateTowards(velocity, forwardVec, angleDiff, 9999.0f);
            newVelocity = newVelocity.normalized * velocity.magnitude;

            rigidBody.velocity = newVelocity;
        }
        
    }

    public void Jump()
    {
        if (isGrounded || CanLenientJump())
        {
            GetComponent<PlayerCombatController>().SpawnJumpHurtbox();

            playerAnimations.OnJump();

            // HEY // Might need to change this later to use the surface normal rather than just up
            rigidBody.AddForce(Vector3.up * playerSettings.jumpForce, ForceMode.Impulse);
            framesSinceJump = 0;

            AudioManager.Instance.PlaySoundVaried("SkateJump");

            turnAngleTotal = 0.0f;
            prevYAngle = transform.rotation.eulerAngles.y;
            curYAngle = transform.rotation.eulerAngles.y;

            if (grindingState.Active) { grindingState.StopGrind(true); }
        }
    }

    private void CheckGrounded()
    {
        bool newGroundedVal = Physics.CheckSphere(transform.position + -contactNormal * playerSettings.groundCheckDistance, playerSettings.groundCheckRadius, playerSettings.groundLayers, QueryTriggerInteraction.Ignore);
        if (newGroundedVal && !isGrounded)
        {
            // Was not grounded but now is
            landedThisFrame = true;
        }
        isGrounded = newGroundedVal;
        if (grindingState.Active) { isGrounded = true; }
        if (isGrounded) { GetComponent<PlayerScore>().CheckBuildingScore(); }
        playerAnimations.grounded = isGrounded;
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

    public bool IsPlayerGrounded()
    {
        return isGrounded;
    }

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
        Vector3 sumOfNormals = Vector3.zero;

        for (int i = 0; i < collision.contactCount; i++)
        {
            if (playerSettings.groundLayers != (playerSettings.groundLayers | (1 << collision.gameObject.layer))) { continue; }
            sumOfNormals += collision.GetContact(i).normal.normalized;

            // contactNormal = normal;
        }

        contactNormal = sumOfNormals.normalized;
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
        if (!Physics.Raycast(transform.position, -contactNormal, out hit, playerSettings.groundSnapDistance, playerSettings.groundLayers, QueryTriggerInteraction.Ignore))
        {
            return false;
        }

        contactNormal = hit.normal;
        Vector3 currentVelocity = rigidBody.velocity;
        float speed = currentVelocity.magnitude;
        if (speed > playerSettings.maxSnapSpeed) { return false; }

        if (hit.collider.gameObject.name == "Dummy") { Debug.Log("Ground check hit dummy"); }

        float dot = Vector3.Dot(currentVelocity, hit.normal);
        if (dot > 0.0f)
        {
            currentVelocity = (currentVelocity - hit.normal * dot).normalized * speed;
            rigidBody.velocity = currentVelocity;
        }

        return true;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) { return; }

        Gizmos.color = (isGrounded) ? Color.green : Color.red;

        Gizmos.DrawWireSphere(transform.position + -contactNormal * playerSettings.groundCheckDistance, playerSettings.groundCheckRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + contactNormal * 2.0f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + -transform.up * playerSettings.groundSnapDistance);

    }
}
