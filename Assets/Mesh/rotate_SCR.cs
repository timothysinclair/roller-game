using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_SCR : MonoBehaviour
{
    [SerializeField] private float rotSpeed;

    [SerializeField] private float amp;
    [SerializeField] private float freq;
    //[SerializeField] private float heightSpeed;

    Vector3 posOffset = new Vector3();
    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotSpeed * Time.deltaTime, 0f);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * freq) * amp;

        transform.position = tempPos;
    }
}
