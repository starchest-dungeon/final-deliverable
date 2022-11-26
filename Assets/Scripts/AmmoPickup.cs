using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour{ 
    private void OnTriggerEnter2D(Collider2D col) {
        /*
        if (col.gameObject.CompareTag("Player")) {
            FirearmBehaviour.AddAmmo(FirearmBehaviour.maxAmmoSize);
            Destroy(gameObject);
        }
        */
        FirearmBehaviour weapon = col.gameObject.GetComponentInChildren<FirearmBehaviour>();
        if (weapon) {
            weapon.AddAmmo(weapon.maxAmmoSize);
            Destroy(gameObject);
        }
    }
}
