using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedScaling : MonoBehaviour
{
    public Animator[] grindParticles;
    public Animator playerAnimator;
    public TrailRenderer[] trails;

    private PlayerMovementController movementController;
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        movementController = GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = rigidBody.velocity.magnitude;
        float maxSpeed = movementController.boostingMaxSpeed;

        float quot = Mathf.Clamp(speed / maxSpeed, 0.0f, 1.0f);
        ScaleEffects(quot);
    }

    private void ScaleEffects(float amount)
    {
        grindParticles[0].speed = Mathf.Lerp(0.25f, 1.25f, amount);
        grindParticles[1].speed = Mathf.Lerp(0.25f, 1.25f, amount);

        playerAnimator.SetFloat("SkateSpeed", Mathf.Lerp(0.15f, 0.8f, amount));

        trails[0].transform.localScale = Vector3.one * Mathf.Lerp(0.0f, 2.0f, amount);
        trails[1].transform.localScale = Vector3.one * Mathf.Lerp(0.0f, 2.0f, amount);

        trails[0].time = Mathf.Lerp(0.1f, 0.25f, amount);
        trails[1].time = Mathf.Lerp(0.1f, 0.25f, amount);
    }
}
