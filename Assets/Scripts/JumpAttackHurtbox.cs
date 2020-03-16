using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttackHurtbox : MonoBehaviour
{
    [SerializeField] PlayerCombatController combatController;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRB = other.GetComponent<Rigidbody>();
        if (otherRB)
        {
            combatController.StartJumpAttack(other.gameObject);
        }
    }
}
