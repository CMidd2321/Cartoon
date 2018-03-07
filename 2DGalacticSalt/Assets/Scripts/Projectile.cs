using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

   // public Transform player;
    public float maxSpeed = 1f;
    //public Transform bullet;
    public moveScript player;
    
    void Start ()
    {
        player = FindObjectOfType<moveScript>();

       if (player.transform.position.x < transform.position.x)
        {
            maxSpeed = -maxSpeed;
        }
    }
	
	
	void Update ()
    {
        // player = GameObject.FindGameObjectWithTag("Player").transform;
        // transform.position = Vector2.MoveTowards(transform.position, maxSpeed * Time.deltaTime);
        GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
