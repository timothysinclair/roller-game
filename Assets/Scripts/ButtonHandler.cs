﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void Play()
    {
        // Load first level
        SceneManager.LoadScene("TimScene4");
    }

    public void Quit()
    {
        Application.Quit();
    }
}