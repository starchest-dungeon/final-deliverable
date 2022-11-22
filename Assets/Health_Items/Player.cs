using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isDead = false;
    public int maxHealth = 4;
    public int currentHealth;
    public int kills = 0;

    public static bool damageTaken;

    public HealthBar healthBar;

    public GameOverScreen GameOverScreen;
    
    public VictoryScreen VictoryScreen;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //ZeldaHealthBar.instance.SetUpHearts(maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0) 
        {
            GameOver();
            gameObject.SetActive(false);
        }

        // if (kills == 15) {
        //     Victory();
        //     gameObject.SetActive(false);
        // }
    }

    void  OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag.Equals("Boss")) {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage) 
    {
        //Debug.Log("In taking damage");
        damageTaken = true;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        //ZeldaHealthBar.instance.RemoveHearts(damage);
        //Debug.Log("Out of taking damage");
    }

    public void GameOver() 
    {
        GameOverScreen.SetUp();
        gameObject.SetActive(false);
    }

    public void Victory() {
        VictoryScreen.SetUp();
        gameObject.SetActive(false);

    }

    public void Heal(int heal) {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }
}
