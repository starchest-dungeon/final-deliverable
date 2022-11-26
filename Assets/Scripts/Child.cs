using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//source: https://answers.unity.com/questions/1614883/moving-objects-together-without-parenting.html

public class Child : MonoBehaviour {

    public Transform Parent; //Remember to assign the parent transform 
    private Vector3 pos, fw, up;
 
    void Start() {
        pos = Parent.transform.InverseTransformPoint(transform.position);
        fw = Parent.transform.InverseTransformDirection(transform.forward);
        up = Parent.transform.InverseTransformDirection(transform.up);
    }

    void Update() {
        var newpos = Parent.transform.TransformPoint(pos);
        var newfw = Parent.transform.TransformDirection(fw);
        var newup = Parent.transform.TransformDirection(up);
        var newrot = Quaternion.LookRotation(newfw, newup);
        transform.position = newpos;
        transform.rotation = newrot;
    }
}
