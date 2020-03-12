using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    public CinemachineFreeLook playerCam;
    public AnimationCurve fovCurve;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float speed = rigidBody.velocity.magnitude;

        float desiredFOV = fovCurve.Evaluate(speed);
        float currentFOV = playerCam.m_Lens.FieldOfView;
        float deltaFOV = (desiredFOV - currentFOV) / 8.0f;

        playerCam.m_Lens.FieldOfView += deltaFOV;
    }
}
