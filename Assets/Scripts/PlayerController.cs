using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool leftPlayer;
    public float speed;

    int leftup, rightup;

    Rigidbody2D rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (leftPlayer)//control left player
        {
            if (Input.GetKey(KeyCode.W))
                leftup = 1;
            if (Input.GetKey(KeyCode.S))
                leftup = -1;
            rigidbody.AddForce(Vector2.up * leftup * speed * Time.deltaTime);

        }
        else//controll right player
        {
            if (Input.GetKey(KeyCode.UpArrow))
                rightup = 1;
            if (Input.GetKey(KeyCode.DownArrow))
                rightup = -1;
            rigidbody.AddForce(Vector2.up * rightup * speed * Time.deltaTime);

        }
    }
}
