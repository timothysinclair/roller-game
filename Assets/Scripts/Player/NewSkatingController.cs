using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]
public class NewSkatingController : MonoBehaviour
{
    // PUBLIC //
    [Header("References")]
    public PlayerAnimations playerAnimations;
    public GameObject leftBooster;
    public GameObject rightBooster;

    [HideInInspector] public bool braking = false;
    [HideInInspector] public bool drifting = false;
    private bool grinding = false;
    public bool useJumpAttackGravity = false;

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
    private GrindRail grindingRail = null;

    private List<bool> groundedFrames;
    private List<GrindRail> grindRails;

    private PlayerSettings playerSettings;

    private void Awake()
    {
        playerSettings = Resources.Load<PlayerSettings>("ScriptableObjects/PlayerSettings");
        rigidBody = GetComponent<Rigidbody>();

        groundedFrames = new List<bool>(playerSettings.extraJumpFrames);
        for (int i = 0; i < playerSettings.extraJumpFrames; i++)
        {
            groundedFrames.Add(true);
        }
        
        GrindRail[] rails = FindObjectsOfType<GrindRail>();
        grindRails = new List<GrindRail>();

        for (int i = 0; i < rails.Length; i++)
        {
            grindRails.Add(rails[i]);
        }
    }

    private void FixedUpdate()
    {
        framesSinceGrounded += 1;
        framesSinceJump += 1;

        if (grinding) { return; }
        // Decided gravity value

        // If doing a jump attack use that gravity : else if holding jump use that gravity : else use normal gravity
        float gravityValue = (useJumpAttackGravity) ? playerSettings.jumpAttackGravity : (jumpInput) ? playerSettings.jumpingGravity : playerSettings.normalGravity;

        // Apply gravity
        rigidBody.AddForce(Vector3.down * gravityValue * Time.fixedDeltaTime, ForceMode.Impulse);

        if (isGrounded || SnapToGround())
        {
            framesSinceGrounded = 0;
        }
        else
        {
            // contactNormal = Vector3.up;
        }

        SurfaceAlignment();
    }

    private void Update()
    {
        CheckGrounded();
        UpdateGroundedFrames();
    }

    public void UpdateJumpInput(bool didJump)
    {
        jumpInput = didJump;
    }

    public void Move(float steering, float accelInput)
    {
        GrindUpdate();

        if (grinding) { return; }

        // Normalise steering and acceleration inputs
        steering = Mathf.Clamp(steering, -1.0f, 1.0f);
        accelInput = Mathf.Clamp(accelInput, 0.0f, 1.0f);

        playerAnimations.drifting = drifting;
        
        if (Mathf.Abs(steering) > 0.1f) { playerAnimations.driftIsRight = (steering >= 0.0f); }
        if (accelInput > 0.4f && isGrounded)
        {
            leftBooster.SetActive(true);
            rightBooster.SetActive(true);
        }
        else
        {
            leftBooster.SetActive(false);
            rightBooster.SetActive(false);
        }

        playerAnimations.accelerating = (accelInput > 0.4f) ? true : false;

        float accelMultiplier = (isGrounded) ? 1.0f : playerSettings.airAcceleration;

        // Add force to player
        Vector3 moveVector = accelInput * playerSettings.moveForce * Time.fixedDeltaTime * transform.forward * accelMultiplier;
        rigidBody.AddForce(moveVector, ForceMode.Impulse);

        // Add braking force to player
        if (braking && isGrounded)
        {
            Vector3 brakeVector = -rigidBody.velocity * Time.fixedDeltaTime * playerSettings.brakingMultiplier;
            rigidBody.AddForce(brakeVector, ForceMode.Impulse);
        }

        currentTurningForce = (drifting) ? playerSettings.driftTurningForce : playerSettings.turningForce;

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

    public bool TryGrind()
    {
        if (grindRails.Count <= 0) { return false; }

        GrindRail closest = FindClosestRail();

        Debug.Assert(closest, "ERROR: Couldn't find a closest grind rail");

        if (closest.CanGrind(transform.position))
        {
            StartGrind(closest);
            return true;
            // Debug.Log("Started grind with " + closest.name);
        }

        return false;
    }

    private GrindRail FindClosestRail()
    {
        GrindRail closest = null;
        float closestDist = 999999.0f;

        for (int i = 0; i < grindRails.Count; i++)
        {
            GrindRail testRail = grindRails[i];
            if (testRail == grindingRail) { continue; }

            float dist = (testRail.ClosestPointOnRail(transform.position) - transform.position).magnitude;

            if (dist < closestDist)
            {
                closest = testRail;
                closestDist = dist;
            }
        }

        return closest;
    }

    private void StartGrind(GrindRail rail)
    {
        Debug.Log("Started grind");
        grinding = true;
        grindingRail = rail;

        // Snap player to rail
        transform.position = grindingRail.ClosestPointOnRail(transform.position);
    }

    private void GrindUpdate()
    {
        if (!grinding) { return; }

        // Check if fallen off end of rail
        if ((grindingRail.ClosestPointOnRail(transform.position) - transform.position).magnitude > 1.0f)
        {
            // Try to find another rail to snap to

            GrindRail closest = FindClosestRail();

            float closestDot = Vector3.Dot(closest.GetForward(), rigidBody.velocity.normalized);

            if (Mathf.Abs(closestDot) > 0.75f && closest.CanGrind(transform.position))
            {
                StopGrind();
                StartGrind(closest);
            }
            else
            {
                StopGrind();
            }

            return;
        }

        // If not, align player velocity with rail
        Vector3 playerVelocity = rigidBody.velocity;
        Vector3 railDir = grindingRail.GetForward();

        float dot = Vector3.Dot(playerVelocity.normalized, railDir);

        // Player should go forward on the rail
        if (dot >= 0.0f)
        {
            rigidBody.velocity = rigidBody.velocity.magnitude * railDir;
        }
        else
        {
            rigidBody.velocity = rigidBody.velocity.magnitude * -railDir;
        }
    }

    private void StopGrind()
    {
        Debug.Log("Stopped Grind");

        grinding = false;
        grindingRail = null;
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

        if (drifting) { angleDiff *= 0.25f; }

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

            if (grinding) { StopGrind(); }
        }
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(transform.position + -contactNormal * playerSettings.groundCheckDistance, playerSettings.groundCheckRadius, playerSettings.groundLayers, QueryTriggerInteraction.Ignore);
        if (grinding) { isGrounded = true; }
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
        if (!Physics.Raycast(transform.position, -contactNormal, out hit, playerSettings.groundSnapDistance, playerSettings.groundLayers))
        {
            return false;
        }

        contactNormal = hit.normal;
        Vector3 currentVelocity = rigidBody.velocity;
        float speed = currentVelocity.magnitude;
        if (speed > playerSettings.maxSnapSpeed) { return false; }

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
