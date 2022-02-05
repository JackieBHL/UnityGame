using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    public float speed;
    public float randomUp;

    Rigidbody2D ballRigidbody;

    GameController cont;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        cont = FindObjectOfType<GameController>();
    }


    private void OnEnable()
    {
        Invoke("PushBall", 1f);
    }
    void PushBall()
    {
        int dir = Random.Range(0, 2); //random 0 and 1
        float x, y;
        if (dir == 0) //Right move
            x = speed;
        else//left move
            x = -speed;

        y = Random.Range(-randomUp, randomUp);
        ballRigidbody.AddForce(new Vector2(x, y));


    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = ballRigidbody.velocity.x;
            vel.y = ballRigidbody.velocity.y / 2 + collision.collider.attachedRigidbody.velocity.y / 2;

            ballRigidbody.velocity = vel;


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            if(ballRigidbody.velocity.x > 0)//left get poing
            {
                cont.Score(true);
            }
            else if (ballRigidbody.velocity.x < 0)//right get point
            {
                cont.Score(false);

            }
            else
            {

            }
            
            ballRigidbody.velocity = Vector2.zero;//new vector (0,0)
            transform.position = Vector3.zero;//0,0,0

            Invoke("PushBall", 2f);


        }
    }

}



