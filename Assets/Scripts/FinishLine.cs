using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // If player
        PlayerTimer player = other.GetComponent<PlayerTimer>();

        if (player)
        {
            player.StopTimer();
        }
    }
}
