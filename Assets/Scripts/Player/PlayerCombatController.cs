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
    const float trickLength = 0.5f;
    float trickTimer;
    bool trickPlaying = false;
    enum AttackState
    {
        NONE = 0,
        FIRST,
        SECOND,
        THIRD
    }
    AttackState currentAttackState = AttackState.NONE;

    [Header("Attack Combo Times")]
    [Tooltip("Maximum time before the combo resets")]
    [SerializeField] float maxAttackTime = 1.0f;
    [Tooltip("Minimum time before a new combo can be triggered")]
    [SerializeField] float minPostAttackTime = 1.5f;
    float timeSinceLastAttack = 10.0f;


    private void Awake()
    {
        trickTimer = trickLength;
    }

    private void Update()
    {
        // Combo timer
        if (timeSinceLastAttack <= 10.0f) { timeSinceLastAttack += Time.deltaTime; }

        // Temp trick animation
        if (trickPlaying && trickTimer <= 0.0f)
        {
            trickTimer = trickLength;
            trickPlaying = false;
            playerAnimator.SetBool("Attacking", false);
            hurtbox.SetActive(false);
        }
        else if (trickPlaying) { trickTimer -= Time.deltaTime; }
    }

    public void BasicAttack()
    {
        // Checks if attacking
        if (trickPlaying) { return; }

        if (currentAttackState == AttackState.NONE) { DoAttack(); }
        else
        {
            if (timeSinceLastAttack >= minPostAttackTime) { DoAttack(true); }
            else if (timeSinceLastAttack < maxAttackTime && currentAttackState != AttackState.THIRD) { DoAttack(); }
        }
    }

    void DoAttack(bool resetAttackChain = false)
    {
        currentAttackState = (resetAttackChain) ? AttackState.FIRST : (AttackState)(int)currentAttackState + 1;

        timeSinceLastAttack = 0.0f;

        playerAnimator.SetBool("Attacking", true);
        trickPlaying = true;
        hurtbox.SetActive(true);

        Debug.Log("Attack " + currentAttackState);
    }
}
