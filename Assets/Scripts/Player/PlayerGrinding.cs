using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrinding : PlayerState
{
    public GameObject grindLoop;

    private List<GrindRail> grindRails;
    private GrindRail currentRail = null;

    // The distance the player needs to be from a rail in order to fall off
    private float fallenOffDistance = 1.0f;

    public override void OnAwake()
    {
        GrindRail[] rails = FindObjectsOfType<GrindRail>();
        grindRails = new List<GrindRail>();

        for (int i = 0; i < rails.Length; i++)
        {
            grindRails.Add(rails[i]);
        }
    }

    public override void OnEnter()
    {
        grindLoop.SetActive(true);
        playerAnimations.grinding = true;
        rigidBody.angularVelocity = Vector3.zero;
    }

    public override void OnExit()
    {
        grindLoop.SetActive(false);
        playerAnimations.grinding = false;
    }

    public override void OnFixedUpdate()
    {
        if (!Active) { return; }
    }

    public void TryGrind()
    {
        if (grindRails.Count <= 0) { return; }

        GrindRail closest = FindClosestRail();

        Debug.Assert(closest != null, "ERROR: Couldn't find a closest grind rail");

        if (closest.CanGrind(transform.position))
        {
            StartGrind(closest, true);
        }
         
        return;
    }

    public override void OnMove(float steering, float accelInput, bool isGrounded)
    {
        if (!Active) { return; }

        // Check if fallen off end of rail
        if ((currentRail.ClosestPointOnRail(transform.position) - transform.position).magnitude > fallenOffDistance)
        {
            // First, try to find another rail to snap to
            GrindRail closest = FindClosestRail();

            float closestDot = Vector3.Dot(closest.GetForward(), rigidBody.velocity.normalized);

            if (Mathf.Abs(closestDot) > 0.75f && closest.CanGrind(transform.position))
            {
                StopGrind(false);
                StartGrind(closest, true);
            }
            else
            {
                StopGrind(true);
            }

            return;
        }

        // If not, align player velocity with rail
        float dot = DotWithRail(rigidBody.velocity.normalized, currentRail);

        Vector3 railDir = currentRail.GetForward();

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

    public override void OnUpdate()
    {
        if (!Active) { return; }
    }

    private void StartGrind(GrindRail rail, bool playSound)
    {
        Active = true;
        currentRail = rail;
        if (playSound) { AudioManager.Instance.PlaySoundVaried("GrindStart"); }

        // Snap player to rail
        transform.position = currentRail.ClosestPointOnRail(transform.position);

        Vector3 railDir = currentRail.GetForward();
        float dot = DotWithRail(transform.forward, currentRail);

        // Player should go forward on the rail
        if (dot >= 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(railDir, currentRail.GetNormal());
        }
        // Player should go backwards on the rail
        else
        {
            transform.rotation = Quaternion.LookRotation(-railDir, currentRail.GetNormal());
        }
    }

    public void StopGrind(bool playSound)
    {
        Active = false;

        if (playSound) { AudioManager.Instance.PlaySoundVaried("GrindEnd"); }
        
        currentRail = null;

        playerScore.AddTrick(Trick.Grind);
    }

    private GrindRail FindClosestRail()
    {
        GrindRail closest = null;
        float closestDist = 999999.0f;

        for (int i = 0; i < grindRails.Count; i++)
        {
            GrindRail testRail = grindRails[i];
            if (currentRail && testRail.GetInstanceID() == currentRail.GetInstanceID()) { continue; }

            float dist = (testRail.ClosestPointOnRail(transform.position) - transform.position).magnitude;

            if (dist < closestDist)
            {
                closest = testRail;
                closestDist = dist;
            }
        }

        return closest;
    }

    private float DotWithRail(Vector3 other, GrindRail rail)
    {
        Vector3 railDir = rail.GetForward();

        return (Vector3.Dot(other, railDir));
    }
}
