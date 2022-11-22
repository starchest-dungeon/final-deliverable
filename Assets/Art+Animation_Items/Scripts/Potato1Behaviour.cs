using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference for this script: https://www.youtube.com/watch?v=acqyXwwJGpY

public class Potato1Behaviour : MonoBehaviour {

    private Vector2 moveAmount;
    [SerializeField]
    private float speed;
    private Rigidbody2D m_Rb;

    public Animator myAnim;
    public SpriteRenderer myRender;
 
    void Start() {
        m_Rb = this.GetComponent<Rigidbody2D>();
    }
 
    void Update() {

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            myAnim.SetBool("isWalking", true);
        } else {
            myAnim.SetBool("isWalking", false);
        }

        if (Input.GetKey("left shift")) {
            myAnim.SetBool("isRunning", true);
            speed = 10f;
        } else {
            myAnim.SetBool("isRunning", false);
            speed = 2.5f;
        }

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //reference for below: https://levelup.gitconnected.com/sprite-flipping-in-unity-for-2d-animations-f5c33d3e8f71
        if (Input.GetAxisRaw("Horizontal") < 0) {
            myRender.flipX = false;
        } else if (Input.GetAxisRaw("Horizontal") > 0) {
            myRender.flipX = true;
        }
        
        moveAmount = moveInput.normalized * speed;
    }
 
    private void FixedUpdate() {
        m_Rb.MovePosition(m_Rb.position + moveAmount * Time.fixedDeltaTime);
    }
}
