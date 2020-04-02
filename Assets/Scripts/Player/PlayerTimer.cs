using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTimer : MonoBehaviour
{
    [SerializeField] GameObject startLine;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Collectible[] collectables;
    [SerializeField] DummyScript[] enemies;

    [HideInInspector] public float currentTime = 0.0f;
    public TextMeshProUGUI timerText;

    private bool isRunning = false;

    private void Awake()
    {
        //StartTimer();
        collectables = GameObject.FindObjectsOfType<Collectible>();
        enemies = GameObject.FindObjectsOfType<DummyScript>();
    }

    public void StartTimer()
    {
        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].Initialise();
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].gameObject.SetActive(true);
            enemies[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
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
