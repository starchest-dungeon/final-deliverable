using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFollow : MonoBehaviour 
{

    public float speed;
    public float stoppingDistance;
    public Animator anim;
    public SpriteRenderer thisRender;
    public Player player;
    bool moving = true;
    private Transform target;
    int damage = 1;
    

    // Start is called before the first frame update
    void Start() 
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //GameObject enemyTag = GameObject.FindGameObjectWithTag("Enemy");     
        
    }

    // Update is called once per frame
    void Update() 
    {             
          
        if(moving)
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance) 
            {
                anim.SetBool("isWalking", true);
                //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                Debug.Log("waiting");
                StartCoroutine(Wait());
                anim.SetBool("isWalking", false);
            }
        }

        if (target.position.x > transform.position.x) {
            thisRender.flipX = true;
        } else if (target.position.x < transform.position.x) {
            thisRender.flipX = false;
        }
    }
    public void enemyContactPlayer()
    {
        //Time.time > nextAttack &&      
        if(Vector2.Distance(transform.position,target.position)<=stoppingDistance)
        {
            attackPlayer();
            //nextAttack = Time.time + cooldown;
        }
        moving = true;
        //Debug.Log("Moving again");
    }
    public void attackPlayer()
    {
        Debug.Log("Attacking");
        anim.SetBool("Attacked", false);
        anim.SetTrigger("isAttacking");
        player.TakeDamage(damage);
        anim.SetBool("Attacked", true);
        moving = true;
    }
    IEnumerator Wait()
    {
        moving = false;
        //Debug.Log("Waiting");
        //this.GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSecondsRealtime(1);  
        //this.GetComponent<SpriteRenderer>().color = Color.red;
        enemyContactPlayer();    
    }
    private void onCollisionEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>()); 
            Physics2D.IgnoreCollision(collision.GetComponent<CapsuleCollider2D>(), GetComponent<CapsuleCollider2D>());
        }
    }
    
}
