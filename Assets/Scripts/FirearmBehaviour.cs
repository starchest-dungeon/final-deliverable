using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirearmBehaviour : MonoBehaviour {

    private SpriteRenderer myRender;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator muzzle;
    public Animator emptyClip;
    public Animator ammoIndicator;
    public Animator fireArm;

    public SpriteRenderer firearmMini, knife;

    private float bulletSpeed = 40f;
    private float cooldown = 0.2f;
    private float nextFire = 0f;

    private bool weaponSwitched;

    public ProtagonistBehaviour protag;

    public int currentClip, maxClipSize = 10, currentAmmo, maxAmmoSize = 100;

    void Start() {
        myRender = this.GetComponent<SpriteRenderer>();
        knife.GetComponent<Renderer>().enabled= false;
    }

    void Update() {

        if (weaponSwitched) {
            Swing(); 
        } else {
            ProcessBulletSpawn();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }

        if (Input.GetMouseButtonDown(1)) {
            weaponSwitched = !weaponSwitched;

            if (weaponSwitched) {
                knife.GetComponent<Renderer>().enabled= true;
                myRender.GetComponent<Renderer>().enabled= false;
                firearmMini.GetComponent<Renderer>().enabled= false;
            } else {
                knife.GetComponent<Renderer>().enabled= false;
                myRender.GetComponent<Renderer>().enabled= true;
                firearmMini.GetComponent<Renderer>().enabled= true;
            }
        }
        /*
        if (Input.GetAxisRaw("Horizontal") > 0) {
            myRender.flipX = false;
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            myRender.flipX = true;
        }
        */
    }

    //referencing: https://www.youtube.com/watch?v=cjNMQkODh1M
    private void ProcessBulletSpawn() {
        if (currentClip > 0) {
            if (Input.GetMouseButtonDown(0) && Time.time > nextFire) {
                muzzle.SetTrigger(name:"shoot");
                fireArm.SetTrigger(name:"shoot");
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D re = bullet.GetComponent<Rigidbody2D>();
                re.velocity = firePoint.up * bulletSpeed;
                nextFire = Time.time + cooldown;
                currentClip--;
            }
        } else if (currentClip <= 0) {
            if (Input.GetMouseButtonDown(0) && Time.time > nextFire) {
                ammoIndicator.SetTrigger(name:"button");
                emptyClip.SetTrigger(name:"shoot");
            }
        }
        
    }

    private void Swing() {
        if (Input.GetMouseButtonDown(0)) {
            protag.sideAnim.SetTrigger(name:"slash");
            protag.backAnim.SetTrigger(name:"slash");
            protag.frontAnim.SetTrigger(name:"slash");
        }
    }

    public void Reload() {
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddAmmo(int ammoAmount) {
        currentAmmo += ammoAmount;
        if (currentAmmo > maxAmmoSize) {
            currentAmmo = maxAmmoSize;
        }
    }
}
