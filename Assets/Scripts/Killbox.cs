using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        PlayerScore playerScore = other.GetComponent<PlayerScore>();

        if (playerScore)
        {
            playerScore.gameObject.transform.position = respawnPoint.transform.position;
            playerScore.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
