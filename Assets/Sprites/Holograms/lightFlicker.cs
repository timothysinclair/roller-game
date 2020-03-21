using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlicker : MonoBehaviour
{
    [SerializeField] private float flickerFreq;
    private float flickerCur;

    [SerializeField] private bool changeColour;
    [SerializeField] private Color colourOne;
    [SerializeField] private Color colourTwo;

    [SerializeField] private bool changeBrightness;
    [SerializeField] private float minBrightness;
    [SerializeField] private float maxBrightness;

    private Light lit;

    // Start is called before the first frame update
    void Start()
    {
        lit = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flickerCur > 0)
        {
            flickerCur -= Time.deltaTime;
        }
        else
        {
            if (changeColour)
            {
                Color col = new Color(Random.Range(colourOne.r, colourTwo.r), Random.Range(colourOne.g, colourTwo.g), Random.Range(colourOne.b, colourTwo.b));
                lit.color = col;
            }

            if (changeBrightness)
            {
                lit.intensity = Random.Range(minBrightness, maxBrightness);
            }

            flickerCur = flickerFreq;
        }
    }
}
