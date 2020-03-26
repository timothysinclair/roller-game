using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialogueCanvas;

    private void OnTriggerEnter(Collider other)
    {
        PlayerScore player = other.GetComponent<PlayerScore>();

        if (player)
        {
            dialogueCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerScore player = other.GetComponent<PlayerScore>();

        if (player)
        {
            dialogueCanvas.SetActive(false);
        }
    }
}
