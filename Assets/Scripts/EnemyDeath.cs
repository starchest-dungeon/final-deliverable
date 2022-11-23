using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour {

    public int health;
    public int maxHealth = 4;
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
                totalKills.text = "Kills: " + player.kills;
                Destroy(gameObject, 0.5f);
            } else {
                anim.SetTrigger("hit");
                health--;
                enemyHealth.SetHealth(health, maxHealth);
            }

        }

    }

    void Start() {
        totalKills.text = "Kills: " + player.kills;
        health = maxHealth;
        enemyHealth.SetHealth(health, maxHealth);
    }
}
