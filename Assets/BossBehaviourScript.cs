using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviourScript : MonoBehaviour {

    int health = 30;
    public Animator anim;
    public Player player;
    public Transform player2;
    //public Text totalKills;

    public float moveSpeed;

    public float followRange;
    private bool inRange;

    void  OnTriggerEnter2D(Collider2D col) { 

        if (col.gameObject.tag.Equals("Bullet")) {

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
    }

    void Start() {
        //totalKills.text = "Kills: " + player.kills;
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player2.position, moveSpeed * Time.deltaTime);
        }
    }
}
