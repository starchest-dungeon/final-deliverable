using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; 

//referencing potato_1 code

public class ProtagonistBehaviour : MonoBehaviour {

    private Vector2 moveAmount;
    [SerializeField]
    private float speed;
    private Rigidbody2D m_Rb;

    public TilemapRenderer door;
    public TilemapCollider2D doorCol;

    public Animator sideAnim;
    public SpriteRenderer sideRender;
    public GameObject side;

    public Animator frontAnim;
    public GameObject front;

    public Animator backAnim;
    public GameObject back;

    //from: https://www.youtube.com/watch?v=tH57EInEb58

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 0.5f, dashCooldown = 0.5f;

    private float dashCounter;
    private float dashCoolCounter;
 
    void Start() {
        m_Rb = this.GetComponent<Rigidbody2D>();
        front.GetComponent<Renderer>().enabled= false;
        back.GetComponent<Renderer>().enabled= false;
        side.GetComponent<Renderer>().enabled= true;
        activeMoveSpeed = speed;
    }
 
    void Update() {

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            sideAnim.SetBool("isRunning", true);
            frontAnim.SetBool("isWalking", true);
            backAnim.SetBool("isWalking", true);
        } else {
            sideAnim.SetBool("isRunning", false);
            frontAnim.SetBool("isWalking", false);
            backAnim.SetBool("isWalking", false);
        }

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetAxisRaw("Horizontal") > 0) {
            side.GetComponent<Renderer>().enabled= true;
            front.GetComponent<Renderer>().enabled= false;
            back.GetComponent<Renderer>().enabled= false;
            sideRender.flipX = false;
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            sideRender.flipX = true;
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

        if (Player.damageTaken) {
            if (Input.GetAxisRaw("Horizontal") != 0) {
                sideAnim.SetTrigger(name:"hit");
            } else if (Input.GetAxisRaw("Vertical") > 0) {
                backAnim.SetTrigger(name:"hit");
            } else if (Input.GetAxisRaw("Vertical") < 0) {
                frontAnim.SetTrigger(name:"hit");
            }

            Player.damageTaken = false;
        }

        moveAmount = moveInput.normalized * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (dashCoolCounter <= 0 && dashCounter <= 0) {
                sideAnim.SetTrigger(name:"dash");
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (Input.GetKeyDown(KeyCode.O)) {
            door.GetComponent<Renderer>().enabled = false;
            doorCol.GetComponent<TilemapCollider2D>().enabled = false;
        }
        

        if (dashCounter > 0) {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0) {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0) {
            dashCoolCounter -= Time.deltaTime;
        }
    }
 
    private void FixedUpdate() {
        m_Rb.MovePosition(m_Rb.position + moveAmount * Time.fixedDeltaTime);
    }
}
