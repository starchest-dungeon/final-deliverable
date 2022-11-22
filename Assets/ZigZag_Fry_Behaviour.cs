using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag_Fry_Behaviour : MonoBehaviour {

    void  OnTriggerEnter2D(Collider2D col) { 
        if (col.gameObject.tag.Equals("Enemy")) {
            Destroy(gameObject);
        }
        if (col.gameObject.tag.Equals("Wall")) {
            Destroy(gameObject);
        }
        if (col.gameObject.tag.Equals("Prop")) {
            Destroy(gameObject);
        }
        if (col.gameObject.tag.Equals("Boss")) {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() { 
        Destroy(gameObject); 
    }
}
