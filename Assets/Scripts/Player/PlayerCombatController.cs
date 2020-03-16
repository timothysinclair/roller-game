using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    // Public


    // Serialiszed
    [SerializeField] Animator playerAnimator;
    [SerializeField] GameObject hurtbox;

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

    [Header("Attack Combo Times")]
    [Tooltip("Maximum time before the combo resets")]
    [SerializeField] float maxAttackTime = 0.5f;
    [Tooltip("Minimum time before a new combo can be triggered")]
    [SerializeField] float minPostAttackTime = 1.0f;
    float timeSinceLastAttack = 10.0f;


    private void Awake()
    {
        movementController = GetComponent<NewSkatingController>();
    }

    private void Update()
    {
        if (trickPlaying && movementController.IsPlayerGrounded()) { trickPlaying = false; }

        // Combo timer
        if (timeSinceLastAttack <= 10.0f) { timeSinceLastAttack += Time.deltaTime; }
    }

    public void BasicAttack()
    {
        // Checks if attacking
        if (trickPlaying || movementController.IsPlayerGrounded()) { return; }

        if (currentAttackState == AttackState.NONE) { DoAttack(); }
        else
        {
            if (timeSinceLastAttack >= minPostAttackTime) { DoAttack(true); }
            else if (timeSinceLastAttack <= maxAttackTime && currentAttackState != AttackState.THIRD) { DoAttack(); }
        }
    }

    void DoAttack(bool resetAttackChain = false)
    {
        currentAttackState = (resetAttackChain) ? AttackState.FIRST : (AttackState)(int)currentAttackState + 1;

        //timeSinceLastAttack = 0.0f;

        playerAnimator.SetInteger("KickState", (int)currentAttackState);
        playerAnimator.SetTrigger("Attacking");
        trickPlaying = true;
        //hurtbox.SetActive(true);

        Debug.Log("Attack " + currentAttackState);
    }

    public void AttackFinished()
    {
        trickPlaying = false;
        hurtbox.SetActive(false);
        timeSinceLastAttack = 0.0f;
    }
}
