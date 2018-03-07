using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{

    public float moveSpeed;
    public PlayerStats stats;
    public bool isGrounded;

    void Update()
    {
        float h = Input.GetAxis("Horizontal") * moveSpeed;//move the player in direction of keypress

        GetComponent<Rigidbody2D>().AddForce(Vector2.right * h);
        
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * stats.jumpHeight);
            isGrounded = false;
        }
        if (Input.GetButtonDown("Fire1") && isGrounded == false)
        {
            Debug.Log("SLAM!.");
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * stats.jumpHeight*2);
            isGrounded = true;
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
       

    }
}

