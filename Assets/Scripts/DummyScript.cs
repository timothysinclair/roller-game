using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    public bool useJumpAttackGrav = false;

    PlayerSettings playerSettings;
    Rigidbody _rigidBody;

    private void Awake()
    {
        playerSettings = Resources.Load<PlayerSettings>("ScriptableObjects/PlayerSettings");
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KickAttackHB")
        {
            if (useJumpAttackGrav) { GameObject.FindObjectOfType<PlayerCombatController>().FloatingEnemyHit(); }
            Debug.Log("Dummy take damage");
        }
    }

    private void Update()
    {
        // Manual gravity
        float gravityVar = 0.0f;
        if (useJumpAttackGrav)
        {
            // Reset velocity
            _rigidBody.velocity = Vector3.up * _rigidBody.velocity.y;
            gravityVar = playerSettings.jumpAttackGravity;
        }
        else { gravityVar = playerSettings.normalGravity; }
        // Apply gravity
        _rigidBody.AddForce(Vector3.down * Time.deltaTime * gravityVar, ForceMode.Impulse);
    }
}
