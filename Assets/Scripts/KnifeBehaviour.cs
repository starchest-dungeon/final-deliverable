using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : MonoBehaviour {

    public SpriteRenderer front, back, side;
    public GameObject sideKnife;
    public GameObject protag;
    private bool active;

    void Start() {
        front.GetComponent<Renderer>().enabled= false;
        back.GetComponent<Renderer>().enabled= false;
    }

    void Update() {

        if (Input.GetMouseButtonDown(1)) {
            active = !active;
        }

        if (active) {
            if (Input.GetAxisRaw("Horizontal") > 0) {
                side.GetComponent<Renderer>().enabled= true;
                front.GetComponent<Renderer>().enabled= false;
                back.GetComponent<Renderer>().enabled= false;
                //sideKnife.transform.position.x = 1;
                //sideKnife.transform.position = new Vector3(protag.transform.position.x - 1, protag.transform.position.y - 1.5f , protag.transform.position.z);
            } else if (Input.GetAxisRaw("Horizontal") < 0) {
                //sideKnife.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                //sideKnife.transform.position.x = -1;
                //sideKnife.transform.position = new Vector3(protag.transform.position.x + 1, protag.transform.position.y - 1.5f , protag.transform.position.z);
                side.GetComponent<Renderer>().enabled= true;
                front.GetComponent<Renderer>().enabled= false;
                back.GetComponent<Renderer>().enabled= false;
            }

            if (Input.GetAxisRaw("Vertical") > 0) {
                back.GetComponent<Renderer>().enabled= true;
                front.GetComponent<Renderer>().enabled= false;
                side.GetComponent<Renderer>().enabled= false;
            } else if (Input.GetAxisRaw("Vertical") < 0) {
                front.GetComponent<Renderer>().enabled= true;
                side.GetComponent<Renderer>().enabled= false;
                back.GetComponent<Renderer>().enabled= false;
            }
        }
        
    }
}
