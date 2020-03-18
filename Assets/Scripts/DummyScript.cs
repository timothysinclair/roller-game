using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    public bool useJumpAttackGrav = false;
    public bool dead = false;
    [SerializeField] Animator enemyAnimator;
    public int Health
    {
        get { return m_health; }
        set
        {
            if (value < m_health) { enemyAnimator.SetTrigger("Damaged"); }
            m_health = value;
            if (value <= 0) { Died(); }
        }
    }

    PlayerSettings playerSettings;
    Rigidbody _rigidBody;
    int m_health = 3;

    private void Awake()
    {
        playerSettings = Resources.Load<PlayerSettings>("ScriptableObjects/PlayerSettings");
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dead) { return; }

        if (other.tag == "KickAttackHB")
        {
            if (useJumpAttackGrav) { GameObject.FindObjectOfType<PlayerCombatController>().FloatingEnemyHit(); }
            Health -= 1;
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

    void Died()
    {
        dead = true;
        //GetComponent<Collider>().isTrigger = true;
        Debug.Log("Dummy died");
    }
}
