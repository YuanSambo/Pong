using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private string input;
    public float speed;
    private GameObject ball;
    public bool isAI;
    Vector3 move = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.name;
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAI)
        {
            float movement = Input.GetAxis(input) * speed * Time.deltaTime;
            transform.Translate(0, movement, 0);

        }

        // If paddle is an AI
        else
        {
            float distance = ball.transform.position.y - transform.position.y;

            // If the ball is higher than the paddle;
            if (distance > 0)
            {
                //Then the paddle will move up;
                move.y = speed * Mathf.Min(distance, 1f);
            }
            // If the ball is lower than the paddle
            if (distance < 0)
            {
                //Then the paddle will move down;
                move.y = -(speed * Mathf.Min(-distance, 1f));
            }

                transform.position += move * Time.deltaTime;
            

        }


        if (transform.position.y > 3)
        {
            transform.position = new Vector3(transform.position.x, 3f, 0);
        }

        if (transform.position.y < -3)
        {
            transform.position = new Vector3(transform.position.x, -3f, 0);

        }


    }

    public void ChangetoAi()
    {
        isAI = true;
    }
}
