using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
code from: https://www.youtube.com/watch?v=2xaQYZW6LLA
*/

public class EnemyAI : MonoBehaviour {

    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    public Rigidbody2D rb;
    public Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    void Start() {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update() {
        anim.SetBool("isWalking", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        dir.Normalize();
        movement = dir;
        if (shouldRotate) {

        }
    }

    private void FixedUpdate() {
        if (isInChaseRange && isInAttackRange) {
            MoveCharacter(movement);
        }
        if (isInAttackRange) {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir) {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
}
