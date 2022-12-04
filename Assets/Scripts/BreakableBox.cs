using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour {

    public ParticleSystem particle;
    public SpriteRenderer potRen;
    public CapsuleCollider2D potCol;
    public AudioSource breakPot;

    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Bullet") {
            StartCoroutine(Break());
        }
    }

    private IEnumerator Break() {
        particle.Play();
        breakPot.Play();

        potRen.enabled = false;
        potCol.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);

        Destroy(gameObject);
    }
}
