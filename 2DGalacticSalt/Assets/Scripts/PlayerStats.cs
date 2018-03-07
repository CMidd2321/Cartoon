using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public float playerHealth = 3;
    public float jumpHeight = 850;
    public bool jumpBoost = false;
    private float jumpTimer = 10;
    public bool Invicibility = false;
    public float invicibilityTimer = 10;
    public float enemyDamage = 1;
    float invuln = 0;
    int correctLayer;
    SpriteRenderer spriteRend;
    public float respawnTimer;
    private moveScript move;
    public Text GameOverText;
    public Image Health1;
    public Image Health2;
    public Image Health3;
    public Image Health4;
    public Image Health5;
    public Image _JB;
    public Text BoostTime;
    public Text InvicibilityTime;
    public Image _INV;
    


    void Start()
    {
        correctLayer = gameObject.layer;
        spriteRend = GetComponent<SpriteRenderer>();
        move = GetComponent<moveScript>();
        if (spriteRend == null)
        {

            Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && Invicibility == false)
        {
            Debug.Log("Enemy Hit");
            if (invuln <= 0)
            {
                playerHealth--;
                invuln = 1f;
                gameObject.layer = 20;
            }

        }
        if (col.gameObject.tag == "EnemyProjectile" && Invicibility == false)
        {
            Debug.Log("Projectile Hit");
            if (invuln <= 0)
            {
                playerHealth--;
                invuln = 1f;
                gameObject.layer = 20;
            }
        }
        if(col.gameObject.tag == "Finish")
        {
            NextLevel();
        }



    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.tag == "Health") && playerHealth < 5)
        {
            playerHealth = playerHealth + 1;
            Debug.Log("HEALTH UP!");
            Destroy(col.gameObject);
        }

        if ((col.gameObject.tag == "Jump") && jumpBoost == false)
        {
            jumpHeight = 1000;
            jumpBoost = true;
            Destroy(col.gameObject);
            Debug.Log("JUMPBOOST ACTIVATED");

        }
        if ((col.gameObject.tag == "Invincibility") && Invicibility == false)
        {
            Invicibility = true;
            enemyDamage = 0;
            Destroy(col.gameObject);
            Debug.Log("INVINCIBILITY ACTIVATED");
        }

        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy killed");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "DeathNet")
        {
            Respawn();
        }
        if(col.gameObject.tag == "Spike")
        {
            Respawn();
        }
    }



    void Update()
    {
        
        if (invuln > 0)
        {
            invuln -= Time.deltaTime;

            if (invuln <= 0)
            {


                gameObject.layer = correctLayer;
                if (spriteRend != null)
                {

                    spriteRend.enabled = true;
                }
            }
            else
            {
                if (spriteRend != null)
                {

                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        } 
        if (jumpBoost == true)
        {
                jumpTimer -= Time.deltaTime;
                _JB.enabled = true;
                BoostTime.text = jumpTimer.ToString("f2");
                if (jumpTimer <= 0)
                {
                    jumpBoost = false;
                    jumpTimer = 10;
                    jumpHeight = 800;
                    _JB.enabled = false;
                    BoostTime.text = null;
                Debug.Log("JUMPBOOST DEACTIVATED");
                }
        }
        if(Invicibility == true)
        {
            invicibilityTimer -= Time.deltaTime;
            _INV.enabled = true;
            InvicibilityTime.text = invicibilityTimer.ToString("f2");
            if (invicibilityTimer <= 0)
            {
                Invicibility = false;
                invicibilityTimer = 10;
                enemyDamage = 1;
                _INV.enabled = false;
                InvicibilityTime.text = null;
                Debug.Log("INVINCIBILITY DEACTIVATED");
            }
        }

        if (playerHealth <= 0)
        {
            Respawn();
        }

        if (playerHealth == 5) 
        {
            Health1.enabled = true;
            Health2.enabled = true;
            Health3.enabled = true;
            Health4.enabled = true;
            Health5.enabled = true;
        }
        if (playerHealth == 4)
        {
            Health1.enabled = true;
            Health2.enabled = true;
            Health3.enabled = true;
            Health4.enabled = true;
            Health5.enabled = false;
        }
        if (playerHealth == 3)
        {
            Health1.enabled = true;
            Health2.enabled = true;
            Health3.enabled = true;
            Health4.enabled = false;
            Health5.enabled = false;
        }
        if (playerHealth == 2)
        {
            Health1.enabled = true;
            Health2.enabled = true;
            Health3.enabled = false;
            Health4.enabled = false;
            Health5.enabled = false;
        }
        if (playerHealth == 1)
        {
            Health1.enabled = !Health1.enabled;
            Health2.enabled = false;
            Health3.enabled = false;
            Health4.enabled = false;
            Health5.enabled = false;
        }


        

    }
    void Respawn()
    {
        playerHealth = 0;
        spriteRend.enabled = false;
        move.enabled = false;
        respawnTimer += Time.deltaTime;
        GameOverText.enabled = true;
        Health1.enabled = false;
        Health2.enabled = false;
        Health3.enabled = false;
        Health4.enabled = false;
        Health5.enabled = false;

        if (respawnTimer >= 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

