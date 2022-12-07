using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier1RemovalScript : MonoBehaviour
{
    Barrier1TriggerScript barrier1;
    // Start is called before the first frame update
    void Start()
    {
        barrier1 = FindObjectOfType<Barrier1TriggerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(barrier1.canPassBarrier)
        {
            Destroy(this.gameObject);
        }
    }
}
