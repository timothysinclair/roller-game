using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParticleEmitter : MonoBehaviour
{
    [Header("Basics")]
    public Sprite texture;
    public float duration = 5;
    public bool looping = true;
    public float speed = 1;
    public float life = 1;
    public float size = 1;
    public Gradient colour;
    [SerializeField] private bool randomRotation = false;
    public float startRotation;
    public float rotationOverTime;
    public float gravityModifier;

    [Header("Emission")]
    [SerializeField] private float rate = 10;    // how many a second
    private float curRate;
    [SerializeField] private int burst;
    [SerializeField] private float burstInterval;
    private float curBurst;
    private float burstNum = 0;

    [Header("Private Variables")]
    [SerializeField] private GameObject basePrefab;

    private void Start()
    {
        curRate = 0;
        curBurst = 0;
    }

    private void Update()
    {
        if (rate > 0)
        {
            if (curRate > 0)
            {
                curRate -= Time.deltaTime;
            }
            else
            {
                CreateParticle();
                curRate = 1.0f / rate;
            }
        }

        if (burstInterval > 0)
        {
            if (curBurst > 0)
            {
                curBurst -= Time.deltaTime;
            }
            else
            {
                CreateBurst();
                curBurst = burstInterval;
            }
        }

        if (!looping)
        {
            if (duration > 0)
            {
                duration -= Time.deltaTime;
            }
            else
            {
                this.enabled = false;
            }
        }
    }

    private void CreateParticle()
    {
        GameObject part = (GameObject)Instantiate(basePrefab, this.transform);

        UIParticleScript ps = part.GetComponent<UIParticleScript>();

        ps.texture = texture;
        ps.speed = speed;
        ps.life = life;
        ps.size = size;
        ps.colour = colour;

        if (randomRotation)
        {
            ps.startRotation = Random.Range(0, 360);
        }
        else
        {
            ps.startRotation = startRotation;
        }
        ps.rotationOverTime = rotationOverTime;
        ps.gravityModifier = gravityModifier;

        //part = null;
    }

    private void CreateBurst()
    {
        for (int i = 0; i < burst; i++)
        {
            GameObject part = (GameObject)Instantiate(basePrefab, this.transform);

            UIParticleScript ps = part.GetComponent<UIParticleScript>();

            ps.texture = texture;
            ps.speed = speed;
            ps.life = life;
            ps.size = size;
            ps.colour = colour;

            if (randomRotation)
            {
                ps.startRotation = Random.Range(0, 360);
            }
            else
            {
                ps.startRotation = startRotation;
            }
            ps.rotationOverTime = rotationOverTime;
            ps.gravityModifier = gravityModifier;
        }
    }
}
