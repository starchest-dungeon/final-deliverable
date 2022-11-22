using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Damage player;
    public Transform target;
    private float speed = 6f;
    private float minDist = 0.7f;
    int damage = 1;
    bool moving = true;
    private float cooldown = 1f;
    private float nextAttack = 0f;
    // Start is called before the first frame update
    void Start()
    {          
        
    }  
    // Update is called once per frame
    void Update()
    { 
        if(moving)
        {
            transform.LookAt(target.position);
            transform.Rotate(new Vector3(0,-90,0),Space.Self);

            if (Vector3.Distance(transform.position,target.position)>1f)
            {
                transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );        
            }
            else
            {                 
                StartCoroutine(Wait());                
            } 
        }
    
               
    }
    public void enemyContactPlayer()
    {   
        //Time.time > nextAttack &&      
        if(Vector3.Distance(transform.position,target.position)<=1f)
        {
            attackPlayer();
            //nextAttack = Time.time + cooldown;
        }
        moving = true; 
    }

    public void attackPlayer()
    {  
        //Debug.Log("Attacking");
        player.takeDamage(damage);
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
}
