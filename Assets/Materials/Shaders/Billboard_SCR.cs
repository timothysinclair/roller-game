using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard_SCR : MonoBehaviour
{
    Renderer rend;

    private float blendVal = -2.0f;
    [SerializeField] private float speed;

    [SerializeField] private float adTime;
    private float adTimeCur;

    private int ad = 0;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Roller/Billboard");

        adTimeCur = adTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (adTimeCur > 0)
        {
            adTimeCur -= Time.deltaTime;
        }
        else
        {
            blendVal = Mathf.Sin(Time.fixedTime * Mathf.PI * speed) * 2;
            rend.material.SetFloat("_Blend", blendVal);

            if (blendVal <= -1.95f)
            {
                blendVal = -2.0f;
                adTimeCur = adTime;
            }

            if (blendVal >= 1.95f)
            {
                blendVal = 12.0f;
                adTimeCur = adTime;
            }
        }
    }
}