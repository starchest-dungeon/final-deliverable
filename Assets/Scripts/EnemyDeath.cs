using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour {

    public float health;
    public int maxHealth = 4;
    public SpriteRenderer drop;
    public BoxCollider2D dropCol;
    public Animator anim;
    public Player player;
    public Text totalKills;

    public EnemyHealth enemyHealth;

    void  OnTriggerEnter2D(Collider2D col) { 

        if (col.gameObject.tag.Equals("Bullet")) {
            if (health <= 0) {
                anim.SetTrigger("Dying");
                Debug.Log("dies");
                player.kills++;
                totalKills.text = "Score: " + player.kills;
                Destroy(gameObject, 0.5f);
                drop.GetComponent<Renderer>().enabled = true;
                dropCol.GetComponent<BoxCollider2D>().enabled = true;
            } else {
                anim.SetTrigger("hit");
                health--;
                enemyHealth.SetHealth(health, maxHealth);
            }

        } else if (col.gameObject.tag.Equals("Knife")) {
            if (health <= 0) {
                anim.SetTrigger("Dying");
                Debug.Log("dies");
                player.kills++;
                totalKills.text = "Score: " + player.kills;
                Destroy(gameObject, 0.15f);
                drop.GetComponent<Renderer>().enabled = true;
                dropCol.GetComponent<BoxCollider2D>().enabled = true;
            } else {
                anim.SetTrigger("hit");
                health -= 0.5f;
                enemyHealth.SetHealth(health, maxHealth);
            }
        }
        if(col.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(col.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>()); 
            Physics2D.IgnoreCollision(col.GetComponent<CapsuleCollider2D>(), GetComponent<CapsuleCollider2D>());
        }

    }

    void Start() {
        drop.GetComponent<Renderer>().enabled = false;
        dropCol.GetComponent<BoxCollider2D>().enabled = false;
        totalKills.text = "Score: " + player.kills;
        health = maxHealth;
        enemyHealth.SetHealth(health, maxHealth);
    }
}
