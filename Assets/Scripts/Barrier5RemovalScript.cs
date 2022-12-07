using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier5RemovalScript : MonoBehaviour
{
    Barrier5TriggerScript barrier5;
    // Start is called before the first frame update
    void Start()
    {
        barrier5 = FindObjectOfType<Barrier5TriggerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(barrier5.canPassBarrier)
        {
            Destroy(this.gameObject);
        }
    }
}
