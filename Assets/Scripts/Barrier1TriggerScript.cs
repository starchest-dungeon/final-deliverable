using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier1TriggerScript : MonoBehaviour
{
    public bool canPassBarrier = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Barrier 1 activated");
            canPassBarrier = true;            
        }
        //Destroy(this.gameObject);
    }
}
