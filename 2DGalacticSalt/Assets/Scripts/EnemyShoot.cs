using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float playerRange;
    public GameObject projectile;
    public GameObject Player;
    public Transform ShootPoint;
    public float cooldown;
    private float cooldowntimer;

    


    void Start()
    {
        cooldowntimer = cooldown;
    }


    void Update()
    {
        cooldowntimer -= Time.deltaTime;
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
        if(transform.localScale.x < 0 && Player.transform.position.x > transform.position.x && Player.transform.position.x < transform.position.x + playerRange && cooldowntimer <= 0)
        {
            Instantiate(projectile, ShootPoint.position, ShootPoint.rotation);
            cooldowntimer = cooldown;
        }
        if (transform.localScale.x > 0 && Player.transform.position.x < transform.position.x && Player.transform.position.x > transform.position.x - playerRange && cooldowntimer <= 0)
        {
            Instantiate(projectile, ShootPoint.position, ShootPoint.rotation);
            cooldowntimer = cooldown;
        }
    }
}

