using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTimer : MonoBehaviour
{
    [HideInInspector] public float currentTime = 0.0f;
    public TextMeshProUGUI timerText;

    private bool isRunning = false;

    private void Awake()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
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
