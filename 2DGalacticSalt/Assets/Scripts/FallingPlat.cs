using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour {

    SpriteRenderer spriteRend;
    public bool destroying;
    public float count = 5;

    void Start ()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        destroying = false;
        
    }
	
	
	void Update ()
    {
        if (destroying == true)
        {
            spriteRend.enabled = !spriteRend.enabled;
            count -= Time.deltaTime;
        }

        if (count <= 0)
        {
            Destroy();
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            destroying = true;
        }
    }

    void Destroy()
    {
        
        Destroy(gameObject);
    }
}
