using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTimer : MonoBehaviour
{
    [SerializeField] GameObject startLine;
    [SerializeField] Transform spawnPoint;
    Collectible[] collectables;
    DummyScript[] enemies;

    [HideInInspector] public float currentTime = 0.0f;
    public TextMeshProUGUI timerText;

    private bool isRunning = false;

    private void Awake()
    {
        //StartTimer();
        collectables = GameObject.FindObjectsOfType<Collectible>();
        enemies = GameObject.FindObjectsOfType<DummyScript>();

        foreach (DummyScript enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    public void StartTimer()
    {
        for (int i = 0; i < collectables.Length; i++)
        {
            // if (!collectables[i].gameObject.activeSelf) { collectables[i].gameObject.SetActive(true); }
            collectables[i].gameObject.SetActive(true);
            collectables[i].Initialise();
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].gameObject.SetActive(true);
            enemies[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            enemies[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            enemies[i].ResetScale();
        }

        currentTime = 0.0f;
        isRunning = true;
        startLine.SetActive(false);
    }

    public void StopTimer()
    {
        isRunning = false;
        startLine.SetActive(true);
        // Tp player back to start
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = spawnPoint.position;
    }

    private void Update()
    {
        if (!isRunning) { return; }

        currentTime += Time.deltaTime;

        string mins = Mathf.Floor(currentTime / 60).ToString("00");
        string secs = (currentTime % 60).ToString("00");

        if (timerText)
        {
            timerText.text = mins + ":" + secs;
        }
    }
}
