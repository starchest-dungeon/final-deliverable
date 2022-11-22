using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public int health = 5;
    bool isDead = false;

    public void takeDamage(int damage)
    {
        //Debug.Log("Taking damage");
        health -=damage;
        if(health <= 0)
        {
            isDead = true;
            Debug.Log("Dead");            
        }
        Debug.Log("Took " + damage + " damage");
        if(isDead)
        {
            //this.GetComponent<SpriteRenderer>().color = Color.gray;
        }        
    }
}
