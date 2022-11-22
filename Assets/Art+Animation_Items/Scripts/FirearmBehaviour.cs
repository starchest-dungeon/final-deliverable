using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirearmBehaviour : MonoBehaviour {

    private SpriteRenderer myRender;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator muzzle;
    public Animator fireArm;

    private float bulletSpeed = 40f;
    private float cooldown = 0.2f;
    private float nextFire = 0f;

    void Start() {
        myRender = this.GetComponent<SpriteRenderer>();
    }

    void Update() {
        ProcessBulletSpawn();

        /*
        if (Input.GetAxisRaw("Horizontal") > 0) {
            myRender.flipX = false;
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            myRender.flipX = true;
        }
        */
    }

    private void ProcessBulletSpawn() {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire) {
            muzzle.SetTrigger(name:"shoot");
            fireArm.SetTrigger(name:"shoot");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D re = bullet.GetComponent<Rigidbody2D>();
            re.velocity = firePoint.up * bulletSpeed;
            nextFire = Time.time + cooldown;
        }
    }
}
