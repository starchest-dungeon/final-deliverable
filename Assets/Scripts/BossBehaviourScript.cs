using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviourScript : MonoBehaviour {

    int health = 45;
    public Animator anim;
    public Player player;
    public Transform player2;
    //public Text totalKills;

    public Slider healthbar;

    public float moveSpeed;

    public float followRange;
    private bool inRange;
    bool fightStarted = false;
    int numStarted = 0;

    void  OnTriggerEnter2D(Collider2D col) { 

        if (col.gameObject.tag.Equals("Bullet") || col.gameObject.tag.Equals("Knife")) {

            if (health <= 0) {
                //anim.SetTrigger("Dying");
                Debug.Log("dies");
                Destroy(gameObject, 0.5f);
                player.Victory();
            } else {
                anim.SetTrigger("hit");
                health--;
            }
        }

    }

    void Update () {
        
        if (Vector2.Distance(transform.position, player2.position) <= followRange)
        {
            inRange = true;            
        }
        else
        {
            inRange = false;
        }
        //Increase player health for boss fight
        /*
        if(numStarted==1)
        {
            player.setBossFightHealth();
            numStarted++;
            fightStarted = true;
        }
        */

        healthbar.value = health;
    }

    void Start() {
        healthbar.gameObject.SetActive(false);
        //totalKills.text = "Kills: " + player.kills;
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            //Increase player health for boss fight
            /*
            if(!fightStarted)
            {
                numStarted ++;
            }   
            */         
            transform.position = Vector2.MoveTowards(transform.position, player2.position, moveSpeed * Time.deltaTime);
        }
    }
}
