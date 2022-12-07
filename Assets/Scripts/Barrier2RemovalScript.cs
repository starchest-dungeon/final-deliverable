using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier2RemovalScript : MonoBehaviour
{
    Barrier2TriggerScript barrier2;
    // Start is called before the first frame update
    void Start()
    {
        barrier2 = FindObjectOfType<Barrier2TriggerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(barrier2.canPassBarrier)
        {
            Destroy(this.gameObject);
        }
    }
}
