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


    private void Awake()
    {
        trickTimer = trickLength;
    }

    private void Update()
    {
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
        playerAnimator.SetBool("Attacking", true);
        trickPlaying = true;
        hurtbox.SetActive(true);


        Debug.Log("Doing trick");
    }
}
