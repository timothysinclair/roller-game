using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkatingSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioSource.isPlaying) { RestartSound(); }
    }

    private void RestartSound()
    {
        audioSource.volume = Random.Range(0.8f, 1.0f);
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        audioSource.Play();
    }
}
