using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableHealthBox : MonoBehaviour {
    
    public ParticleSystem particle;
    public SpriteRenderer potRen;
    public CapsuleCollider2D potCol;
    public AudioSource breakPot;

    public SpriteRenderer drop;
    public BoxCollider2D dropCol;

    void Start() {
        drop.GetComponent<Renderer>().enabled = false;
        dropCol.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Bullet" || col.tag == "Knife") {
            breakPot.Play();
            StartCoroutine(Break());
        }
    }

    private IEnumerator Break() {
        particle.Play();

        drop.GetComponent<Renderer>().enabled = true;
        dropCol.GetComponent<BoxCollider2D>().enabled = true;
        
        potRen.enabled = false;
        potCol.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);

        Destroy(gameObject);
    }
}
