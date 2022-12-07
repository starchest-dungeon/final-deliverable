using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier3RemovalScript : MonoBehaviour
{
    Barrier3TriggerScript barrier3;
    // Start is called before the first frame update
    void Start()
    {
        barrier3 = FindObjectOfType<Barrier3TriggerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(barrier3.canPassBarrier)
        {
            Destroy(this.gameObject);
        }
    }
}
