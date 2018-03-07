using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingProjectile : MonoBehaviour {

    public Transform player;
    public float maxSpeed = 1f;
   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    

    void Update()
    {
        

        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 1f);
        }

        
         transform.position = Vector2.MoveTowards(transform.position, player.position,  maxSpeed * Time.deltaTime);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
