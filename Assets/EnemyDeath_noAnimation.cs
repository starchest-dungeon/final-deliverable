using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath_noAnimation : MonoBehaviour {

    int health = 4;

    void  OnTriggerEnter2D(Collider2D col) { 

        if (col.gameObject.tag.Equals("Bullet")) {

            if ( health <= 0) {
                Destroy(gameObject);
            } else {
                health--;
            }

        }

    }

    void Update() {
        
    }
}
