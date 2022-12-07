using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier4RemovalScript : MonoBehaviour
{
    Barrier4TriggerScript barrier4;
    // Start is called before the first frame update
    void Start()
    {
        barrier4 = FindObjectOfType<Barrier4TriggerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(barrier4.canPassBarrier)
        {
            Destroy(this.gameObject);
        }
    }
}
