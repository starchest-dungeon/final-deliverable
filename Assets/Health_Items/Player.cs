using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isDead = false;
    public int maxHealth = 4;
    public int currentHealth;
    public int bossFightHealth = 10;
    public float cooldownTime = 2;
    private float nextFireTime = 0;
    private bool cooldown = false;
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
        if(Time.time > nextFireTime)
        {
            cooldown = false;
        }

        // if (kills == 15) {
        //     Victory();
        //     gameObject.SetActive(false);
        // }
    }
    public void setBossFightHealth()
    {
        healthBar.SetMaxHealth(bossFightHealth);
        currentHealth = bossFightHealth;
    }

    void  OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag.Equals("Boss Arm")) 
        {            
            if(!cooldown)
            {
                TakeBossDamage(3);
                cooldown = true;
                nextFireTime = Time.time+cooldownTime;
            }
        }
    }
    public void TakeBossDamage(int damage)
    {
        damageTaken = true;
        currentHealth-=damage;
        healthBar.SetHealth(currentHealth);
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
