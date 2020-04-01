using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIParticleScript : MonoBehaviour
{
    public Sprite texture;
    public float speed;
    public float life;
    public float size;
    public Gradient colour;
    public float startRotation;
    public float rotationOverTime;
    public float gravityModifier;

    Image image;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        rb = GetComponent<Rigidbody2D>();

        image.sprite = texture;
        image.color = colour.Evaluate(0.0f);

        transform.rotation = Quaternion.Euler(0, 0, startRotation);

        rb.AddForce(transform.up * (speed * 5), ForceMode2D.Impulse);
        rb.gravityScale = gravityModifier;

        this.transform.localScale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        if (life > 0)
        {
            life -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (rotationOverTime > 0)
        {
            this.transform.Rotate(0, 0, rotationOverTime);
        }

        image.color = colour.Evaluate(1.0f / life);
    }
}
