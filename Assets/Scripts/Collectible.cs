using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Collectible : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        PlayerScore playerScore = other.gameObject.GetComponent<PlayerScore>();

        if (playerScore)
        {
            playerScore.CollectCollectible();
            Destroy(this.gameObject);
        }
    }
}

