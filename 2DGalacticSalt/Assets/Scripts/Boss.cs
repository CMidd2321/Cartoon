using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour {

    //patrol 
    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;
    private bool NotAtEdge;
    public Transform edgeCheck;

    //shooting
    public float playerRange;
    public GameObject projectile;
    public GameObject Player;
    public Transform ShootPoint;
    public float cooldown;
    private float cooldowntimer;
    public GameObject seekerProjectile;
    public Transform seekerShoot;
    

    //other
    public float health = 20;
    private int attack;
    
    

    void Start ()
    {
        
        cooldowntimer = cooldown;
        
    }
	
	
	void Update ()
    {

        cooldowntimer -= Time.deltaTime;
        //patrolling
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        NotAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
        if (hittingWall || !NotAtEdge)
        {
            moveRight = !moveRight;
        }
        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        //end patrolling

        //shooting 
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3
            (transform.position.x + playerRange, transform.position.y, transform.position.z));

        if (transform.localScale.x < 0 && Player.transform.position.x > transform.position.x && Player.transform.position.x
            < transform.position.x + playerRange && cooldowntimer <= 0 && health >= 11)
        {

            moveSpeed = 0;
            attack = Random.Range(0, 3);
            Debug.Log(attack);
            if (attack == 0)
            {
                Instantiate(projectile, ShootPoint.position, ShootPoint.rotation);
                cooldowntimer = cooldown;
            }
            if (attack == 1)
            {
                Instantiate(seekerProjectile, seekerShoot.position, seekerShoot.rotation);
                cooldowntimer = cooldown;
            }
        }

    }
}
