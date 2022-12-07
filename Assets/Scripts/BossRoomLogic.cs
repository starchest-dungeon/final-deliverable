using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BossRoomLogic : MonoBehaviour {

    //public Player player;
    private BossBehaviourScript boss;

    public TilemapRenderer door;
    public TilemapCollider2D doorCol;

    public Slider healthbar;

    void Start() {
        boss = FindObjectOfType<BossBehaviourScript>();
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            door.GetComponent<Renderer>().enabled = true;
            doorCol.GetComponent<TilemapCollider2D>().enabled = true;
            healthbar.gameObject.SetActive(true);
            boss.moveSpeed = 0f;
            boss.anim.SetTrigger("playerEnter");
            StartCoroutine(waiter());
            boss.moveSpeed = 8f;
            //player.setBossFightHealth();

        }
    }

    private IEnumerator waiter() {

    //Wait for 2 second
    yield return new WaitForSeconds(2);

    }
}
