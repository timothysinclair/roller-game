using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [HideInInspector] public bool grounded = false;
    [HideInInspector] public bool moving = false;
    [HideInInspector] public bool accelerating = false;

    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        playerAnimator.SetBool("Grounded", grounded);
        playerAnimator.SetBool("Moving", moving);
        playerAnimator.SetBool("Accelerating", accelerating);
    }

    public void OnJump()
    {
        playerAnimator.SetTrigger("Jump");
    }
}
