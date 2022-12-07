using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier3TriggerScript : MonoBehaviour
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
            Debug.Log("Barrier 3 activated");
            canPassBarrier = true;            
        }
        //Destroy(this.gameObject);
    }
}
