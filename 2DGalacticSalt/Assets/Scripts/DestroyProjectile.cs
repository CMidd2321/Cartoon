using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour {

    public float timer = 5;
    

	// Use this for initialization
	void Start ()
    {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy();
        }
    }
    // Update is called once per frame
    void Update ()
    {
        
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            Destroy();
        }
	}

    void Destroy()
    {
        
        Destroy(gameObject);
    }
}
