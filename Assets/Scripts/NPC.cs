using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialogueCanvas;
    [SerializeField] GameObject buttonPrompt;

    bool inRange = true;

    PlayerInput m_playerInput;

    private void Awake()
    {
        m_playerInput = GameObject.FindObjectOfType<PlayerInput>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerScore player = other.GetComponent<PlayerScore>();

        if (player)
        {
            buttonPrompt.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerScore player = other.GetComponent<PlayerScore>();

        if (player)
        {
            buttonPrompt.SetActive(false);
            inRange = false;
        }
    }

    public void Interact()
    {
        if (!inRange) { return; }

        m_playerInput.SetControls(false);
        dialogueCanvas.SetActive(true);
    }

    public void Accept()
    {
        m_playerInput.SetControls(true);
        dialogueCanvas.SetActive(false);
        // Start timer
        GameObject.FindObjectOfType<PlayerTimer>().StartTimer();
    }

    public void Decline()
    {
        m_playerInput.SetControls(true);
        dialogueCanvas.SetActive(false);
    }
}
