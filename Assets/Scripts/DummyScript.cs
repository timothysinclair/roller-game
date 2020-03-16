using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HurtBox")
        {
            // Take damage
            Debug.Log("Dummy Hit");
        }
    }
}
