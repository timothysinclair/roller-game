using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

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
    int m_health = 1;
    Vector3 spawnPos;
    Quaternion spawnRot;

    private void Awake()
    {
        playerSettings = Resources.Load<PlayerSettings>("ScriptableObjects/PlayerSettings");
        _rigidBody = GetComponent<Rigidbody>();
        spawnPos = transform.position;
        spawnRot = transform.localRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KickAttackHB")
        {
            AudioManager.Instance.PlaySoundVaried("Robot Hit");

            if (dead) { return; }

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
        transform.DOScale(0.0f, 1.0f).SetEase(Ease.InOutElastic).OnComplete(() => Destroy(this.gameObject));
        AudioManager.Instance.PlaySoundVaried("Robot Death");
        // Debug.Log("Dummy died");
    }

    public void CheckIfDead()
    {
        if (dead)
        {
            //Destroy(this.gameObject);
            transform.position = spawnPos;
            transform.localRotation = spawnRot;
            this.gameObject.SetActive(false);
        }
    }
}
