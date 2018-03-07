using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    private int loot = 0;
    public GameObject Health;

    void Start()
    {

    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy();
            loot = Random.Range(0, 5);
            Debug.Log(loot);
            if (loot == 4)
            {
                Instantiate(Health, transform.position, Quaternion.identity);
            }


        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
