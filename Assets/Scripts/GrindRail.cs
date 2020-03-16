using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRail : MonoBehaviour
{
    // Place grindrail transform at rail start
    public Transform railEnd;
    public Transform normalTransform;
    // public Transform distanceTester;

    public float grindRange = 10.0f;

    private Vector3 normal = Vector3.up;

    private void Awake()
    {
        normal = (normalTransform.position - transform.position).normalized;
    }

    public Vector3 ClosestPointOnRail(Vector3 queryPosition)
    {
        Vector3 wander = queryPosition - transform.position;
        Vector3 span = railEnd.position - transform.position;

        float t = Vector3.Dot(wander, span) / span.sqrMagnitude;

        t = Mathf.Clamp01(t);

        Vector3 closestPoint = transform.position + t * span;

        return closestPoint;
    }

    public bool CanGrind(Vector3 queryPosition)
    {
        Vector3 closestPos = ClosestPointOnRail(queryPosition);

        float distance = (closestPos - queryPosition).magnitude;

        // Player must be within range and above rail to grind
        return (distance < grindRange && (queryPosition.y - closestPos.y) > -5.0f);
    }

    public Vector3 GetForward()
    {
        return (railEnd.position - transform.position).normalized;
    }

    public Vector3 GetNormal()
    {
        return normal;
    }

    private void OnDrawGizmos()
    {
        // Debug.Log(CanGrind(distanceTester.position));
        

        Gizmos.color = Color.cyan;
        // Gizmos.DrawWireSphere(transform.position, grindRange);
        // Gizmos.DrawWireSphere(railEnd.transform.position, grindRange);

        Gizmos.DrawLine(transform.position, railEnd.position);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + GetNormal());
    }
}
