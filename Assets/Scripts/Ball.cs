using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    TrailRenderer tr;
    public AudioSource ImpactSound, GoalSound;
    public int speed;
    Vector2 direction;

    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        ImpactSound = GetComponent<AudioSource>();
        Invoke("Launch", 2f);
    }


    void Update()
    {
        if (!IsInvoking("Launch"))
        {
            transform.Translate(direction * speed * Time.deltaTime);

        }
        else return;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        if (collision.collider.CompareTag("Wall"))
        {
            tr.material.SetColor("_EmissionColor", color);
            direction.y = -direction.y;
        }
        if (collision.collider.CompareTag("Paddle"))
        {
            tr.material.SetColor("_EmissionColor", color);
            direction.x = -direction.x;
        }
        if (collision.collider.CompareTag("Goal"))
        {
            GoalSound.Play();
            GameManager.Score(collision.gameObject);
            Reset();

        }

        ImpactSound.Play();

    }

    void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        direction = new Vector2(x, y);
        
    }

    public void Reset()
    {
        transform.position = Vector2.zero;
        CancelInvoke("Launch");
        Invoke("Launch", 1f);

    }
}
