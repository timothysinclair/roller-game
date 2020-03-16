using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    public bool useJumpAttackGrav = false;

    PlayerSettings playerSettings;

    private void Awake()
    {
        playerSettings = Resources.Load<PlayerSettings>("ScriptableObjects/PlayerSettings");
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
        float gravityVar = (useJumpAttackGrav) ? playerSettings.jumpAttackGravity : playerSettings.normalGravity;
        GetComponent<Rigidbody>().AddForce(Vector3.down * Time.deltaTime * gravityVar, ForceMode.Impulse);
    }
}
