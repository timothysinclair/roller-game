using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    // Public


    // Serialiszed
    [SerializeField] Animator playerAnimator;
    [SerializeField] GameObject kickHurtbox;
    [SerializeField] GameObject jumpHurtbox;

    // Private
    bool trickPlaying = false;
    enum AttackState
    {
        NONE = 0,
        FIRST,
        SECOND,
        THIRD
    }
    AttackState currentAttackState = AttackState.NONE;
    NewSkatingController movementController;

    // Jump attack
    float jumpHurtboxTimer = 0.0f;
    bool jumpAttackHurtboxActive = false;
    bool jumpAttackHit = false;
    float jumpAttackTimer = 0.0f;
    GameObject lastEnemyHit;

    // Punch attack
    float timeSinceLastAttack = 10.0f;

    PlayerSettings playerSettings;

    private void Awake()
    {
        playerSettings = Resources.Load<PlayerSettings>("ScriptableObjects/PlayerSettings");
        movementController = GetComponent<NewSkatingController>();
    }

    private void Update()
    {
        if (trickPlaying && movementController.IsPlayerGrounded()) { trickPlaying = false; kickHurtbox.SetActive(false); }

        // Combo timer
        if (timeSinceLastAttack <= 10.0f) { timeSinceLastAttack += Time.deltaTime; }

        // Jump hurt box
        if (jumpHurtboxTimer <= 0.0f && jumpAttackHurtboxActive) { DespawnJumpHurtbox(); }
        else if (jumpAttackHurtboxActive) { jumpHurtboxTimer -= Time.deltaTime; }

        // Jump attack in air
        if (jumpAttackHit)
        {
            jumpAttackTimer += Time.deltaTime;
            if (jumpAttackTimer >= playerSettings.maxTimeToHit) { StopJumpAttack(); }
        }
    }

    public void BasicAttack()
    {
        // Checks if attacking
        if (trickPlaying || movementController.IsPlayerGrounded()) { return; }

        if (currentAttackState == AttackState.NONE) { DoAttack(); }
        else
        {
            if (timeSinceLastAttack >= playerSettings.minPostAttackTime) { DoAttack(true); }
            else if (timeSinceLastAttack <= playerSettings.maxAttackTime && currentAttackState != AttackState.THIRD) { DoAttack(); }
        }
    }

    void DoAttack(bool resetAttackChain = false)
    {
        currentAttackState = (resetAttackChain) ? AttackState.FIRST : (AttackState)(int)currentAttackState + 1;

        //timeSinceLastAttack = 0.0f;

        playerAnimator.SetInteger("KickState", (int)currentAttackState);
        playerAnimator.SetTrigger("Attacking");
        trickPlaying = true;
        kickHurtbox.SetActive(true);
    }

    public void AttackFinished()
    {
        trickPlaying = false;
        kickHurtbox.SetActive(false);
        timeSinceLastAttack = 0.0f;
    }

    public void SpawnJumpHurtbox()
    {
        jumpHurtbox.SetActive(true);
        jumpHurtboxTimer = playerSettings.maxJumpHurtBoxTimer;
        jumpAttackHurtboxActive = true;
    }

    public void DespawnJumpHurtbox()
    {
        jumpAttackHurtboxActive = false;
        jumpHurtbox.SetActive(false);
    }

    public void StartJumpAttack(GameObject enemyHit)
    {
        // Enemy
        lastEnemyHit = enemyHit;
        enemyHit.GetComponent<Rigidbody>().velocity = Vector3.zero;
        enemyHit.GetComponent<Rigidbody>().AddForce(Vector3.up * playerSettings.jumpForce, ForceMode.Impulse);
        enemyHit.GetComponent<DummyScript>().useJumpAttackGrav = true;

        // Player
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(Vector3.up * playerSettings.jumpForce, ForceMode.Impulse);

        // Variables
        jumpAttackTimer = 0.0f;
        jumpAttackHit = true;
        movementController.useJumpAttackGravity = true;
    }

    void StopJumpAttack()
    {
        jumpAttackHit = false;
        movementController.useJumpAttackGravity = false;
        lastEnemyHit.GetComponent<DummyScript>().useJumpAttackGrav = false;
    }

    public void FloatingEnemyHit()
    {
        if (!jumpAttackHit) { return; }

        // Reset timer to hit the enemy
        jumpAttackTimer = 0.0f;
    }
}
