using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hologramScript : MonoBehaviour
{
    [SerializeField] private float amp;
    [SerializeField] private float freq;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    [SerializeField] private float alphaFreq;
    private float alphaCur;

    [SerializeField] private float alphaMin;
    [SerializeField] private float alphaMax;

    [SerializeField] private Light pointLight;

    private Color newCol;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        newCol = sr.color;

        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * freq) * amp;

        transform.position = tempPos;

        if (alphaCur > 0)
        {
            alphaCur -= Time.deltaTime;
        }
        else
        {
            float alpha = Random.Range(alphaMin, alphaMax);

            newCol.a = alpha;
            sr.color = newCol;

            pointLight.intensity = alpha * 2;

            alphaCur = alphaFreq;
        }
    }
}
